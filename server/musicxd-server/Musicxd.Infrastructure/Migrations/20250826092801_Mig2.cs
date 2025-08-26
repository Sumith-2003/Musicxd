using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musicxd.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_album_date_release_date_id",
                table: "album");

            migrationBuilder.DropForeignKey(
                name: "FK_album_studio_studio_id",
                table: "album");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_date_created_date_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_date_date_joined_id",
                table: "profile");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_user_user_id",
                table: "profile");

            migrationBuilder.AddForeignKey(
                name: "FK_album_date_release_date_id",
                table: "album",
                column: "release_date_id",
                principalTable: "date",
                principalColumn: "date_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_album_studio_studio_id",
                table: "album",
                column: "studio_id",
                principalTable: "studio",
                principalColumn: "studio_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comment_date_created_date_id",
                table: "comment",
                column: "created_date_id",
                principalTable: "date",
                principalColumn: "date_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_date_date_joined_id",
                table: "profile",
                column: "date_joined_id",
                principalTable: "date",
                principalColumn: "date_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_user_user_id",
                table: "profile",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_album_date_release_date_id",
                table: "album");

            migrationBuilder.DropForeignKey(
                name: "FK_album_studio_studio_id",
                table: "album");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_date_created_date_id",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_date_date_joined_id",
                table: "profile");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_user_user_id",
                table: "profile");

            migrationBuilder.AddForeignKey(
                name: "FK_album_date_release_date_id",
                table: "album",
                column: "release_date_id",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_album_studio_studio_id",
                table: "album",
                column: "studio_id",
                principalTable: "studio",
                principalColumn: "studio_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_date_created_date_id",
                table: "comment",
                column: "created_date_id",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_profile_date_date_joined_id",
                table: "profile",
                column: "date_joined_id",
                principalTable: "date",
                principalColumn: "date_id");

            migrationBuilder.AddForeignKey(
                name: "FK_profile_user_user_id",
                table: "profile",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id");
        }
    }
}
