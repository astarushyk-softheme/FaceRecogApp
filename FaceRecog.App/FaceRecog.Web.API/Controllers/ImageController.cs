using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaceRecog.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        public ImageController()
        {

        }

        // POST: api/image
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            return Ok();
        }
    }
}