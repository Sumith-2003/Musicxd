using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musicxd.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modification4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_list_date_DateId",
                table: "list");

            migrationBuilder.DropForeignKey(
                name: "FK_list_date_DateId1",
                table: "list");

            migrationBuilder.DropForeignKey(
                name: "FK_review_date_DateId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_date_DateId1",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_review_DateId",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_review_DateId1",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_list_DateId",
                table: "list");

            migrationBuilder.DropIndex(
                name: "IX_list_DateId1",
                table: "list");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "review");

            migrationBuilder.DropColumn(
                name: "DateId1",
                table: "review");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "list");

            migrationBuilder.DropColumn(
                name: "DateId1",
                table: "list");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "review",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateId1",
                table: "review",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "list",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateId1",
                table: "list",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_DateId",
                table: "review",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_review_DateId1",
                table: "review",
                column: "DateId1");

            migrationBuilder.CreateIndex(
                name: "IX_list_DateId",
                table: "list",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_list_DateId1",
                table: "list",
                column: "DateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_list_date_DateId",
                table: "list",
                column: "DateId",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_list_date_DateId1",
                table: "list",
                column: "DateId1",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_date_DateId",
                table: "review",
                column: "DateId",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_date_DateId1",
                table: "review",
                column: "DateId1",
                principalTable: "date",
                principalColumn: "date_id");
        }
    }
}
