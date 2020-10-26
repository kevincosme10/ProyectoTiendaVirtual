using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaService.ServiceInterface
{
   public interface IopcionesMenu
    {
        List<string> obtenerOpcionesMenu(List<int> opcionesMenu);
    }
}
