using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) 
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Details",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreateDate = new DateTime(2025, 12, 5, 0, 0, 0, DateTimeKind.Utc)
                },
                new Villa
                {
                    Id = 2,
                    Name = "Queen Villa",
                    Details = "Details",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                    Occupancy = 2,
                    Rate = 400,
                    Sqft = 850,
                    Amenity = "",
                    CreateDate = new DateTime(2025, 12, 5, 0, 0, 0, DateTimeKind.Utc)
                },
                new Villa
                {
                    Id = 3,
                    Name = "The Breeze Villa",
                    Details = "Details",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                    Occupancy = 8,
                    Rate = 100,
                    Sqft = 250,
                    Amenity = "",
                    CreateDate = new DateTime(2025, 12, 5, 0, 0, 0, DateTimeKind.Utc)
                }
                );

        }
    }
}
