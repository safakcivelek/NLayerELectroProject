using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7ff535c1-1cd6-4c63-965d-a0481a42353c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0e2fbdf6-fb7c-4ad0-aa59-a93d251e6203");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c9efc0ee-fa3f-41f9-b7e3-a8afc3be4ddb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "d2cd45b0-d32c-4659-a1b4-f9b6e4fc2f6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e999bd0-cfaf-494e-a8be-b23e76f30831", "AQAAAAIAAYagAAAAEM3jfZrpD8LvFYmK58pABY1vjhEe6HFEAo6fn6S0Af6KCt8fl2VchGbW7twlzIcCqA==", "b61cdbda-1236-4272-b150-402731940321" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db2696c3-61e5-4729-ba3e-7bd0b7013d50", "AQAAAAIAAYagAAAAEL7yQw4uLkgiYw0K6FY2Er/WdrKRrKPbSNLgm/7gusrYlQy5Pss9ams9Aed0/m725w==", "df77d141-9097-4d33-afb7-5a8b9b798bca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f08468a-c0d1-464d-a725-d650388768b7", "AQAAAAIAAYagAAAAEMeNeC04q8YsXe/9q45NojuVdNGFvvm1VInZNiUhwJYXDejbIJZg+Dh8pjThJzasnw==", "f333a020-ec43-4cc8-a329-b2c7e0fab8c2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6690), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6695), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6695) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6698), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6701), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7418), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7421), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7424), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7427), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7430), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7433), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7435), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7436) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7438), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7265), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7282), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7286), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7290), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 5 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7293), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7297), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 7 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7300), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 8 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7304), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7141), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7146), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7150), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7154), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6991), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6996), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7000), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7006), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7010), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7013), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7017), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7018) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7021), new DateTime(2023, 7, 10, 19, 57, 46, 757, DateTimeKind.Local).AddTicks(7022) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "45acdf50-761a-443c-859f-709f3526d906");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "19c4b3f2-c1b5-4b88-a5a8-b837abe38496");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "d553a401-7def-4a39-94e8-60ffecdb4eb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b6d1d5ad-607c-44fc-9b95-9729d8c0dfe5");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b47fca18-dc1e-445a-8802-241bec77c50c", "AQAAAAIAAYagAAAAEEJWLbHRCgYloUCtFSuidA1tvJ9A9S9kd5XH9t8t6M4G4yl2rHBUz4gxOIi54trEkw==", "eb45eed7-5f09-4c37-a8ef-ce931145dc5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3354f848-ee0e-4c6b-b904-f948efab94ce", "AQAAAAIAAYagAAAAEP/YpLcvnQS5VlPdhTSlYDwCd8QKSsZ56dZYpIYCiRbIXvdy1Nt71fbfnmEhw5Go7w==", "60ef0bb4-f5b6-44f3-8282-73d50e1074cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "819775fc-b3ac-4cae-9958-08c37db86ffe", "AQAAAAIAAYagAAAAEPvSnWUYISuvz60G/SEl9tJ/0WSZIeSB9OP22RQitPIwAEr9YQ1PKft1KORRis0Acg==", "9c1adcf8-85a4-4c0f-b12e-fc2b390afede" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1871), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1872) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1876), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1877) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1879), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1882), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2879), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2883), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2886), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2889), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2892), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2895), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2895) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2898), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2898) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2900), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2901) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2679), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2696), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2697) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2700), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2703), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2704) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 5 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2707), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2708) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2711), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 7 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2714), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 8 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2717), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2718) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2518), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2518) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2523), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2527), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2531), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2532) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2287), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2287) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2293), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2294) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2304), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2321), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2325), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2326) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2329), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2329) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2333), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2337), new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2337) });
        }
    }
}
