using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class CarritoCompraServices : ServiceBase<CarritoCompra>, ICarritoCompra
    {
        readonly IMapper mapper;
        readonly IBaseRepository<CarritoCompra> _baseRepository;
        readonly IBaseRepository<Producto> _producto;

        public CarritoCompraServices(IBaseRepository<CarritoCompra> baseRepository, IBaseRepository<Producto> producto, IMapper _mapper) : base(baseRepository)
        {

            mapper = _mapper;
            _baseRepository = baseRepository;
            _producto = producto;
        }

        private void UpdateProducto(int id)
        {
            foreach (var item in _producto.FindByCondition(c => c.Id == id).ToList())
            {
                item.Cantidad = item.Cantidad - 1;
                _producto.Update(item);
            }
        }

        private void UpdateCarrito(CarritoCompra data)
        {
            foreach(var item in _baseRepository.FindByCondition(c=> c.Codigo == data.Codigo ).ToList())
            {
                if(item != null)
                {
                    item.Cantidad = item.Cantidad + 1;
                    item.Precio = data.Precio;
                    item.Nombre = data.Nombre;
                    item.Codigo = data.Codigo;
                    item.idProducto = data.idProducto;
                    item.Estado = true;
                    _baseRepository.Update(item);
                }
            }
        }
        public void CreateCompra(int id)
        {
            foreach (var item in _producto.FindByCondition(c => c.Id == id).ToList())
            {
                var consult = new CarritoCompra()
                {
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Codigo = item.CodigoProducto,
                    idProducto = id
                };
                UpdateProducto(id);
                UpdateCarrito(consult);
                var result = _baseRepository.Exist(c => c.Codigo == consult.Codigo);
                if (!result)
                {
                    _baseRepository.Create(consult);
                }
            }
        }
    }
}
