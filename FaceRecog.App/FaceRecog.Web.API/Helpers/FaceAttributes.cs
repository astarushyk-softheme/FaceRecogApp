using System.Collections.Generic;
using Microsoft.ProjectOxford.Face;

namespace FaceRecog.Web.API.Helpers
{
    public static class FaceAttributes
    {
        public static IEnumerable<FaceAttributeType> BaseAttributes => new[]
        {
            FaceAttributeType.Gender,
            FaceAttributeType.Age,
            FaceAttributeType.Smile,
            FaceAttributeType.Glasses,
            FaceAttributeType.FacialHair,
            FaceAttributeType.HeadPose
        };
    }
}
