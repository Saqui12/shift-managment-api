using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HorariosDisponibilidads",
                keyColumn: "HorariosDisponibilidadId",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba51237"),
                column: "DiaSemana",
                value: "Wednesday");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HorariosDisponibilidads",
                keyColumn: "HorariosDisponibilidadId",
                keyValue: new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba51237"),
                column: "DiaSemana",
                value: "Wendesday");
        }
    }
}
