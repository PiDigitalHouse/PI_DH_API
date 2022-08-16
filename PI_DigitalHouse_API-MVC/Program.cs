using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PI_DigitalHouse_API_MVC.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = @"Data Source = ME003391\SQLEXPRESS; Initial Catalog = MeuPet;Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "AL1",
        Title = "API FIND PET",
        Description = "API FIND PET / Cadastros de usuários, pets perdidos e achados. (Autenticação Pendente)",

        //License = new OpenApiLicense
        //{
        //    Name = "Licença",
        //    Url = new Uri("https://example.com/license")
        //}
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
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

app.UseAuthorization();

app.MapControllers();

app.Run();
