using DBContext;
using Doctor.DalEF;
using Microsoft.EntityFrameworkCore;
using Patient.Persister.Model;
using Patient.Persister.Persister;
using PatientConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DoctorDBContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=DoctorDB;User ID=myusername;Password=mypassword;"), optionsLifetime: ServiceLifetime.Singleton);

// Add services to the container.
builder.Services.AddDalEF();
builder.Services.AddModel();
builder.Services.AddPersister();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PatientDetailsHandler, PatientDetailsHandler>();
builder.Services.AddHostedService<PatientDetailsConsumer>();

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
