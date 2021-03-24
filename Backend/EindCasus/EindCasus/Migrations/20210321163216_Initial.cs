﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EindCasus.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AchterNaam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duur = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BedrijfsMedewerker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BedrijfsNaam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Afdeling = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OfferteNummer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedrijfsMedewerker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BedrijfsMedewerker_Cursist_Id",
                        column: x => x.Id,
                        principalTable: "Cursist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Particulier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StraatNaam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HuisNummer = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    WoonPlaats = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RekeningNummer = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Particulier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Particulier_Cursist_Id",
                        column: x => x.Id,
                        principalTable: "Cursist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursusInstantie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CursusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursusInstantie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursusInstantie_Cursus_CursusId",
                        column: x => x.CursusId,
                        principalTable: "Cursus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursistCursusInstantie",
                columns: table => new
                {
                    CursistenId = table.Column<int>(type: "int", nullable: false),
                    CursusInstantiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursistCursusInstantie", x => new { x.CursistenId, x.CursusInstantiesId });
                    table.ForeignKey(
                        name: "FK_CursistCursusInstantie_Cursist_CursistenId",
                        column: x => x.CursistenId,
                        principalTable: "Cursist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursistCursusInstantie_CursusInstantie_CursusInstantiesId",
                        column: x => x.CursusInstantiesId,
                        principalTable: "CursusInstantie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursistCursusInstantie_CursusInstantiesId",
                table: "CursistCursusInstantie",
                column: "CursusInstantiesId");

            migrationBuilder.CreateIndex(
                name: "IX_CursusInstantie_CursusId",
                table: "CursusInstantie",
                column: "CursusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BedrijfsMedewerker");

            migrationBuilder.DropTable(
                name: "CursistCursusInstantie");

            migrationBuilder.DropTable(
                name: "Particulier");

            migrationBuilder.DropTable(
                name: "CursusInstantie");

            migrationBuilder.DropTable(
                name: "Cursist");

            migrationBuilder.DropTable(
                name: "Cursus");
        }
    }
}
