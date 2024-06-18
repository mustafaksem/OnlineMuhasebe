using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebeServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class entity_updateddated_duzeltildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserAndCompanyRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoles",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoleAndUserRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoleAndRoleRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Companies",
                newName: "UpdatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserAndCompanyRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoles",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoleAndUserRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoleAndRoleRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Companies",
                newName: "UpdatedDate");
        }
    }
}
