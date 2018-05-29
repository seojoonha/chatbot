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
    [LuisModel("b764b107-9ed2-4f9e-ad3f-9251430dafa8", "be608df8436f4ccea3bec7a39f2a03a5")]
    public class LuisDialog : LuisDialog<Activity>
    {
        /*
            string strtemp = "";
            for (int i = 0; i < result.Entities.Count; i++)
            {
                strtemp = strtemp + (i + 1) + " Entitie의 타입은 : " + result.Entities[i].Type + "  Entitie의 Target Text는 " + result.Entities[i].Entity + " 입니다.###";
            }
            var activity = context.MakeMessage();
            activity.Text = $"{strtemp} Intent는 {result.Intents[0].Intent}. 해당 Intent일 확률은 {result.Intents[0].Score}% 입니다. {result.Entities.Count} is Entities count //";
            context.Done(activity);
        */

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"말씀을 이해하지 못했습니다..\n";
            context.Done(activity);
        }

        [LuisIntent("goToStart")]
        [LuisIntent("Menu")]
        public async Task Menu(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"메뉴를 불러옵니다.\n";
            context.Done(activity);
        }


        [LuisIntent("Information")]
        public async Task InformationIntent(IDialogContext context, LuisResult result)
        {
            var strtmp = result.Entities[0].Type;
            //if (strtmp == "_courseRegistration") await aboutCourseRegistration.CourseRegistraionOptionSelected(context);
            //else if (strtmp == "_courseInformation") await aboutCourseInfo.CourseInfoOptionSelected(context);
            //else if (strtmp == "_credits") await aboutCredits.CreditsOptionSelected(context);
            //else if (strtmp == "_others") await aboutOthers.OtherOptionSelected(context);
            //else
            //{
            //    var activity = context.MakeMessage();
            //    activity.Text = $"Information intent error.";
            //    context.Done(activity);
            //}

            switch (strtmp)
            {
                //기본 메뉴
                case "_courseRegistration": await aboutCourseRegistration.CourseRegistraionOptionSelected(context); break;
                case "_courseInformation": await aboutCourseInfo.CourseInfoOptionSelected(context); break;
                case "_credits": await aboutCredits.CreditsOptionSelected(context); break;
                case "_others": await aboutOthers.OtherOptionSelected(context); break;
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
                //학점관리 메뉴
                //아직 구현안함
                case "_credits::_currentCredits": await aboutCredits.Reply_currentCredits(context); break;
                case "_credits::_majorCredits": await aboutCredits.Reply_majorCredits(context); break;
                case "_credits::_liberalArtsCredits": await aboutCredits.Reply_liberalArtsCredits(context); break;
                case "_credits::_changeStuNum": break;
                //기타 메뉴
                case "_others::_leaveOrReadmission": await aboutOthers.Reply_leaveOrReadmission(context); break;
                case "_others::_scholarship": await aboutOthers.Reply_scholarship(context); break;

                //번호 메뉴 인식
                case "_number":
                    {
                        var activity = context.MakeMessage();
                        activity.Text = result.Query;
                        context.Done(activity);
                    }
                    break;

                //디버그용
                case null:
                    {
                        var activity = context.MakeMessage();
                        activity.Text = $"Entity not delivered.\n";
                        context.Done(activity);
                    }
                    break;
                default:
                    {
                        var activity = context.MakeMessage();
                        activity.Text = $"Information intent error.\n";
                        context.Done(activity);
                    }
                    break;
            }
            return;
        }


        [LuisIntent("Help")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {
            var strtmp = result.Entities[0].Type;

            switch (strtmp)
            {
                //도움말 메뉴 
                //언어변경 메뉴는 넣지 않음.
                case "_help": await aboutHelp.HelpOptionSelected(context); break;
                case "_help::_introduction": await aboutHelp.Reply_introduction(context); break;
                case "_help::_requestInformationCorrection": await aboutHelp.Reply_requestInformationCorrection(context); break;
                case "_help::_contactMaster": await aboutHelp.Reply_contactMaster(context); break;
                //디버그용
                default:
                    {
                        var activity = context.MakeMessage();
                        activity.Text = $"Help intent error.\n";
                        context.Done(activity);
                    }
                    break;
            }
            return;
        }

        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"인사해주셔서 감사해요." +
                             $"좋은하루 되시길 바랄게요 :)\n";

            context.Done(activity);
        }

        [LuisIntent("ChangeLanguage")]
        public async Task ChangeLanguage(IDialogContext context, LuisResult result)
        {
            if (result.Query.Contains("한국"))
            {
                RootDialog._storedvalues = new StoredValues_kr();
            }   //for convert en to kr
            else
            {
                RootDialog._storedvalues = new StoredValues_en();
            }
            var activity = context.MakeMessage();
            activity.Text = $"\nChanged Language settings. \n";
            context.Done(activity);
        }

        [LuisIntent("meal")]
        public async Task meal(IDialogContext context, LuisResult result)
        {

        }
    }
}