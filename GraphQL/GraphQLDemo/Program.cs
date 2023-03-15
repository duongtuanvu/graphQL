using GraphQLDemo;
using GraphQLDemo.Controllers;
using GraphQLDemo.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var signingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("MySuperSecretKey"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidIssuer = "https://auth.chillicream.com",
                ValidAudience = "https://graphql.chillicream.com",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey
            };
    });
builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType(q => q.Name("query"))
    .AddType<QueryType>().AddFiltering().AddSorting()
    .AddType<EmployeeType>()
    .AddMutationType<MutationType>()
    .AddErrorFilter<ErrorExtension>()
    .AddHttpRequestInterceptor<HttpRequestInterceptor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("<div> Hello World from the middleware 1 </div>");
//    await next.Invoke();
//    await context.Response.WriteAsync("<div> Returning from the middleware 1 </div>");
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("<div> Hello World from the middleware 2 </div>");
//    await next.Invoke();
//    await context.Response.WriteAsync("<div> Returning from the middleware 2 </div>");
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("<div> Hello World from the middleware 3 </div>");
//});

//app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.MapGraphQL("/graphql");
app.Run();
