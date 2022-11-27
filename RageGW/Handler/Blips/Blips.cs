using GTANetworkAPI;
using RageGW.Modules.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace RageGW.Handler
{
    class Blips : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Handler: Blips geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Handler: Blips entladen", LoggerEnums.LogType.Info);
        }

        //Blips
        Blip YakuzaBlip = NAPI.Blip.CreateBlip(310, new Vector3(-1521.4286f, 853.1868f, 181.58533f), 0.8f, 1, "TeamSpawn: YakuZa Mafia", 255, 0, true);
        Blip GroveBlip = NAPI.Blip.CreateBlip(310, new Vector3(1382.7693f, -590.53186f, 74.3363f), 0.8f, 52, "TeamSpawn: Grove Street Families", 255, 0, true);
        Blip AztecasBlip = NAPI.Blip.CreateBlip(310, new Vector3(1415.4989f, 3633.2966f, 34.654907f), 0.8f, 26, "TeamSpawn: Varrios Los Aztecas", 255, 0, true);
        Blip HxxverBlip = NAPI.Blip.CreateBlip(310, new Vector3(1286.5319f, -1603.5692f, 54.82422f), 0.8f, 64, "TeamSpawn: 52 Hxxver Crips", 255, 0, true);
        Blip LCNBlip = NAPI.Blip.CreateBlip(310, new Vector3(-1535.7627f, 97.63516f, 56.761963f), 0.8f, 72, "TeamSpawn: La Cosa Nostra", 255, 0, true);
        Blip BallasBlip = NAPI.Blip.CreateBlip(310, new Vector3(84.64616f, -1958.3737f, 21.107666f), 0.8f, 58, "TeamSpawn: Davis Braxton Ballas", 255, 0, true);

        //AufsatzShop
        Blip AufsatzShopBlip = NAPI.Blip.CreateBlip(110, new Vector3(21.019781f, -1106.6901f, 29.7854f), 0.8f, 28, "Aufsatz Shop", 255, 0, true);

        //Marker
        Marker YakuzaMarker = NAPI.Marker.CreateMarker(36, new Vector3(-1539.158f, 858.36365f, 181.50923f), new Vector3(), new Vector3(), 0.8f, 255, 0, 0);
        Marker GroveMarker = NAPI.Marker.CreateMarker(36, new Vector3(1367.2704f, -580.9736f, 74.380455f), new Vector3(), new Vector3(), 0.8f, 0, 51, 3);
        Marker AztecasMarker = NAPI.Marker.CreateMarker(36, new Vector3(1419.9716f, 3618.0981f, 34.910378f), new Vector3(), new Vector3(), 0.8f, 0, 255, 247);
        Marker HxxverMarker = NAPI.Marker.CreateMarker(36, new Vector3(1273.7133f, -1587.2535f, 52.446854f), new Vector3(), new Vector3(), 0.8f, 255, 128, 0);
        Marker LCNMarker = NAPI.Marker.CreateMarker(36, new Vector3(-1523.2712f, 85.83939f, 56.474106f), new Vector3(), new Vector3(), 0.8f, 0, 0, 0);
        Marker BallasMarker = NAPI.Marker.CreateMarker(36, new Vector3(102.868164f, -1942.1025f, 20.803722f), new Vector3(), new Vector3(), 0.8f, 59, 0, 61);

        //AufsatzShop
        Marker AufsatzShopMarker = NAPI.Marker.CreateMarker(42, new Vector3(21.019781f, -1106.6901f, 29.7854f), new Vector3(), new Vector3(), 0.8f, 0, 0, 0);
    }
}
