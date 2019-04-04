using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PingPongWebApplication.Migrations
{
    public partial class PingPongWebApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Age = table.Column<int>(nullable: true),
                    SkillLevel = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "Id", "Age", "CreatedOn", "Email", "FirstName", "LastName", "ModifiedOn", "SkillLevel" },
                values: new object[] { 1, 23, new DateTime(2019, 4, 3, 23, 59, 12, 289, DateTimeKind.Local), "cshah9925@gmail.com", "Chandni", "Shah", new DateTime(2019, 4, 3, 23, 59, 12, 291, DateTimeKind.Local), "Advanced" });

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "Id", "Age", "CreatedOn", "Email", "FirstName", "LastName", "ModifiedOn", "SkillLevel" },
                values: new object[] { 2, null, new DateTime(2019, 4, 3, 23, 59, 12, 291, DateTimeKind.Local), "jharsh23.hs@gmail.com", "Harsh", "Shah", new DateTime(2019, 4, 3, 23, 59, 12, 291, DateTimeKind.Local), "Beginner" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
