using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagement.Migrations
{
    public partial class v2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb1CDisease",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1CDisease", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb1Patients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    diseaseName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb1Problems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    problemDescription = table.Column<string>(nullable: true),
                    patientid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Problems", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb1Problems_tb1Patients_patientid",
                        column: x => x.patientid,
                        principalTable: "tb1Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb1Problems_patientid",
                table: "tb1Problems",
                column: "patientid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb1CDisease");

            migrationBuilder.DropTable(
                name: "tb1Problems");

            migrationBuilder.DropTable(
                name: "tb1Patients");
        }
    }
}
