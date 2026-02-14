using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop26.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<IdentityUser> SeedUsers()
        {
            var users = new List<IdentityUser>();
            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                UserName = "admin@test.bg",
                NormalizedUserName = "ADMIN@TEST.BG",
                Email = "admin@test.bg",
                NormalizedEmail = "ADMIN@TEST.BG",
                EmailConfirmed = true,
                SecurityStamp = "YIXYIXE6GJSSN4KVYJROXMJQKQ2EVPJT",
                ConcurrencyStamp = "f81c19fd-26e6-4bf4-b0d5-9fe7b6ab964e",
                
                
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Test123/");

            users.Add(user);
            

            return users;
        }
    }
}
