using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    public partial class addImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "id",
                keyValue: new Guid("c930b61d-5734-4d68-9ce0-2990de87cd09"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "id",
                keyValue: new Guid("ea50e3db-07fc-426c-a2a8-b57b0e6edd4b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "id",
                keyValue: new Guid("ef1c17e1-6b37-4df5-9b38-82c4bcfa7692"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0daba18c-8b88-49d5-ac64-b79ad3454073"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1328ac8f-057c-4457-932d-1e5eab00bf20"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("47b83a8b-8e3d-4017-b2d7-7e4ed093fd94"));

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Walks",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileExtention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileSizeinBytes = table.Column<long>(type: "bigint", nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Walks",
                newName: "id");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { new Guid("c930b61d-5734-4d68-9ce0-2990de87cd09"), "medium" },
                    { new Guid("ea50e3db-07fc-426c-a2a8-b57b0e6edd4b"), "easy" },
                    { new Guid("ef1c17e1-6b37-4df5-9b38-82c4bcfa7692"), "hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0daba18c-8b88-49d5-ac64-b79ad3454073"), "ALK", "Al Khobar", "https://images.unsplash.com/photo-1642762890357-910e7be63d82?q=80&w=3015&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("1328ac8f-057c-4457-932d-1e5eab00bf20"), "JED", "Jeddah", "https://images.unsplash.com/photo-1642762890357-910e7be63d82?q=80&w=3015&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { new Guid("47b83a8b-8e3d-4017-b2d7-7e4ed093fd94"), "RUH", "Riyadh", "https://images.unsplash.com/photo-1642762890357-910e7be63d82?q=80&w=3015&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }
                });
        }
    }
}
