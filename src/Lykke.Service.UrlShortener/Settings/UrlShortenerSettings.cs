using JetBrains.Annotations;

namespace Lykke.Service.UrlShortener.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class UrlShortenerSettings
    {
        public DbSettings Db { get; set; }

        public FirebaseSettings Firebase { get; set; }
    }
}
