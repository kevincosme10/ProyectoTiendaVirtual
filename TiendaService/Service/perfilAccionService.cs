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
    
        public List<int> obtenerAcciones(List<int> perfiles)
        {
            List<int> acciones = new List<int>();
            foreach(perfilAccion p in base.FindAll())
            {
                if (perfiles.Contains(p.IdPerfil))
                {
                    if(!acciones.Contains(p.IdAccion))
                        acciones.Add(p.IdAccion);
                }
            }
            return acciones;
        }
    }
}
