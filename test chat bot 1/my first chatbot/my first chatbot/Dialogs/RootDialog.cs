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
        public static StoredStringValuesMaster _storedvalues = new StoredValues_kr();                           //StoredValues의 마스터를 만들어 둔다. 디폴트는 한국어로 되어있다.
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
            await context.PostAsync(_storedvalues._typePleaseWelcome);
            context.Call(new LuisDialog(), LuisDialogResumeAfter);
        }

        //LUIS 결과 메시지 출력부분
        public static async Task LuisDialogResumeAfter(IDialogContext context, IAwaitable<Activity> result)
        {
            var message = await result;
            int number;
            if (Int32.TryParse(message.Text, out number))
            {
                switch (number)
                {
                    case 1: await aboutCourseRegistration.CourseRegistraionOptionSelected(context); break;
                    case 2: await aboutCourseInfo.CourseInfoOptionSelected(context); break;
                    case 3: await aboutCredits.CreditsOptionSelected(context); break;
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
                await GoToMenu(context, result);
            }
        }
        public static async Task GoToMenu(IDialogContext context, IAwaitable<Activity> result)
        {
            var message = await result;
            switch (message.Text)
            {
                //기본 메뉴
                case "menu": await ShowWelcomeOptions(context); break;
                case "_courseRegistration": await aboutCourseRegistration.CourseRegistraionOptionSelected(context); break;
                case "_courseInformation": await aboutCourseInfo.CourseInfoOptionSelected(context); break;
                case "_credits": await aboutCredits.CreditsOptionSelected(context); break;
                case "_others::_leaveOrReadmission": await aboutOthers.Reply_leaveOrReadmission(context); break;
                case "_others::_scholarship": await aboutOthers.Reply_scholarship(context); break;
                case "_help": await aboutHelp.HelpOptionSelected(context); break;
                //수강신청 메뉴
                case "_courseRegistration::_howToDoIt": await aboutCourseRegistration.Reply_howToDoIt(context); break;
                case "_courseRegistration::_schedule": await aboutCourseRegistration.Reply_schedule(context); break;
                case "_courseRegistration::_regulation": await aboutCourseRegistration.Reply_regulation(context); break;
                case "_courseRegistration::_terms": await aboutCourseRegistration.Reply_terms(context); break;
                //과목정보 메뉴
                case "_courseInformation::_openedMajorCourses": await aboutCourseInfo.Reply_openedMajorCourses(context); break;
                case "_courseInformation::_openedLiberalArts": await aboutCourseInfo.Reply_openedLiberalArts(context); break;
                case "_courseInformation::_syllabus": await aboutCourseInfo.Reply_syllabus(context); break;
                case "_courseInformation::_lecturerInfo": await aboutCourseInfo.Reply_lecturerInfo(context); break;
                case "_courseInformation::_mandatorySubject": await aboutCourseInfo.Reply_mandatorySubject(context); break;
                case "_courseInformation::_prerequisite": await aboutCourseInfo.Reply_prerequisite(context); break;
                case "_courseInformation::_popular": await aboutCourseInfo.PopularOptionSelected(context); break;
                case "_courseInformation::_liberalSubject": await aboutCourseInfo.LiberalOptionSelected(context); break;
                //학점관리 메뉴
                case "_credits::_currentCredits": await aboutCredits.Reply_currentCredits(context); break;
                case "_credits::_majorCredits": await aboutCredits.Reply_majorCredits(context); break;
                case "_credits::_liberalArtsCredits": await aboutCredits.Reply_liberalArtsCredits(context); break;
                case "_credits::_changeStuNum": await aboutCredits.Reply_changeStuNum(context); break;
                //도움말
                case "_help::_introduction": await aboutHelp.Reply_introduction(context); break;
                case "_help::_requestInformationCorrection": await aboutHelp.Reply_requestInformationCorrection(context); break;
                case "_help::_contactMaster": await aboutHelp.Reply_contactMaster(context); break;

                //for debug
                default:
                    {
                        await context.PostAsync(message.Text);
                        await ShowWelcomeOptions(context);
                    }
                    break;
            }
        }

        //구현하지 않은 메뉴에 넣을 더미
        public static async Task ForUnimplementedOptions(IDialogContext context)       //그 외 말을 했을 때
        {
            var activity = context.MakeMessage();
            activity.Text = $"추후 추가예정 입니다.\n";
            await context.PostAsync(activity);
        }

    }
}
