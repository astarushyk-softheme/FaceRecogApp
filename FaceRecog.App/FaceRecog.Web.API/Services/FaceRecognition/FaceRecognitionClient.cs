using System.Collections.Generic;
using System.Threading.Tasks;
using FaceRecog.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace FaceRecog.Web.API.Services.FaceRecognition
{
    public class FaceRecognitionClient : IFaceRecognitionClient
    {
        private readonly IFaceServiceClient _client;

        public FaceRecognitionClient(IOptions<ApiSettings> settings)
        {
            _client = new FaceServiceClient(settings.Value.SubscriptionKey, settings.Value.ApiRoot);
        }

        public async Task<Face[]> DetectAsync(IFormFile file, IEnumerable<FaceAttributeType> faceAttributes)
        {
            using (var fileStream = file.OpenReadStream())
            {
                var result = await _client.DetectAsync(fileStream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
                return result;
            }
        }
    }
}
