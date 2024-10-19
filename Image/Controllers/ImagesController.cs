using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImageContext _context;

        public ImagesController( ImageContext context )
        {
            _context = context;
        }
        [HttpPost("addImage")]
        public async Task<IActionResult> AddImage( [FromForm] ImageVM image )
        {
            using (var stream = new MemoryStream())
            {
                await image.Image.CopyToAsync(stream);
                var myImage = new Image()
                {
                    MyImage = stream.ToArray()
                };
                await _context.Images.AddAsync(myImage);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetImage()
        {
            var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == 2);
            return Ok(new
            {
                id = image.Id ,
                image = File(image.MyImage , "image/jpeg")
            });
            //return File(image.MyImage , "image/jpeg");
        }
    }
}
