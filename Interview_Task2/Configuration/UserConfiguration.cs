using Interview_Task2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview_Task2.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(t => t.Id);
            builder.Property(u => u.Fullname).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Birthday).IsRequired().HasColumnType("datetime");
            builder.Property(u => u.CreatedAt).IsRequired().HasColumnType("datetime");
            builder.Property(u => u.Phone).IsRequired().HasMaxLength(20);

            builder.HasIndex(u => u.Phone).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
