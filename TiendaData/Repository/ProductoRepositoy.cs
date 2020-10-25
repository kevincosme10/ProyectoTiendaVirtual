using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaData.Interfaces;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
    public class ProductoRepository : BaseRepository<Producto>
    {
        public ProductoRepository(TiendaDataContext context) : base(context)
        {

        }

        public override IQueryable<Producto> FindAll()
        {
            return base.FindAll().Where(c=> c.Estado == true);
        }
    }
}
