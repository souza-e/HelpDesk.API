using HelpDesk.API.Models;
using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;

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
    public async Task<List<Chamado>> GetAllAsync()
    {

        return await _context.Chamados.ToListAsync();

    }

    public async Task<Chamado?> GetByIdAsync(int id)
    {

        return await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
    }


    public async Task<Chamado> CreateAsync(Chamado chamado)
    {
        _context.Chamados.Add(chamado);
       await  _context.SaveChangesAsync();

        return (chamado);
    }
    public async Task<Chamado?> UpdateAsync(int id, Chamado chamado)
    {
        var chamadoExistente = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

        if (chamadoExistente == null)
        {
         
            return null;
        }

        // Atualiza os campos do chamado existente com os valores do chamado fornecido
        chamadoExistente.Titulo = chamado.Titulo;
        chamadoExistente.Descricao = chamado.Descricao;
        chamadoExistente.Status = chamado.Status;

        await _context.SaveChangesAsync();

        return chamadoExistente;

    }
    public async Task<bool> DeleteAsync(int id)
    {
        var chamado = await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);

        if (chamado == null)
        {
            return false;


        }
        _context.Chamados.Remove(chamado);
        await _context.SaveChangesAsync();
        return true;

    #endregion


    }
}