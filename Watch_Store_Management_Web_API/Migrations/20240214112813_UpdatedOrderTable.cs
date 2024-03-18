using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Watch_Store_Management_Web_API.Migrations
{
    public partial class UpdatedOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
