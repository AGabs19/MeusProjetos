using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendasApp.DataBase;
using VendasApp.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

//Abaixo minha ligação com banco de dados
builder.Services.AddDbContext<VendasAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VendasApp") ?? throw new InvalidOperationException("Connection string 'VendasAppContext' not found."))); //.ToString()));
                                                                                                                                                                                                                                    //Conexão com Banco de Dados

//builder.Services.AddDbContext<VendasAppContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("VendasApp") ?? throw new InvalidOperationException("Connection string 'VendasAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<PopularService>();
builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<RegistroDeVendaService>();

var app = builder.Build();
var PopularService = new PopularService();
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions //Para trocar a Localização
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};
app.UseRequestLocalization(localizationOptions);
app.Services.CreateScope().ServiceProvider.GetRequiredService<PopularService>().Popular();
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    PopularService.Popular();
    //app.Services.CreateScope().ServiceProvider.GetRequiredService<PopularService>().Popular();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
   
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
