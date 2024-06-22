using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracker.Core.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Init_temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_CreatedById",
                schema: "core",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "core",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                schema: "core",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "core",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "core",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_CreatedById",
                schema: "core",
                table: "Issues",
                column: "CreatedById",
                principalSchema: "core",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_CreatedById",
                schema: "core",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                schema: "core",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "core",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "core",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "core",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_CreatedById",
                schema: "core",
                table: "Issues",
                column: "CreatedById",
                principalSchema: "core",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
