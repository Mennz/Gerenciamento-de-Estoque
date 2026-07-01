using Microsoft.EntityFrameworkCore;
using GerenciamentoEstoqueAPI.Core.Interfaces;
using GerenciamentoEstoqueAPI.Infrastructure.Data;
using GerenciamentoEstoqueAPI.Infrastructure.Repositories;
using GerenciamentoEstoqueAPI.Infrastructure.Notifications;
using GerenciamentoEstoqueAPI.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura o Banco de Dados em Memória
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EstoqueDatabase"));

// 2. Registra as Dependências (Injeção de Dependência)
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IAlertaServico, ConsoleAlertaServico>();
builder.Services.AddScoped<EstoqueServico>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();