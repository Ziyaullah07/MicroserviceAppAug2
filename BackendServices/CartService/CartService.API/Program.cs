

using CartService.Application.HttpClients;
using CartService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceRegistration.RegisterServices(builder.Services, builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddHttpClient<CatalogServiceClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiAddress:CatalogApi"]);
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
