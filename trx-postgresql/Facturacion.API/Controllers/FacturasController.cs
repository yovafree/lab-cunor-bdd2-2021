using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.API.Models;
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
        public Factura GetFactura(int id){
            return _context.Facturas.Find(id);
        }

        [HttpPost]
        public IActionResult CreateFactura([FromBody] Factura Factura){
            try{
                _context.Add(Factura);
                _context.SaveChanges();
            }catch
            {
                return BadRequest("No fue posible realizar la operación");
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