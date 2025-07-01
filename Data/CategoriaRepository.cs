using Prova.Data.Interface;
using Prova.Models;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDataContext _context;
    public CategoriaRepository(AppDataContext context)
    {
        _context = context;
    }

    public Categoria BuscarCategoriaPorId(int id)
    {
        return _context.Categorias.Find(id);
    }

    public void Cadastrar(Categoria categeoria)
    {
        _context.Categorias.Add(categeoria);
        _context.SaveChanges();
    }

    public List<Categoria> Listar()
    {
        return _context.Categorias.ToList();
    }
    public void ExcluirCategoria(int Id)
    {
        Categoria? categoria = _context.Categorias.Find(Id);
        _context.Categorias.Remove(categoria);
        _context.SaveChanges();        
    }
}