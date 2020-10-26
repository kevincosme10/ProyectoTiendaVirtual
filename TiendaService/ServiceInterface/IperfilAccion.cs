using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaService.ServiceInterface
{
   public interface IperfilAccion
    {
        List<int> obtenerAcciones(List<int> perfiles);
    }
}
