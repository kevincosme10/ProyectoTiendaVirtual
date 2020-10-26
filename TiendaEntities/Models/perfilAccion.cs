using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("perfilAccion", Schema = "dbo")]
  public  class perfilAccion: BaseEntity
    {
        public int IdAccion { get; set; }
        public int IdPerfil { get; set; }
    }
}
