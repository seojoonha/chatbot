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
    public static class aboutCourseInfo
    {
        public static async Task CourseInfoOptionSelected(IDialogContext context)
        {
            PromptDialog.Choice<string>(
                context,
                HandelCourseInfoOptionSelection,
                StoredValues._courseInfoOptions,
                "강의 정보",                                                                                 //Course Registration
                "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.   [위치] : CourseInfoOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        public static async Task HandelCourseInfoOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;
            switch (value.ToString())                                                              
            {
                case StoredValues._openedCourses:       await Reply_openedCourses(context);     break;      
                case StoredValues._syllabus:            await Reply_syllabus(context);          break;    
                case StoredValues._lecturerInfo:         await Reply_lecturerInfo(context);       break;
                case StoredValues._mandatorySubject:    await Reply_mandatorySubject(context);  break;
                case StoredValues._prerequisite:        await Reply_prerequisite(context);      break;
            }

            await RootDialog.ShowWelcomeOptions(context);           //Return To Start
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_openedCourses(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"이번학기 개설강의에 대한 안내입니다.\n" +
                            $"Myiweb내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            activity.Attachments.Add(new HeroCard
            {
                Title = "이번학기 개설강의",
                Subtitle = "학과별 강의시간표",          //Location of information in MJU homepage
                Text = "이번학기 개설강의정보",
                Images = new List<CardImage> { new CardImage("https://myiweb.mju.ac.kr/images/title/sue/t_sue335.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                "정보로 이동",
                                                value: "https://myiweb.mju.ac.kr/servlet/MyLocationPage?link=/su/sue/sue01/w_sue337pr.jsp#") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_syllabus(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"강의계획서에 대한 안내입니다.\n" +
                            $"Myiweb내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            activity.Attachments.Add(new HeroCard
            {
                Title = "강의계획서",
                Subtitle = "강의별 강의계획서",
                Text = "강의계획서정보",
                Images = new List<CardImage> { new CardImage("https://myiweb.mju.ac.kr/images/title/sue/t_sue390.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                "정보로 이동",
                                                value: "https://myiweb.mju.ac.kr/servlet/MyLocationPage?link=/su/sue/sue07/w_sue390Main.jsp") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_lecturerInfo(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"강사 정보에 대한 안내입니다.\n" +
                            $"Eclass내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            activity.Attachments.Add(new HeroCard
            {
                Title = "교수 정보",
                Subtitle = "교수 홈페이지 검색",
                Text = "교수 정보",
                //Images = new List<CardImage> { new CardImage("http://search.mju.ac.kr/RSA/front/images/logo.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                "정보로 이동",
                                                value: "http://home.mju.ac.kr/mainIndex/searchHomepage.action") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_mandatorySubject(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"필수과목 정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";
            
            await context.PostAsync(activity);
        }

        public static async Task Reply_prerequisite(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"선수과목 정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";

            await context.PostAsync(activity);
        }
    }
}