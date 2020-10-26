using System;
using System.Collections.Generic;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class perfilAccionService : ServiceBase<perfilAccion>, IperfilAccion
    {
        private readonly IBaseRepository<perfilAccion> repository;

        public perfilAccionService(IBaseRepository<perfilAccion> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
