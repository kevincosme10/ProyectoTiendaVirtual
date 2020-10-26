using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaService.ServiceInterface
{
   public interface IperfilUsuario
    {
        List<int> ObtenerPerfilesdeUsuario(int idUsiario);
    }
}
