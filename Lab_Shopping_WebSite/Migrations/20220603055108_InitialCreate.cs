using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_Shopping_WebSite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action_Auths",
                columns: table => new
                {
                    ActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action_Auths", x => x.ActionID);
                });

            migrationBuilder.CreateTable(
                name: "Blog_Contents",
                columns: table => new
                {
                    Blog_ContentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blog_Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_Contents", x => x.Blog_ContentID);
                });

            migrationBuilder.CreateTable(
                name: "Blog_Hrefs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_Hrefs", x => new { x.BlogID, x.CommodityID });
                });

            migrationBuilder.CreateTable(
                name: "Blog_Images",
                columns: table => new
                {
                    Blog_Images_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogID = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_Images", x => x.Blog_Images_ID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blog_Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    CommodityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isReleased = table.Column<bool>(type: "bit", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.CommodityID);
                });

            migrationBuilder.CreateTable(
                name: "Commodity_Images",
                columns: table => new
                {
                    Commodity_ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Images", x => x.Commodity_ImageID);
                    table.ForeignKey(
                        name: "FK_Commodity_Images_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "CommodityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commodity_Kinds",
                columns: table => new
                {
                    Commodity_KindID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Kinds", x => x.Commodity_KindID);
                });

            migrationBuilder.CreateTable(
                name: "Commodity_Prices",
                columns: table => new
                {
                    Commodity_PriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    PriceID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Prices", x => x.Commodity_PriceID);
                    table.ForeignKey(
                        name: "FK_Commodity_Prices_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "CommodityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commodity_Sizes",
                columns: table => new
                {
                    Commodity_SizesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Sizes", x => x.Commodity_SizesID);
                    table.ForeignKey(
                        name: "FK_Commodity_Sizes_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commodity_Sizes_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "CommodityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commodity_Tags",
                columns: table => new
                {
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity_Tags", x => new { x.CommodityID, x.TagID });
                    table.ForeignKey(
                        name: "FK_Commodity_Tags_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "CommodityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupon_Uses",
                columns: table => new
                {
                    SaleID = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    CouponID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Use_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon_Uses", x => new { x.SaleID, x.CouponID });
                });

            migrationBuilder.CreateTable(
                name: "Coupon_Ways",
                columns: table => new
                {
                    Coupon_WayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupon_Way = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon_Ways", x => x.Coupon_WayID);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupon_Key = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Coupon_Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Coupon_Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Coupon_WayID = table.Column<int>(type: "int", nullable: false),
                    Amount_Achieved = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Issued_Amount = table.Column<int>(type: "int", nullable: true),
                    Issued_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isIssued = table.Column<bool>(type: "bit", nullable: false),
                    Received_Amount = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponID);
                    table.ForeignKey(
                        name: "FK_Coupons_Coupon_Ways_Coupon_WayID",
                        column: x => x.Coupon_WayID,
                        principalTable: "Coupon_Ways",
                        principalColumn: "Coupon_WayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Options",
                columns: table => new
                {
                    Delivery_OptionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_Option = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Delivery_PlaceID = table.Column<int>(type: "int", nullable: false),
                    Delivery_Cost = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Options", x => x.Delivery_OptionsID);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Places",
                columns: table => new
                {
                    Delivery_PlaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_Place = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Places", x => x.Delivery_PlaceID);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "Href_Coordinations",
                columns: table => new
                {
                    Href_CoordinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileID = table.Column<int>(type: "int", nullable: false),
                    Top = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true, comment: "CSS:Position Top"),
                    Right = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true, comment: "CSS:Position Right"),
                    Bottom = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true, comment: "CSS:Position Bottom"),
                    Left = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true, comment: "CSS:Position Left"),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Href_Coordinations", x => x.Href_CoordinationID);
                    table.ForeignKey(
                        name: "FK_Href_Coordinations_Files_FileID",
                        column: x => x.FileID,
                        principalTable: "Files",
                        principalColumn: "FileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commodity_SizeID = table.Column<int>(type: "int", nullable: false),
                    Increase_Decrease = table.Column<bool>(type: "bit", nullable: false),
                    SaleID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Total_Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_Commodity_Sizes_Commodity_SizeID",
                        column: x => x.Commodity_SizeID,
                        principalTable: "Commodity_Sizes",
                        principalColumn: "Commodity_SizesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like_Commodities",
                columns: table => new
                {
                    Like_CommodityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    Add_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like_Commodities", x => x.Like_CommodityID);
                    table.ForeignKey(
                        name: "FK_Like_Commodities_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "CommodityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email_Address = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    LastSignin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Members_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    MenuUrl = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_Menus_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Menus_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Payments_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceID);
                    table.ForeignKey(
                        name: "FK_Prices_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Prices_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Received_Coupons",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    CouponID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Received_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Received_Coupons", x => new { x.MemberID, x.CouponID });
                    table.ForeignKey(
                        name: "FK_Received_Coupons_Coupons_CouponID",
                        column: x => x.CouponID,
                        principalTable: "Coupons",
                        principalColumn: "CouponID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Received_Coupons_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Received_Coupons_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Received_Coupons_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Recently_Viewed",
                columns: table => new
                {
                    Recently_ViewedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    Viewed_Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recently_Viewed", x => x.Recently_ViewedID);
                    table.ForeignKey(
                        name: "FK_Recently_Viewed_Commodities_CommodityID",
                        column: x => x.CommodityID,
                        principalTable: "Commodities",
                        principalColumn: "CommodityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recently_Viewed_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Recently_Viewed_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Recently_Viewed_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_Roles_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Roles_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Carts",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Commodity_SizeID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Carts", x => new { x.MemberID, x.Commodity_SizeID });
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Commodity_Sizes_Commodity_SizeID",
                        column: x => x.Commodity_SizeID,
                        principalTable: "Commodity_Sizes",
                        principalColumn: "Commodity_SizesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shop_Address = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Shop_Info = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopID);
                    table.ForeignKey(
                        name: "FK_Shops_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Shops_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commodity_KindsID = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                    table.ForeignKey(
                        name: "FK_Sizes_Commodity_Kinds_Commodity_KindsID",
                        column: x => x.Commodity_KindsID,
                        principalTable: "Commodity_Kinds",
                        principalColumn: "Commodity_KindID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sizes_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Sizes_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                    table.ForeignKey(
                        name: "FK_Status_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Status_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    SubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email_Address = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Sub_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.SubID);
                    table.ForeignKey(
                        name: "FK_Subscribes_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Subscribes_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commodity_KindsID = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_Tags_Commodity_Kinds_Commodity_KindsID",
                        column: x => x.Commodity_KindsID,
                        principalTable: "Commodity_Kinds",
                        principalColumn: "Commodity_KindID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Tags_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MenuID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    PageUrl = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => new { x.PageID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_Pages_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Pages_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Pages_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Discount_Total = table.Column<int>(type: "int", precision: 10, scale: 2, nullable: false),
                    Total_Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Delivery_optionID = table.Column<int>(type: "int", nullable: false),
                    Delivery_Cost = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    InVoice = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false),
                    isPayed = table.Column<bool>(type: "bit", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sales_Delivery_Options_Delivery_optionID",
                        column: x => x.Delivery_optionID,
                        principalTable: "Delivery_Options",
                        principalColumn: "Delivery_OptionsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Sales_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Sales_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales_items",
                columns: table => new
                {
                    SaleID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Commodity_SizeID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Unit_Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Total_Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_items", x => new { x.SaleID, x.Commodity_SizeID });
                    table.ForeignKey(
                        name: "FK_Sales_items_Commodity_Sizes_Commodity_SizeID",
                        column: x => x.Commodity_SizeID,
                        principalTable: "Commodity_Sizes",
                        principalColumn: "Commodity_SizesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_items_Members_Creator",
                        column: x => x.Creator,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Sales_items_Members_Modifier",
                        column: x => x.Modifier,
                        principalTable: "Members",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_Sales_items_Sales_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "SaleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_items_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Creator", "Modifier", "ModifyTime", "RoleName" },
                values: new object[] { 1, null, null, null, "管理者" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Creator", "Modifier", "ModifyTime", "RoleName" },
                values: new object[] { 2, null, null, null, "使用者" });

            migrationBuilder.CreateIndex(
                name: "IX_Action_Auths_Creator",
                table: "Action_Auths",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Action_Auths_Modifier",
                table: "Action_Auths",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Action_Auths_RoleID",
                table: "Action_Auths",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Contents_BlogID",
                table: "Blog_Contents",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Contents_Creator",
                table: "Blog_Contents",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Contents_Modifier",
                table: "Blog_Contents",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Hrefs_CommodityID",
                table: "Blog_Hrefs",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Hrefs_Creator",
                table: "Blog_Hrefs",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Hrefs_Modifier",
                table: "Blog_Hrefs",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Images_BlogID",
                table: "Blog_Images",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Images_Creator",
                table: "Blog_Images",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Images_Modifier",
                table: "Blog_Images",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Creator",
                table: "Blogs",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Modifier",
                table: "Blogs",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Creator",
                table: "Colors",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Modifier",
                table: "Colors",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_Creator",
                table: "Commodities",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Commodities_Modifier",
                table: "Commodities",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Images_CommodityID",
                table: "Commodity_Images",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Images_Creator",
                table: "Commodity_Images",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Images_Modifier",
                table: "Commodity_Images",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Kinds_Creator",
                table: "Commodity_Kinds",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Kinds_Modifier",
                table: "Commodity_Kinds",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Prices_CommodityID",
                table: "Commodity_Prices",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Prices_Creator",
                table: "Commodity_Prices",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Prices_Modifier",
                table: "Commodity_Prices",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Prices_PriceID",
                table: "Commodity_Prices",
                column: "PriceID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Sizes_ColorID",
                table: "Commodity_Sizes",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Sizes_CommodityID",
                table: "Commodity_Sizes",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Sizes_Creator",
                table: "Commodity_Sizes",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Sizes_Modifier",
                table: "Commodity_Sizes",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Sizes_SizeID",
                table: "Commodity_Sizes",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Tags_Creator",
                table: "Commodity_Tags",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Tags_Modifier",
                table: "Commodity_Tags",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_Tags_TagID",
                table: "Commodity_Tags",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Uses_CouponID",
                table: "Coupon_Uses",
                column: "CouponID");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Uses_Creator",
                table: "Coupon_Uses",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Uses_Modifier",
                table: "Coupon_Uses",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Ways_Creator",
                table: "Coupon_Ways",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Ways_Modifier",
                table: "Coupon_Ways",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Coupon_WayID",
                table: "Coupons",
                column: "Coupon_WayID");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Creator",
                table: "Coupons",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Modifier",
                table: "Coupons",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Options_Creator",
                table: "Delivery_Options",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Options_Delivery_PlaceID",
                table: "Delivery_Options",
                column: "Delivery_PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Options_Modifier",
                table: "Delivery_Options",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Places_Creator",
                table: "Delivery_Places",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Places_Modifier",
                table: "Delivery_Places",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Creator",
                table: "Files",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Modifier",
                table: "Files",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Href_Coordinations_Creator",
                table: "Href_Coordinations",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Href_Coordinations_FileID",
                table: "Href_Coordinations",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_Href_Coordinations_Modifier",
                table: "Href_Coordinations",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Commodity_SizeID",
                table: "Inventories",
                column: "Commodity_SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Creator",
                table: "Inventories",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Modifier",
                table: "Inventories",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SaleID",
                table: "Inventories",
                column: "SaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Commodities_CommodityID",
                table: "Like_Commodities",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Commodities_Creator",
                table: "Like_Commodities",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Commodities_MemberID",
                table: "Like_Commodities",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_Commodities_Modifier",
                table: "Like_Commodities",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Creator",
                table: "Members",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Modifier",
                table: "Members",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Members_RoleID",
                table: "Members",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Creator",
                table: "Menus",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Modifier",
                table: "Menus",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Creator",
                table: "Pages",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_MenuID",
                table: "Pages",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Modifier",
                table: "Pages",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Creator",
                table: "Payments",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Modifier",
                table: "Payments",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Creator",
                table: "Prices",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Modifier",
                table: "Prices",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Received_Coupons_CouponID",
                table: "Received_Coupons",
                column: "CouponID");

            migrationBuilder.CreateIndex(
                name: "IX_Received_Coupons_Creator",
                table: "Received_Coupons",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Received_Coupons_Modifier",
                table: "Received_Coupons",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Recently_Viewed_CommodityID",
                table: "Recently_Viewed",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Recently_Viewed_Creator",
                table: "Recently_Viewed",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Recently_Viewed_MemberID",
                table: "Recently_Viewed",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Recently_Viewed_Modifier",
                table: "Recently_Viewed",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Creator",
                table: "Roles",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Modifier",
                table: "Roles",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Creator",
                table: "Sales",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Delivery_optionID",
                table: "Sales",
                column: "Delivery_optionID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_MemberID",
                table: "Sales",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Modifier",
                table: "Sales",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PaymentID",
                table: "Sales",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_items_Commodity_SizeID",
                table: "Sales_items",
                column: "Commodity_SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_items_Creator",
                table: "Sales_items",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_items_Modifier",
                table: "Sales_items",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_items_StatusID",
                table: "Sales_items",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_Commodity_SizeID",
                table: "Shopping_Carts",
                column: "Commodity_SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_Creator",
                table: "Shopping_Carts",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_Modifier",
                table: "Shopping_Carts",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_Creator",
                table: "Shops",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_Modifier",
                table: "Shops",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Commodity_KindsID",
                table: "Sizes",
                column: "Commodity_KindsID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Creator",
                table: "Sizes",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Modifier",
                table: "Sizes",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Creator",
                table: "Status",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Modifier",
                table: "Status",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_Creator",
                table: "Subscribes",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_Modifier",
                table: "Subscribes",
                column: "Modifier");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Commodity_KindsID",
                table: "Tags",
                column: "Commodity_KindsID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Creator",
                table: "Tags",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Modifier",
                table: "Tags",
                column: "Modifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Auths_Members_Creator",
                table: "Action_Auths",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Auths_Members_Modifier",
                table: "Action_Auths",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Auths_Roles_RoleID",
                table: "Action_Auths",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Contents_Blogs_BlogID",
                table: "Blog_Contents",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Contents_Members_Creator",
                table: "Blog_Contents",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Contents_Members_Modifier",
                table: "Blog_Contents",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Hrefs_Blogs_BlogID",
                table: "Blog_Hrefs",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Hrefs_Commodities_CommodityID",
                table: "Blog_Hrefs",
                column: "CommodityID",
                principalTable: "Commodities",
                principalColumn: "CommodityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Hrefs_Members_Creator",
                table: "Blog_Hrefs",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Hrefs_Members_Modifier",
                table: "Blog_Hrefs",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Images_Blogs_BlogID",
                table: "Blog_Images",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Images_Members_Creator",
                table: "Blog_Images",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Images_Members_Modifier",
                table: "Blog_Images",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Members_Creator",
                table: "Blogs",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Members_Modifier",
                table: "Blogs",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Members_Creator",
                table: "Colors",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Members_Modifier",
                table: "Colors",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Members_Creator",
                table: "Commodities",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Members_Modifier",
                table: "Commodities",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Images_Members_Creator",
                table: "Commodity_Images",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Images_Members_Modifier",
                table: "Commodity_Images",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Kinds_Members_Creator",
                table: "Commodity_Kinds",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Kinds_Members_Modifier",
                table: "Commodity_Kinds",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Prices_Members_Creator",
                table: "Commodity_Prices",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Prices_Members_Modifier",
                table: "Commodity_Prices",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Prices_Prices_PriceID",
                table: "Commodity_Prices",
                column: "PriceID",
                principalTable: "Prices",
                principalColumn: "PriceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Sizes_Members_Creator",
                table: "Commodity_Sizes",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Sizes_Members_Modifier",
                table: "Commodity_Sizes",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Sizes_Sizes_SizeID",
                table: "Commodity_Sizes",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Tags_Members_Creator",
                table: "Commodity_Tags",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Tags_Members_Modifier",
                table: "Commodity_Tags",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Tags_Tags_TagID",
                table: "Commodity_Tags",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Uses_Coupons_CouponID",
                table: "Coupon_Uses",
                column: "CouponID",
                principalTable: "Coupons",
                principalColumn: "CouponID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Uses_Members_Creator",
                table: "Coupon_Uses",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Uses_Members_Modifier",
                table: "Coupon_Uses",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Uses_Sales_SaleID",
                table: "Coupon_Uses",
                column: "SaleID",
                principalTable: "Sales",
                principalColumn: "SaleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Ways_Members_Creator",
                table: "Coupon_Ways",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupon_Ways_Members_Modifier",
                table: "Coupon_Ways",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Members_Creator",
                table: "Coupons",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Members_Modifier",
                table: "Coupons",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Options_Delivery_Places_Delivery_PlaceID",
                table: "Delivery_Options",
                column: "Delivery_PlaceID",
                principalTable: "Delivery_Places",
                principalColumn: "Delivery_PlaceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Options_Members_Creator",
                table: "Delivery_Options",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Options_Members_Modifier",
                table: "Delivery_Options",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Places_Members_Creator",
                table: "Delivery_Places",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Places_Members_Modifier",
                table: "Delivery_Places",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Members_Creator",
                table: "Files",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Members_Modifier",
                table: "Files",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Href_Coordinations_Members_Creator",
                table: "Href_Coordinations",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Href_Coordinations_Members_Modifier",
                table: "Href_Coordinations",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Members_Creator",
                table: "Inventories",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Members_Modifier",
                table: "Inventories",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Sales_SaleID",
                table: "Inventories",
                column: "SaleID",
                principalTable: "Sales",
                principalColumn: "SaleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Commodities_Members_Creator",
                table: "Like_Commodities",
                column: "Creator",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Commodities_Members_MemberID",
                table: "Like_Commodities",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Commodities_Members_Modifier",
                table: "Like_Commodities",
                column: "Modifier",
                principalTable: "Members",
                principalColumn: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Roles_RoleID",
                table: "Members",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Members_Creator",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Members_Modifier",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Action_Auths");

            migrationBuilder.DropTable(
                name: "Blog_Contents");

            migrationBuilder.DropTable(
                name: "Blog_Hrefs");

            migrationBuilder.DropTable(
                name: "Blog_Images");

            migrationBuilder.DropTable(
                name: "Commodity_Images");

            migrationBuilder.DropTable(
                name: "Commodity_Prices");

            migrationBuilder.DropTable(
                name: "Commodity_Tags");

            migrationBuilder.DropTable(
                name: "Coupon_Uses");

            migrationBuilder.DropTable(
                name: "Href_Coordinations");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Like_Commodities");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Received_Coupons");

            migrationBuilder.DropTable(
                name: "Recently_Viewed");

            migrationBuilder.DropTable(
                name: "Sales_items");

            migrationBuilder.DropTable(
                name: "Shopping_Carts");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Commodity_Sizes");

            migrationBuilder.DropTable(
                name: "Coupon_Ways");

            migrationBuilder.DropTable(
                name: "Delivery_Options");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Commodities");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Delivery_Places");

            migrationBuilder.DropTable(
                name: "Commodity_Kinds");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
