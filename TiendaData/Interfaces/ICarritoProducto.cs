using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaEntities.Models;

namespace TiendaData.Interfaces
{
    public interface ICarritoProducto
    {
        IQueryable<CarritoCompra> GetAll();
    }
}
