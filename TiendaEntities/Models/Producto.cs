using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("PRODUCTO", Schema = "dbo")]
    public class Producto: BaseEntity
    {

        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }


    }
}
