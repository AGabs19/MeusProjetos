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
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using ExcelSF.DataBase;

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
            Title = "ExcelSF",
            Version = "v2",
            Description = "Importando uma planilha Excel para um Banco de Dados",
        });
});

builder.Services.AddScoped<IExcelService, ExcelService>();

var app = builder.Build();

var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions //Para trocar a localização e assim alterar o formato das minhas datas
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();