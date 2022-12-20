using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using WebUI.AuthService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", 
        builder => { 
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000");
        });
});

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options => {
        options.Authority = "https://dev-i1ukqqc3wcdbhyix.us.auth0.com/";
        options.Audience = "https://localhost:7231/";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
      "read:messages",
      policy => policy.Requirements.Add(
        new HasScopeRequirement("read:messages", "https://dev-i1ukqqc3wcdbhyix.us.auth0.com")
      )
    );
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName: "CORSPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
