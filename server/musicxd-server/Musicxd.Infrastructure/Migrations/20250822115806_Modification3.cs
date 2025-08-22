using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musicxd.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modification3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_date_UpdatedDateId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_profile_ProfileId1",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_review_ProfileId1",
                table: "review");

            migrationBuilder.DropColumn(
                name: "ProfileId1",
                table: "review");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateId",
                table: "review",
                newName: "updated_date_id");

            migrationBuilder.RenameIndex(
                name: "IX_review_UpdatedDateId",
                table: "review",
                newName: "IX_review_updated_date_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_review_DateId",
                table: "review",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_review_DateId1",
                table: "review",
                column: "DateId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_review_date_updated_date_id",
                table: "review",
                column: "updated_date_id",
                principalTable: "date",
                principalColumn: "date_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_review_date_DateId",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_date_DateId1",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_date_updated_date_id",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_review_DateId",
                table: "review");

            migrationBuilder.DropIndex(
                name: "IX_review_DateId1",
                table: "review");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "review");

            migrationBuilder.DropColumn(
                name: "DateId1",
                table: "review");

            migrationBuilder.RenameColumn(
                name: "updated_date_id",
                table: "review",
                newName: "UpdatedDateId");

            migrationBuilder.RenameIndex(
                name: "IX_review_updated_date_id",
                table: "review",
                newName: "IX_review_UpdatedDateId");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId1",
                table: "review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_ProfileId1",
                table: "review",
                column: "ProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_review_date_UpdatedDateId",
                table: "review",
                column: "UpdatedDateId",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_review_profile_ProfileId1",
                table: "review",
                column: "ProfileId1",
                principalTable: "profile",
                principalColumn: "profile_id");
        }
    }
}
