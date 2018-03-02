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
    public class AddDialog : IDialog<object>
    {
        private int number1;

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Provider number one: ");
            context.Wait(MessageRecivedAddNumber1);
        }
        
        private async Task MessageRecivedAddNumber1(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var numbers = await result;
            this.number1 = int.Parse(numbers.Text);
            await context.PostAsync("Provide number two: ");
            context.Wait(MessageReceivedAddNumber2);
        }

        private async Task MessageReceivedAddNumber2(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var numbers = await result;
            var number2 = int.Parse(numbers.Text);
            await context.PostAsync($"{this.number1} + {number2} is = {this.number1 + number2}");

            context.Done<object>(new object());
        }
    }
}