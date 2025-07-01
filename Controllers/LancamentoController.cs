using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Data.Interface;
using Prova.Models;

namespace Prova.Controllers;

[Route("api/lacamento")]
[ApiController]
[Authorize]
public class lancamentoController : ControllerBase
{
    private readonly ILancamentoRepository _lancamentoRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    public lancamentoController(ILancamentoRepository lancamentoRepository, IUsuarioRepository usuarioRepository,
        ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
        _lancamentoRepository = lancamentoRepository;
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Lancamento lancamento)
    {
        var Categoria = _categoriaRepository.BuscarCategoriaPorId(lancamento.CategoriaId);
        string? email = User.Identity?.Name;
        Usuario? Usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
        lancamento.categoria = Categoria;
        lancamento.usuario = Usuario;
        _lancamentoRepository.Cadastrar(lancamento);
        return Created("", lancamento);
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_lancamentoRepository.Listar());
    }
    [HttpGet("buscarlancamentoporid/{lancamentoId}")]
    public IActionResult BuscarlancamentoPorId(int lancamentoId)
    {
        return Ok(_lancamentoRepository.BuscarLancamentoPorId(lancamentoId));
    }
    [HttpPut("alterar/{lancamentoId}")]
public IActionResult AlterarLancamento(int lancamentoId, [FromBody] Lancamento lancamentoAlterado)
{
    Lancamento? lancamentoExistente = _lancamentoRepository.BuscarLancamentoPorId(lancamentoId);
    if (lancamentoExistente == null)
        return NotFound("Lançamento não encontrado.");

    string? email = User.Identity?.Name;
    Usuario? usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
    if (usuario == null)
        return Unauthorized("Usuário não encontrado.");

    // Atualiza os campos do lançamento existente
    lancamentoExistente.Valor = lancamentoAlterado.Valor;
    lancamentoExistente.CategoriaId = lancamentoAlterado.CategoriaId;
    lancamentoExistente.UsuarioId = usuario.UsuarioId; // Aqui está o ponto crítico

    _lancamentoRepository.Atualizar(lancamentoExistente);
    return Ok(lancamentoExistente);
}
    
    [HttpDelete("deletar/{lancamentoId}")]
    public IActionResult Deletar(int lancamentoId)
    {
        _lancamentoRepository.ExcluirLacamento(lancamentoId);
        return Ok();
    }

}

