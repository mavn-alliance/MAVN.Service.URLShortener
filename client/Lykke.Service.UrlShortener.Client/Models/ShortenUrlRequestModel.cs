using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.UrlShortener.Client.Models
{
    /// <summary>
    /// Model containing info about the url to shorten
    /// </summary>
    public class ShortenUrlRequestModel
    {
        /// <summary>
        /// The url to shorten
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Url { get; set; }
    }
}
