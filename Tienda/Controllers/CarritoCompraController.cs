using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Infraestructura.Base;
using TiendaEntities.DTOS;
using TiendaEntities.Models;
using TiendaService.Base.BaseInterface;
using TiendaService.ServiceInterface;

namespace Tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoCompraController : BaseApi<CarritoCompra, CarritoCompraDto, IServiceBase<CarritoCompra>>
    {
        readonly ICarritoCompra carritocompra;

        public CarritoCompraController(IServiceBase<CarritoCompra> manager, IMapper mapper, ICarritoCompra _carritocompra) : base(manager, mapper)
        {
            carritocompra = _carritocompra;
        }


        [HttpGet, DisableRequestSizeLimit]
        [Route("PostCarrito/{idproducto}")]
        [AllowAnonymous]
        public ActionResult PostCarrito(int idproducto)
        {
            try
            {
                carritocompra.CreateCompra(idproducto);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
           
        }

    }
}
