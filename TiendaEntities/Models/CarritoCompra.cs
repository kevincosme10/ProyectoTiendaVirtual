using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("CarritoCompra", Schema = "dbo")]
    public class CarritoCompra : BaseEntity
    {

    
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int cantidadPrecio { get; set; }
      
    }
}
