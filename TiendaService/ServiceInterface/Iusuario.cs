using System;
using System.Collections.Generic;
using System.Text;
using TiendaEntities.Models;

namespace TiendaService.ServiceInterface
{
   public interface Iusuario
    {
        usuario login(string correo, string contrasena);
    }
}
