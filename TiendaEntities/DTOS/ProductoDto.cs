using System;
using System.Collections.Generic;
using System.Text;
using TiendaEntities.Models;

namespace TiendaEntities.DTOS
{
   public class ProductoDto: BaseEntity
    {
 
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

    
        public string Descripcion { get; set; }
     
    }
}
