using Microsoft.EntityFrameworkCore;
using AppContext = ExcelSF.DataBase.AppContext;
using System.Data.OleDb;
using System.Data;
using ExcelSF;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using ExcelSF.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<IPlanilhaExcel>()); 
builder.Services.AddDbContext<AppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ExcelSF")));
//Conexão com Banco de Dados
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => // O c é de Configuração
{
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "ImportExcel",
            Version = "v1",
            Description = "Importando uma planilha Excel para um Banco de Dados",
        });

    //string caminhoXmlDoc = Path.Combine("https://localhost:7144/swagger/v1/swagger.json", $"{"Ferias.xls"}.xml");
    //c.IncludeXmlComments(caminhoXmlDoc);
});

builder.Services.AddScoped<IPlanilhaExcel, PlanilhaExcel>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();