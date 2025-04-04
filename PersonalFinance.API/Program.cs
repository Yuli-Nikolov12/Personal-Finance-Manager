using Microsoft.EntityFrameworkCore;
using PersonalFinance.Business;
using PersonalFinance.DataAccess;
using PersonalFinance.DataAccess.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusiness();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonalFinanceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
