using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TiendaEntities.Models
{
    [Table("usuario", Schema = "dbo")]
    public class usuario: BaseEntity
    {
        public string Nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }

        public string contrasena { get; set; }
        
    }
}
