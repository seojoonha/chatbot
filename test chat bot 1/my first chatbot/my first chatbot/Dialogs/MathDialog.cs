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
    public class MathDialog : IDialog<object>
    {
        private int number1;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedStart);
        }

        private async Task MessageReceivedStart(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("do you want to add or square root?");
            context.Wait(MessageReceivedOperationChoice);
        }

        private async Task MessageReceivedOperationChoice(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text.ToLower().Equals("add", StringComparison.InvariantCultureIgnoreCase))
            {
                //await context.PostAsync("Provider number one: ");
                //context.Wait(MessageRecivedAddNumber1);

                context.Call<Object>(new AddDialog(), AfterChildDialogIsDone);

            }
            else if (message.Text.ToLower().Equals("square root", StringComparison.InvariantCultureIgnoreCase))
            {
                //await context.PostAsync("Provider number one: ");
                //context.Wait(MessageRecivedSquareRoot);

                context.Call<Object>(new Squart(), AfterChildDialogIsDone);
            }
            else {
                context.Wait(MessageReceivedStart);
            }
        }

        private async Task AfterChildDialogIsDone(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceivedStart);
        }

        private async Task MessageRecivedSquareRoot(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var number = await result;
            var num = double.Parse(number.Text);
            await context.PostAsync($" square root of {num} is {Math.Sqrt(num)}");

            context.Wait(MessageReceivedStart);
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
            context.Wait(MessageReceivedStart);
        }
    }
}