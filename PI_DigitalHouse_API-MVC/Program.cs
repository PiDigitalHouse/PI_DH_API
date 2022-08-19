using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PI_DigitalHouse_API_MVC;
using PI_DigitalHouse_API_MVC.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var chave = Encoding.ASCII.GetBytes(Ambiente.Chave);

// Add services to the container.

builder.Services
    .AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(chave),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "AL1",
        Title = "API FIND PET",
        Description = "API FIND PET / Cadastros de usuários, pets perdidos e achados. Autenticação.",

        //License = new OpenApiLicense
        //{
        //    Name = "Licença",
        //    Url = new Uri("https://example.com/license")
        //}
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var ConnectionString = @"Data Source = ME003391\SQLEXPRESS; Initial Catalog = MeuPet;Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
builder.Services.AddDbContext<MeuPetContext>(opt => opt.UseSqlServer(ConnectionString));
//builder.Services.AddDbContext<MeuPetContext>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

