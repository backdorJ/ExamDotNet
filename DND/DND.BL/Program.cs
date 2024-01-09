using DND.BL.Data;
using DND.BL.Services.BattleLogic;
using DND.BL.Services.Dice;
using DND.BL.Services.Logger;
using DND.Domain.BattleResultsDTO;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EfContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<BattleResult>();
builder.Services.AddScoped<IDbContext, EfContext>();
builder.Services.AddScoped<IBattleLogger, BattleLogger>();
builder.Services.AddScoped<IBattleLogic, BattleLogic>();
builder.Services.AddScoped<IDice, Dice>();

builder.Services.AddScoped<Migrator>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await migrator.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.Run();