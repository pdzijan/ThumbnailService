using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using WebApi.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddHostedService<BackgroundWorkerService>();
// Add services to the container.
builder.Services
    .RegisterServices();

// Add DbContext
builder.Services.AddDbContext<ThumbnailContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
