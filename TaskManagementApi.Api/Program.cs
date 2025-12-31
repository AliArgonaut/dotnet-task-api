using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Core.Interfaces;
using TaskManagementApi.Infrastructure.Data;
using TaskManagementApi.Infrastructure.Repositories;
using TaskManagementApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();


builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
        {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        } 
        );
    } 
);


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
