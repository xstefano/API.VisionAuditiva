using API.VisionAuditiva.Interfaces;
using Azure;
using Azure.AI.OpenAI;

namespace API.VisionAuditiva.Services
{
    public class CognitiveChatService : ICognitiveChatService
    {
        private const string endpoint = "[endpoint]";
        private const string key = "[key]";
        private readonly OpenAIClient _client;

        public CognitiveChatService()
        {
            _client = new(new Uri(endpoint), new AzureKeyCredential(key));
        }

        public async Task<string> getResponse(string request)
        {
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System, "Eres un asistente de ayuda para personas con discapacidad visual, " +
                    "darás información respecto a Peru si es que no se te especifica, darás respuestas cortas (si no se te especifica) como maximo 50 palabras, " +
                    "amables pero coherente. Tu nombre será Vision, tu aplicación se llama Vision Auditiva. Tu creador es Henry, un estudiante de la Universidad Privada del Norte"),
                    new ChatMessage(ChatRole.User, $"{request}"),
                },
                MaxTokens = 150
            };

            Response<ChatCompletions> response = _client.GetChatCompletions(
                deploymentOrModelName: "botsitoComunal",
                chatCompletionsOptions);

            return response.Value.Choices[0].Message.Content;
        }
    }
}
