using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.UrlShortener.Client.Models;
using Refit;

namespace Lykke.Service.UrlShortener.Client.Api
{
    /// <summary>
    /// UrlShortener UrlShortening client API interface.
    /// </summary>
    [PublicAPI]
    public interface IUrlShorteningApi
    {
        /// <summary>
        /// Used to shorten a url
        /// </summary>
        /// <param name="model">Information about the url to shorten</param>
        /// <returns>Shortened url</returns>
        [Post("/api/urlShortening/longUrls")]
        Task<ShortenUrlResponseModel> ShortenUrlAsync(ShortenUrlRequestModel model);
    }
}
