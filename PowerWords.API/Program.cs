using PowerWords.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<WordService>();
builder.Services.AddScoped<WordService>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/", () => Results.Ok(new { message = "Funcionando!" }));

app.MapGet("/{word:alpha}", async (string word) =>
{
    var wordService = new WordService();

    return Results.Ok(await wordService.GetWordDescriptionAsync(word.ToLower()));
});

app.Run();
