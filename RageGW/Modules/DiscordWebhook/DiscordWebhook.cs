using GTANetworkAPI;
using RageGW.Modules.Logger;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RageGW.Modules.DiscordWebhook
{
    class DiscordWebhook : Script
    {
        public static async void SendMessage(string title, string msg, string webhook, string type)
        {
            DateTime now = DateTime.Now;
            string[] strArray = new string[20];
            strArray[0] = "{\"username\":\"Gangwar | RageMP\",\"avatar_url\":\"https://cdn.discordapp.com/attachments/1028764041004462142/1041424837186433144/pN3MJyS1_400x400.jpg\",\"content\":\"\",\"embeds\":[{\"author\":{\"name\":\"Gangwar | RageMP\",\"url\":\"https://discord.gg/uTYbxh3zmf\",\"icon_url\":\"https://cdn.discordapp.com/attachments/1028764041004462142/1041424837186433144/pN3MJyS1_400x400.jpg\"},\"title\":\"" + type + "\",\"thumbnail\":{\"url\":\"https://cdn.discordapp.com/attachments/1028764041004462142/1041424837186433144/pN3MJyS1_400x400.jpg\"},\"url\":\"https://discord.gg/uTYbxh3zmf\",\"description\":\"Es wurde am **";
            int num = now.Day;
            strArray[1] = num.ToString();
            strArray[2] = ".";
            num = now.Month;
            strArray[3] = num.ToString();
            strArray[4] = ".";
            num = now.Year;
            strArray[5] = num.ToString();
            strArray[6] = " | ";
            num = now.Hour;
            strArray[7] = num.ToString();
            strArray[8] = ":";
            num = now.Minute;
            strArray[9] = num.ToString();
            strArray[10] = "** ein " + type + " ausgelöst.\",\"color\":1127128,\"fields\":[{\"name\":\"";
            strArray[11] = title;
            strArray[12] = "\",\"value\":\"";
            strArray[13] = msg;
            strArray[14] = "\",\"inline\":true}],\"footer\":{\"text\":\" Gangwar | RageMP | " + type + " (c) 2022\"}}]}";
            string stringPayload = string.Concat(strArray);
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webhook, (HttpContent)httpContent);
            }
            stringPayload = (string)null;
            httpContent = (StringContent)null;
        }
    }
}
