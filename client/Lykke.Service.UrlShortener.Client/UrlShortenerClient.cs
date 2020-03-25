using Lykke.HttpClientGenerator;
using Lykke.Service.UrlShortener.Client.Api;

namespace Lykke.Service.UrlShortener.Client
{
    /// <summary>
    /// UrlShortener API aggregating interface.
    /// </summary>
    public class UrlShortenerClient : IUrlShortenerClient
    {
        /// <summary>Inerface to UrlShortener UrlShorteningApi.</summary>
        public IUrlShorteningApi UrlShorteningApi { get; private set; }

        /// <summary>C-tor</summary>
        public UrlShortenerClient(IHttpClientGenerator httpClientGenerator)
        {
            UrlShorteningApi = httpClientGenerator.Generate<IUrlShorteningApi>();
        }
    }
}
