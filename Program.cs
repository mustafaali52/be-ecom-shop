using be_ecom_shop.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddJsonOptions(options =>
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
//);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
    );

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "E-Commerce Shop",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce Shop");
            c.RoutePrefix = string.Empty;
        }
    );
}


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
