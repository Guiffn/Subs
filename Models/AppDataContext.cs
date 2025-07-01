namespace Prova.Models;
using Microsoft.EntityFrameworkCore;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Lancamento> Lacamentos { get; set; }
}