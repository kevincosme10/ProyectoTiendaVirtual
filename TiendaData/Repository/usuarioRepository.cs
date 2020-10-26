using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
    public class usuarioRepository : BaseRepository<usuario>
    {
        public usuarioRepository(TiendaDataContext Context) : base(Context)
        {
        }

        public override IQueryable<usuario> FindAll()
        {
            return base.FindAll().Where(c => c.Estado == true);
        }
    }
}
