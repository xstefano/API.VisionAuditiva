using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using API.VisionAuditiva.Interfaces;

namespace API.VisionAuditiva.Services
{
    public class CognitiveVisionService : ICognitiveVisionService
    {
        private readonly ComputerVisionClient _computerVision;
        private const string endpoint = "[endpoint]";
        private const string key = "[key]";

        public async Task<string> AnalyzeFromUrlAsync(string imageUrl)
        {
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
                VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Tags, VisualFeatureTypes.Adult,
                VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
                VisualFeatureTypes.Objects
            };
            ImageAnalysis analysis = await _computerVision.AnalyzeImageAsync(imageUrl, visualFeatures: features, language: "es");

            string? response = analysis.Description.Captions.FirstOrDefault()?.Text;

            if (response != null)
            {
                return response;
            }
            return "No se ha encontrado ninguna descripcion para la imagen";
        }

        public async Task<string> DescribeFromUrlAsync(string imageUrl)
        {
            ImageDescription descriptions = await _computerVision.DescribeImageAsync(imageUrl, language: "es");

            string? response = descriptions.Captions.FirstOrDefault()?.Text;

            if (response != null)
            {
                return response;
            }
            return "No se ha encontrado ninguna descripcion para la imagen";
        }

        public Task<string> DetectObjectsFromUrlAsync(string imageUrl)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadImageUrlAsync(string imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
