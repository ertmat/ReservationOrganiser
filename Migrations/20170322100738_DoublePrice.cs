using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationOrganiser.Migrations
{
    public partial class DoublePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePer",
                table: "Reservations");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "PricePer",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }
    }
}
