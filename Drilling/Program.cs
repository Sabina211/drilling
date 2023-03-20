using Drilling.Infrastructure;
using Drilling.Infrastructure.Middlewares;
using Drilling.Infrastructure.Repositories;
using Drilling.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDrillBlockRepository, DrillBlockRepository>();
builder.Services.AddScoped<IHoleRepository, HoleRepository>();
builder.Services.AddScoped<IDrillBlockPointRepository, DrillBlockPointRepository>();
builder.Services.AddScoped<IHolePointRepository, HolePointRepository>();
builder.Services.AddScoped<IDrillBlockService, DrillBlockService>();
builder.Services.AddScoped<IHoleService, HoleService>();
builder.Services.AddScoped<IDrillBlockPointService, DrillBlockPointService>();
builder.Services.AddScoped<IHolePointService, HolePointService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Drilling", Version = "v1" });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "AppXml.xml");
    c.IncludeXmlComments(filePath);
});

builder.Services.AddDbContext<DrillingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DrillingDb"),
        x => x.MigrationsAssembly("Drilling.Infrastructure")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var s = scope.ServiceProvider;
    var c = s.GetRequiredService<DrillingContext>();
    await TestData.CreateDataAsync(c);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomExceptionFilter>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
