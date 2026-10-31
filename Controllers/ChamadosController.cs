using Microsoft.AspNetCore.Mvc;
using HelpDesk.API.Models;
using HelpDesk.API.Services;
using System.Collections.Generic;
using HelpDesk.API.DTOs;

namespace HelpDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : ControllerBase
{
    //A interface IEnumerable no C# serve para permitir que uma 
    // coleção de dados seja iterada (percorrida) usando um laço 
    #region Conf. Service
    private readonly ChamadosService _chamadosService;

    // O construtor da classe ChamadosController recebe uma instância do serviço ChamadosService como parâmetro.
    public ChamadosController(ChamadosService chamadosService)
    {
        _chamadosService = chamadosService;
    }
    #endregion






    #region CRUD 
    [HttpGet]
    public ActionResult<IEnumerable<ChamadoResponseDto>> Get()
    {

        var chamados = _chamadosService.GetAll();
        var resposta = chamados.Select(ParaResponseDto).ToList();

        return Ok(resposta);

    }

    [HttpGet("{id}")]
    public ActionResult<ChamadoResponseDto> GetById(int id)
    {
        var chamado = _chamadosService.GetById(id);
        if (chamado == null)
        {
            return NotFound();
        }

        return Ok(ParaResponseDto(chamado));
    }

    [HttpPost]
    public IActionResult Create(CriarChamadoDto dto)
    {
        var chamado = new Chamado
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            Status = dto.Status,
            Prioridade = dto.Prioridade
        };

        var novoChamado = _chamadosService.Create(chamado);

        return CreatedAtAction(
            nameof(GetById),
            new { id = novoChamado.Id },
           ParaResponseDto(novoChamado));
    }

    [HttpPut("{id}")] //O put é usado para atualizar um recurso existente 
    public IActionResult Update(int id, AtualizarChamadoDto dto)
    {
        var chamado = new Chamado
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            Status = dto.Status,
            Prioridade = dto.Prioridade
        };
        var chamadoAtualizado = _chamadosService.Update(id, chamado);

        if (chamadoAtualizado == null)
        {

            return NotFound();
        }

        return Ok(ParaResponseDto(chamadoAtualizado));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete( int id)
    {
        var deleted = _chamadosService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }


        return NoContent();
    }

    #endregion


    private static ChamadoResponseDto ParaResponseDto(Chamado chamado)
    {
        return new ChamadoResponseDto
        {
            Id = chamado.Id,
            Titulo = chamado.Titulo,
            Descricao = chamado.Descricao,
            Status = chamado.Status,
            Prioridade = chamado.Prioridade
        };
    }
}