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

        public static async Task CreditsOptionSelected(IDialogContext context, IAwaitable<object> result)
        {
            //설정된 학번이 없으면 새로 설정함
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), CreditsOptionSelected);                //get student number
            }
            else
            {

                var activity = context.MakeMessage();
                activity.Text = $"{RootDialog._storedvalues._typePleaseCredits}\n" +
                                $"▶현재 설정된 학번: " +
                                $"{RootDialog.stuNum}\n";
                await context.PostAsync(activity);
                context.Call(new LuisDialog(), HandleCreditsOptionSelection);

            }
        }

        public static async Task HandleCreditsOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {
            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_currentCredits(context); break;
                case "2": await Reply_majorCredits(context); break;
                case "3": await Reply_liberalArtsCredits(context); break;
                case "4": await Reply_changeStuNum(context); break;
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

        public static async Task Reply_currentCredits(IDialogContext context)
        {
            //설정된 학번이 없으면 새로 설정함
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), CreditsOptionSelected);                 //get student number
            }
            else
            {
                var activity = context.MakeMessage();
                activity.Text = RootDialog._storedvalues._reply_CurrentCredits + RootDialog.studentinfo.totalCredits(RootDialog.stuNum);
                await context.PostAsync(activity);
            }
        }

        public static async Task Reply_majorCredits(IDialogContext context)
        {
            //설정된 학번이 없으면 새로 설정함
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), CreditsOptionSelected);                  //get student number
            }
            else
            {
                var activity = context.MakeMessage();
                activity.Text = RootDialog._storedvalues._reply_MajorCredits + RootDialog.studentinfo.totalMajorCredits(RootDialog.stuNum);

                await context.PostAsync(activity);
            }
        }

        public static async Task Reply_liberalArtsCredits(IDialogContext context)
        {
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), CreditsOptionSelected);               //get student number
            }
            else
            {
                var activity = context.MakeMessage();
                activity.Text = RootDialog._storedvalues._reply_LiberalArtsCredits + RootDialog.studentinfo.totalElectiveCredits(RootDialog.stuNum);

                await context.PostAsync(activity);
            }
        }

        public static async Task Reply_changeStuNum(IDialogContext context)         //학번 재설정
        {
            await context.PostAsync(RootDialog._storedvalues._reply_ChangeStuNum + RootDialog.stuNum);            //메시지를 보낸다.
            context.Call(new GetInfoDialog(), CreditsOptionSelected);     //바로 학번입력으로 간다.
        }
    }
}