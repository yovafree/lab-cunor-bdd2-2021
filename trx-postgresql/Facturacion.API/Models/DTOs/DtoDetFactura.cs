using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facturacion.API.Models.DTOs
{
    public class DtoDetFactura {
        public int cod_det_factura {get; set;}
        public decimal cantidad {get;set;}
        public decimal subtotal {get;set;}
        public decimal precio_unitario {get;set;}
        public int cod_producto {get;set;}
        public int cod_factura {get;set;}
    }
}