using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("237ca902-fee1-4cee-b19c-3286bb3be960"), "Erik@gmail.com", "Erik", "Eriksson", "Erik123" },
                    { new Guid("3d3f345d-d494-4a53-af72-a079fd7b4a7e"), "Adam@gmail.com", "Adam", "Andersson", "Adam123" },
                    { new Guid("3d5dd7a8-04ac-4a99-b0ba-6ecda4addd6b"), "Bertil@gmail.com", "Bertil", "Bengtsson", "Bertil123" },
                    { new Guid("74526f85-6dcb-473e-bc71-8f70a1df29c7"), "Fredrik@gmail.com", "Fredrik", "Fredriksson", "Fredrik123" },
                    { new Guid("e338824e-22f8-4a83-8a80-14c1ca52630c"), "Cecar@gmail.com", "Cecar", "Citron", "Cecar123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
