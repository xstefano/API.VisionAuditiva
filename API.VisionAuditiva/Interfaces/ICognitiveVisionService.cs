namespace API.VisionAuditiva.Interfaces
{
    public interface ICognitiveVisionService
    {
        public Task<string> AnalyzeFromUrlAsync(string imageUrl);
        public Task<string> DescribeFromUrlAsync(string imageUrl);
        public Task<string> ReadImageUrlAsync(string imageUrl);
        public Task<string> DetectObjectsFromUrlAsync(string imageUrl);
    }
}
