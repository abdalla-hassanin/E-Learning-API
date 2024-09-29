using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ELearningApi.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43121e27-bbe7-46cf-973b-3844118929d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e686c3-180a-443d-97dc-0810ef3f7c27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3ffa2de-71d5-4edf-bd95-7c67179ed699");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1ad2d40-20ac-4dae-89ad-97ec78d29b3e", null, "Admin", "ADMIN" },
                    { "e194a71f-face-4864-9dd0-5f51cce75320", null, "Student", "STUDENT" },
                    { "f530511c-cd8a-4a9e-b079-c94638a5a86f", null, "Instructor", "Instructor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1ad2d40-20ac-4dae-89ad-97ec78d29b3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e194a71f-face-4864-9dd0-5f51cce75320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f530511c-cd8a-4a9e-b079-c94638a5a86f");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43121e27-bbe7-46cf-973b-3844118929d3", null, "Instructor", "Instructor" },
                    { "e3e686c3-180a-443d-97dc-0810ef3f7c27", null, "Student", "STUDENT" },
                    { "e3ffa2de-71d5-4edf-bd95-7c67179ed699", null, "Admin", "ADMIN" }
                });
        }
    }
}
