using HelpDesk.API.Services;
using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//injetando a dependência do HelpDeskDbContext no container de serviços da aplicação. Isso permite que o contexto do banco de dados seja resolvido
//  e injetado automaticamente em controladores ou outros serviços que precisem dele.
builder.Services.AddDbContext<HelpDeskDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//injetando a dependência do ChamadosService no container de serviços da aplicação. Isso permite que o serviço seja resolvido e injetado automaticamente em 
// controladores ou outros serviços que precisem dele.
builder.Services.AddScoped<ChamadosService>();

// Adiciona suporte a controladores (Controllers) na aplicação, permitindo que ela responda a solicitações HTTP e execute ações definidas nos controladores.
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            title = "Erro interno do servidor",
            status = 500,
            detail = "Ocorreu um erro inesperado."
        });
    });
});




app.UseAuthorization();

app.MapControllers();

app.Run();