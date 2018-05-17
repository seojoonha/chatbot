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
                RootDialog._storedvalues._courseInfoOptions,
                RootDialog._storedvalues._courseInfoSelected,                                                                                 //Course Registration
                RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : CourseInfoOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        public static async Task HandelCourseInfoOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);

            else if (value.ToString() == RootDialog._storedvalues._help) await aboutHelp.HelpOptionSelected(context);

            else
            {
                if (value.ToString() == RootDialog._storedvalues._openedCourses) await Reply_openedCourses(context);
                else if (value.ToString() == RootDialog._storedvalues._syllabus) await Reply_syllabus(context);
                else if (value.ToString() == RootDialog._storedvalues._lecturerInfo) await Reply_lecturerInfo(context);
                else if (value.ToString() == RootDialog._storedvalues._mandatorySubject) await Reply_mandatorySubject(context);
                else if (value.ToString() == RootDialog._storedvalues._prerequisite) await Reply_prerequisite(context);
                
                await RootDialog.ShowWelcomeOptions(context);           //Return To Start
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_openedCourses(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_OpenedCourses;

            activity.Attachments.Add(new HeroCard
            {
                Title = "이번학기 개설강의",
                Subtitle = "학과별 강의시간표",          //Location of information in MJU homepage
                Text = "이번학기 개설강의정보",
                Images = new List<CardImage> { new CardImage("https://myiweb.mju.ac.kr/images/title/sue/t_sue335.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://myiweb.mju.ac.kr/servlet/MyLocationPage?link=/su/sue/sue01/w_sue337pr.jsp#") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_syllabus(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Syllabus;

            activity.Attachments.Add(new HeroCard
            {
                Title = "강의계획서",
                Subtitle = "강의별 강의계획서",
                Text = "강의계획서정보",
                Images = new List<CardImage> { new CardImage("https://myiweb.mju.ac.kr/images/title/sue/t_sue390.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://myiweb.mju.ac.kr/servlet/MyLocationPage?link=/su/sue/sue07/w_sue390Main.jsp") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_lecturerInfo(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_LecturerInfo;

            activity.Attachments.Add(new HeroCard
            {
                Title = "교수 정보",
                Subtitle = "교수 홈페이지 검색",
                Text = "교수 정보",
                //Images = new List<CardImage> { new CardImage("http://search.mju.ac.kr/RSA/front/images/logo.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://home.mju.ac.kr/mainIndex/searchHomepage.action") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_mandatorySubject(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_MandatorySubject;

            await context.PostAsync(activity);
        }

        public static async Task Reply_prerequisite(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Prerequisite;

            await context.PostAsync(activity);
        }
    }
}