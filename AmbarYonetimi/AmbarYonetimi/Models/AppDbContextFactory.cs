using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AmbarYonetimi.Models;

namespace AmbarYonetimi
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Bu bağlantı cümlesini kendi veritabanına göre ayarla!
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AmbarYonetimi;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
