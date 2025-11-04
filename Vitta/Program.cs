// Vitta/Program.cs
using Microsoft.EntityFrameworkCore;
using Vitta.Data; // Importar o DbContext
using Vitta.Models; // Importar a interface e o repositório
using Vitta.Services; // Importar o serviço

var builder = WebApplication.CreateBuilder(args);

// *** INÍCIO DAS CONFIGURAÇÕES ***

// 1. Registrar o DbContext
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
builder.Services.AddDbContext<VittaDbContext>(options =>
    options.UseOracle(connectionString)
);

// 2. Registrar a Injeção de Dependência (DI)
// "Quando alguém pedir um IUsuarioRepository, entregue uma instância de UsuarioRepository"
// Nota: Seu arquivo de interface está nomeado "IUsurarioRepository.cs".
// Renomeie o arquivo e a interface para "IUsuarioRepository.cs" para consistência.
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// "Quando alguém pedir um UsuarioService, entregue uma instância de UsuarioService"
builder.Services.AddScoped<UsuarioService>();

// *** FIM DAS CONFIGURAÇÕES ***

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();