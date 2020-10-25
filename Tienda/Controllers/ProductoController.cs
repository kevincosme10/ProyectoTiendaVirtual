using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tienda.Infraestructura.Base;
using tiendaCommon.Filtro;
using tiendaCommon.Page;
using TiendaEntities.DTOS;
using TiendaEntities.Models;
using TiendaService.Base.BaseInterface;
using TiendaService.ServiceInterface;

namespace Tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : BaseApi<Producto, ProductoDto, IServiceBase<Producto>>
    {
        readonly IProductoService productoService;

        public ProductoController(IServiceBase<Producto> manager, IMapper mapper, IProductoService _productoService) : base(manager, mapper)
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

        [HttpGet, DisableRequestSizeLimit]
        [Route("PostProducto/{nombre}/{codigo}/{description}/{precio}/{cantidad}")]
        [AllowAnonymous]
        public ActionResult PostProducto(string nombre, string codigo, string description, decimal precio, int cantidad)
        {
            try
            {
                var producto = new Producto()
                {
                    Nombre = nombre,
                    CodigoProducto = codigo,
                    Descripcion = description,
                    Precio = precio,
                    Cantidad = cantidad,
                };
                productoService.InsertProducto(producto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
