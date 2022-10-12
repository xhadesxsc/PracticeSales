using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Ecommerce.Application.DTO
{
    public class SalesDto
    {
        public int SalesId { get; set; }
        public string Cliente { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
