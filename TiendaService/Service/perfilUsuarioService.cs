﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class perfilUsuarioService : ServiceBase<perfilUsuario>, IperfilUsuario
    {
        private readonly IBaseRepository<perfilUsuario> repository;

        public perfilUsuarioService(IBaseRepository<perfilUsuario> repository) : base(repository)
        {
            this.repository = repository;
        }

        public List<int> ObtenerPerfilesdeUsuario(int idUsiario)
        {
            List<int> perfiles = new List<int>();
            perfiles = base.FindByCondition(c => c.IdUsuario == idUsiario).Select(c => c.IdPerfil).ToList();
            return perfiles;
        }
    }
}
