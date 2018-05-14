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
                StoredValues._othersOption,
                "기타 정보",                                                                                 //Course Registration
                "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.   [위치] : OtherOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        public static async Task HandelOtherOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;
            switch (value.ToString())                                                              
            {
                case StoredValues._leaveOrRejoin:          await Reply_leaveOrRejoin(context);        break;      
                case StoredValues._scholarship:            await Reply_scholarship(context);          break;    
            }

            await RootDialog.ShowWelcomeOptions(context);           //Return To Start
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_leaveOrRejoin(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"휴학 및 복학정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";
            await context.PostAsync(activity);
        }

        public static async Task Reply_scholarship(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"장학금 관련정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";

            await context.PostAsync(activity);
        }
        
    }
}