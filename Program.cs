using az_sql_ad_auth.DAL; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdwContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ADW"));
});
var  _origins = "_origins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _origins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "http://www.contoso.com");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_origins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
