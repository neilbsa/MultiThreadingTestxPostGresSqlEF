using Microsoft.EntityFrameworkCore.Migrations;

namespace NetoCoreEFtoPostgres.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subsidiary",
                table: "Somethings",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subsidiary",
                table: "Somethings");
        }
    }
}
