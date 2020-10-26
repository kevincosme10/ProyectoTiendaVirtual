using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class opcionesMenuService : ServiceBase<opcionesMenu>, IopcionesMenu
    {
        private readonly IBaseRepository<opcionesMenu> repository;

        public opcionesMenuService(IBaseRepository<opcionesMenu> repository) : base(repository)
        {
            this.repository = repository;
        }

        public List<string> obtenerOpcionesMenu(List<int> opcionesMenu)
        {
            List<string> opciones = new List<string>();
            foreach(opcionesMenu om in base.FindAll())
            {
                if (opcionesMenu.Contains(om.Id))
                {
                    if (!opciones.Contains(om.codigoAccion))
                    {
                        opciones.Add(om.codigoAccion);
                    }
                }
            }
            return opciones;
        }
    }
}
