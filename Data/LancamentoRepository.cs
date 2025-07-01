using Microsoft.EntityFrameworkCore;
using Prova.Data.Interface;
using Prova.Models;

public class LancamentoRepository : ILancamentoRepository
{
    private readonly AppDataContext _context;
    public LancamentoRepository(AppDataContext context)
    {
        _context = context;
    }

    public Lancamento? BuscarLancamentoPorId(int id)
    {
        return _context.Lacamentos.Find(id);
    }

    public void Cadastrar(Lancamento lancamento)
    {
        _context.Lacamentos.Add(lancamento);
        _context.SaveChanges();
    }

    public List<Lancamento> Listar()
    {
        return _context.Lacamentos.Include(x => x.categoria).ToList();
    }
    public void Atualizar(Lancamento lancamento)
    {
        _context.Lacamentos.Update(lancamento);
        _context.SaveChanges();
    }
     public void ExcluirLacamento(int Id)
    {
        Lancamento? lancamento = _context.Lacamentos.Find(Id);
        _context.Lacamentos.Remove(lancamento);
        _context.SaveChanges();
    }

}