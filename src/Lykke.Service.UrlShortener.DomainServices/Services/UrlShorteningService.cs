using System;
using System.Threading.Tasks;
using Common.Log;
using Google.Apis.FirebaseDynamicLinks.v1;
using Google.Apis.FirebaseDynamicLinks.v1.Data;
using Google.Apis.Services;
using Lykke.Common.Log;
using Lykke.Service.UrlShortener.Domain.Services;

namespace Lykke.Service.UrlShortener.DomainServices.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly ILog _log;
        private readonly IClientService _clientService;
        private readonly string _domainUrlPrefix;
        private readonly string _androidPackageName;
        private readonly string _iosBundleId;
        private readonly string _iosAppStoreId;

        public UrlShorteningService(IClientService clientService, string domainUrlPrefix,
            string androidPackageName, string iosBundleId, string iosAppStoreId, ILogFactory logFactory)
        {
            _clientService = clientService;
            _domainUrlPrefix = domainUrlPrefix;
            _androidPackageName = androidPackageName;
            _iosBundleId = iosBundleId;
            _iosAppStoreId = iosAppStoreId;
            _log = logFactory.CreateLog(this);
        }

        public async Task<string> ShortenUrlAsync(string url)
        {
            _log.Info("Starting creation of short url", new {url});
            
            var linkRequest = new ShortLinksResource(_clientService).Create(new CreateShortDynamicLinkRequest
            {
                DynamicLinkInfo = new DynamicLinkInfo
                {
                    Link = url,
                    DomainUriPrefix = _domainUrlPrefix,
                    AndroidInfo = new AndroidInfo
                    {
                        AndroidPackageName = _androidPackageName
                    },
                    IosInfo = new IosInfo
                    {
                        IosBundleId = _iosBundleId,
                        IosAppStoreId = _iosAppStoreId
                    }
                }
            });

            _log.Info("Executing request for creation of short url", new {url});
            var response = await linkRequest.ExecuteAsync();

            _log.Info("Successfully created short url", new { url, response.ShortLink });
            return response.ShortLink;
        }
    }
}
