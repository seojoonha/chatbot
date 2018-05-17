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
        public static StoredStringValuesMaster _storedvalues;
        public static StudentInfoService studentinfo = new StudentInfoService();
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            //_storedvalues = new StoredValues_kr();
            _storedvalues = new StoredValues_en();

        }


        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            //This is from webapp code
            //buttons = new string[] { "처음으로", "도움말" },           //goto start, help

            try
            {
                var value = await result;

                if (value.Text.ToString() == _storedvalues._gotostart) await ShowWelcomeOptions(context);
                else if (value.Text.ToString() == _storedvalues._help) await ShowWelcomeOptions(context);
                else await ShowWelcomeOptions(context);

                //switch (value.Text.ToString())
                //{
                //    case _storedvalues._gotostart: await ShowWelcomeOptions(context); break;
                //    case _storedvalues._help: await aboutHelp.HelpOptionSelected(context); break;
                //    default: await ShowWelcomeOptions(context); break;
                //}
            }
            catch (Exception ee)
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
                "안녕하세요 AAR3입니다. 원하시는 정보를 선택해 주세요" + studentinfo.totalMajorCredits("60131937"),                          //선택시 출력되는 메시지 정의
                "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.   [위치] : showWelcomeOptions",    //오류시 표시될 메시지 정의
                3,
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


            //switch (value.ToString())
            //{
            //    case _storedvalues._courseRegistration: await aboutCourseRegistration.CourseRegistraionOptionSelected(context); break;
            //    case _storedvalues._courseInformation: await aboutCourseInfo.CourseInfoOptionSelected(context); break;
            //    case _storedvalues._credits: await aboutCredits.CreditsOptionSelected(context); break;
            //    case _storedvalues._others: await aboutOthers.OtherOptionSelected(context); break;
            //    case _storedvalues._help: await aboutHelp.HelpOptionSelected(context); break;
            //    default: await ForUnimplementedOptions(context, value); break;
            //}

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