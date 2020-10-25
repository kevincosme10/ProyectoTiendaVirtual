using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEntities.Models
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Estado { get; set; }
    }
}
