using System.Threading.Tasks;
using FaceRecog.Web.API.Helpers;
using FaceRecog.Web.API.Services.FaceRecognition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.ProjectOxford.Face.Contract;
using FaceAttributes = FaceRecog.Web.API.Helpers.FaceAttributes;

namespace FaceRecog.Web.API.Controllers
{
    public class RecognitionController : BaseController
    {
        private readonly IFaceRecognitionClient _client;

        public RecognitionController(IFaceRecognitionClient client)
        {
            _client = client;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Face[]), 200)]
        [ProducesResponseType(typeof(ModelStateDictionary), 400)]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _client.DetectAsync(file, FaceAttributes.BaseAttributes);
            
            return Ok(result);
        }
    }
}