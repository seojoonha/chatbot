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
            PromptDialog.Choice<string>(
                context,
                HandelHelpOptionSelected,
                StoredValues._helpOptionsList,
                "AAR3 도움말입니다. 무엇을 도와드릴까요?",           //선택시 출력되는 메시지 정의
                "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.   [위치] : ShowHelpOptions",    //오류시 표시될 메시지 정의
                3,
                PromptStyle.Auto);
        }


        public static async Task HandelHelpOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            switch (value.ToString())
            {
                case StoredValues._introduction:                    await Reply_introduction(context);                  break;
                case StoredValues._requestInformationCorrection:    await Reply_requestInformationCorrection(context);  break;
                case StoredValues._contactMaster:                   await Reply_contactMaster(context);                 break;
            }

        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_introduction(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";
            await context.PostAsync(activity);
        }

        public static async Task Reply_requestInformationCorrection(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"정보수정을 요청하실 수 있습니다.\n" +
                            $"추후 추가예정 입니다.\n";

            await context.PostAsync(activity);
        }

        public static async Task Reply_contactMaster(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"관리자와 상담을 요청하실 수 있습니다.\n" +
                            $"추후 추가예정 입니다.\n";

            await context.PostAsync(activity);
        }

        
    }
}