using ListaTasks.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ListaTasks.Data;

var builder = WebApplication.CreateBuilder(args);

// Isso define a URL base da API para chamadas HTTP.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7229/") });


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configuração da DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
