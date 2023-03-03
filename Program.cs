using Microsoft.Azure.Cosmos;
using WebApicosmosdb.Models;
using WebApicosmosdb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFamilyCosmosService>(options =>{
    string URL = builder.Configuration.GetSection("CosmosDBSettings")
        .GetValue<string>("URL");
    string PrimaryKey = builder.Configuration.GetSection("CosmosDBSettings")
        .GetValue<string>("PrimaryKey");
    string DataBaseName = builder.Configuration.GetSection("CosmosDBSettings")
        .GetValue<string>("DataBaseName");
    string ContainerName = builder.Configuration.GetSection("CosmosDBSettings")
        .GetValue<string>("ContainerName");
    var cosmosclient = new CosmosClient(URL, PrimaryKey);
    return new FamilyCosmosService(cosmosclient, DataBaseName, ContainerName);
});

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
