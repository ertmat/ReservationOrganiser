using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationOrganiser.Migrations
{
    public partial class DoubleForReser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Deposit",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Deposit",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
