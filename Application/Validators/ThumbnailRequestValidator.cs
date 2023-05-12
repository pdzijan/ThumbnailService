using Domain.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class ThumbnailRequestValidator: AbstractValidator<ThumbnailRequest>
    {
        public ThumbnailRequestValidator()
        {
            RuleFor(o => o.Url).NotEmpty().Must(IsValidUrl).WithMessage("Url is not valid");
            RuleFor(o => o.SizeX).InclusiveBetween(0, 500).WithMessage("Max width is 500");
            RuleFor(o => o.SizeY).InclusiveBetween(0, 500).WithMessage("Max height is 500");
        }

        public bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
