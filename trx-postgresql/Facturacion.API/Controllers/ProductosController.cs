using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductosController : ControllerBase{

        private readonly PostgreSQLContext _context;

        public ProductosController(PostgreSQLContext context){
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Producto> GetProductos(){
            return _context.Productos.ToList();
        }

        [HttpPost]
        public IActionResult CreateProducto([FromBody] Producto producto){
            try{
                _context.Add(producto);
                _context.SaveChanges();
            }catch
            {
                return BadRequest("No fue posible realizar la operación");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarProducto([FromBody] Producto producto){
            try{
                if (ModelState.IsValid){
                    Producto p = _context.Productos.Find(producto.cod_producto);
                    if (p == null){
                        return BadRequest("No existe el producto");
                    }else{
                        p.nombre = producto.nombre;
                        p.precio_unitario = producto.precio_unitario;

                        _context.Productos.Update(p);
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
        public IActionResult DeleteProducto(int id){
             try{
                Producto p = _context.Productos.Find(id);
                if (p == null){
                    return BadRequest("No existe el producto");
                }else{
                    _context.Productos.Remove(p);
                    _context.SaveChanges();
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}