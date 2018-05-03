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
    public class FirstOptionDialog : IDialog
    {
        private List<string> options = new List<string> { "Course Registeration", "Course Schedule", "Drop Course" };



        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
            
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            

            PromptDialog.Choice<string>(
                context,
                this.DisplaySelectedCard,
                this.options,
                "What card would like to test?",
                "Ooops, what you wrote is not a valid option, please try again",
                3,
                PromptStyle.PerLine);
        }

        private async Task DisplaySelectedCard(IDialogContext context, IAwaitable<string> result)
        {
            var selectedOption = await result;
            await context.PostAsync("You said: " + selectedOption);
        }
    }
}