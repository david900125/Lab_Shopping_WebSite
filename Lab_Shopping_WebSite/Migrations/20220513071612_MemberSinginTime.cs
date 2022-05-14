using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_Shopping_WebSite.Migrations
{
    public partial class MemberSinginTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Tags",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Tags",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Subscribes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Subscribes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Status",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Status",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sizes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Shops",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Shops",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Shopping_Carts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Shopping_Carts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sales_items",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sales_items",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sales",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sales",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Recently_Viewed",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Recently_Viewed",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Received_Coupons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Received_Coupons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Prices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Prices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Pages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Pages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Members",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Members",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSignin",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Like_Commodities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Like_Commodities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Inventories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Inventories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Href_Coordinations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Href_Coordinations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Files",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Files",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Delivery_Places",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Delivery_Places",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Delivery_Options",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Delivery_Options",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Coupons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Coupons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Coupon_Ways",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Coupon_Ways",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Coupon_Uses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Coupon_Uses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Tags",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Tags",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Sizes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Sizes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Prices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Prices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Kinds",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Kinds",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Images",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Images",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodities",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blogs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blogs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blog_Images",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blog_Images",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blog_Hrefs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blog_Hrefs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blog_Contents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blog_Contents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Action_Auths",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Action_Auths",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1874), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1876), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1878), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1878) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1880), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1879) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 5,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1881), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 6,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1882), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1882) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 7,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1883), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 8,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1885), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1884) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 9,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1886), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1886) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 10,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1887), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1887) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 11,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1889), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 12,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1890), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1889) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 13,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1891), new DateTime(2022, 5, 13, 15, 16, 10, 780, DateTimeKind.Local).AddTicks(1891) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9186), new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9188), new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9192), new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9193), new DateTime(2022, 5, 13, 15, 16, 10, 756, DateTimeKind.Local).AddTicks(9192) });

            migrationBuilder.UpdateData(
                table: "Coupon_Ways",
                keyColumn: "Coupon_WayID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 919, DateTimeKind.Local).AddTicks(4200), new DateTime(2022, 5, 13, 15, 16, 10, 919, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Coupon_Ways",
                keyColumn: "Coupon_WayID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 919, DateTimeKind.Local).AddTicks(4211), new DateTime(2022, 5, 13, 15, 16, 10, 919, DateTimeKind.Local).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "Delivery_Options",
                keyColumn: "Delivery_OptionsID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 868, DateTimeKind.Local).AddTicks(7907), new DateTime(2022, 5, 13, 15, 16, 10, 868, DateTimeKind.Local).AddTicks(7912) });

            migrationBuilder.UpdateData(
                table: "Delivery_Options",
                keyColumn: "Delivery_OptionsID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 868, DateTimeKind.Local).AddTicks(7914), new DateTime(2022, 5, 13, 15, 16, 10, 868, DateTimeKind.Local).AddTicks(7914) });

            migrationBuilder.UpdateData(
                table: "Delivery_Options",
                keyColumn: "Delivery_OptionsID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 868, DateTimeKind.Local).AddTicks(7915), new DateTime(2022, 5, 13, 15, 16, 10, 868, DateTimeKind.Local).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "Delivery_Places",
                keyColumn: "Delivery_PlaceID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 861, DateTimeKind.Local).AddTicks(6748), new DateTime(2022, 5, 13, 15, 16, 10, 861, DateTimeKind.Local).AddTicks(6758) });

            migrationBuilder.UpdateData(
                table: "Delivery_Places",
                keyColumn: "Delivery_PlaceID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 861, DateTimeKind.Local).AddTicks(6764), new DateTime(2022, 5, 13, 15, 16, 10, 861, DateTimeKind.Local).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "Delivery_Places",
                keyColumn: "Delivery_PlaceID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 861, DateTimeKind.Local).AddTicks(6766), new DateTime(2022, 5, 13, 15, 16, 10, 861, DateTimeKind.Local).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 742, DateTimeKind.Local).AddTicks(2246), new DateTime(2022, 5, 13, 15, 16, 10, 742, DateTimeKind.Local).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime", "RoleID" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 742, DateTimeKind.Local).AddTicks(2248), new DateTime(2022, 5, 13, 15, 16, 10, 742, DateTimeKind.Local).AddTicks(2247), 2 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 875, DateTimeKind.Local).AddTicks(8984), new DateTime(2022, 5, 13, 15, 16, 10, 875, DateTimeKind.Local).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 875, DateTimeKind.Local).AddTicks(8990), new DateTime(2022, 5, 13, 15, 16, 10, 875, DateTimeKind.Local).AddTicks(8991) });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 749, DateTimeKind.Local).AddTicks(6865), new DateTime(2022, 5, 13, 15, 16, 10, 749, DateTimeKind.Local).AddTicks(6879) });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 749, DateTimeKind.Local).AddTicks(6881), new DateTime(2022, 5, 13, 15, 16, 10, 749, DateTimeKind.Local).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 749, DateTimeKind.Local).AddTicks(6883), new DateTime(2022, 5, 13, 15, 16, 10, 749, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9009), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9014) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9015), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9016) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9017), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9017) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9018), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9019) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 5,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9020), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 6,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9023), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 7,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9025), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 8,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9026), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9027) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 9,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9028), new DateTime(2022, 5, 13, 15, 16, 10, 772, DateTimeKind.Local).AddTicks(9028) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 882, DateTimeKind.Local).AddTicks(8231), new DateTime(2022, 5, 13, 15, 16, 10, 882, DateTimeKind.Local).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 882, DateTimeKind.Local).AddTicks(8232), new DateTime(2022, 5, 13, 15, 16, 10, 882, DateTimeKind.Local).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 882, DateTimeKind.Local).AddTicks(8233), new DateTime(2022, 5, 13, 15, 16, 10, 882, DateTimeKind.Local).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5934), new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5941), new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5942), new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5944), new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 5,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5945), new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5946) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 6,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5949), new DateTime(2022, 5, 13, 15, 16, 10, 765, DateTimeKind.Local).AddTicks(5955) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSignin",
                table: "Members");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Subscribes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Subscribes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Shopping_Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Shopping_Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sales_items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sales_items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Recently_Viewed",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Recently_Viewed",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Received_Coupons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Received_Coupons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Pages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Pages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Like_Commodities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Like_Commodities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Href_Coordinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Href_Coordinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Delivery_Places",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Delivery_Places",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Delivery_Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Delivery_Options",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Coupons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Coupons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Coupon_Ways",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Coupon_Ways",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Coupon_Uses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Coupon_Uses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Kinds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Kinds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodity_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodity_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Commodities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Commodities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blog_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blog_Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blog_Hrefs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blog_Hrefs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Blog_Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Blog_Contents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyTime",
                table: "Action_Auths",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Action_Auths",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2346), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2319) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2351), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2349) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2354), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2358), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2356) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 5,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2361), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2359) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 6,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2364), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 7,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2367), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 8,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2370), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2369) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 9,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2373), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 10,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2376), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2374) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 11,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2379), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2378) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 12,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2383), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2381) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 13,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2386), new DateTime(2022, 5, 11, 11, 7, 0, 8, DateTimeKind.Local).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5831), new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5836), new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5837), new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Commodity_Kinds",
                keyColumn: "Commodity_KindID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5839), new DateTime(2022, 5, 11, 11, 6, 59, 974, DateTimeKind.Local).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Coupon_Ways",
                keyColumn: "Coupon_WayID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 201, DateTimeKind.Local).AddTicks(7457), new DateTime(2022, 5, 11, 11, 7, 0, 201, DateTimeKind.Local).AddTicks(7469) });

            migrationBuilder.UpdateData(
                table: "Coupon_Ways",
                keyColumn: "Coupon_WayID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 201, DateTimeKind.Local).AddTicks(7472), new DateTime(2022, 5, 11, 11, 7, 0, 201, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Delivery_Options",
                keyColumn: "Delivery_OptionsID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 136, DateTimeKind.Local).AddTicks(3119), new DateTime(2022, 5, 11, 11, 7, 0, 136, DateTimeKind.Local).AddTicks(3135) });

            migrationBuilder.UpdateData(
                table: "Delivery_Options",
                keyColumn: "Delivery_OptionsID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 136, DateTimeKind.Local).AddTicks(3139), new DateTime(2022, 5, 11, 11, 7, 0, 136, DateTimeKind.Local).AddTicks(3139) });

            migrationBuilder.UpdateData(
                table: "Delivery_Options",
                keyColumn: "Delivery_OptionsID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 136, DateTimeKind.Local).AddTicks(3140), new DateTime(2022, 5, 11, 11, 7, 0, 136, DateTimeKind.Local).AddTicks(3141) });

            migrationBuilder.UpdateData(
                table: "Delivery_Places",
                keyColumn: "Delivery_PlaceID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 127, DateTimeKind.Local).AddTicks(5325), new DateTime(2022, 5, 11, 11, 7, 0, 127, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Delivery_Places",
                keyColumn: "Delivery_PlaceID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 127, DateTimeKind.Local).AddTicks(5342), new DateTime(2022, 5, 11, 11, 7, 0, 127, DateTimeKind.Local).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "Delivery_Places",
                keyColumn: "Delivery_PlaceID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 127, DateTimeKind.Local).AddTicks(5344), new DateTime(2022, 5, 11, 11, 7, 0, 127, DateTimeKind.Local).AddTicks(5345) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 955, DateTimeKind.Local).AddTicks(6628), new DateTime(2022, 5, 11, 11, 6, 59, 955, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime", "RoleID" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 955, DateTimeKind.Local).AddTicks(6640), new DateTime(2022, 5, 11, 11, 6, 59, 955, DateTimeKind.Local).AddTicks(6630), 1 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 144, DateTimeKind.Local).AddTicks(418), new DateTime(2022, 5, 11, 11, 7, 0, 144, DateTimeKind.Local).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 144, DateTimeKind.Local).AddTicks(428), new DateTime(2022, 5, 11, 11, 7, 0, 144, DateTimeKind.Local).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 965, DateTimeKind.Local).AddTicks(1448), new DateTime(2022, 5, 11, 11, 6, 59, 965, DateTimeKind.Local).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 965, DateTimeKind.Local).AddTicks(1462), new DateTime(2022, 5, 11, 11, 6, 59, 965, DateTimeKind.Local).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "PriceID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 965, DateTimeKind.Local).AddTicks(1463), new DateTime(2022, 5, 11, 11, 6, 59, 965, DateTimeKind.Local).AddTicks(1464) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6092), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6103) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6106), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6108), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6108) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6109), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 5,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6111), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6112) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 6,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6113), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 7,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6115), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 8,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6117), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 9,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6118), new DateTime(2022, 5, 11, 11, 6, 59, 995, DateTimeKind.Local).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 153, DateTimeKind.Local).AddTicks(3610), new DateTime(2022, 5, 11, 11, 7, 0, 153, DateTimeKind.Local).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 153, DateTimeKind.Local).AddTicks(3613), new DateTime(2022, 5, 11, 11, 7, 0, 153, DateTimeKind.Local).AddTicks(3613) });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "StatusID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 7, 0, 153, DateTimeKind.Local).AddTicks(3615), new DateTime(2022, 5, 11, 11, 7, 0, 153, DateTimeKind.Local).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 1,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(493), new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 2,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(509), new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 3,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(511), new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 4,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(513), new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 5,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(515), new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 6,
                columns: new[] { "CreateTime", "ModifyTime" },
                values: new object[] { new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(517), new DateTime(2022, 5, 11, 11, 6, 59, 986, DateTimeKind.Local).AddTicks(518) });
        }
    }
}
