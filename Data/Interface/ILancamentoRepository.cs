using System;
using Prova.Models;

namespace Prova.Data.Interface;

public interface ILancamentoRepository
{

    List<Lancamento> Listar();
    Lancamento? BuscarLancamentoPorId(int id);
    void Cadastrar(Lancamento lancamento);
     void ExcluirLacamento(int Id);
    void Atualizar(Lancamento lancamento);


}
