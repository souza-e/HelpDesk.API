using HelpDesk.API.Models;
using HelpDesk.API.Data;

namespace HelpDesk.API.Services;


public class ChamadosService
{
    // o Readonly é usado para garantir que a variável _context não seja modificada após a sua inicialização no construtor da classe. Isso ajuda a manter a integridade do serviço e evita alterações acidentais no contexto do banco de dados durante a execução do serviço.
    private readonly HelpDeskDbContext _context;
    public ChamadosService(HelpDeskDbContext context)
    {
        _context = context;
    }


    #region Service Methods
    public IEnumerable<Chamado> GetAll()
    {

        return _context.Chamados.ToList();

    }

    public Chamado? GetById(int id)
    {

        return _context.Chamados.FirstOrDefault(c => c.Id == id);
    }


    public Chamado Create(Chamado chamado)
    {
        _context.Chamados.Add(chamado);
        _context.SaveChanges();

        return chamado;
    }
    public Chamado? Update(int id, Chamado chamado)
    {
        var chamadoExistente = _context.Chamados.FirstOrDefault(c => c.Id == id);

        if (chamadoExistente == null)
        {
            throw new Exception("Chamado não encontrado.");
        }

        // Atualiza os campos do chamado existente com os valores do chamado fornecido
        chamadoExistente.Titulo = chamado.Titulo;
        chamadoExistente.Descricao = chamado.Descricao;
        chamadoExistente.Status = chamado.Status;

        _context.SaveChanges();

        return chamadoExistente;

    }
    public bool Delete(int id)
    {
        var chamado = _context.Chamados.FirstOrDefault(c => c.Id == id);

        if (chamado == null)
        {
            return false;


        }
        _context.Chamados.Remove(chamado);
        _context.SaveChanges();
        return true;

    #endregion


    }
}