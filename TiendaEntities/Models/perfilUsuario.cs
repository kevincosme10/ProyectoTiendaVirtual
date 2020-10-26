using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("perfilUsuario", Schema = "dbo")]
    public class perfilUsuario: BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
    }
}
