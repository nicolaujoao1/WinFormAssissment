using AssessmentApp.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssessmentApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veiculo>? Veiculos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<decimal>().HavePrecision(16, 2);
            configuration.Properties<string>().HaveMaxLength(250);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Veiculo>().ToTable("tb_Veiculo")
                   .HasKey(x => x.Id);
            modelBuilder.Entity<Veiculo>().Property(x => x.Placa).HasMaxLength(250);
            modelBuilder.Entity<Veiculo>().Property(x => x.Chassi).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Veiculo>().Property(x => x.Marca).HasMaxLength(250);
            modelBuilder.Entity<Veiculo>().Property(x => x.Modelo).HasMaxLength(250);
            modelBuilder.Entity<Veiculo>().Property(x => x.Observacoes).HasMaxLength(250);


        }

        #region MyRegion
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("Server=localhost;Database=Db_Assessment_App;User=root;Password='';",
        //        new MySqlServerVersion(new Version(8, 0, 23)));
        //}
        #endregion
    }
}
