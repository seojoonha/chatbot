using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using my_first_chatbot.Helper;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
           context.Wait(MessageReceivedAsync);
        }


        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            //await context.PostAsync("test 2");
            ////context.Wait(MessageReceivedAsync);
            //context.Call(new FirstOptionDialog(), this.FirstOptionDialogResumeAfter);

            PromptDialog.Choice<string>(
                context,
                this.DisplaySelectedCard,
                StoredValues.firstOptionsList,
                "Welcome to AAR service. What can i help you?",
                "Ooops, what you wrote is not a valid option, please try again",
                3,
                PromptStyle.Auto);

        }

        private async Task DisplaySelectedCard(IDialogContext context, IAwaitable<string> result)
        {
            var selectedOption = await result;
            await context.PostAsync("You said: " + selectedOption);

            await context.PostAsync("Thanks for using AAR!!!. See u soon");


            //var message = context.MakeMessage();
            //var attachment = GetHeroCard();
            //message.Attachments.Add(attachment);

            //await context.PostAsync(message);


        }

        private async Task FirstOptionDialogResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            //context.Wait(MessageReceivedAsync);
            //context.Done(this);

            context.PostAsync("on the call back");

        }
        

    }
}