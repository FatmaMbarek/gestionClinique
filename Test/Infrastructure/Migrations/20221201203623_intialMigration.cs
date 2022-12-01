using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class intialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chanbres",
                columns: table => new
                {
                    NumeroChambre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    typeChamber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chanbres", x => x.NumeroChambre);
                });

            migrationBuilder.CreateTable(
                name: "Cliniques",
                columns: table => new
                {
                    CliniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NumTel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliniques", x => x.CliniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    NumDossier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "date", nullable: false),
                    NumTel = table.Column<int>(type: "int", nullable: false),
                    nomCompletNom = table.Column<string>(name: "nomComplet_Nom", type: "nvarchar(max)", nullable: false),
                    nomCompletPrenom = table.Column<string>(name: "nomComplet_Prenom", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.NumDossier);
                });

            migrationBuilder.CreateTable(
                name: "ChambreClinique",
                columns: table => new
                {
                    ChanbresNumeroChambre = table.Column<int>(type: "int", nullable: false),
                    CliniquesCliniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChambreClinique", x => new { x.ChanbresNumeroChambre, x.CliniquesCliniqueId });
                    table.ForeignKey(
                        name: "FK_ChambreClinique_Chanbres_ChanbresNumeroChambre",
                        column: x => x.ChanbresNumeroChambre,
                        principalTable: "Chanbres",
                        principalColumn: "NumeroChambre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChambreClinique_Cliniques_CliniquesCliniqueId",
                        column: x => x.CliniquesCliniqueId,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    DateAdmission = table.Column<DateTime>(type: "date", nullable: false),
                    PatientsFk = table.Column<int>(type: "int", nullable: false),
                    ChambresFk = table.Column<int>(type: "int", nullable: false),
                    ModifAdmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbJours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => new { x.ChambresFk, x.PatientsFk, x.DateAdmission });
                    table.ForeignKey(
                        name: "FK_Admissions_Chanbres_ChambresFk",
                        column: x => x.ChambresFk,
                        principalTable: "Chanbres",
                        principalColumn: "NumeroChambre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientsFk",
                        column: x => x.PatientsFk,
                        principalTable: "Patients",
                        principalColumn: "NumDossier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientsFk",
                table: "Admissions",
                column: "PatientsFk");

            migrationBuilder.CreateIndex(
                name: "IX_ChambreClinique_CliniquesCliniqueId",
                table: "ChambreClinique",
                column: "CliniquesCliniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "ChambreClinique");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Chanbres");

            migrationBuilder.DropTable(
                name: "Cliniques");
        }
    }
}
