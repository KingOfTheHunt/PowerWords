using PowerWords.API.Exceptions;
using PowerWords.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<WordService>();
builder.Services.AddScoped<WordService>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/", () => Results.Ok(new { status = "Sucesso", data = "Funcionando!" }));

app.MapGet("/{word:alpha}", async (string word) =>
{
    try
    {
        var wordService = new WordService();
        var response = await wordService.GetWordDescriptionAsync(word.ToLower());

        if (response is not null)
            return Results.Ok(new { status = "Sucesso", data = response });

        return Results.NotFound(new { status = "Erro", data = "Não foi possível encontrar a palavra." });
    }
    catch (WordNotFoundExcption ex)
    {
        return Results.NotFound(new { status = "Erro", data = ex.Message });
    }
});

app.Run();
