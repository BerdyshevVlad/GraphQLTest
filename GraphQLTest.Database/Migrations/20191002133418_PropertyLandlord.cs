using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLTest.Database.Migrations
{
    public partial class PropertyLandlord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LandlordId",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Properties");
        }
    }
}
