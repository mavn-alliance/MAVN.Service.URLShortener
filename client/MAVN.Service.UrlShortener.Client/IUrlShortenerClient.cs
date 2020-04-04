using JetBrains.Annotations;
using Lykke.Service.UrlShortener.Client.Api;

namespace Lykke.Service.UrlShortener.Client
{
    /// <summary>
    /// UrlShortener client interface.
    /// </summary>
    [PublicAPI]
    public interface IUrlShortenerClient
    {
        /// <summary>Application UrlShorteningApi interface</summary>
        IUrlShorteningApi UrlShorteningApi { get; }
    }
}
