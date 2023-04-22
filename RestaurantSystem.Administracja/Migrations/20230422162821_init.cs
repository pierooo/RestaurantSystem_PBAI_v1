using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystem.Administracja.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LinkTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    IsContactPage = table.Column<bool>(type: "bit", nullable: false),
                    IsIndexPage = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergens = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPriceGross = table.Column<decimal>(type: "money", nullable: true),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForMainPage = table.Column<bool>(type: "bit", nullable: true),
                    PartialType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialButtonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partial_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartialEntityBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDataTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDataContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDataTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDataContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneDataTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneDataContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormButtonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentEventPartial_PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<long>(type: "bigint", nullable: true),
                    HeroPartial_PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroButtonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoModalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServicePartial_PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePartial_EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServicePartial_EventInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePartial_FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePartial_LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialEntityBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartialEntityBase_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteTitlePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopbarRightTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBarRightInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBarRightPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopbarCenterTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBarCenterPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopbarLeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBarLeftInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBarLeftPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftBoxTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftBoxPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftBoxDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoTwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoFacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterLeftInfoLinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterCenterInfoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterRightInfoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterRightInfoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterRightInfoButtonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterRightInfoButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterBottom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentEventsPartialId = table.Column<int>(type: "int", nullable: true),
                    CurrentEventPartialId = table.Column<int>(type: "int", nullable: true),
                    ContactPartialId = table.Column<int>(type: "int", nullable: true),
                    CurrentMenuPartialId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_PartialEntityBase_ContactPartialId",
                        column: x => x.ContactPartialId,
                        principalTable: "PartialEntityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_PartialEntityBase_CurrentEventPartialId",
                        column: x => x.CurrentEventPartialId,
                        principalTable: "PartialEntityBase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_PartialEntityBase_CurrentMenuPartialId",
                        column: x => x.CurrentMenuPartialId,
                        principalTable: "PartialEntityBase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ContactPartialId",
                table: "Company",
                column: "ContactPartialId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CurrentEventPartialId",
                table: "Company",
                column: "CurrentEventPartialId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CurrentMenuPartialId",
                table: "Company",
                column: "CurrentMenuPartialId");

            migrationBuilder.CreateIndex(
                name: "IX_Partial_PageId",
                table: "Partial",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PartialEntityBase_PartialId",
                table: "PartialEntityBase",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PartialEntityBase");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Partial");

            migrationBuilder.DropTable(
                name: "Page");
        }
    }
}
