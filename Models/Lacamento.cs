namespace Prova.Models;
public class Lancamento
{
    public int LancamentoId { get; set; }
    public double Valor { get; set; }
    public Categoria? categoria { get; set; }
    public int CategoriaId { get; set; }
    public Usuario? usuario { get; set; }
    public int UsuarioId { get; set; }
}    