using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreateDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2025, 12, 2, 18, 55, 12, 718, DateTimeKind.Local).AddTicks(3497), "Details", "https://www.lecollectionist.com/en/luxury-rental/villa-cavillonne-grimaud", "Royal Villa", 5, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2025, 12, 2, 18, 55, 12, 719, DateTimeKind.Local).AddTicks(8473), "Details", "https://media.inmobalia.com/imgV1/B98Le8~d7M9k3DegigWkzHXQlgzMFGqGJJp6ZRUcpX033lqadFBp2i4GGW4X2J1jIJ9Pwc6GsJX5cPSaC8Y5L~JfyHdu4Kip1k1F_9jq2QL1VlZkhoZwz17cTlFZNkNz3cS1P_oNeDi2nalfIzOHCukLbLsWTdvHO7XeSjMdZ_Z0_Ly766bTtu6PR960e0cp3S3nu~K~6B6gKJ0EHmX9y3T8_7P4AKNIUzg5bomJ14gPD0j7n2GO4RUmUotYoxhsgFwD~xK1l6gyQ~jJev0BEsdf7j29W1qY55FPh6RRQVme_TpPQ6P3p3jlwdsdQIbggg--.jpg", "Queen Villa", 2, 400.0, 850, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2025, 12, 2, 18, 55, 12, 719, DateTimeKind.Local).AddTicks(8487), "Details", "https://media.inmobalia.com/imgV1/B95mbh8olwFQm~uCUaVOI2kQT0hb0a8sZ9turUNfnwtvuccYCzs0YVPfPbfkc2VnnN1JFDpiXNU9xzJ~Ag4BlYYPYZFIAjR7mCUc5JBLZPdgYJCxR1v5rEuUzU_c2l5t5RfA9A4ibbDcCe10wLVTA1gzagr2V3lBJiT7AZrQwB0hDkvTgaLD_paCEArhEnq8vZRo~5EsD4KnhBpeRR6wl14AfUVUY9d3J9Ih5kJFwzq7eRBg1Xs1c8fBJ3sutGCYoLfMyae~hKabvRxbS02z508fgWrSsd~RZvDcxlVTBWcMS~92Gj21s9Oizf2_G83WhPaqKRghQiWKpV3e6JPRkBrUnDS9vb91IqeGGkR5fc_~y5iYifxFGDsBRMuXKTp7HcnjfKB19Nuw50aPfi7uBdn_fyl5sd0qS17J1WQgSCpiyK_6K_Ozqg--.jpg", "The Breeze Villa", 8, 100.0, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
