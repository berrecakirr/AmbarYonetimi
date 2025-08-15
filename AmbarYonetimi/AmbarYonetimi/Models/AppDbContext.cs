using Microsoft.EntityFrameworkCore;

namespace AmbarYonetimi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<MalzemeHareket> MalzemeHareketleri { get; set; }
        public DbSet<BaslikDepo> BaslikDepolar { get; set; }
        public DbSet<KolcakDepo> KolcakDepolar { get; set; }
        public DbSet<KilifDepo> KilifDepolar { get; set; }
        public DbSet<IskeletDepo> IskeletDepolar { get; set; }
        public DbSet<SungerDepo> SungerDepolar { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TransferModel> Transferler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public object BaslikDepo { get; internal set; }
        public IEnumerable<object> SungerDepo { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Password).IsUnique();
            });

            modelBuilder.Entity<BaslikDepo>().ToTable("BaslikDepolar");
            modelBuilder.Entity<KilifDepo>().ToTable("KilifDepolar");
            modelBuilder.Entity<KolcakDepo>().ToTable("KolcakDepolar");
            modelBuilder.Entity<SungerDepo>().ToTable("SungerDepolar");
            modelBuilder.Entity<IskeletDepo>().ToTable("IskeletDepolar");
        }
    }
}
