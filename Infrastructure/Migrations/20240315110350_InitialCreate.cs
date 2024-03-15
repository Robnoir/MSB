using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8231cd1f-c54b-40f7-b76a-fd58224ec787"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ebb23e38-1735-4192-bf03-3d143d51a6fa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f606a06e-77c4-4ec6-871d-e7389c811997"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("837eec4c-f4fb-4d7e-80cb-cea2ea654649"), "Erik@gmail.com", "Erik", "Eriksson", "Erik123" },
                    { new Guid("a54f8b51-3e71-4b7c-8880-46574e532d44"), "Bertil@gmail.com", "Bertil", "Bengtsson", "Bertil123" },
                    { new Guid("b870b5ce-fecc-4afb-ab2b-07ddb9d8837e"), "Adam@gmail.com", "Adam", "Andersson", "Adam123" },
                    { new Guid("de545d2e-9959-4bcc-b363-b90b8bfa3581"), "Cecar@gmail.com", "Cecar", "Citron", "Cecar123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("837eec4c-f4fb-4d7e-80cb-cea2ea654649"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a54f8b51-3e71-4b7c-8880-46574e532d44"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b870b5ce-fecc-4afb-ab2b-07ddb9d8837e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de545d2e-9959-4bcc-b363-b90b8bfa3581"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("8231cd1f-c54b-40f7-b76a-fd58224ec787"), "Bertil@gmail.com", "Bertil", "Bengtsson", "Bertil123" },
                    { new Guid("ebb23e38-1735-4192-bf03-3d143d51a6fa"), "Cecar@gmail.com", "Cecar", "Citron", "Cecar123" },
                    { new Guid("f606a06e-77c4-4ec6-871d-e7389c811997"), "Adam@gmail.com", "Adam", "Andersson", "Adam123" }
                });
        }
    }
}
