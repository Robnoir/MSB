using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2218032d-f64d-439a-9be8-91d8060c18b3"), "Bertil@gmail.com", "Bertil", "Bengtsson", "Bertil123" },
                    { new Guid("33ca6ffc-f18f-4f17-80c6-07a96f3424d4"), "Adam@gmail.com", "Adam", "Andersson", "Adam123" },
                    { new Guid("4129a15f-2b5d-4d7f-8423-dc65d919fa11"), "Erik@gmail.com", "Erik", "Eriksson", "Erik123" },
                    { new Guid("5761d564-e513-4f3d-aec6-8f8db61c2b2d"), "Cecar@gmail.com", "Cecar", "Citron", "Cecar123" },
                    { new Guid("82d98b6d-575d-436f-8c8c-a756a4cd42dd"), "Fredrik@gmail.com", "Fredrik", "Fredriksson", "Fredrik123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2218032d-f64d-439a-9be8-91d8060c18b3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33ca6ffc-f18f-4f17-80c6-07a96f3424d4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4129a15f-2b5d-4d7f-8423-dc65d919fa11"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5761d564-e513-4f3d-aec6-8f8db61c2b2d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("82d98b6d-575d-436f-8c8c-a756a4cd42dd"));

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
    }
}
