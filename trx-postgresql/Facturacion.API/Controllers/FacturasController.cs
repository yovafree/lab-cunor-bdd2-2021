using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.API.Models;
using Facturacion.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Controllers
{
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase{

        private readonly PostgreSQLContext _context;

        public FacturasController(PostgreSQLContext context){
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Factura> GetFactura(){
            return _context.Facturas.ToList();
        }

        [HttpGet("id")]
        public DtoFactura GetFactura(int id){
            var factura = (from f in _context.Facturas
                            where f.cod_factura == id
                            select new DtoFactura{
                                cod_factura=f.cod_factura,
                                fec_factura=f.fec_factura,
                                nombre=f.nombre,
                                nit=f.nit,
                                total= f.total
                            }).FirstOrDefault();

            var lstDetFactura = (from df in _context.DetFactura
                                where df.cod_factura == id
                                select new DtoDetFactura{
                                    cod_det_factura = df.cod_det_factura,
                                    cantidad = df.cantidad,
                                    subtotal = df.subtotal,
                                    precio_unitario = df.precio_unitario,
                                    cod_producto = df.cod_producto,
                                    cod_factura = df.cod_factura
                                }).ToList();

            factura.DetFacturas = lstDetFactura;

            return factura;
        }

        [HttpPost]
        public IActionResult CreateFactura([FromBody] Factura Factura){

            using var transaction = _context.Database.BeginTransaction();
            try{
                decimal total = 0;
                foreach(var item in Factura.DetFacturas){
                    item.subtotal = item.cantidad * item.precio_unitario;
                    total+=item.subtotal;
                }
                if (total == 0){
                    throw new InvalidOperationException("El total no puede ser igual a 0.");
                }
                Factura.total = total;

                _context.Add(Factura);
                _context.SaveChanges();
                transaction.Commit();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("No fue posible realizar la operación. Error -> " + ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarFactura([FromBody] Factura factura){
            try{
                if (ModelState.IsValid){
                    Factura f = _context.Facturas.Find(factura.cod_factura);
                    if (f == null){
                        return BadRequest("No existe el Factura");
                    }else{
                        f.nombre = factura.nombre;
                        f.fec_factura = new DateTime();
                        f.nit = factura.nit;
                        f.total = factura.total;

                        _context.Facturas.Update(f);
                        _context.SaveChanges();
                    }
                }else{
                    throw new Exception("El modelo no es válido");
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFactura(int id){
             try{
                Factura p = _context.Facturas.Find(id);
                if (p == null){
                    return BadRequest("No existe el Factura");
                }else{
                    _context.Facturas.Remove(p);
                    _context.SaveChanges();
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}