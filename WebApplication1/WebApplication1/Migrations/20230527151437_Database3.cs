using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Database3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_Name",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Name",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d46aad8-cbf0-4726-bd4d-b2cac09ae270",
                column: "ConcurrencyStamp",
                value: "db487807-89e4-4415-bc76-8ffb445daa7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a31a09f7-df8e-4cdd-a2ec-fd5d88fdd080",
                column: "ConcurrencyStamp",
                value: "1b1043e2-dab9-4501-842e-b1e0fff21481");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d46aad8-cbf0-4726-bd4d-b2cac09ae270",
                column: "ConcurrencyStamp",
                value: "978ff5be-2d51-45a1-9cd1-cf742662e171");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a31a09f7-df8e-4cdd-a2ec-fd5d88fdd080",
                column: "ConcurrencyStamp",
                value: "428574b2-8290-4f05-81d2-88199071b474");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Name",
                table: "Contacts",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_Name",
                table: "Contacts",
                column: "Name",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
