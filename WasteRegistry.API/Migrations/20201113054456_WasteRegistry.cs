using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WasteRegistry.API.Migrations
{
    public partial class WasteRegistry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteRegistryTB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WasteType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    WasteKind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WasteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteRegistryTB", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "FirstName", "LastName", "ModifiedDate", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 13, 8, 44, 56, 467, DateTimeKind.Local).AddTicks(6984), "Fredrick", "Schuppe", new DateTime(2020, 11, 13, 8, 44, 56, 469, DateTimeKind.Local).AddTicks(5060), "ksa3cwsf", "Fredrick.Schuppe" },
                    { 2, new DateTime(2020, 11, 13, 8, 44, 56, 467, DateTimeKind.Local).AddTicks(6984), "Isabel", "Pollich", new DateTime(2020, 11, 13, 8, 44, 56, 469, DateTimeKind.Local).AddTicks(5060), "uk1qcl2y", "Isabel62" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dummy", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "qwerty124", "DummyUser123" }
                });

            migrationBuilder.InsertData(
                table: "WasteRegistryTB",
                columns: new[] { "Id", "Content", "CreateDate", "ModifiedDate", "Month", "Quantity", "QuantityUnit", "RecipientCompany", "Store", "WasteDate", "WasteKind", "WasteType" },
                values: new object[,]
                {
                    { 1, "Voluptates labore laborum quisquam nihil ratione rem.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 3, 36, "Unit2", "Company2", "Store4", new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind1", "WasteType2" },
                    { 2, "Officia velit veniam quisquam vel quis et.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 6, 77, "Unit2", "Company1", "Store1", new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind2", "WasteType1" },
                    { 3, "Laboriosam aliquam libero quas debitis sed voluptatem.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 3, 52, "Unit2", "Company2", "Store3", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind1", "WasteType1" },
                    { 4, "Molestias magni dolorum deleniti et quis sit.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 1, 128, "Unit1", "Company2", "Store5", new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind2", "WasteType2" },
                    { 5, "Porro quae ut omnis et maxime quam.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 3, 183, "Unit1", "Company1", "Store3", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind1", "WasteType1" },
                    { 6, "Blanditiis sed sapiente officiis et commodi aut.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 3, 113, "Unit1", "Company2", "Store5", new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind2", "WasteType2" },
                    { 7, "Eligendi voluptates reiciendis nostrum autem sit autem.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 2, 53, "Unit2", "Company1", "Store4", new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind2", "WasteType1" },
                    { 8, "Ex omnis eos minima voluptates molestiae unde.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 4, 38, "Unit2", "Company1", "Store4", new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind1", "WasteType1" },
                    { 9, "Voluptatibus totam quis est voluptas ea tenetur.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 6, 94, "Unit2", "Company4", "Store1", new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind1", "WasteType2" },
                    { 10, "Expedita et molestiae sunt rerum blanditiis et.", new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1407), new DateTime(2020, 11, 13, 8, 44, 56, 511, DateTimeKind.Local).AddTicks(1620), 1, 64, "Unit2", "Company1", "Store1", new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "WasteKind2", "WasteType1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WasteRegistryTB");
        }
    }
}
