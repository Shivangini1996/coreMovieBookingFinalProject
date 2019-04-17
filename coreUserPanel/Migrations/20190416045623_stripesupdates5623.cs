using Microsoft.EntityFrameworkCore.Migrations;

namespace coreUserPanel.Migrations
{
    public partial class stripesupdates5623 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripePaymentId",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripeSettingsId",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripePaymentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "StripeSettingsId",
                table: "Payments");
        }
    }
}
