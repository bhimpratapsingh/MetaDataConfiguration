using MetadataConfigurationAPI.Data;
using MetadataConfigurationAPI.Services;
using MetadataConfigurationAPI.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConfigurationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MetaDataConfigurationConnection")));

builder.Services.AddTransient<HttpClient>();
builder.Services.AddTransient<IEntityFieldConfigurationService, EntityFieldConfigurationService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
