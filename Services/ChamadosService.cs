using HelpDesk.API.Models;

namespace HelpDesk.API.Services;


public class ChamadosService
{

    public IEnumerable<Chamado> GetAll()
    {

        return new List<Chamado>
        {
              new Chamado
              {


                  Id = 1,
                  Titulo = "Computador não liga",
                  Descricao = "O computador não está ligando.",
                  Status = "Aberto",
                  Prioridade = "Alta"
              }


        };
    }

    public Chamado GetById(int id)
    {

        return new Chamado
        {
            Id = id,
            Titulo = "Computador não liga",
            Descricao = "O computador do setor financeiro não está ligando.",
            Status = "Aberto",
            Prioridade = "Alta"

        };
    }


    public Chamado Create(Chamado chamado)
    {

        return chamado;
    }
    public Chamado Update(int id, Chamado chamado)
    {
        chamado.Id = id;
        return chamado;

    }
    public void Delete(int id)
    {
        // Lógica para excluir o chamado com o ID fornecido
    }


}