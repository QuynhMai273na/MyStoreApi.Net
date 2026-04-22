
using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces;
using MyStore.Application.Services;
using MyStore.Infrastructure.Contexts;
using MyStore.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Kết nối DB Docker
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Đăng ký DI (Gắn Interface với Class thực thi)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyStore API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
