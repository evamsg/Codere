using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codere.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id_key);
                });

            migrationBuilder.CreateTable(
                name: "ShowGenres",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Genre_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowGenres", x => x.Id_key);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    IdKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Runtime = table.Column<int>(type: "int", nullable: true),
                    AverageRuntime = table.Column<int>(type: "int", nullable: true),
                    Premiered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfficialSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<long>(type: "bigint", nullable: true),
                    Rating_Average = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.IdKey);
                    table.UniqueConstraint("AK_Shows_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DvdCountries",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DvdCountries", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_DvdCountries_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Externals",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Tvrage = table.Column<int>(type: "int", nullable: true),
                    Thetvdb = table.Column<int>(type: "int", nullable: true),
                    Imdb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Externals", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_Externals_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: true),
                    Medium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Original = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_Images_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: true),
                    Self_Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Previousepisode_Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Previousepisode_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_Links_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Id = table.Column<int>(type: "int", nullable: true),
                    OfficialSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_Networks_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreviousEpisodes",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousEpisodes", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_PreviousEpisodes_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Average = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_Ratings_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Show_Id = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_Schedules_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WebChannels",
                columns: table => new
                {
                    Id_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebChannels", x => x.Id_key);
                    table.ForeignKey(
                        name: "FK_WebChannels_Shows_Show_Id",
                        column: x => x.Show_Id,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DvdCountries_Show_Id",
                table: "DvdCountries",
                column: "Show_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Externals_Show_Id",
                table: "Externals",
                column: "Show_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_Show_Id",
                table: "Images",
                column: "Show_Id",
                unique: true,
                filter: "[Show_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Links_Show_Id",
                table: "Links",
                column: "Show_Id",
                unique: true,
                filter: "[Show_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_Show_Id",
                table: "Networks",
                column: "Show_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEpisodes_Show_Id",
                table: "PreviousEpisodes",
                column: "Show_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_Show_Id",
                table: "Ratings",
                column: "Show_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Show_Id",
                table: "Schedules",
                column: "Show_Id",
                unique: true,
                filter: "[Show_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WebChannels_Show_Id",
                table: "WebChannels",
                column: "Show_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DvdCountries");

            migrationBuilder.DropTable(
                name: "Externals");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "PreviousEpisodes");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ShowGenres");

            migrationBuilder.DropTable(
                name: "WebChannels");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
