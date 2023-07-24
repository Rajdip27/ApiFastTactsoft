using ApiFastTactsoft.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//DataBaseConnation//
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1",
		new OpenApiInfo
		{
			Title = "Tactsoft Api Documentation v1",
			Version = "v1",
			Description = "This is a demo to see how documentation can easily be generated for ASP.NET Core Web APIs using Swagger and ReDoc.",
			Contact = new OpenApiContact
			{
				Name = "Santanu Chandra Shailay",
				Email = "Srajdip920@gmail.com"
			}
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
	app.UseSwaggerUI(options =>
	options.SwaggerEndpoint("/swagger/v1/swagger.json",
	"Tactsoft Api Documentation v1"));

	app.UseReDoc(options =>
	{
		options.DocumentTitle = "Tactsoft Api Documentation v1";
		options.SpecUrl = "/swagger/v1/swagger.json";
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
