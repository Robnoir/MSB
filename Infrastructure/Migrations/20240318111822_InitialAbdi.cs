using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialAbdi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("237ca902-fee1-4cee-b19c-3286bb3be960"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d3f345d-d494-4a53-af72-a079fd7b4a7e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d5dd7a8-04ac-4a99-b0ba-6ecda4addd6b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("74526f85-6dcb-473e-bc71-8f70a1df29c7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e338824e-22f8-4a83-8a80-14c1ca52630c"));

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("0242de68-0b52-405c-a89b-8a48670b6ee9"), "Fredrik@gmail.com", "Fredrik", "Fredriksson", "Fredrik123" },
                    { new Guid("041b4692-6ac0-45e3-98d5-65594a857065"), "Adam@gmail.com", "Adam", "Andersson", "Adam123" },
                    { new Guid("2fc12c97-32a7-4ac8-9716-15c94e3b50a3"), "Erik@gmail.com", "Erik", "Eriksson", "Erik123" },
                    { new Guid("65793820-9c55-4a93-8ed3-0b5516ee291c"), "Bertil@gmail.com", "Bertil", "Bengtsson", "Bertil123" },
                    { new Guid("e643395d-f63a-4cba-96fb-e35446f9af8c"), "Cecar@gmail.com", "Cecar", "Citron", "Cecar123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0242de68-0b52-405c-a89b-8a48670b6ee9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("041b4692-6ac0-45e3-98d5-65594a857065"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2fc12c97-32a7-4ac8-9716-15c94e3b50a3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65793820-9c55-4a93-8ed3-0b5516ee291c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e643395d-f63a-4cba-96fb-e35446f9af8c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("237ca902-fee1-4cee-b19c-3286bb3be960"), "Erik@gmail.com", "Erik", "Eriksson", "Erik123" },
                    { new Guid("3d3f345d-d494-4a53-af72-a079fd7b4a7e"), "Adam@gmail.com", "Adam", "Andersson", "Adam123" },
                    { new Guid("3d5dd7a8-04ac-4a99-b0ba-6ecda4addd6b"), "Bertil@gmail.com", "Bertil", "Bengtsson", "Bertil123" },
                    { new Guid("74526f85-6dcb-473e-bc71-8f70a1df29c7"), "Fredrik@gmail.com", "Fredrik", "Fredriksson", "Fredrik123" },
                    { new Guid("e338824e-22f8-4a83-8a80-14c1ca52630c"), "Cecar@gmail.com", "Cecar", "Citron", "Cecar123" }
                });
        }
    }
}
