using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace latestfootasylumtest
{
    public class DiscordBot
    {
        private string webhook, name, avatarurl;
        private NameValueCollection webhookData;
        private WebClient WebClient;

        public DiscordBot(string webhook, string name, string avatarurl)
        {
            webhookData = new NameValueCollection();
            WebClient = new WebClient();

            this.webhook = webhook;
            this.name = name;
            this.avatarurl = avatarurl;

            webhookData.Set("username", name);
            webhookData.Set("avatar_url", avatarurl);
        }

        public void SendDiscordWebHookSimple(string content)
        {
            //string text = File.ReadAllText("bottest.json");

            webhookData.Set("content", "```" + content + "```" +
                "http://morgan.games/kraken/krakenbeta.png");

            WebClient.UploadValues(webhook, webhookData);
            WebClient.Dispose();
        }

        public void SendDiscordWebHookEmbeded(
            string imageurl,
            string title,
            string titleurl,
            DiscordEmbedField field1,
            DiscordEmbedField field2,
            DiscordEmbedField field3,
            DiscordEmbedField field4)
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["webhook"] = webhook;

                data["name"] = name;
                data["avatar"] = avatarurl;
                data["image"] = imageurl;
                data["title"] = title;
                data["titleurl"] = titleurl;

                data["field1"] = field1.title;
                data["field1val"] = field1.value;

                data["field2"] = field2.title;
                data["field2val"] = field2.value;

                data["field3"] = field3.title;
                data["field3val"] = field3.value;

                data["field4"] = field4.title;
                data["field4val"] = field4.value;

                var response = wb.UploadValues("http://morgan.games/kraken/discord.php", "POST", data);
                Console.WriteLine(Encoding.UTF8.GetString(response));
            }
        }
    }

    public struct DiscordEmbedField
    {
        public string title;
        public string value;

        public DiscordEmbedField(string title, string value)
        {
            this.title = title;
            this.value = value;
        }
    }
}
