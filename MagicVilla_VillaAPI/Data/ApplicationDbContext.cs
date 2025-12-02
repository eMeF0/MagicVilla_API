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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Details",
                    ImageUrl = "https://www.lecollectionist.com/en/luxury-rental/villa-cavillonne-grimaud",
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
                    ImageUrl = "https://media.inmobalia.com/imgV1/B98Le8~d7M9k3DegigWkzHXQlgzMFGqGJJp6ZRUcpX033lqadFBp2i4GGW4X2J1jIJ9Pwc6GsJX5cPSaC8Y5L~JfyHdu4Kip1k1F_9jq2QL1VlZkhoZwz17cTlFZNkNz3cS1P_oNeDi2nalfIzOHCukLbLsWTdvHO7XeSjMdZ_Z0_Ly766bTtu6PR960e0cp3S3nu~K~6B6gKJ0EHmX9y3T8_7P4AKNIUzg5bomJ14gPD0j7n2GO4RUmUotYoxhsgFwD~xK1l6gyQ~jJev0BEsdf7j29W1qY55FPh6RRQVme_TpPQ6P3p3jlwdsdQIbggg--.jpg",
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
                    ImageUrl = "https://media.inmobalia.com/imgV1/B95mbh8olwFQm~uCUaVOI2kQT0hb0a8sZ9turUNfnwtvuccYCzs0YVPfPbfkc2VnnN1JFDpiXNU9xzJ~Ag4BlYYPYZFIAjR7mCUc5JBLZPdgYJCxR1v5rEuUzU_c2l5t5RfA9A4ibbDcCe10wLVTA1gzagr2V3lBJiT7AZrQwB0hDkvTgaLD_paCEArhEnq8vZRo~5EsD4KnhBpeRR6wl14AfUVUY9d3J9Ih5kJFwzq7eRBg1Xs1c8fBJ3sutGCYoLfMyae~hKabvRxbS02z508fgWrSsd~RZvDcxlVTBWcMS~92Gj21s9Oizf2_G83WhPaqKRghQiWKpV3e6JPRkBrUnDS9vb91IqeGGkR5fc_~y5iYifxFGDsBRMuXKTp7HcnjfKB19Nuw50aPfi7uBdn_fyl5sd0qS17J1WQgSCpiyK_6K_Ozqg--.jpg",
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
