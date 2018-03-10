using Harmony;
using Rocket.Core.Plugins;
using System;
using System.Linq;
using System.Reflection;
using Rocket.Core.Logging;
using Rocket.API.Collections;
using Rocket.Unturned.Permissions;

namespace ExtraConcentratedJuice.ExtraCommandLimiter
{
    public class ExtraCommandLimiter : RocketPlugin<ExtraCommandLimiterConfiguration>
    {
        public static ExtraCommandLimiter instance;

        protected override void Load()
        {
            instance = this;

            HarmonyInstance harmony = HarmonyInstance.Create("pw.cirno.extraconcentratedjuice");
            var orig = typeof(UnturnedPermissions).GetMethod("CheckPermissions", BindingFlags.Static | BindingFlags.NonPublic);
            var pre = typeof(CheckPermissionsOverride).GetMethod("Prefix", BindingFlags.Static | BindingFlags.NonPublic);
            var post = typeof(CheckPermissionsOverride).GetMethod("Postfix", BindingFlags.Static | BindingFlags.Public);
            harmony.Patch(orig, new HarmonyMethod(pre), new HarmonyMethod(post));

            Logger.Log("Command execution method successfully patched, disabled commands:");
            Logger.Log($"Safezone:\n{String.Join("\n", Configuration.Instance.safezoneBlockedCommands.Select(x => $"\t{x}").ToArray())}");
            Logger.Log($"Deadzone:\n{String.Join("\n", Configuration.Instance.deadzoneBlockedCommands.Select(x => $"\t{x}").ToArray())}");
        }

        protected override void Unload()
        {
            Logger.LogWarning("Please restart your server and remove the plugin to undisable your commands.");
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "deadzone", "You are not allowed to call this command from within a deadzone." },
            { "safezone", "You are not allowed to call this command from within a safezone." }
        };
    }
}
