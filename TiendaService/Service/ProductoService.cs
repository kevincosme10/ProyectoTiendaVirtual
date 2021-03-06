﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tiendaCommon.Filtro;
using TiendaData.Interfaces;
using TiendaData.Interfaces.Base;
using TiendaEntities.DTOS;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.Base.BaseInterface;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class ProductoService :ServiceBase<Producto>, IProductoService
    {
        readonly IMapper mapper;
        readonly IBaseRepository<Producto> _baseRepository;


        public ProductoService(IBaseRepository<Producto> baseRepository, IMapper _mapper) : base(baseRepository)
        {
   
            mapper = _mapper;
            _baseRepository = baseRepository;

        }
        public IEnumerable<Producto> GetPaged(ProductoFilter Filtro)
        {
            var producto = base.FindAll();

            if (Filtro.nombre != null)
                producto = producto.Where(c => c.Nombre == Filtro.nombre);
            if (Filtro.Codigo !=null )
                producto = producto.Where(c => c.CodigoProducto == Filtro.Codigo);
            
            if (Filtro.StartDate == null && Filtro.EndDate != null)
                throw new ArgumentException("Se necesita la fecha de inicio para buscar");
            if (Filtro.StartDate != null && Filtro.EndDate == null)
                throw new ArgumentException("Se necesita la fecha final para buscar");
            if (Filtro.StartDate != null && Filtro.EndDate != null && producto.Count() > 0)
            {
                if (Filtro.EndDate < Filtro.StartDate)
                    throw new ArgumentException("La fecha inicio no puede ser mayor que la fecha final");
                producto = producto.Where(c => c.CreateDate >= Filtro.StartDate && c.CreateDate <= Filtro.EndDate);

                if (producto.Count() == 0)
                    throw new ArgumentException("No existen datos con los parametros suministrado por el usuario");
            }

            return producto;
        }
        private void UpdateProducto(Producto data)
        {
            foreach (var item in _baseRepository.FindByCondition(c => c.CodigoProducto == data.CodigoProducto).ToList())
            {
                if (item != null)
                {
                    item.CodigoProducto = data.CodigoProducto;
                    item.Nombre = data.Nombre;
                    item.Precio = data.Precio;
                    item.Descripcion = data.Descripcion;
                    item.Cantidad = data.Cantidad;
                    item.Estado = true;
                    _baseRepository.Update(item);
                }
            }
        }
        public void InsertProducto(Producto data)
        {
            UpdateProducto(data);

            var consult = _baseRepository.Exist(c => c.CodigoProducto == data.CodigoProducto);
            if (!consult)
            {
                _baseRepository.Create(data);
            }
        }
    }
}
