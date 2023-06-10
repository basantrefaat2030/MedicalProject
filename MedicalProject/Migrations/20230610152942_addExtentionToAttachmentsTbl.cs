using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalProject.Migrations
{
    public partial class addExtentionToAttachmentsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extention",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extention",
                table: "Attachments");
        }
    }
}
