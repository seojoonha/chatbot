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
            //설정된 학번이 없으면 새로 설정함
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), RootDialog.GetInfoDialogResumeAfter);                //get student number
            }
            else
            {

                //텍스트 입력방식
                var activity = context.MakeMessage();
                activity.Text = $"{RootDialog._storedvalues._typePleaseCredits}\n" +
                                $"▶현재 설정된 학번: " +
                                $"{RootDialog.stuNum}\n";
                await context.PostAsync(activity);
                context.Call(new LuisDialog(), HandleCreditsOptionSelection);

                //버튼방식
                //PromptDialog.Choice<string>(
                //context,
                //HandleCreditsOptionSelection,
                //RootDialog._storedvalues._creditsOptions,
                //RootDialog._storedvalues._creditsOptionSelected + "\n현재 설정된 학번 : " + RootDialog.stuNum,                                                                                 //Course Registration
                //RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : CreditOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                //1,
                //PromptStyle.Auto);
            }


        }

        public static async Task HandleCreditsOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {
            //텍스트 입력방식
            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_currentCredits(context); break;
                case "2": await Reply_majorCredits(context); break;
                case "3": await Reply_liberalArtsCredits(context); break;
                case "4": await Reply_changeStuNum(context); break;
                case "5": break;//go to start
                case "6": await aboutHelp.HelpOptionSelected(context); break;
                default:
                    {
                        await context.PostAsync(message);
                    }
                    break;
            }
            await RootDialog.ShowWelcomeOptions(context);

            //버튼방식
            //var value = await result;
            //if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);
            //else if (value.ToString() == RootDialog._storedvalues._help) await aboutHelp.HelpOptionSelected(context);
            //else
            //{
            //    if (value.ToString() == RootDialog._storedvalues._changeStuNum)
            //    {               //학번 재설정 요청일시
            //        await Reply_changeStuNum(context);                                          //학번 재설정으로 연결
            //    }
            //    else
            //    {
            //        if (value.ToString() == RootDialog._storedvalues._currentCredits) await Reply_currentCredits(context);
            //        else if (value.ToString() == RootDialog._storedvalues._majorCredits) await Reply_majorCredits(context);
            //        else if (value.ToString() == RootDialog._storedvalues._liberalArtsCredits) await Reply_liberalArtsCredits(context);


            //        //await RootDialog.ShowWelcomeOptions(context);           //Return To Start
            //        await CreditsOptionSelected(context);
            //    }
            //}
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_currentCredits(IDialogContext context)
        {
            //설정된 학번이 없으면 새로 설정함
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), RootDialog.GetInfoDialogResumeAfter);                //get student number
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
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), RootDialog.GetInfoDialogResumeAfter);                //get student number
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
                context.Call(new GetInfoDialog(), RootDialog.GetInfoDialogResumeAfter);                //get student number
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
            context.Call(new GetInfoDialog(), RootDialog.GetInfoDialogAfterResettingStudentNumber);     //바로 학번입력으로 간다.
        }
    }
}