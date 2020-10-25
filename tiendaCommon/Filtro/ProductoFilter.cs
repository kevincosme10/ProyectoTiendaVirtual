using System;
using System.Collections.Generic;
using System.Text;

namespace tiendaCommon.Filtro
{
   public class ProductoFilter: BaseFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string nombre { get; set; }
        public string Codigo { get; set; }
    }
}
