using Microsoft.AspNetCore.Mvc;
using HelpDesk.API.Models;

namespace HelpDesk.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : ControllerBase
{
    //A interface IEnumerable no C# serve para permitir que uma 
    // coleção de dados seja iterada (percorrida) usando um laço 

    [HttpGet]
    public IEnumerable<Chamado> Get()
    {


        return new List<Chamado>
        {
            new Chamado
            {
                Id = 1,
                Titulo = "Computodor não liga",
                Descricao = "O computador do setor financeiro não ta ligando",
                Status = "Aberto",
                Prioridade = "Alta"
            }

        };
    }

    [HttpGet("{id}")]
    public Chamado GetById(int id)
    {
        return new Chamado
        {
            Id = id,
            Titulo = "Computador não liga",
            Descricao = "O computador do setor financeiro não ta ligando",
            Status = "Aberto",
            Prioridade = "Alta"
        };


    }

    [HttpPost]
    public Chamado Create(Chamado chamado)
    {


        return chamado;
    }

    [HttpPut("{id}")]
    public Chamado Update(int id, Chamado chamado)
    {
        chamado.Id = id;
        return chamado;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
       
        return NoContent();
    }
}