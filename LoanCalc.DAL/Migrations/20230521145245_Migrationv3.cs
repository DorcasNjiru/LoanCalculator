using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanCalc.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }
    }
}
