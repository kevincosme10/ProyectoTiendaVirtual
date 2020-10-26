using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
   public class perfilAccionRepository : BaseRepository<perfilAccion>
    {
        public perfilAccionRepository(TiendaEntities.Models.TiendaDataContext Context) : base(Context)
        {
        }

        public override IQueryable<perfilAccion> FindAll()
        {
            return base.FindAll().Where(c => c.Estado == true);
        }
    }
}
