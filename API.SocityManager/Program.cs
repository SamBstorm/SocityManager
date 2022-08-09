using Common.SocityManager.Repositories;
using D = DAL.SocityManager;
using B = BLL.SocityManager;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository<D.Entities.User>, D.Services.UserService>();
builder.Services.AddScoped<IUserRepository<B.Entities.User>, B.Services.UserService>();
builder.Services.AddScoped<IBuildingRepository<D.Entities.Building>, D.Services.BuildingService>();
builder.Services.AddScoped<IBuildingRepository<B.Entities.Building>, B.Services.BuildingService>();
builder.Services.AddScoped<ILocalRepository<D.Entities.Local>, D.Services.LocalService>();
builder.Services.AddScoped<ILocalRepository<B.Entities.Local>, B.Services.LocalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();