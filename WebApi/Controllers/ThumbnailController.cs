using Application.Interfaces;
using Domain.Enums;
using Domain.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThumbnailController : ControllerBase
    {
        private readonly IThumbnailService _thumbnailService;
        private readonly IValidator<ThumbnailRequest> _validator;

        public ThumbnailController(IThumbnailService thumbnailService, IValidator<ThumbnailRequest> validator)
        {
            _thumbnailService = thumbnailService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _thumbnailService.GetThumbnail(id);
            if (result is null)
            {
                return NotFound();
            }
            if (result.Status == (int)ThumbnailStatus.COMPLETED)
            {
                return File(result.Content, "image/jpeg");
            }
            return Ok(new ThumbnailStatusResponse()
            {
                ThumbnailUid = result.ThumbnailUid,
                Status = ((ThumbnailStatus)result.Status).ToString(),
                ErrorMessage = result.ErrorMessage
            });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(ThumbnailRequest thumbnail)
        {
            var validationResult = await _validator.ValidateAsync(thumbnail);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _thumbnailService.AddThumbnail(thumbnail);
            return Ok(result);
        }
    }
}