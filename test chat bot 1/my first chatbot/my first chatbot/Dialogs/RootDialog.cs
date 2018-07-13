using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using my_first_chatbot.Helper;
using my_first_chatbot.Forms;
using my_first_chatbot.MessageReply;
using Microsoft.Bot.Builder.FormFlow;
using my_first_chatbot.Helper.StoredStringValues;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public static int stuNum = 0;
        public static StoredStringValuesMaster _storedvalues = new StoredValues_kr();
        public static StudentInfoService studentinfo = new StudentInfoService();
        public static POPInfoService popinfo = new POPInfoService();
        public static LiberalArtsService LAService = new LiberalArtsService();

        public async Task StartAsync(IDialogContext context)
        {
            _storedvalues = new StoredValues_kr();          //Default is korean
            context.Wait(MessageReceivedAsync);
        }


        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {

            try
            {
                var value = await result;

                await ShowWelcomeOptions(context);
            }
            catch (Exception ee)                                        //Exception 잡아주기
            {
                string msg = ee.Message;
            }
        }

        public static async Task ShowWelcomeOptions(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = _storedvalues._typePleaseWelcome;
            await context.PostAsync(activity);
            context.Call(new LuisDialog(), LuisDialogResumeAfter);

        }

        //LUIS 결과 메시지 출력부분
        public static async Task LuisDialogResumeAfter(IDialogContext context, IAwaitable<Activity> result)
        {
            int number;
            var message = await result;
            if (Int32.TryParse(message.Text, out number))
            {
                switch (number)
                {
                    case 1: await aboutCourseRegistration.CourseRegistraionOptionSelected(context); break;
                    case 2: await aboutCourseInfo.CourseInfoOptionSelected(context); break;
                    case 3: await aboutCredits.CreditsOptionSelected(context, null); break;
                    case 4: await aboutOthers.Reply_leaveOrReadmission(context); break;
                    case 5: await aboutOthers.Reply_scholarship(context); break;
                    case 6: await aboutHelp.HelpOptionSelected(context); break;
                    default:
                        {
                            await context.PostAsync(_storedvalues._sorryMessage);
                            await ShowWelcomeOptions(context);
                        }
                        break;
                }
            }
            else
            {
                await context.PostAsync(message.Text);
                await ShowWelcomeOptions(context);
            }
        }



        //구현하지 않은 메뉴에 넣을 더미
        public static async Task ForUnimplementedOptions(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"추후 추가예정 입니다.\n";
            await context.PostAsync(activity);
        }

    }
}
