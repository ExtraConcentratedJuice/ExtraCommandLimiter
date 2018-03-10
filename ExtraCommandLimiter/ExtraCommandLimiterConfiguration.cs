using Rocket.API;
using System.Collections.Generic;

namespace ExtraConcentratedJuice.ExtraCommandLimiter
{
    public class ExtraCommandLimiterConfiguration : IRocketPluginConfiguration
    {
        public List<string> safezoneBlockedCommands;
        public List<string> deadzoneBlockedCommands;
        public bool allowAdminOverride;
        public string ignorePlayerPermission;

        public void LoadDefaults()
        {
            safezoneBlockedCommands = new List<string> { "vault" };
            deadzoneBlockedCommands = new List<string> { "spaghetti" };
            allowAdminOverride = true;
            ignorePlayerPermission = "ExtraCommandLimiter.ignore";
        }
    }
}
