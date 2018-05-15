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
                case StoredValues._gotostart:                       await RootDialog.ShowWelcomeOptions(context);       break;
            }
            await RootDialog.ShowWelcomeOptions(context);                  //Return To Start
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_introduction(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3는 학생들의 수강신청 및 학점관리를 도울 수 있습니다..\n" +
                            $"궁금하신 정보를 선택하시면 해당 정보페이지로 연결됩니다.\n" +
                            $"선택 도중에 처음으로 돌아가고 싶으시면 처음으로를 눌러주세요.\n" +
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