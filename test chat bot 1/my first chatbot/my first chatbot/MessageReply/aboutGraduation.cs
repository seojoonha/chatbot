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
    public static class aboutGraduation
    {

        public static async Task GraduateOptionSelected(IDialogContext context)
        {


            PromptDialog.Choice<string>(
                context,
                HandelGraduationOptionSelection,
                RootDialog._storedvalues._graduationOptions,
                RootDialog._storedvalues._graduationOptionSelected,                                                                                //Course Registration
                RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : GraduationOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }



        public static async Task HandelGraduationOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);

            else if (value.ToString() == RootDialog._storedvalues._help) await aboutHelp.HelpOptionSelected(context);

            else
            {
                if (value.ToString() == RootDialog._storedvalues._requiredCredits) await Reply_requiredCredits(context);
                else if (value.ToString() == RootDialog._storedvalues._certification) await Reply_certification(context);
                
                await RootDialog.ShowWelcomeOptions(context);           //Return To Start
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_requiredCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_requiredCredits;

            activity.Attachments.Add(new HeroCard
            {
                Title = "졸업 요건",
                Subtitle = "온라인서비스-학사운영-졸업-졸업요건",          //Location of information in MJU homepage
                Text = "졸업 요건",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/mbs/mjukr/images/title/tle5_5_4.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://www.mju.ac.kr/mbs/mjukr/subview.jsp?id=mjukr_050510030000") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_certification(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_certification;

            activity.Attachments.Add(new HeroCard
            {
                Title = "졸업인증제",
                Subtitle = "온라인서비스-학사운영-졸업-졸업인증제",          //Location of information in MJU homepage
                Text = "졸업인증제",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/mbs/mjukr/images/title/tle5_5_4.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://www.mju.ac.kr/mbs/mjukr/subview.jsp?id=mjukr_050510010000") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

    }
}