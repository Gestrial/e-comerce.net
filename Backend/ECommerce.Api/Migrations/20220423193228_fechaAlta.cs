using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComerce.Api.Migrations
{
    public partial class fechaAlta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Products",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Products");
        }
    }
}
