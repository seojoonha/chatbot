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
        public static string stuNum = "";
        public static StoredStringValuesMaster _storedvalues;                           //StoredValues의 마스터를 만들어 둔다. 디폴트는 한국어로 되어있다.
        public static StudentInfoService studentinfo = new StudentInfoService();

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
                if (value.Text.ToString() == "English") _storedvalues = new StoredValues_en();      //if you choose english at first keyboard convert to english

                await ShowWelcomeOptions(context);   
            }
            catch (Exception ee)                                        //Exception 잡아주기
            {
                string msg = ee.Message;
            }
            //await ShowWelcomeOptions(context);
        }

        

        public static async Task ShowWelcomeOptions(IDialogContext context)
        {


            PromptDialog.Choice<string>(
                context,
                HandelWelcomeOptionSelected,
                _storedvalues._welcomeOptionsList,
                _storedvalues._welcomeMessage,                          //선택시 출력되는 메시지 정의
                _storedvalues._invalidSelectionMessage + "[ERROR] : showWelcomeOptions",    //오류시 표시될 메시지 정의
                1,
                PromptStyle.Auto);
        }



        public static async Task HandelWelcomeOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            if (value.ToString() == _storedvalues._courseRegistration) await aboutCourseRegistration.CourseRegistraionOptionSelected(context);
            else if (value.ToString() == _storedvalues._courseInformation) await aboutCourseInfo.CourseInfoOptionSelected(context);
            else if (value.ToString() == _storedvalues._credits) await aboutCredits.CreditsOptionSelected(context);
            else if (value.ToString() == _storedvalues._others) await aboutOthers.OtherOptionSelected(context);
            else if (value.ToString() == _storedvalues._help) await aboutHelp.HelpOptionSelected(context);
            else await ForUnimplementedOptions(context, value);
        }



        public static async Task GetInfoDialogResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
                stuNum = message.ToString();
                await aboutCredits.CreditsOptionSelected(context);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("I'm sorry, I'm having issues understanding you. Let's try again.");

                await ShowWelcomeOptions(context);
            }
            //throw new NotImplementedException();
        }

        public static async Task GetInfoDialogAfterResettingStudentNumber(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            stuNum = message.ToString();

            await context.PostAsync(_storedvalues._getStudentNumUpdateMessage + stuNum);
            await aboutCredits.CreditsOptionSelected(context);
        }



        private static async Task ForUnimplementedOptions(IDialogContext context, string selectedOption)       //그 외 말을 했을 때
        {
            var activity = context.MakeMessage();
            activity.Text = $"요청하신 정보는 " + selectedOption + "입니다.\n" +          //"You said: " + selectedOption
                            $"추후 추가예정 입니다.\n";                                   //"Thanks for using AAR!!!. See u soon"
            await context.PostAsync(activity);
        }

    }
}