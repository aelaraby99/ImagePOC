using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Image
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure( EntityTypeBuilder<Image> builder )
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MyImage)
                .HasColumnType("BLOB")
                .IsRequired();
        }
    }
}
