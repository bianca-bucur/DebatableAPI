using DebatableAPI.Models;
using DebatableAPI.Services;
using Microsoft.Extensions.Options;
using AutoMapper;
using DebatableAPI.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DebatableDatabaseSettings>(builder.Configuration.GetSection(nameof(DebatableDatabaseSettings)));

builder.Services.AddSingleton<IDebatableDatabaseSettings>(sp =>
  sp.GetRequiredService<IOptions<DebatableDatabaseSettings>>().Value);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//  .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => builder.Configuration.Bind("JwtSettings",options))
//  .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => builder.Configuration.Bind("CookieSettings",options));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var mappingConfig = new MapperConfiguration(mc =>
//{
//  mc.AddProfile(new UsersProfiles());
//});

//IMapper autoMapper = mappingConfig.CreateMapper();

//builder.Services.AddSingleton(autoMapper);

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
