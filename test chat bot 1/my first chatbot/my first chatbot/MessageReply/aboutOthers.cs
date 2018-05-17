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
    public static class aboutOthers
    {
        public static async Task OtherOptionSelected(IDialogContext context)
        {
            PromptDialog.Choice<string>(
                context,
                HandelOtherOptionSelection,
                RootDialog._storedvalues._othersOption,
                RootDialog._storedvalues._otherOptionSelected,                                                                                 //Course Registration
                RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : OtherOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        public static async Task HandelOtherOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);

            else if (value.ToString() == RootDialog._storedvalues._help) await aboutHelp.HelpOptionSelected(context);

            else
            {
                if (value.ToString() == RootDialog._storedvalues._leaveOrRejoin) await Reply_leaveOrRejoin(context);
                else if (value.ToString() == RootDialog._storedvalues._scholarship) await Reply_scholarship(context);
                
                await RootDialog.ShowWelcomeOptions(context);           //Return To Start
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_leaveOrRejoin(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_LeaveOrRejoin;
            await context.PostAsync(activity);
        }

        public static async Task Reply_scholarship(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Scholarship;

            await context.PostAsync(activity);
        }

    }
}