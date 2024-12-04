using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<ClientModel> Clients { get; set; }
    }
}
