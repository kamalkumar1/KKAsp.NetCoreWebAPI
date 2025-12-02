using LearnProject.Data;
using LearnProject.Mapper;
using LearnProject.Repository.Region;
using LearnProject.Repository.Tokens;
using LearnProject.Repository.WalkRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Register Swagger generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Setup Db Connections
builder.Services.AddDbContext<KKWebAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("KKWebAPIConnectionStrings")));
builder.Services.AddDbContext<KKauthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("KKAuthConnectionStrings")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProjectMapperProfiles>());

builder.Services.AddScoped<ITokenRepositiory, TokenRepository>();

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("KKAuth")
    .AddEntityFrameworkStores<KKauthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    RoleClaimType = ClaimTypes.Role,
    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromHexString(builder.Configuration["Jwt:Key"]))

});
builder.Logging.AddConsole();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.RoutePrefix = "swagger";
    });
}
//app.UsePathBase("/api");

app.UseHttpsRedirection();


//add this setup app for autehntication to vlaidate the otp
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
