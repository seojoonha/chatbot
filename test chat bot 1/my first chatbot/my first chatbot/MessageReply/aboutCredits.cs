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
    public static class aboutCredits
    {
        
        public static async Task CreditsOptionSelected(IDialogContext context)
        {
            

            PromptDialog.Choice<string>(
                context,
                HandelCreditsOptionSelection,
                RootDialog._storedvalues._creditsOptions,
                RootDialog._storedvalues._creditsOptionSelected,                                                                                 //Course Registration
                RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : CreditOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        


        public static async Task HandelCreditsOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);

            else if (value.ToString() == RootDialog._storedvalues._help) await aboutHelp.HelpOptionSelected(context);

            else
            {
                if (value.ToString() == RootDialog._storedvalues._currentCredits) await Reply_currentCredits(context);
                else if (value.ToString() == RootDialog._storedvalues._majorCredits) await Reply_majorCredits(context);
                else if (value.ToString() == RootDialog._storedvalues._electiveCredits) await Reply_electiveCredits(context);
                else if (value.ToString() == RootDialog._storedvalues._changeStuNum) await Reply_changeStuNum(context);

                await RootDialog.ShowWelcomeOptions(context);           //Return To Start
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_currentCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_CurrentCredits + RootDialog.studentinfo.totalCredits(RootDialog.stuNum);
            await context.PostAsync(activity);
        }

        public static async Task Reply_majorCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();

            activity.Text = RootDialog._storedvalues._reply_MajorCredits + RootDialog.studentinfo.totalMajorCredits(RootDialog.stuNum);

            await context.PostAsync(activity);
        }

        public static async Task Reply_electiveCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_ElectiveCredits + RootDialog.studentinfo.totalElectiveCredits(RootDialog.stuNum);

            await context.PostAsync(activity);
        }

        public static async Task Reply_changeStuNum(IDialogContext context)
        {
            RootDialog.stuNum = "";
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_ChangeStuNum;

            await context.PostAsync(activity);
        }

    }
}