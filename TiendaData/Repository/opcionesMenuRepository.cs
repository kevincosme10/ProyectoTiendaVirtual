using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
    public class opcionesMenuRepository : BaseRepository<opcionesMenu>
    {
        public opcionesMenuRepository(TiendaDataContext Context) : base(Context)
        {
        }

        public override IQueryable<opcionesMenu> FindAll()
        {
            return base.FindAll().Where(c => c.Estado == true);
        }
    }
}
