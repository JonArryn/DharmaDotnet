using DharmaServerDotnetApi.Database;
using DharmaServerDotnetApi.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddDbContext<DharmaDbContext>(
options => options.UseSqlServer( builder.Configuration.GetConnectionString( "Local" ) ) );

// Add services to the container.

builder.Services.AddControllers();

//TODO update swagger to show wrapped responses
// TODO eventually remove related data from examples when you introduce embeds
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddHelpers();

builder.Services.AddAutoMapper( typeof(AutoMapperConfig).Assembly );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();