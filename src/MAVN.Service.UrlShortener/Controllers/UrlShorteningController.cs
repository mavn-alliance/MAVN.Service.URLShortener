using System.Threading.Tasks;
using Lykke.Service.UrlShortener.Client.Api;
using Lykke.Service.UrlShortener.Client.Models;
using Lykke.Service.UrlShortener.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.UrlShortener.Controllers
{
    [ApiController]
    [Route("/api/urlShortening/")]
    public class UrlShorteningController : Controller, IUrlShorteningApi
    {
        private readonly IUrlShorteningService _urlShorteningService;

        public UrlShorteningController(IUrlShorteningService urlShorteningService)
        {
            _urlShorteningService = urlShorteningService;
        }

        /// <summary>
        /// Used to shorten a url
        /// </summary>
        /// <param name="model">Information about the url to shorten</param>
        /// <returns>Shortened url</returns>
        [HttpPost("longUrls")]
        public async Task<ShortenUrlResponseModel> ShortenUrlAsync(ShortenUrlRequestModel model)
        {
            var shortenedUrl = await _urlShorteningService.ShortenUrlAsync(model.Url);

            return new ShortenUrlResponseModel
            {
                ShortenedUrl = shortenedUrl
            };
        }
    }
}
