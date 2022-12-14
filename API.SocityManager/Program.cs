using Common.SocityManager.Repositories;
using D = DAL.SocityManager;
using B = BLL.SocityManager;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((options) => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IUserRepository<D.Entities.User>, D.Services.UserService>();
builder.Services.AddScoped<IUserRepository<B.Entities.User>, B.Services.UserService>();
builder.Services.AddScoped<IBuildingRepository<D.Entities.Building>, D.Services.BuildingService>();
builder.Services.AddScoped<IBuildingRepository<B.Entities.Building>, B.Services.BuildingService>();
builder.Services.AddScoped<ILocalRepository<D.Entities.Local>, D.Services.LocalService>();
builder.Services.AddScoped<ILocalRepository<B.Entities.Local>, B.Services.LocalService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters() {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();