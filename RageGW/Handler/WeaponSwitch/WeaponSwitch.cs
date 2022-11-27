using GTANetworkAPI;
using RageGW.Modules.Logger;

namespace RageGW.Handler.WeaponSwitch
{
    class WeaponSwitch : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: WeaponSwitch geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: WeaponSwitch entladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.PlayerWeaponSwitch)]
        public void OnPlayerWeaponSwitch(Player player, WeaponHash oldgun, WeaponHash newWeapon)
        {
            NAPI.Player.SetPlayerCurrentWeapon(player, newWeapon);
            NAPI.Player.SetPlayerWeaponAmmo(player, newWeapon, 9999);
        }
    }
}
