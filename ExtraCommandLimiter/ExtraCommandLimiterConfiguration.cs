using Rocket.API;
using System.Collections.Generic;

namespace ExtraConcentratedJuice.ExtraCommandLimiter
{
    public class ExtraCommandLimiterConfiguration : IRocketPluginConfiguration
    {
        public List<string> safezoneBlockedCommands;
        public List<string> deadzoneBlockedCommands;
        public List<string> safezoneOnlyCommands;
        public List<string> deadzoneOnlyCommands;

        public bool allowAdminOverride;
        public string ignorePlayerPermission;

        public void LoadDefaults()
        {
            safezoneBlockedCommands = new List<string> { "moms" };
            deadzoneBlockedCommands = new List<string> { "spaghetti" };
            safezoneOnlyCommands = new List<string> { "vault" };
            deadzoneOnlyCommands = new List<string> { "meme" };
            allowAdminOverride = true;
            ignorePlayerPermission = "ExtraCommandLimiter.ignore";
        }
    }
}
