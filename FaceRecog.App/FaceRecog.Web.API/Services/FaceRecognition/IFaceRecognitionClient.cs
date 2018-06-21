using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace FaceRecog.Web.API.Services.FaceRecognition
{
    public interface IFaceRecognitionClient
    {
        Task<Face[]> DetectAsync(IFormFile file, IEnumerable<FaceAttributeType> faceAttributes);
    }
}
