using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using project_of_dotnet.Models;

namespace project_of_dotnet.Data
{
    public class project_of_dotnetContext : DbContext
    {
        public project_of_dotnetContext (DbContextOptions<project_of_dotnetContext> options)
            : base(options)
        {
        }

        public DbSet<project_of_dotnet.Models.user_data> user_data { get; set; } = default!;

        public DbSet<project_of_dotnet.Models.trip_pkg>? trip_pkg { get; set; }

        public DbSet<project_of_dotnet.Models.admin>? admin { get; set; }

        public DbSet<project_of_dotnet.Models.booking>? booking { get; set; }

        public DbSet<project_of_dotnet.Models.destination>? destination { get; set; }

       
    }
}
