using Microsoft.EntityFrameworkCore;
using Projekt.Model;
using Projekt.Repository.Authors;
using Projekt.Repository.Books;
using Projekt.Repository.Publishers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IBookRepository,BookRepository>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
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
