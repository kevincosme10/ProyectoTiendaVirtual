using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaData.Interfaces;
using TiendaEntities.Models;

namespace TiendaData.Repository
{
    public class CarritoCompraRepository : BaseRepository<CarritoCompra> 
    {
        public CarritoCompraRepository(TiendaDataContext context) : base(context)
        {

        }

        public override IQueryable<CarritoCompra> FindAll()
        {
            return base.FindAll().Where(c=> c.Estado == true);
        }
    }
}
