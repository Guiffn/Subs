using System;
using Prova.Models;

namespace Prova.Data.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    List<Usuario> Listar();
    Usuario? BuscarUsuarioPorEmailSenha(string email, string senha);
    Usuario? BuscarUsuarioPorEmail(string email);

}
