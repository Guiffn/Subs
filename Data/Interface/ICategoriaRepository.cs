using System;
using Prova.Models;

namespace Prova.Data.Interface;

public interface ICategoriaRepository
{
    void Cadastrar(Categoria categeoria);
    Categoria BuscarCategoriaPorId(int id);
    List<Categoria> Listar();
    void ExcluirCategoria(int Id);
}
