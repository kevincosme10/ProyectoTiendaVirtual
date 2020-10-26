using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEntities.Models
{
    public class TiendaDataContext : IdentityDbContext
    {
        public TiendaDataContext(DbContextOptions<TiendaDataContext> options) : base(options)
        {

        }

        public DbSet<Producto> PRODUCTO { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<opcionesMenu> opcionesMenu  { get; set; }
        public DbSet<perfilAccion> perfilAccion{ get; set; }
        public DbSet<perfilUsuario> perfilUsuario{ get; set; }
        public DbSet<CarritoCompra> CarritoCompra{ get; set; }
    }
}
