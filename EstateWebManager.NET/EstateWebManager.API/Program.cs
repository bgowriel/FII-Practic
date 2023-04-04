using EstateWebManager.API;
using EstateWebManager.API.Services;
using EstateWebManager.Application.Abstractions;
using EstateWebManager.Application.Commands;
using EstateWebManager.DataAccess;
using EstateWebManager.DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EstateWebManager.Application;
using EstateWebManager.API.Middleware;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using EstateWebManager.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.Configuration;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISingletonService, CityRatingSingletonService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(provider =>
{
    var accessor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(absoluteUri);
});

var logger = new LoggerConfiguration().ReadFrom
                    .Configuration(builder.Configuration).Enrich
                    .FromLogContext()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
                    .WriteTo.Console()
                    .WriteTo.File($@"{Directory.GetCurrentDirectory()}\Logs\log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//--------------------
builder.Services.AddProblemDetails();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IFlatRepository, FlatRepository>();
builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
builder.Services.AddScoped<ILandRepository, LandRepository>();
builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

string connectionString = builder.Configuration.GetConnectionString("EstateWebManager");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));// (options =>
                                                 //options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

//----------------


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//--------------

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).
AddJwtBearer(options =>
{
    //options.SaveToken = true;
    //options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ContentEditor", policy => policy.RequireRole("admin"));
    /*options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireAgentRole", policy => policy.RequireRole("Agent"));
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));*/
});


builder.Services.AddMediatR(Assembly.GetAssembly(typeof(AssemblyMarker)));
builder.Services.AddAutoMapper(typeof(EstateWebManagerPresentation));

builder.Services.Configure<MyLocationSettings>(
    builder.Configuration.GetSection("Location"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseProblemDetails();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionMiddleware();

app.UseGlobalTraceMiddleware();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

//
app.UseDefaultFiles();
app.UseStaticFiles();
//

app.UseMostWantedCityMiddleware();

app.MapControllers();

app.Run();


