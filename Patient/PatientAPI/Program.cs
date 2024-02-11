using DBContext;
using Microsoft.EntityFrameworkCore;
using Patient.DalEF;
using Patient.Persister.Model;
using Patient.Persister.Persister;
using Patient.Producer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PatientDBContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=PatientDB;User ID=myusername;Password=mypassword;"));

// Add services to the container.
builder.Services.AddDalEF();
builder.Services.AddModel();
builder.Services.AddPersister();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PatientDetailsProducer>();
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
