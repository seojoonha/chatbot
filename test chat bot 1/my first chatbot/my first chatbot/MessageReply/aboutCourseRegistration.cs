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
    public static class aboutCourseRegistration
    {
        public static async Task CourseRegistraionOptionSelected(IDialogContext context)
        {

            await context.PostAsync(RootDialog._storedvalues._typePleaseCourseRegistration);
            context.Call(new LuisDialog(), HandleCourseRegistrationOptionSelection);

        }
        public static async Task HandleCourseRegistrationOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {
            
            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_howToDoIt(context); break;
                case "2": await Reply_schedule(context); break;
                case "3": await Reply_regulation(context); break;
                case "4": await Reply_terms(context); break;
                default:
                    {
                        await RootDialog.GoToMenu(context, result);
                    }
                    break;
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_howToDoIt(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_HowToDoIt;

            activity.Attachments.Add(new HeroCard
            {
                Title = "수강신청 방법",
                Subtitle = "온라인서비스-학사운영-수강신청",          //Location of information in MJU homepage
                Text = "수강신청 방법\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1G4Vnh3vDnpZ5AXgwgSQy88k7wEgPermE") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_schedule(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Schedule;

            activity.Attachments.Add(new HeroCard
            {
                Title = "수강신청 일정",
                Subtitle = "온라인서비스-공지사항-일반공지",
                Text = "수강신청 일정\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1hkUuDnWVq4LgS5odnhda4CeZSkhdiET2") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_regulation(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Regulation;

            activity.Attachments.Add(new HeroCard
            {
                Title = "명지대학교 학칙",
                Subtitle = "2018.05.01 개정",
                Text = "명지대학교 학칙 [ 2018.05.01 ]\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://law.mju.ac.kr/lmxsrv/law/lawviewer.srv?lawseq=69&hseq=1571&refid=undefined") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_terms(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Terms;

            activity.Attachments.Add(new HeroCard
            {
                Title = "수강신청관련 용어정리",
                Subtitle = "수강신청관련 용어정리",
                Text = "수강신청관련 용어정리\n",
                //Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=13K60TUyp8Cim21w5jFmPZ-CWR5Ub-0iHDLtl8wbN0D0") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }
    }
}