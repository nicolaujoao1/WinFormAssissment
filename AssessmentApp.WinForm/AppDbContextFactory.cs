using AssessmentApp.Data.Context;
using AssessmentApp.WinForm.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AssessmentApp.WinForm
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(ConnectionString.connectionString,
                new MySqlServerVersion(new Version(8, 0, 23)));

            return new AppDbContext(optionsBuilder.Options);
        }
    }

}
