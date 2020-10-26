using System;
using System.Collections.Generic;
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
    }
}
