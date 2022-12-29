using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_net_app.Migrations
{
    public partial class DNSModelsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DNSModel");

            migrationBuilder.CreateTable(
                name: "DNSRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNSRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DNSZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TTL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Refresh = table.Column<int>(type: "int", nullable: false),
                    Retry = table.Column<int>(type: "int", nullable: false),
                    Expire = table.Column<int>(type: "int", nullable: false),
                    MTTL = table.Column<int>(type: "int", nullable: false),
                    NS1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NS2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NS3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NS4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNSZones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DNSRecords");

            migrationBuilder.DropTable(
                name: "DNSZones");

            migrationBuilder.CreateTable(
                name: "DNSModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nameserver1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameserver2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameserver3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameserver4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOAHostmasterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOAPrimaryNameServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOASerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOATTEXPIRE = table.Column<int>(type: "int", nullable: false),
                    SOATTLIVE = table.Column<int>(type: "int", nullable: false),
                    SOATTREFRESH = table.Column<int>(type: "int", nullable: false),
                    SOATTRETRY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNSModel", x => x.Id);
                });
        }
    }
}
