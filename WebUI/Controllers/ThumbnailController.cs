using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThumbnailController : ControllerBase
    {
        private readonly ILogger<ThumbnailController> _logger;
        private readonly IImageService _imageService;

        public ThumbnailController(ILogger<ThumbnailController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _imageService.GetImage(id);
            if(result is null)
            {
                return NotFound();
            }
            if(result.Status == (int)ImageStatus.COMPLETED)
            {
                return File(result.TumbnailImage, "image/jpeg");
            }
            return Ok(string.Format("Status: " + (ImageStatus)result.Status));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(Image image)
        {
            var result = await _imageService.AddImage(image);
            return Ok(result);
        }
    }
}