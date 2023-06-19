using Newtonsoft.Json;
using Zadanie8.Mapper;
using Zadanie8.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MainDbContext>();
builder.Services.AddTransient<IMapDoctorToDTO,  MapDoctorToDTO>();
builder.Services.AddTransient<IMapPrescriptionToDTO, MapPrescriptionToDTO>();
// Add services to the container

builder.Services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
