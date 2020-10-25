using System;
using System.Collections.Generic;
using System.Text;
using tiendaCommon.Filtro;
using TiendaEntities.DTOS;
using TiendaEntities.Models;

namespace TiendaService.ServiceInterface
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetPaged(ProductoFilter Filtro);
    }
}
