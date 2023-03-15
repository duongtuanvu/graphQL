using GraphiQl;
using GraphQLExam;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddGraphQLServer().AddQueryType<IService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseRouting();
//app.UseGraphiQl("/graphql");
//app.UseHttpsRedirection();
//app.MapControllers();
//app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapGraphQL());
app.Run();
