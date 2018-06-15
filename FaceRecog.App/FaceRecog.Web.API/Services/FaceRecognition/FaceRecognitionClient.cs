using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public async Task Test()
        {
            var filePath = @"D:\170705133020_1_540x360.jpg";

            IEnumerable<FaceAttributeType> faceAttributes =
                new []
                {
                    FaceAttributeType.Gender,
                    FaceAttributeType.Age,
                    FaceAttributeType.Smile,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.FacialHair,
                    FaceAttributeType.HeadPose
                };

            try
            {
                using (Stream imageFileStream = File.OpenRead(filePath))
                {
                    var faces = await _client.DetectAsync(imageFileStream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
                }
            }
            catch
            { }
        }

    }
}
