namespace PowerWords.API.Entities;

public class WordDescription
{
    public string Word { get; set; } = string.Empty;
    public string GrammarClass { get; set; } = string.Empty;
    public List<string> Meanings { get; set; } = new();
    public string Etymology { get; set; } = string.Empty;

    public WordDescription(string word, string grammarClass, string[] meanings, string etymology)
    {
        Word = word;
        GrammarClass = grammarClass;
        Meanings.AddRange(meanings);
        Etymology = etymology;
    }
}
