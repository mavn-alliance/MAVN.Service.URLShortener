using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Google.Apis.FirebaseDynamicLinks.v1;
using Google.Apis.Services;
using Lykke.Service.UrlShortener.Domain.Services;
using Lykke.Service.UrlShortener.DomainServices.Services;
using Lykke.Service.UrlShortener.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.UrlShortener.Modules
{
    public class ServiceModule : Module
    {
        private readonly AppSettings _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings.CurrentValue;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UrlShorteningService>()
                .As<IUrlShorteningService>()
                .SingleInstance()
                .WithParameter("domainUrlPrefix", _appSettings.UrlShortenerService.Firebase.DomainUriPrefix)
                .WithParameter("androidPackageName", _appSettings.UrlShortenerService.Firebase.AndroidPackageName)
                .WithParameter("iosAppStoreId", _appSettings.UrlShortenerService.Firebase.IosAppStoreId)
                .WithParameter("iosBundleId", _appSettings.UrlShortenerService.Firebase.IosBundleId);

            builder.RegisterType<FirebaseDynamicLinksService>()
                .As<IClientService>()
                .SingleInstance()
                .WithParameter("initializer", new BaseClientService.Initializer
                {
                    ApiKey = _appSettings.UrlShortenerService.Firebase.FirebaseApiKey
                });
        }
    }
}
