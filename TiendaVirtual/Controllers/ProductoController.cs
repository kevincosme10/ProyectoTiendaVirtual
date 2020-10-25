using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tiendaCommon.Filtro;
using tiendaCommon.Page;
using TiendaEntities.DTOS;
using TiendaEntities.Models;
using TiendaService.Base.BaseInterface;
using TiendaService.ServiceInterface;
using TiendaVirtual.Infraestructura.Base;

namespace TiendaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : BaseApiController<Producto, ProductoDto, IServiceBase<Producto>>
    {
        readonly IProductoService productoService;

        public ProductoController(IServiceBase<Producto> producto, IMapper mapper, IProductoService _productoService): base(producto, mapper)
        {
            productoService = _productoService;
        }

        [HttpGet]
        [Route("GetPaged")]
        public ActionResult GetPagedList([FromQuery] ProductoFilter filter)
        {
            try
            {
                var empty = new List<Producto>();
                var data = productoService.GetPaged(filter);
                var result = PagedList<ProductoDto>.Create((IQueryable<ProductoDto>)data.AsQueryable(), filter.PageNumber, filter.PageSize);
                if (result == null)
                {
                    return BadRequest("No existen datos con este filtro");
                }
                var pagination = new
                {
                    totalCount = result.TotalCount,
                    pageSize = result.PageSize,
                    currentPage = result.CurrentPage,
                    totalPage = result.TotalPages,
                    HasNext = result.HasNext,
                    HasPrevious = result.HasPrevious,
                    data = result
                };
                return Ok(pagination);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
