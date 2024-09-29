using System.Reflection;
using System.Text;
using ELearningApi.Core;
using ELearningApi.Core.Base.MiddleWare;
using ELearningApi.Data.Entities;
using ELearningApi.Infrustructure;
using ELearningApi.Infrustructure.Context;
using ELearningApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder.Services, builder.Configuration);


var app = builder.Build();

// Configure middleware pipeline
ConfigureMiddleware(app);

app.Run();
return;



void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    // Enable XML comments
    services.AddControllers()
        .AddControllersAsServices();

    services.AddEndpointsApiExplorer();
    ConfigureSwagger(services);
    ConfigureIdentity(services);
    ConfigureJwtAuthentication(services, configuration);
    ConfigureDatabase(services, configuration);
    RegisterApplicationServices(services);
}
void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ELearningApi", Version = "v1" });

        // Enable XML comments (make sure to set the XML documentation file in project properties)
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        opt.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

        // Enable Annotations (for [FromBody], [FromQuery], etc.)
        opt.EnableAnnotations();

        // Add Authorization header
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. 
                            Enter 'Bearer' [space] and then your token in the text input below.
                            Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    });
}

void ConfigureIdentity(IServiceCollection services)
{
    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

}
void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
{
    var jwtSettings = configuration.GetSection("JWT");
    var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

    services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = JwtRegisteredClaimNames.Sub,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

    services.AddAuthorization();
}
void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
}

void RegisterApplicationServices(IServiceCollection services)
{
    services
        .AddServiceDependencies()
        .AddCoreDependencies()
        .AddInfrastructureDependencies();
}

void ConfigureMiddleware(WebApplication application)
{
    // Enable middleware to serve generated Swagger as a JSON endpoint and the Swagger UI
    application.UseSwagger();
    application.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ELearningApi");
            c.RoutePrefix = string.Empty;
            c.DisplayRequestDuration();
        }
    );
    application.UseMiddleware<ErrorHandlerMiddleware>();


    application.UseHttpsRedirection();
    application.UseRouting();
    application.UseAuthentication();
    application.UseAuthorization();
    application.MapControllers();
}


//        "DefaultConnection": "Data Source=abdalla\\SQLEXPRESS;Database=ELearningApiDB;Integrated Security=True;Trust Server Certificate=True"
//        "DefaultConnection": "Server=db8462.public.databaseasp.net; Database=db8462; User Id=db8462; Password=6q?LC5o%d=8X; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;"
