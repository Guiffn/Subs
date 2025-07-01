using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Data.Interface;
using Prova.Models;

namespace Prova.Controllers;

[ApiController]
[Authorize]
[Route("api/categoria")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_categoriaRepository.Listar());
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Categoria categoria)
    {
        _categoriaRepository.Cadastrar(categoria);
        return Created("", categoria);
    }
    [HttpDelete("deletar/{categoriaId}")]
    public IActionResult Deletar(int categoriaId)
    {
        _categoriaRepository.ExcluirCategoria(categoriaId);
        return Ok();
    }
}

