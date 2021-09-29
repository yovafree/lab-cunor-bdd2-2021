using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Models
{
    public class AuthenticateResponse {
        public int Codigo {get; set;}
        public string CorreoElectronico {get; set;}
        public string Rol {get; set;}
        public string Token {get; set;}

        public AuthenticateResponse(Usuario user, string token)
        {
            Codigo = user.cod_usuario;
            CorreoElectronico = user.correo_electronico;
            Rol = user.rol;
            Token = token;
        }
    }
}