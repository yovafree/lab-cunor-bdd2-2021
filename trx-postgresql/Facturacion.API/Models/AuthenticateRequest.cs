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
    public class AuthenticateRequest {
        public string CorreoElectronico {get; set;}
        public string Contrasenia {get; set;}
    }
}