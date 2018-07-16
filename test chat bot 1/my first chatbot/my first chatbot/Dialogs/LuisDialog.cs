using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using my_first_chatbot.MessageReply;
using my_first_chatbot.Helper;
namespace my_first_chatbot.Dialogs
{
    [Serializable]
    [LuisModel("659e8d9a-f239-440e-9f87-eecf3fc9ed7b", "d392904c4dee4c41bb5985a5f466d472",
                domain: "eastasia.api.cognitive.microsoft.com")]
    public class LuisDialog : LuisDialog<Activity>
    {

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"말씀을 이해하지 못했습니다..\n";
            context.Done(activity);
        }

        [LuisIntent("Menu")]
        public async Task Menu(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = "menu";
            context.Done(activity);
        }


        [LuisIntent("Information")]
        public async Task InformationIntent(IDialogContext context, LuisResult result)
        {
            //입력받은 메시지가 숫자(번호메뉴)인 경우
            int number;
            if (Int32.TryParse(result.Query, out number))
            {
                var activity = context.MakeMessage();
                activity.Text = result.Query;
                context.Done(activity);
            }
            //입력받은 메시지가 텍스트인 경우
            else
            {
                //텍스트가 LUIS Entity 중 하나로 예측되면 메뉴이동으로 판단함
                if (result.Entities.Count == 1)
                {
                    var activity = context.MakeMessage();
                    activity.Text = result.Entities[0].Type;
                    context.Done(activity);
                }
                //텍스트가 LUIS Entity 중 여러개로 예측되면 
                //예측된 Entity를 출력해주고 다시 입력하게 함
                else if (result.Entities.Count >= 2)
                {
                    await this.AskAgain(context, result);
                }

                //텍스트를 특정한 메뉴로 알아듣지 못한 경우(Entity가 없으면)
                //정해진 메시지를 내보냄
                else
                {
                    var activity = context.MakeMessage();
                    activity.Text = RootDialog._storedvalues._sorryMessage;
                    context.Done(activity);
                }
            }
            return;
        }

        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"인사해 주셔서 감사해요. 좋은 하루 되시길 바랄게요!\n\n";

            context.Done(activity);
        }

        [LuisIntent("ChangeLanguage")]
        public async Task ChangeLanguage(IDialogContext context, LuisResult result)
        {
            if (result.Query.Contains("한국") || result.Query.Contains("korea"))
            {
                RootDialog._storedvalues = new StoredValues_kr();
            }   //convert en to kr
            else
            {
                RootDialog._storedvalues = new StoredValues_en();
            }
            var activity = context.MakeMessage();
            activity.Text = $"\nChanged Language settings. \n";
            context.Done(activity);
        }

        public async Task AskAgain(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            string str;
            string strSum = null;
            foreach (var s in result.Entities)
            {
                str = s.Type;
                switch (str)
                {
                    //기본 메뉴
                    case "_courseRegistration": strSum += "*" + RootDialog._storedvalues._courseRegistration + "\n"; break;
                    case "_courseInformation": strSum += "*" + RootDialog._storedvalues._courseInformation + "\n"; break;
                    case "_credits": strSum += "*" + RootDialog._storedvalues._credits + "\n"; break;
                    case "_others::_leaveOrReadmission": strSum += "*" + RootDialog._storedvalues._leaveOrReadmission + "\n"; break;
                    case "_others::_scholarship": strSum += "*" + RootDialog._storedvalues._scholarship + "\n"; break;
                    case "_help": await aboutHelp.HelpOptionSelected(context); break;
                    //수강신청 메뉴
                    case "_courseRegistration::_howToDoIt": strSum += "*" + RootDialog._storedvalues._howToDoIt + "\n"; break;
                    case "_courseRegistration::_schedule": strSum += "*" + RootDialog._storedvalues._schedule + "\n"; break;
                    case "_courseRegistration::_regulation": strSum += "*" + RootDialog._storedvalues._regulation + "\n"; break;
                    case "_courseRegistration::_terms": strSum += "*" + RootDialog._storedvalues._terms + "\n"; break;
                    //과목정보 메뉴
                    case "_courseInformation::_openedMajorCourses": strSum += "*" + RootDialog._storedvalues._openedMajorCourses + "\n"; break;
                    case "_courseInformation::_openedLiberalArts": strSum += "*" + RootDialog._storedvalues._openedLiberalArts + "\n"; break;
                    case "_courseInformation::_syllabus": strSum += "*" + RootDialog._storedvalues._syllabus + "\n"; break;
                    case "_courseInformation::_lecturerInfo": strSum += "*" + RootDialog._storedvalues._lecturerInfo + "\n"; break;
                    case "_courseInformation::_mandatorySubject": strSum += "*" + RootDialog._storedvalues._mandatorySubject + "\n"; break;
                    case "_courseInformation::_prerequisite": strSum += "*" + RootDialog._storedvalues._prerequisite + "\n"; break;
                    case "_courseInformation::_popular": strSum += "*" + RootDialog._storedvalues._popular + "\n"; break; ;
                    case "_courseInformation::_liberalSubject": strSum += "*" + RootDialog._storedvalues._LiberalSubject + "\n"; break;
                    //학점관리 메뉴
                    case "_credits::_currentCredits": strSum += "*" + RootDialog._storedvalues._currentCredits + "\n"; break;
                    case "_credits::_majorCredits": strSum += "*" + RootDialog._storedvalues._majorCredits + "\n"; break;
                    case "_credits::_liberalArtsCredits": strSum += "*" + RootDialog._storedvalues._liberalArtsCredits + "\n"; break;
                    case "_credits::_changeStuNum": strSum += "*" + RootDialog._storedvalues._changeStuNum + "\n"; break;
                    //도움말
                    case "_help::introduction": strSum += "*" + RootDialog._storedvalues._introduction + "\n"; break;
                    case "_help::_requestInformationCorrection": strSum += "*" + RootDialog._storedvalues._requestInformationCorrection + "\n"; break;
                    case "_help::_contactMaster": strSum += "*" + RootDialog._storedvalues._contactMaster + "\n"; break;
                }
            }
            activity.Text = $"\n{strSum}\n" +
                            $"{RootDialog._storedvalues._askAgain}";

            await context.PostAsync(activity.Text);
            context.Call(new LuisDialog(), RootDialog.LuisDialogResumeAfter);
        }
    }
}