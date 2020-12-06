using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CRUD.API.Core.Domain;

using Microsoft.EntityFrameworkCore;

namespace CRUD.API.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
