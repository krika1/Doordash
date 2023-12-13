using Microsoft.EntityFrameworkCore.Migrations;

namespace Doordash.Data.Migrations
{
    public partial class ResolvingTheIsuue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Resturants_Id",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ResturantId",
                table: "Addresses",
                column: "ResturantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Resturants_ResturantId",
                table: "Addresses",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Resturants_ResturantId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ResturantId",
                table: "Addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Resturants_Id",
                table: "Addresses",
                column: "Id",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
