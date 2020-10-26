using System;
using System.Collections.Generic;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class PerfilService : ServiceBase<perfil>, Iperfil
    {
        private readonly IBaseRepository<perfil> repository;

        public PerfilService(IBaseRepository<perfil> repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
