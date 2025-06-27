using API_Usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Usuario.Context
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db>options) : base(options) { }

        public DbSet<Acompanhamento> Acompanhamentos { get; set; }

        public DbSet<Desligamento> Desligamentos { get;  set; }

        public DbSet<FitCultural> FitCulturals { get; set; }

        public DbSet<MotivoDesligamentos> MotivoDesligamentos { get; set; }


    }
}
