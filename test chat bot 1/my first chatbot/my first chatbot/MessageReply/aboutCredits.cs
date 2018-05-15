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
                StoredValues._creditsOptions,
                "학점 관리를 선택하셨습니다.\n세부항목을 선택해주세요.",                                                                                 //Course Registration
                "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.   [위치] : CreditOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        public static async Task HandelCreditsOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;
            switch (value.ToString())                                                              
            {
                case StoredValues._currentCredits:          await Reply_currentCredits(context);            break;      
                case StoredValues._majorCredits:            await Reply_majorCredits(context);              break;    
                case StoredValues._electiveCredits:         await Reply_electiveCredits(context);           break;
                case StoredValues._gotostart:               await RootDialog.ShowWelcomeOptions(context);   break;
                case StoredValues._help:                    await aboutHelp.HelpOptionSelected(context);    break;
            }

            //await RootDialog.ShowWelcomeOptions(context);           //Return To Start
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_currentCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"나의 이수학점에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";
            await context.PostAsync(activity);
        }

        public static async Task Reply_majorCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"전공 학점에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";

            await context.PostAsync(activity);
        }

        public static async Task Reply_electiveCredits(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"선택 학점에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";

            await context.PostAsync(activity);
        }

        
    }
}