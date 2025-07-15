using Microsoft.AspNetCore.Mvc;
using UsersApi.MiddleWare;
using UsersApi.Repositories.Implementations;
using UsersApi.Repositories.Interfaces;
using UsersApi.Results.Implementations;
using UsersApi.Services.Implementations;
using UsersApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var messages = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage);
        var all = string.Join("; ", messages);

        var errorResult = new ErrorOperationResult(all);
        return new ObjectResult(errorResult)
        {
            StatusCode = StatusCodes.Status400BadRequest,
            ContentTypes = { "application/json" }
        };
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();