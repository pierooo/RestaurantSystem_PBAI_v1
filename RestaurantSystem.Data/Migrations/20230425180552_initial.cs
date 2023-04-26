using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystem.Data.Migrations
{
    public partial class initial : Migration
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForMainPage = table.Column<bool>(type: "bit", nullable: true),
                    PartialType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialButtonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentEventPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentEventPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentEventPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentMenuPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMenuPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentMenuPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentMenuPartial_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<long>(type: "bigint", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroButtonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoModalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpinionPartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionPartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpinionPartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePartial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartialId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePartial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePartial_Partial_PartialId",
                        column: x => x.PartialId,
                        principalTable: "Partial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutPartial_PartialId",
                table: "AboutPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPartial_PartialId",
                table: "ContactPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentEventPartial_PartialId",
                table: "CurrentEventPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMenuPartial_PartialId",
                table: "CurrentMenuPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMenuPartial_ProductId",
                table: "CurrentMenuPartial",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FactPartial_PartialId",
                table: "FactPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroPartial_PartialId",
                table: "HeroPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_OpinionPartial_PartialId",
                table: "OpinionPartial",
                column: "PartialId");

            migrationBuilder.CreateIndex(
                name: "IX_Partial_PageId",
                table: "Partial",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePartial_PartialId",
                table: "ServicePartial",
                column: "PartialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPartial");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ContactPartial");

            migrationBuilder.DropTable(
                name: "CurrentEventPartial");

            migrationBuilder.DropTable(
                name: "CurrentMenuPartial");

            migrationBuilder.DropTable(
                name: "FactPartial");

            migrationBuilder.DropTable(
                name: "HeroPartial");

            migrationBuilder.DropTable(
                name: "OpinionPartial");

            migrationBuilder.DropTable(
                name: "ServicePartial");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Partial");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Page");
        }
    }
}
