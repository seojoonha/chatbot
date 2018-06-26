using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using my_first_chatbot.Helper;
using my_first_chatbot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace my_first_chatbot.MessageReply
{
    public static class aboutHelp
    {
        public static async Task HelpOptionSelected(IDialogContext context)
        {

            await context.PostAsync(RootDialog._storedvalues._typePleaseHelp);
            context.Call(new LuisDialog(), HandleHelpOptionSelection);

        }


        public static async Task HandleHelpOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {
            
            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_introduction(context); break;
                case "2": await Reply_requestInformationCorrection(context); break;
                case "3": await Reply_contactMaster(context); break;
                case "": await RootDialog.ShowWelcomeOptions(context); break;
                default:
                    {
                        await context.PostAsync(message);
                    }
                    break;
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_introduction(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Introduction;
            await context.PostAsync(activity);
        }

        public static async Task Reply_requestInformationCorrection(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_RequestInformationCorrection;

            await context.PostAsync(activity);
        }

        public static async Task Reply_contactMaster(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_ContactMaster;

            await context.PostAsync(activity);
        }


    }
}