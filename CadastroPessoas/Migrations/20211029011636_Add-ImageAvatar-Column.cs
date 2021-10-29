using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroPessoas.Migrations
{
    public partial class AddImageAvatarColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Pessoa",
                newName: "Cpf");

            migrationBuilder.AddColumn<string>(
                name: "ImgAvatar",
                table: "Pessoa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgAvatar",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Pessoa",
                newName: "CPF");
        }
    }
}
