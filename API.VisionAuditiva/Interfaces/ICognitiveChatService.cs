namespace API.VisionAuditiva.Interfaces
{
    public interface ICognitiveChatService
    {
        public Task<string> getResponse(string request);
    }
}
