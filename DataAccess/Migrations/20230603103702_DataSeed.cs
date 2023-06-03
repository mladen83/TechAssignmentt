using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9684d77b-dc61-4911-9f36-0e0c6dfdd9ab"), "Heidel" },
                    { new Guid("e86fec12-5567-4dd6-82bd-7a9a0ebc9e9e"), "Arborstone" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), "Ring" },
                    { new Guid("f7651581-3f14-4f71-87c1-92d6f09de99c"), "Necklace" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new Guid("e86fec12-5567-4dd6-82bd-7a9a0ebc9e9e"), "Worst Customer" },
                    { new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new Guid("9684d77b-dc61-4911-9f36-0e0c6dfdd9ab"), "Best Customer" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "DateOfSale", "PricePerPiece", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0b6604ff-f9ac-46cb-88ba-5003d8c72cea"), new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new DateTime(2014, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 251.29m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 14 },
                    { new Guid("2d3d3114-f83b-4a0f-bbd9-9f73c93d9fea"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2016, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 526.30m, new Guid("f7651581-3f14-4f71-87c1-92d6f09de99c"), 7 },
                    { new Guid("2e56d544-0333-4e8a-be8f-def8b72e09e7"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2020, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 550.58m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 6 },
                    { new Guid("39559be8-1399-463b-b747-03163c798d23"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2015, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 444.97m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 19 },
                    { new Guid("3a988af4-1b73-4839-91e5-b62784b6e58a"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2012, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 405.57m, new Guid("f7651581-3f14-4f71-87c1-92d6f09de99c"), 11 },
                    { new Guid("3e2057d9-bb32-40f1-b20e-8bd507a84c2b"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 274.79m, new Guid("f7651581-3f14-4f71-87c1-92d6f09de99c"), 13 },
                    { new Guid("4614a97b-2b1d-4170-ba2d-3c74a7906183"), new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new DateTime(2011, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 564.02m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 17 },
                    { new Guid("5215e406-025d-42c9-a20e-64c7e12621db"), new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 197.67m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 6 },
                    { new Guid("5c6a6c6c-a70d-43c3-b57c-1c91f9c4381e"), new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new DateTime(2017, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 672.83m, new Guid("f7651581-3f14-4f71-87c1-92d6f09de99c"), 13 },
                    { new Guid("7a440841-e4a4-4423-aaae-e888940ac45f"), new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new DateTime(2013, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 524.40m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 16 },
                    { new Guid("ad2782f3-23c3-4b7f-a3d5-77efe7841113"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 291.44m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 12 },
                    { new Guid("c3136cc0-13ef-4af8-bd3b-a91214cc11d0"), new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"), new DateTime(2010, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 257.53m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 6 },
                    { new Guid("ca52000d-1b51-4522-8dd4-3b718d04157d"), new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"), new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 621.65m, new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"), 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("0b6604ff-f9ac-46cb-88ba-5003d8c72cea"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("2d3d3114-f83b-4a0f-bbd9-9f73c93d9fea"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("2e56d544-0333-4e8a-be8f-def8b72e09e7"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("39559be8-1399-463b-b747-03163c798d23"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("3a988af4-1b73-4839-91e5-b62784b6e58a"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("3e2057d9-bb32-40f1-b20e-8bd507a84c2b"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("4614a97b-2b1d-4170-ba2d-3c74a7906183"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("5215e406-025d-42c9-a20e-64c7e12621db"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("5c6a6c6c-a70d-43c3-b57c-1c91f9c4381e"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("7a440841-e4a4-4423-aaae-e888940ac45f"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("ad2782f3-23c3-4b7f-a3d5-77efe7841113"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("c3136cc0-13ef-4af8-bd3b-a91214cc11d0"));

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: new Guid("ca52000d-1b51-4522-8dd4-3b718d04157d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("10d480b9-cc6b-4bd9-9195-efed3592e67f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("24242eb1-e8d7-4a8e-af9a-667fdf37a752"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("750e95b2-ae10-4e48-9c65-adae23be5fb0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f7651581-3f14-4f71-87c1-92d6f09de99c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9684d77b-dc61-4911-9f36-0e0c6dfdd9ab"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e86fec12-5567-4dd6-82bd-7a9a0ebc9e9e"));
        }
    }
}
