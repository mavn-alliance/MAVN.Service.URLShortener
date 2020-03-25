using System.Threading.Tasks;

namespace Lykke.Service.UrlShortener.Domain.Services
{
    public interface IUrlShorteningService
    {
        Task<string> ShortenUrlAsync(string url);
    }
}
