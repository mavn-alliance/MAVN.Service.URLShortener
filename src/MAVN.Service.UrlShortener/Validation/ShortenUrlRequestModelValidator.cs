using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Lykke.Service.UrlShortener.Client.Models;

namespace Lykke.Service.UrlShortener.Validation
{
    public class ShortenUrlRequestModelValidator : AbstractValidator<ShortenUrlRequestModel>
    {

        public ShortenUrlRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Url)
                .Must(LinkMustBeAUri)
                .WithMessage("Link '{PropertyValue}' must be a valid URI.");

        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            return Uri.TryCreate(link, UriKind.Absolute, out var outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
