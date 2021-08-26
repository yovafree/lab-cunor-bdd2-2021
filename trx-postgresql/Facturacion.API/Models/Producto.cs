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
    [Table("producto")]
    public class Producto {
        [Key]
        public int cod_producto {get; set;}
        public string nombre {get; set;}
        public decimal precio_unitario {get; set;}
        public List<DetFactura> DetFacturas {get;set;}
    }
}