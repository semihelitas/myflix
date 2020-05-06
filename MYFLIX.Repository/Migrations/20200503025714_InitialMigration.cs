using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MYFLIX.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Star = table.Column<string>(nullable: false),
                    WatchedDateTime = table.Column<DateTime>(nullable: false),
                    MyScore = table.Column<int>(nullable: false),
                    ImdbScore = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Star = table.Column<string>(nullable: false),
                    WatchedDateTime = table.Column<DateTime>(nullable: false),
                    CurrentSeason = table.Column<int>(nullable: false),
                    CurrentEpisode = table.Column<int>(nullable: false),
                    IsFinish = table.Column<bool>(nullable: false),
                    MyScore = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ImdbScore = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVSeries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TVSeries");
        }
    }
}
