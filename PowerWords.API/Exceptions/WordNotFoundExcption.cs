namespace PowerWords.API.Exceptions
{
    public class WordNotFoundExcption : ApplicationException
    {
        public WordNotFoundExcption(string? message) : base(message)
        {
        }
    }
}
