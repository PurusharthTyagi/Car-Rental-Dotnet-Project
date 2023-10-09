using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DAL.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: new Guid("2d8382a4-1c87-45e7-86e1-b2fcfa0741aa"),
                columns: new[] { "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { "purutyagi18@gmail.com", "Purusharth", "Tyagityagi", "8287530685" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: new Guid("ebb78241-6990-4ee9-8c2b-968bd3e400c3"),
                columns: new[] { "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { "Tester@test.com", "Tester", "Markmark", "7982215948" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: new Guid("fac2a973-aaea-4108-a31d-1cad2f662fad"),
                columns: new[] { "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { "purusharthtyagi22@gmail.com", "Puru", "Tyagityagi1818", "8287530685" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: new Guid("2d8382a4-1c87-45e7-86e1-b2fcfa0741aa"),
                columns: new[] { "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { "gulshan@test.com", "Gulshan", "gulshan123", "7011856425" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: new Guid("ebb78241-6990-4ee9-8c2b-968bd3e400c3"),
                columns: new[] { "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { "admin@test.com", "Admin", "admin123", "9990724214" });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: new Guid("fac2a973-aaea-4108-a31d-1cad2f662fad"),
                columns: new[] { "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { "dubey@test.com", "Dubey", "dubey123", "8198093390" });
        }
    }
}
