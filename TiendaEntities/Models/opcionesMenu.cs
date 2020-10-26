using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("opcionesMenu", Schema = "dbo")]
    public class opcionesMenu: BaseEntity
    {
        public string codigoAccion { get; set; }
    }
}
