using Microsoft.AspNetCore.Mvc;
using HelpDesk.API.Models;
using HelpDesk.API.Services;

namespace HelpDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : ControllerBase
{
    //A interface IEnumerable no C# serve para permitir que uma 
    // coleção de dados seja iterada (percorrida) usando um laço 

    private readonly ChamadosService _chamadosService;

    // O construtor da classe ChamadosController recebe uma instância do serviço ChamadosService como parâmetro.
    public ChamadosController(ChamadosService chamadosService)
    {
        _chamadosService = chamadosService;
    }

    [HttpGet]
    public IEnumerable<Chamado> Get()
    {

        return _chamadosService.GetAll();
    }

    [HttpGet("{id}")]
    public Chamado GetById(int id)
    {
        return _chamadosService.GetById(id);


    }

    [HttpPost]
    public Chamado Create(Chamado chamado)
    {


        return _chamadosService.Create(chamado);
    }

    [HttpPut("{id}")] //O put é usado para atualizar um recurso existente 
    public Chamado Update(int id, Chamado chamado)
    {
        return _chamadosService.Update(id, chamado);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {

        _chamadosService.Delete(id);
      
        return NoContent();
    }
}