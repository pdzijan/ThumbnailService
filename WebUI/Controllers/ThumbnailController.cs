using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThumbnailController : ControllerBase
    {
        private readonly ILogger<ThumbnailController> _logger;
        private readonly IThumbnailService _thumbnailService;

        public ThumbnailController(ILogger<ThumbnailController> logger, IThumbnailService thumbnailService)
        {
            _logger = logger;
            _thumbnailService = thumbnailService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _thumbnailService.GetThumbnail(id);
            if(result is null)
            {
                return NotFound();
            }
            if(result.Status == (int)ThumbnailStatus.COMPLETED)
            {
                return File(result.Content, "image/jpeg");
            }
            return Ok(string.Format("Status: " + (ThumbnailStatus)result.Status));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(ThumbnailRequest thumbnail)
        {
            var result = await _thumbnailService.AddThumbnail(thumbnail);
            return Ok(result);
        }
    }
}