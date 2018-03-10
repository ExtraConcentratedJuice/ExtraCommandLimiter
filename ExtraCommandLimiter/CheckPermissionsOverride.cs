using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Linq;

namespace ExtraConcentratedJuice.ExtraCommandLimiter
{
    internal static class CheckPermissionsOverride
    {
        internal static bool Prefix(SteamPlayer caller, string permission)
        {
            var config = ExtraCommandLimiter.instance.Configuration.Instance;
            var player = UnturnedPlayer.FromSteamPlayer(caller);

            if (player.GetPermissions().Any(x => x.Name == config.ignorePlayerPermission))
                return true;

            if (player.IsAdmin && config.allowAdminOverride)
                return true;

            string cmd = permission.TrimStart('/');

            bool inSz = player.Player.movement.isSafe;
            bool inDz = player.Player.movement.isRadiated;

            if (inDz && config.deadzoneBlockedCommands.Any(x => String.Equals(cmd, x, StringComparison.OrdinalIgnoreCase)))
            {
                UnturnedChat.Say(player, ExtraCommandLimiter.instance.Translations.Instance.Translate("deadzone"));
                return false;
            }

            if (inSz && config.safezoneBlockedCommands.Any(x => String.Equals(cmd, x, StringComparison.OrdinalIgnoreCase)))
            {
                UnturnedChat.Say(player, ExtraCommandLimiter.instance.Translations.Instance.Translate("safezone"));
                return false;
            }

            return true;
        }

        internal static void Postfix() { /* lol */ }
    }
}
