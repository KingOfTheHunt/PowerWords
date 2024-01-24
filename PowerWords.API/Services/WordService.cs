using HtmlAgilityPack;
using PowerWords.API.Entities;

namespace PowerWords.API.Services;

public class WordService
{
    private HttpClient _httpClient;


    public WordService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://www.dicio.com.br/");
    }

    // Este método vai baixar o contéudo da página e vai extrair os
    // dados: palavra, classe gramatical, significados e a etimologia.
    public async Task<WordDescription> GetWordDescriptionAsync(string word)
    {
        var htmlContent = await _httpClient.GetStringAsync($"{_httpClient.BaseAddress}/{word}");

        var document = new HtmlDocument();
        document.LoadHtml(htmlContent);

        var paragraph = document.DocumentNode.SelectSingleNode("//p[@class='significado textonovo']");
        var meanings = new List<string>();

        if (paragraph is not null)
        {
            var spans = paragraph.SelectNodes(".//span");

            for (int i = 1; i < spans.Count - 1; i++)
            {
                if (spans[i].InnerText.StartsWith("[") && spans[i].InnerText.EndsWith("]"))
                    continue;

                meanings.Add(spans[i].InnerText);
            }

            return new WordDescription(
                    word,
                    spans[0].InnerText,
                    [.. meanings],
                    spans.LastOrDefault().InnerText
                );
        }

        return null;
    }
}
