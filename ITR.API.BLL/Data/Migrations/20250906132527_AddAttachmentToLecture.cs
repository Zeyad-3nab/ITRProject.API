using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITR.API.BLL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAttachmentToLecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Lectures");
        }
    }
}
