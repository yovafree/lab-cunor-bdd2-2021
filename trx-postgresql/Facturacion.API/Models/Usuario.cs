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
    [Table("usuario")]
    public class Usuario {
        [Key]
        public int cod_usuario {get; set;}
        public string correo_electronico {get; set;}
        public string contrasenia {get; set;}
        public int estado {get; set;}
        public string rol {get; set;}
    }
}