using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musicxd.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    artist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.artist_id);
                });

            migrationBuilder.CreateTable(
                name: "date",
                columns: table => new
                {
                    date_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_value = table.Column<DateTime>(type: "date", nullable: false),
                    decade = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    day = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_date", x => x.date_id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "studio",
                columns: table => new
                {
                    studio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studio_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studio", x => x.studio_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    album_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    album_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date_id = table.Column<int>(type: "integer", nullable: true),
                    country_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studio_id = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    album_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.album_id);
                    table.ForeignKey(
                        name: "FK_album_date_release_date_id",
                        column: x => x.release_date_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_album_studio_studio_id",
                        column: x => x.studio_id,
                        principalTable: "studio",
                        principalColumn: "studio_id");
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_joined_id = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.profile_id);
                    table.ForeignKey(
                        name: "FK_profile_date_date_joined_id",
                        column: x => x.date_joined_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_profile_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumArtist",
                columns: table => new
                {
                    AlbumsAlbumId = table.Column<int>(type: "integer", nullable: false),
                    ArtistsArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtist", x => new { x.AlbumsAlbumId, x.ArtistsArtistId });
                    table.ForeignKey(
                        name: "FK_AlbumArtist_album_AlbumsAlbumId",
                        column: x => x.AlbumsAlbumId,
                        principalTable: "album",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumArtist_artist_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "artist",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumGenre",
                columns: table => new
                {
                    AlbumsAlbumId = table.Column<int>(type: "integer", nullable: false),
                    GenresGenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenre", x => new { x.AlbumsAlbumId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_AlbumGenre_album_AlbumsAlbumId",
                        column: x => x.AlbumsAlbumId,
                        principalTable: "album",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumGenre_genre_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favourite_album_list",
                columns: table => new
                {
                    favourite_album_list_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profile_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favourite_album_list", x => x.favourite_album_list_id);
                    table.ForeignKey(
                        name: "FK_favourite_album_list_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profile",
                        principalColumn: "profile_id");
                });

            migrationBuilder.CreateTable(
                name: "list",
                columns: table => new
                {
                    list_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profile_id = table.Column<int>(type: "integer", nullable: false),
                    created_date_id = table.Column<int>(type: "integer", nullable: false),
                    updated_date_id = table.Column<int>(type: "integer", nullable: true),
                    list_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    list_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_list", x => x.list_id);
                    table.ForeignKey(
                        name: "FK_list_date_created_date_id",
                        column: x => x.created_date_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_list_date_updated_date_id",
                        column: x => x.updated_date_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_list_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profile",
                        principalColumn: "profile_id");
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profile_id = table.Column<int>(type: "integer", nullable: false),
                    album_id = table.Column<int>(type: "integer", nullable: false),
                    created_date_id = table.Column<int>(type: "integer", nullable: false),
                    updated_date_id = table.Column<int>(type: "integer", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_review_album_album_id",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "album_id");
                    table.ForeignKey(
                        name: "FK_review_date_created_date_id",
                        column: x => x.created_date_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_review_date_updated_date_id",
                        column: x => x.updated_date_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_review_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profile",
                        principalColumn: "profile_id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumFavouriteAlbumList",
                columns: table => new
                {
                    AlbumsAlbumId = table.Column<int>(type: "integer", nullable: false),
                    FavouriteAlbumListsFavouriteAlbumListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumFavouriteAlbumList", x => new { x.AlbumsAlbumId, x.FavouriteAlbumListsFavouriteAlbumListId });
                    table.ForeignKey(
                        name: "FK_AlbumFavouriteAlbumList_album_AlbumsAlbumId",
                        column: x => x.AlbumsAlbumId,
                        principalTable: "album",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumFavouriteAlbumList_favourite_album_list_FavouriteAlbumListsFavouriteAlbumListId",
                        column: x => x.FavouriteAlbumListsFavouriteAlbumListId,
                        principalTable: "favourite_album_list",
                        principalColumn: "favourite_album_list_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumList",
                columns: table => new
                {
                    AlbumsAlbumId = table.Column<int>(type: "integer", nullable: false),
                    ListsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumList", x => new { x.AlbumsAlbumId, x.ListsListId });
                    table.ForeignKey(
                        name: "FK_AlbumList_album_AlbumsAlbumId",
                        column: x => x.AlbumsAlbumId,
                        principalTable: "album",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumList_list_ListsListId",
                        column: x => x.ListsListId,
                        principalTable: "list",
                        principalColumn: "list_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    review_id = table.Column<int>(type: "integer", nullable: false),
                    profile_id = table.Column<int>(type: "integer", nullable: false),
                    comment_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comment_date_created_date_id",
                        column: x => x.created_date_id,
                        principalTable: "date",
                        principalColumn: "date_id");
                    table.ForeignKey(
                        name: "FK_comment_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profile",
                        principalColumn: "profile_id");
                    table.ForeignKey(
                        name: "FK_comment_review_review_id",
                        column: x => x.review_id,
                        principalTable: "review",
                        principalColumn: "review_id");
                });

            migrationBuilder.CreateTable(
                name: "like",
                columns: table => new
                {
                    like_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    review_id = table.Column<int>(type: "int", nullable: false),
                    profile_id = table.Column<int>(type: "int", nullable: false),
                    profile_id1 = table.Column<int>(type: "int", nullable: false),
                    review_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like", x => x.like_id);
                    table.ForeignKey(
                        name: "FK_like_profile_profile_id1",
                        column: x => x.profile_id1,
                        principalTable: "profile",
                        principalColumn: "profile_id");
                    table.ForeignKey(
                        name: "FK_like_review_review_id",
                        column: x => x.review_id,
                        principalTable: "review",
                        principalColumn: "review_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_album_release_date_id",
                table: "album",
                column: "release_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_album_studio_id",
                table: "album",
                column: "studio_id");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtist_ArtistsArtistId",
                table: "AlbumArtist",
                column: "ArtistsArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumFavouriteAlbumList_FavouriteAlbumListsFavouriteAlbumListId",
                table: "AlbumFavouriteAlbumList",
                column: "FavouriteAlbumListsFavouriteAlbumListId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenre_GenresGenreId",
                table: "AlbumGenre",
                column: "GenresGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumList_ListsListId",
                table: "AlbumList",
                column: "ListsListId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_created_date_id",
                table: "comment",
                column: "created_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_profile_id",
                table: "comment",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_review_id",
                table: "comment",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "IX_favourite_album_list_profile_id",
                table: "favourite_album_list",
                column: "profile_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_like_profile_id1",
                table: "like",
                column: "profile_id1");

            migrationBuilder.CreateIndex(
                name: "IX_like_review_id",
                table: "like",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "IX_list_created_date_id",
                table: "list",
                column: "created_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_list_profile_id",
                table: "list",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_list_updated_date_id",
                table: "list",
                column: "updated_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_profile_date_joined_id",
                table: "profile",
                column: "date_joined_id");

            migrationBuilder.CreateIndex(
                name: "IX_profile_user_id",
                table: "profile",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profile_username",
                table: "profile",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_album_id",
                table: "review",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_created_date_id",
                table: "review",
                column: "created_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_profile_id",
                table: "review",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_updated_date_id",
                table: "review",
                column: "updated_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "user",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtist");

            migrationBuilder.DropTable(
                name: "AlbumFavouriteAlbumList");

            migrationBuilder.DropTable(
                name: "AlbumGenre");

            migrationBuilder.DropTable(
                name: "AlbumList");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "like");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "favourite_album_list");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "list");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "studio");

            migrationBuilder.DropTable(
                name: "date");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
