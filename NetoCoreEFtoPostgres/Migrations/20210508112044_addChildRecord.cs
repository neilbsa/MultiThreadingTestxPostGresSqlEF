using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetoCoreEFtoPostgres.Migrations
{
    public partial class addChildRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildSomethingModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    SampleDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Subsidiary = table.Column<string>(type: "text", nullable: true),
                    SomethingModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildSomethingModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildSomethingModel_Somethings_SomethingModelId",
                        column: x => x.SomethingModelId,
                        principalTable: "Somethings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildSomethingModel_SomethingModelId",
                table: "ChildSomethingModel",
                column: "SomethingModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildSomethingModel");
        }
    }
}
