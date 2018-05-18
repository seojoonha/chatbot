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
            PromptDialog.Choice<string>(
                context,
                HandelCourseRegistrationOptionSelection,
                RootDialog._storedvalues._courseRegistrationOptions,
                RootDialog._storedvalues._courseRegistrationSelected,                                                                                        //Course Registration
                RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : CourseRegistraionOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);

        }
        public static async Task HandelCourseRegistrationOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);

            else if (value.ToString() == RootDialog._storedvalues._help) await aboutHelp.HelpOptionSelected(context);

            else
            {
                if (value.ToString() == RootDialog._storedvalues._howToDoIt) await Reply_howToDoIt(context);      //각각의 메서드에 연결
                else if (value.ToString() == RootDialog._storedvalues._schedule) await Reply_schedule(context);     //각각의 Dialog로 연결하는 것 보다 편한듯
                else if (value.ToString() == RootDialog._storedvalues._regulation) await Reply_regulation(context);
                else if (value.ToString() == RootDialog._storedvalues._terms) await Reply_terms(context);

                //await RootDialog.ShowWelcomeOptions(context);                  //Return To Start
                await aboutCourseRegistration.CourseRegistraionOptionSelected(context);
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
                Text = "수강신청 방법",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/mbs/mjukr/images/title/tle5_5_4.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://www.mju.ac.kr/mbs/mjukr/subview.jsp?id=mjukr_050504000000") }
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
                Text = "수강신청 일정",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/upload/board/11294/editor/20180130_094627346_91111.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://www.mju.ac.kr/mbs/mjukr/jsp/board/view.jsp?spage=1&boardId=11294&boardSeq=79712853&mcategoryId=&id=mjukr_050101000000&search=%EC%88%98%EA%B0%95%EC%8B%A0%EC%B2%AD&column=TITLE&categoryDepth=&categoryId=0") }
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
                Text = "명지대학교 학칙 [ 2018.05.01 ]",
                Images = new List<CardImage> { new CardImage("http://search.mju.ac.kr/RSA/front/images/logo.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "http://law.mju.ac.kr/lmxsrv/law/lawviewer.srv?lawseq=69&hseq=1571&refid=undefined") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_terms(IDialogContext context)
        {
            await context.PostAsync(RootDialog._storedvalues._reply_Terms);
        }
    }
}