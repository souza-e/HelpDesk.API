using HelpDesk.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.API.Data;


public class HelpDeskDbContext : DbContext
{

// O construtor da classe HelpDeskDbContext recebe um objeto DbContextOptions como parâmetro,
//  que contém as opções de configuração para o contexto do banco de dados.
    public HelpDeskDbContext(DbContextOptions<HelpDeskDbContext> options)
           : base(options)
    {
        


    }

    
 public DbSet<Chamado> Chamados { get; set; }

}