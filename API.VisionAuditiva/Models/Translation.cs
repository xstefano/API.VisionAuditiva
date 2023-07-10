namespace API.VisionAuditiva.Models
{
    public class Translation
    {
        public string Text { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
    }

    public class TranslationResponse
    {
        public List<Translation> Translations { get; set; } = new List<Translation>();
    }
}
