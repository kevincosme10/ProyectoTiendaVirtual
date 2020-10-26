using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TiendaData.Interfaces.Base;
using TiendaEntities.Models;
using TiendaService.Base;
using TiendaService.ServiceInterface;

namespace TiendaService.Service
{
    public class usuarioService: ServiceBase<usuario>, Iusuario
    {

        readonly IMapper mapper;
        readonly IBaseRepository<Producto> _baseRepository;

        public usuarioService(IMapper mapper, IBaseRepository<usuario> baseRepository): base(baseRepository)
        {

        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int Create(usuario entity)
        {
            return base.Create(entity);
        }

        public override void Delete(int Id)
        {
            base.Delete(Id);
        }

        public override IQueryable<usuario> FindAll()
        {
            return base.FindAll();
        }

        public override IQueryable<usuario> FindByCondition(Expression<Func<usuario, bool>> expression)
        {
            return base.FindByCondition(expression);
        }

        public override usuario GetOne(int Id)
        {
            return base.GetOne(Id);
        }

        public override usuario Update(usuario entity)
        {
            return base.Update(entity);
        }

        public usuario login(string correo, string contrasena) 
        {
            var usrs = base.FindByCondition(c => c.correo == correo && c.contrasena == contrasena);
            usuario usr = new usuario();
            if(usrs.Count() > 0)
            {
                usr = usrs.FirstOrDefault();
            }
            return usr;
        }

    
    }
}
