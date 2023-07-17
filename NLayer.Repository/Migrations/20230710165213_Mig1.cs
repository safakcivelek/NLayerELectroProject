using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    IsDiscounted = table.Column<bool>(type: "bit", nullable: false),
                    StarPoint = table.Column<int>(type: "int", nullable: false),
                    StarGivenUserCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "45acdf50-761a-443c-859f-709f3526d906", "FullAccess", "FULLACCESS" },
                    { 2, "19c4b3f2-c1b5-4b88-a5a8-b837abe38496", "ReadOnly", "READONLY" },
                    { 3, "d553a401-7def-4a39-94e8-60ffecdb4eb6", "LoggedCustomer", "LOGGEDCUSTOMER" },
                    { 4, "b6d1d5ad-607c-44fc-9b95-9729d8c0dfe5", "NotLoggedCustomer", "NOTLOGGEDCUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of Electro", 0, "b47fca18-dc1e-445a-8802-241bec77c50c", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAIAAYagAAAAEEJWLbHRCgYloUCtFSuidA1tvJ9A9S9kd5XH9t8t6M4G4yl2rHBUz4gxOIi54trEkw==", "+905555555555", true, "userImages/defaultUser.png", "eb45eed7-5f09-4c37-a8ef-ce931145dc5b", "https://twitter.com/adminuser", false, "adminuser", "https://electro.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of Electro", 0, "3354f848-ee0e-4c6b-b904-f948efab94ce", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Editor", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAIAAYagAAAAEP/YpLcvnQS5VlPdhTSlYDwCd8QKSsZ56dZYpIYCiRbIXvdy1Nt71fbfnmEhw5Go7w==", "+905555555555", true, "userImages/defaultUser.png", "60ef0bb4-f5b6-44f3-8282-73d50e1074cd", "https://twitter.com/editoruser", false, "editoruser", "https://electro.com/", "https://youtube.com/editoruser" },
                    { 3, "Customer User of Electro", 0, "819775fc-b3ac-4cae-9958-08c37db86ffe", "customeruser@gmail.com", true, "https://facebook.com/customeruser", "Customer", "https://github.com/customeruser", "https://instagram.com/customeruser", "User", "https://linkedin.com/customeruser", false, null, "CUSTOMERUSER@GMAIL.COM", "CUSTOMERUSER", "AQAAAAIAAYagAAAAEPvSnWUYISuvz60G/SEl9tJ/0WSZIeSB9OP22RQitPIwAEr9YQ1PKft1KORRis0Acg==", "+905555555555", true, "userImages/defaultUser.png", "9c1adcf8-85a4-4c0f-b12e-fc2b390afede", "https://twitter.com/customeruser", false, "customeruser", "https://electro.com/", "https://youtube.com/customeruser" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1871), "Laptop Modelleri", true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1872), "Laptop" },
                    { 2, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1876), "Kamera Modelleri", true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1877), "Kamera" },
                    { 3, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1879), "Kulaklık Modelleri", true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1880), "Kulaklık" },
                    { 4, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1882), "Monitor Modelleri", true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(1883), "Monitor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "AddressTitle", "City", "Country", "CreatedByName", "CreatedDate", "Description", "District", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "OrderNumber", "PostalCode", "Status", "Total", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2. Küçükçekmece/İstanbul", "Ev", "İstanbul", "Türkiye", "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2518), "1 No'lu Sipariş Açıklaması.", "Küçükçekmece", false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2518), "No1111", "34660", 0, 350m, 3, "customeruser" },
                    { 2, "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2.", "Ev", "Brüksel", "Belçika", "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2523), "2 No'lu Sipariş Açıklaması.", "Üsküdar", false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2524), "No2222", "34660", 0, 950m, 3, "customeruser" },
                    { 3, "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2. Küçükçekmece/İstanbul", "İş", "Tokyo", "Japonya", "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2527), "3 No'lu Sipariş Açıklaması.", "Kadiköy", false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2528), "No3333", "34660", 0, 1700m, 3, "customeruser" },
                    { 4, "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2. Küçükçekmece/İstanbul", "İş", "Paris", "Fransa", "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2531), "4 No'lu Sipariş Açıklaması.", "Beylikdüzü", false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2532), "No4444", "34660", 0, 2630m, 3, "customeruser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "CommentCount", "CreatedByName", "CreatedDate", "Description", "Discount", "ImageUrl", "IsActive", "IsDeleted", "IsDiscounted", "ModifiedByName", "ModifiedDate", "Name", "Price", "Size", "StarGivenUserCount", "StarPoint", "Stock" },
                values: new object[,]
                {
                    { 1, 1, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2287), "2 Yıl Garantili, Taşınabilir Bilgisayar", 0.0, "productImages/defaultProduct1.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2287), "Casper Nirvana Intel Core i7", 10m, null, 10, 5, 10 },
                    { 2, 2, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2293), "2 Yıl Garantili, Taşınabilir Kamera", 0.0, "productImages/defaultProduct3.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2294), "Canon XA11 FUll HD", 20m, null, 10, 5, 20 },
                    { 3, 3, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2304), "2 Yıl Garantili, Taşınabilir Kulaklık", 0.0, "productImages/defaultProduct4.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2305), "Sony WH-CH510W Kablosuz", 30m, null, 10, 5, 30 },
                    { 4, 4, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2321), "2 Yıl Garantili, Taşınabilir Monitor", 0.0, "productImages/defaultProduct5.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2322), "ASUS Rog 24.5 140Hz ", 40m, null, 10, 5, 40 },
                    { 5, 1, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2325), "2 Yıl Garantili, Taşınabilir Bilgisayar", 0.0, "productImages/defaultProduct2.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2326), "Hp Victus Intel Core i5", 50m, null, 10, 5, 50 },
                    { 6, 2, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2329), "2 Yıl Garantili, Taşınabilir Kamera", 0.0, "productImages/defaultProduct3.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2329), "Haikon DA33 FUll HD", 60m, null, 10, 5, 60 },
                    { 7, 3, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2333), "2 Yıl Garantili, Taşınabilir Kulaklık", 0.0, "productImages/defaultProduct4.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2333), "SAMSUNG O-IA500B Kulaklık", 70m, null, 10, 5, 70 },
                    { 8, 4, null, 0, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2337), "2 Yıl Garantili, Taşınabilir Monitor", 0.0, "productImages/defaultProduct5.png", true, false, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2337), "MSI Optix G241VC 23.6 75Hz", 80m, null, 10, 5, 80 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "ProductId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2879), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2880), 1, "Yorum 1. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 2, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2883), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2884), 2, "Yorum 2. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 3, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2886), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2887), 3, "Yorum 3. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 4, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2889), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2889), 4, "Yorum 4. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 5, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2892), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2892), 5, "Yorum 5. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 6, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2895), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2895), 6, "Yorum 6. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 7, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2898), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2898), 7, "Yorum 7. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null },
                    { 8, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2900), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2901), 8, "Yorum 8. Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.", null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Price", "Quantity", "SubTotal" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2679), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2680), 10m, (short)11, 110m },
                    { 1, 2, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2696), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2697), 20m, (short)12, 240m },
                    { 2, 3, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2700), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2700), 30m, (short)13, 390m },
                    { 2, 4, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2703), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2704), 40m, (short)14, 560m },
                    { 3, 5, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2707), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2708), 50m, (short)15, 750m },
                    { 3, 6, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2711), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2711), 60m, (short)16, 960m },
                    { 4, 7, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2714), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2715), 70m, (short)17, 1190m },
                    { 4, 8, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2717), true, false, "InitialCreate", new DateTime(2023, 7, 10, 19, 52, 13, 161, DateTimeKind.Local).AddTicks(2718), 80m, (short)18, 1440m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
