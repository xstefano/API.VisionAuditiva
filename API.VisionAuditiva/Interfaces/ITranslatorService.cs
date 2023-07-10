namespace API.VisionAuditiva.Interfaces
{
    public interface ITranslatorService
    {
        Task<string> TranslateTextAsync(string text, string targetLanguage);
    }
}
