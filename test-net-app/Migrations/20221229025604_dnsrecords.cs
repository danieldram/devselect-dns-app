using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_net_app.Migrations
{
    public partial class dnsrecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordClass",
                table: "DNSRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordData",
                table: "DNSRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordType",
                table: "DNSRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TTL",
                table: "DNSRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordClass",
                table: "DNSRecords");

            migrationBuilder.DropColumn(
                name: "RecordData",
                table: "DNSRecords");

            migrationBuilder.DropColumn(
                name: "RecordType",
                table: "DNSRecords");

            migrationBuilder.DropColumn(
                name: "TTL",
                table: "DNSRecords");
        }
    }
}
