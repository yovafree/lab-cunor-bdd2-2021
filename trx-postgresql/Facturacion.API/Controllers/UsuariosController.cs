using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.API.Models;
using Facturacion.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsuariosController : ControllerBase{

        private readonly PostgreSQLContext _context;
        private IUserService _userService;

        public UsuariosController(PostgreSQLContext context, IUserService userService){
            _context = context;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios(){
            return _context.Usuario.ToList();
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] Usuario Usuario){
            try{
                _context.Add(Usuario);
                _context.SaveChanges();
            }catch
            {
                return BadRequest("No fue posible realizar la operación");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarUsuario([FromBody] Usuario Usuario){
            try{
                if (ModelState.IsValid){
                    Usuario p = _context.Usuario.Find(Usuario.cod_usuario);
                    if (p == null){
                        return BadRequest("No existe el Usuario");
                    }else{
                        p.correo_electronico = Usuario.correo_electronico;
                        p.contrasenia = Usuario.contrasenia;
                        p.estado = Usuario.estado;
                        _context.Usuario.Update(p);
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
        public IActionResult DeleteUsuario(int id){
             try{
                Usuario p = _context.Usuario.Find(id);
                if (p == null){
                    return BadRequest("No existe el Usuario");
                }else{
                    _context.Usuario.Remove(p);
                    _context.SaveChanges();
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}