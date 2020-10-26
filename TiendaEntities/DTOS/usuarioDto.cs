using System;
using System.Collections.Generic;
using System.Text;
using TiendaEntities.Models;

namespace TiendaEntities.DTOS
{
   public class usuarioDto: BaseEntity
    {
        public string Nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }

        public string contrasena { get; set; }
    }
}
