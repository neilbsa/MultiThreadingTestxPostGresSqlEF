using Microsoft.EntityFrameworkCore.Migrations;

namespace NetoCoreEFtoPostgres.Migrations
{
    public partial class AddHeadModelinChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSomethingModel_Somethings_SomethingModelId",
                table: "ChildSomethingModel");

            migrationBuilder.RenameColumn(
                name: "SomethingModelId",
                table: "ChildSomethingModel",
                newName: "HeadModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildSomethingModel_SomethingModelId",
                table: "ChildSomethingModel",
                newName: "IX_ChildSomethingModel_HeadModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSomethingModel_Somethings_HeadModelId",
                table: "ChildSomethingModel",
                column: "HeadModelId",
                principalTable: "Somethings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSomethingModel_Somethings_HeadModelId",
                table: "ChildSomethingModel");

            migrationBuilder.RenameColumn(
                name: "HeadModelId",
                table: "ChildSomethingModel",
                newName: "SomethingModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildSomethingModel_HeadModelId",
                table: "ChildSomethingModel",
                newName: "IX_ChildSomethingModel_SomethingModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSomethingModel_Somethings_SomethingModelId",
                table: "ChildSomethingModel",
                column: "SomethingModelId",
                principalTable: "Somethings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
