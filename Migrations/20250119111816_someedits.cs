using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceOrderManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class someedits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "AvailableQuantity");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderProducts",
                newName: "RequiredQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableQuantity",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "RequiredQuantity",
                table: "OrderProducts",
                newName: "Quantity");
        }
    }
}
