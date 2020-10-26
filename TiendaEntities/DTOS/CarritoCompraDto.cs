using System;
using System.Collections.Generic;
using System.Text;
using TiendaEntities.Models;

namespace TiendaEntities.DTOS
{
    public class CarritoCompraDto : BaseEntity
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int cantidadPrecio { get; set; }
    }
}
