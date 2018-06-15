using FaceRecog.Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.ProjectOxford.Face;

namespace FaceRecog.Web.API.Services.FaceRecognition
{
    public class FaceRecognitionClient : IFaceRecognitionClient
    {
        private readonly IFaceServiceClient _client;

        public FaceRecognitionClient(IOptions<ApiSettings> settings)
        {
            _client = new FaceServiceClient(settings.Value.SubscriptionKey, settings.Value.ApiRoot);
        }
    }
}
