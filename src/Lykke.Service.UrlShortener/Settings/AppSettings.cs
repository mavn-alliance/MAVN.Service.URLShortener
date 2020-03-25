using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.UrlShortener.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public UrlShortenerSettings UrlShortenerService { get; set; }
    }
}
