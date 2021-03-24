using Microsoft.EntityFrameworkCore.Migrations;

namespace EindCasus.Migrations
{
    public partial class UniekeInstantie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CursusInstantie_StartDatum_CursusId",
                table: "CursusInstantie",
                columns: new[] { "StartDatum", "CursusId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CursusInstantie_StartDatum_CursusId",
                table: "CursusInstantie");
        }
    }
}
