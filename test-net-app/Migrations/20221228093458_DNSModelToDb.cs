using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_net_app.Migrations
{
    public partial class DNSModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DNSModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOAPrimaryNameServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOAHostmasterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOASerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOATTREFRESH = table.Column<int>(type: "int", nullable: false),
                    SOATTRETRY = table.Column<int>(type: "int", nullable: false),
                    SOATTEXPIRE = table.Column<int>(type: "int", nullable: false),
                    SOATTLIVE = table.Column<int>(type: "int", nullable: false),
                    Nameserver1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameserver2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameserver3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameserver4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNSModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DNSModel");
        }
    }
}
