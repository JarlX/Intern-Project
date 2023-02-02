using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId1",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogId1",
                table: "Blogs",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Blogs_BlogId1",
                table: "Blogs",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Blogs_BlogId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "Blogs");
        }
    }
}
