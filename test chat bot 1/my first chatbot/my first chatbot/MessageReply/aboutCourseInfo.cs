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

            await context.PostAsync(RootDialog._storedvalues._typePleaseCourseInfo);
            context.Call(new LuisDialog(), HandleCourseInfoOptionSelection);

        }
        public static async Task HandleCourseInfoOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {

            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_openedMajorCourses(context); break;
                case "2": await Reply_openedLiberalArts(context); break;
                case "3": await Reply_syllabus(context); break;
                case "4": await Reply_lecturerInfo(context); break;
                case "5": await Reply_mandatorySubject(context); break;
                case "6": await Reply_prerequisite(context); break;
                case "7": await LiberalOptionSelected(context, null); break;
                case "8": await PopularOptionSelected(context); break;

                default:
                    {
                        await RootDialog.GoToMenu(context, result);
                    }
                    break;
            }
        }

        public static async Task PopularOptionSelected(IDialogContext context)
        {
            PromptDialog.Choice<string>(
                context,
                Reply_popular,
                RootDialog._storedvalues._popularOptionsList,
                RootDialog._storedvalues._popularOptionSelected,                                                                                 //Course Registration
                RootDialog._storedvalues._sorryMessage + "[ERROR] : CourseInfoOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);
        }
        public static async Task LiberalOptionSelected(IDialogContext context, IAwaitable<object> result)
        {
            if (RootDialog.stuNum == 0)
            {
                await context.PostAsync(RootDialog._storedvalues._getStudentNumMessage);
                context.Call(new GetInfoDialog(), LiberalOptionSelected);                //get student number
            }
            else
            {

                PromptDialog.Choice<string>(
                context,
                Reply_liberalSubject,
                RootDialog._storedvalues._liberalOptionsList,
                $"{RootDialog._storedvalues._liberalOptionSelected}\n" +
                                $"▶현재 설정된 학번: " +
                                $"{RootDialog.stuNum}\n",
                RootDialog._storedvalues._sorryMessage + "[ERROR] : CreditOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                1,
                PromptStyle.Auto);

            }
        }
        public static async Task HandleLiberalOptionSelection(IDialogContext context, IAwaitable<object> result)
        {

        }
        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_openedMajorCourses(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_OpenedMajorCourses;

            activity.Attachments.Add(new HeroCard
            {
                Title = "이번학기 전공개설강의",
                Subtitle = "이번학기 전공개설강의",          //Location of information in MJU homepage
                Text = "이번학기 전공개설강의정보\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1iVNvUHc2-Qs_AXWGgnXpsPx3mp0BWCK7") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_openedLiberalArts(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_openedLiberalArts;

            activity.Attachments.Add(new HeroCard
            {
                Title = "이번학기 교양개설강의",
                Subtitle = "이번학기 교양개설강의",          //Location of information in MJU homepage
                Text = "이번학기 교양개설강의정보\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1Q7Ej1JB2OHcBP-TjXEdZYWz8H7ncUtpd") }
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
                Text = "강의계획서 열람 방법\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1Yn5FBeBVedQdodPsnM3I_1kWcKyL2abM") }
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
                Text = "교수 홈페이지 검색 페이지\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
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

            activity.Attachments.Add(new HeroCard
            {
                Title = "정보통신공학과 이수체계도",
                Subtitle = "정보통신공학과 이수체계도",
                Text = "정보통신공학과 이수체계도\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1Fy7bAxihUXqlNLLToimYcKSiTHg_XdGe") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_prerequisite(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Prerequisite;

            activity.Attachments.Add(new HeroCard
            {
                Title = "정보통신공학과 선후수 과목정보",
                Subtitle = "정보통신공학과 선후수 과목정보",
                Text = "정보통신공학과 선후수 과목정보\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://www.mju.ac.kr/mbs/mjukr/images/editor/1406095802964_img_2017.jpg") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }
        public static async Task Reply_popular(IDialogContext context, IAwaitable<string> result)
        {

            var message = await result;
            var activity = context.MakeMessage();

            if (message == RootDialog._storedvalues.a) { activity.Text = RootDialog.popinfo.totalpopularity(0); }
            else if (message == RootDialog._storedvalues.b) { activity.Text = RootDialog.popinfo.totalpopularity(1); }
            else if (message == RootDialog._storedvalues.c) { activity.Text = RootDialog.popinfo.totalpopularity(2); }
            else if (message == RootDialog._storedvalues.d) { activity.Text = RootDialog.popinfo.totalpopularity(3); }
            else if (message == RootDialog._storedvalues.e) { activity.Text = RootDialog.popinfo.totalpopularity(4); }
            else if (message == RootDialog._storedvalues.f) { activity.Text = RootDialog.popinfo.totalpopularity(5); }
            else if (message == RootDialog._storedvalues.g) { activity.Text = RootDialog.popinfo.totalpopularity(6); }
            else if (message == RootDialog._storedvalues.h) { activity.Text = RootDialog.popinfo.totalpopularity(7); }

            await context.PostAsync(activity);

        }
        public static async Task Reply_liberalSubject(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            var activity = context.MakeMessage();

            if (message == RootDialog._storedvalues.a) { activity.Text = RootDialog.popinfo.totalpopularity(0); }
            else if (message == RootDialog._storedvalues.i) { activity.Text = RootDialog.LAService.LiberalArtsGetList(RootDialog.stuNum, 1); }
            else if (message == RootDialog._storedvalues.j) { activity.Text = RootDialog.LAService.LiberalArtsGetList(RootDialog.stuNum, 2); }
            else if (message == RootDialog._storedvalues.k) { activity.Text = RootDialog.LAService.LiberalArtsGetList(RootDialog.stuNum, 3); }
            else if (message == RootDialog._storedvalues.l) { activity.Text = RootDialog.LAService.LiberalArtsGetList(RootDialog.stuNum, 4); }
            else if (message == RootDialog._storedvalues.m) { await Reply_changeStuNum(context); }
            await context.PostAsync(activity);
        }
        public static async Task Reply_changeStuNum(IDialogContext context)         //학번 재설정
        {
            await context.PostAsync(RootDialog._storedvalues._reply_ChangeStuNum + RootDialog.stuNum);            //메시지를 보낸다.
            context.Call(new GetInfoDialog(), LiberalOptionSelected);     //바로 학번입력으로 간다.
        }
    }
}