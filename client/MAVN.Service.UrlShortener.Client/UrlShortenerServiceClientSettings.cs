using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.UrlShortener.Client 
{
    /// <summary>
    /// UrlShortener client settings.
    /// </summary>
    public class UrlShortenerServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
