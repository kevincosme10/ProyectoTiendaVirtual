using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
   public class perfilRepository : BaseRepository<perfil>
    {
        public perfilRepository(TiendaDataContext Context) : base(Context)
        {

        }

        public override IQueryable<perfil> FindAll()
        {
            return base.FindAll().Where(c => c.Estado == true);
        }
    }
}
