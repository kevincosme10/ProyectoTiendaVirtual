using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("perfil", Schema = "dbo")]
    public class perfil: BaseEntity
    {
        public string nombrePerfil { get; set; }

    }
}
