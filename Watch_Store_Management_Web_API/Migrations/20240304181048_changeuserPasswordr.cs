using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Watch_Store_Management_Web_API.Migrations
{
    public partial class changeuserPasswordr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
