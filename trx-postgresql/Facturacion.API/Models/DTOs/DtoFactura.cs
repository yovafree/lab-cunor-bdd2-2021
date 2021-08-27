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
    public class DtoFactura {
        public int cod_factura {get; set;}
        public DateTime fec_factura {get; set;}
        public string nombre {get; set;}
        public string nit {get; set;}
        public decimal total {get; set;}
        public List<DtoDetFactura> DetFacturas {get;set;}
    }
}