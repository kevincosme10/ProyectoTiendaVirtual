using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendaEntities.DTOS;
using TiendaEntities.Models;

namespace TiendaVirtual.Infraestructura.Mapeo
{
    public class MapeoEntity
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
