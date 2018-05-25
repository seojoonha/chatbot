using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using my_first_chatbot.MessageReply;
using my_first_chatbot.Helper;
namespace my_first_chatbot.Dialogs
{
    [Serializable]
    [LuisModel("b764b107-9ed2-4f9e-ad3f-9251430dafa8", "be608df8436f4ccea3bec7a39f2a03a5")]
    public class LuisDialog : LuisDialog<Activity>
    {
        /*
            string strtemp = "";
            for (int i = 0; i < result.Entities.Count; i++)
            {
                strtemp = strtemp + (i + 1) + " Entitie의 타입은 : " + result.Entities[i].Type + "  Entitie의 Target Text는 " + result.Entities[i].Entity + " 입니다.###";
            }
            var activity = context.MakeMessage();
            activity.Text = $"{strtemp} Intent는 {result.Intents[0].Intent}. 해당 Intent일 확률은 {result.Intents[0].Score}% 입니다. {result.Entities.Count} is Entities count //";
            context.Done(activity);
        */

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"말씀을 이해하지 못했습니다..";
            //await context.PostAsync(activity);
            context.Done(activity);
        }



        [LuisIntent("Information")]
        public async Task InformationIntent(IDialogContext context, LuisResult result)
        {
            var strtmp = result.Entities[0].Type;
            if (strtmp == "_courseRegistration") await aboutCourseRegistration.CourseRegistraionOptionSelected(context);
            else if (strtmp == "_courseInformation") await aboutCourseInfo.CourseInfoOptionSelected(context);
            else if (strtmp == "_credits") await aboutCredits.CreditsOptionSelected(context);
            else if (strtmp == "_others") await aboutOthers.OtherOptionSelected(context);
            else
            {
                var activity = context.MakeMessage();
                activity.Text = $"못알아들음";
                context.Done(activity);
            }
            
        }
        

        [LuisIntent("Help")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {
            await aboutHelp.HelpOptionSelected(context);
        }



        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"인사해주셔서 감사해요." +
                             $"좋은하루 되시길 바랄게요 :)\n";
            
            context.Done(activity);
        }
        
        [LuisIntent("ChangeLanguage")]
        public async Task ChangeLanguage(IDialogContext context, LuisResult result)
        {

            if (result.Entities[0].Type == "한국어")
            {
                RootDialog._storedvalues = new StoredValues_kr();
            }   //for convert en to kr
            else
            {
                RootDialog._storedvalues = new StoredValues_en();
            }

            await RootDialog.ShowWelcomeOptions(context);
        }
    }
}