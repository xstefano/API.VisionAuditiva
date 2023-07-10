﻿using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using API.VisionAuditiva.Interfaces;

namespace API.VisionAuditiva.Services
{
    public class CognitiveVisionService : ICognitiveVisionService
    {
        private readonly ComputerVisionClient _computerVision;
        private readonly TranslatorService _translatorService;
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

        public async Task<string> DetectObjectsFromUrlAsync(string imageUrl)
        {
            DetectResult analysis = await _computerVision.DetectObjectsAsync(imageUrl);
            Dictionary<string, int> objectCounts = new Dictionary<string, int>();

            foreach (var obj in analysis.Objects)
            {
                if (!objectCounts.ContainsKey(obj.ObjectProperty))
                {
                    objectCounts[obj.ObjectProperty] = 0;
                }

                objectCounts[obj.ObjectProperty]++;
            }

            if (objectCounts.Count > 0)
            {
                var translatedObjects = new List<string>();

                foreach (var kvp in objectCounts)
                {
                    string translatedObject = await _translatorService.TranslateTextAsync(kvp.Key, "es");
                    translatedObjects.Add($"{kvp.Value} {translatedObject}");
                }

                var objectString = string.Join(", ", translatedObjects);

                if (translatedObjects.Count > 1)
                {
                    var lastCommaIndex = objectString.LastIndexOf(",");
                    objectString = objectString.Substring(0, lastCommaIndex) + " y" + objectString.Substring(lastCommaIndex + 1);
                }

                return "Se han detectado los siguientes objetos: " + objectString;
            }
            else
            {
                return "En la imagen no se ha encontrado ningún objeto.";
            }
        }

        public Task<string> ReadImageUrlAsync(string imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
