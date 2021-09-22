using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using CadastroSeries_API.Interfaces;

namespace CadastroSeries_API.Web
{
    public class ContextModel : DbContext
    {
        public DbSet<SerieModel> Series { get; set; }
        public ContextModel(DbContextOptions<ContextModel> options) : base(options)
        {

        }
    }
}
