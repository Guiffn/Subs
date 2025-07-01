using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lacamentos_Usuarioss_UsuarioId",
                table: "Lacamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarioss",
                table: "Usuarioss");

            migrationBuilder.RenameTable(
                name: "Usuarioss",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lacamentos_Usuarios_UsuarioId",
                table: "Lacamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lacamentos_Usuarios_UsuarioId",
                table: "Lacamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuarioss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarioss",
                table: "Usuarioss",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lacamentos_Usuarioss_UsuarioId",
                table: "Lacamentos",
                column: "UsuarioId",
                principalTable: "Usuarioss",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
