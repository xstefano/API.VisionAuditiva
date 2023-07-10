using API.VisionAuditiva.Interfaces;
using API.VisionAuditiva.Models;
using Newtonsoft.Json;
using System.Text;

namespace API.VisionAuditiva.Services
{
    public class TranslatorService : ITranslatorService
    {
        public TranslatorService() { }

        public async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            string apiKey = "[apiKey]";
            string endpoint = "[endpoint]" + targetLanguage;

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", "eastus");
                request.Content = new StringContent("[{'Text':'" + text + "'}]", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.SendAsync(request);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var translationResponse = JsonConvert.DeserializeObject<List<TranslationResponse>>(jsonResponse);
                    string translatedText = translationResponse[0].Translations[0].Text;

                    return translatedText;
                }
                else
                {
                    return "Error al traducir el texto.";
                }
            }
        }
    }
}
