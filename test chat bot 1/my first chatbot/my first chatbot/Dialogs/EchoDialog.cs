using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using my_first_chatbot.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {



            var data = new gifObject().data;
            using (HttpClient client = new HttpClient())
            {
                string RequestURI = "http://api.giphy.com/v1/gifs/trending?api_key=dc6zaTOxFJmzC";
                HttpResponseMessage msg = await client.GetAsync(RequestURI);

                if (msg.IsSuccessStatusCode)
                {
                    var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<gifObject>(JsonDataResponse).data;
                }
            }

            var gif = data[(int)Math.Floor(new Random().NextDouble() * data.Count())];
            var gifurl = gif.images.fixed_height.url;
            var slug = gif.slug;


            var outboundMessage = context.MakeMessage();
            outboundMessage.Attachments = new List<Attachment>();
            outboundMessage.Attachments.Add(new Attachment() {
                ContentUrl = gifurl,
                ContentType = "image/gif",
                Name = slug + ".gif"
            });

            var message = await result;
            //await context.PostAsync("You said: " + message.Text);
            await context.PostAsync(outboundMessage);
            context.Wait(MessageReceivedAsync);
        }
    }
}