using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaEntities.Models
{
    public class TiendaDataContext : DbContext
    {
        public TiendaDataContext(DbContextOptions<TiendaDataContext> options) : base(options)
        {

        }

        public DbSet<Producto> PRODUCTO { get; set; }
    }
}
