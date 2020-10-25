using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaEntities.DTOS;
using TiendaEntities.Models;

namespace Tienda.Infraestructura.Mapping
{
    public class MappingEntity
    {
       public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

                //Mapeo de producto
                cfg.CreateMap<Producto, ProductoDto>().ReverseMap();

            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
