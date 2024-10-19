using Microsoft.EntityFrameworkCore;

namespace Image
{
    public class ImageContext : DbContext
    {
        public ImageContext( DbContextOptions<ImageContext> options ) : base(options) { }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImageContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
