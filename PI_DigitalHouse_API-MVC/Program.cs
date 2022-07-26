using Microsoft.EntityFrameworkCore;
using PI_DigitalHouse_API_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = @"Data Source = ME003391\SQLEXPRESS; Initial Catalog = MeuPet;Integrated Security = True; Connect Timeout = 30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
