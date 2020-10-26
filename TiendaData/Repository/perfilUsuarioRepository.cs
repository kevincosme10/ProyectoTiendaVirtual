using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
    public class perfilUsuarioRepository : BaseRepository<perfilUsuario>
    {
        public perfilUsuarioRepository(TiendaDataContext Context) : base(Context)
        {
        }

        public override IQueryable<perfilUsuario> FindAll()
        {
            return base.FindAll().Where(c => c.Estado == true);
        }
    }
}
