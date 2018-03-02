using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class Squart : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Provider number one: ");
            context.Wait(MessageRecivedSquareRoot);
        }


        private async Task MessageRecivedSquareRoot(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var number = await result;
            var num = double.Parse(number.Text);
            await context.PostAsync($" square root of {num} is {Math.Sqrt(num)}");

            context.Done<object>(new object());
        }
    }
}