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
                StoredValues._courseRegistrationOptions,
                "수강 신청을 선택하셨습니다.\n세부항목을 선택해주세요.",                                                                                        //Course Registration
                "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.   [위치] : CourseRegistraionOptionSelected",          //Ooops, what you wrote is not a valid option, please try again
                3,
                PromptStyle.Auto);
            
        }
        public static async Task HandelCourseRegistrationOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;
            switch (value.ToString())                                                               //ToString이 없어도 되려나..?
            {
                case StoredValues._howToDoIt:       await Reply_howToDoIt(context);                 break;      //각각의 메서드에 연결
                case StoredValues._schedule:        await Reply_schedule(context);                  break;      //각각의 Dialog로 연결하는 것 보다 편한듯
                case StoredValues._regulation:      await Reply_regulation(context);                break;
                case StoredValues._terms:           await Reply_terms(context);                     break;
                case StoredValues._gotostart:       await RootDialog.ShowWelcomeOptions(context);   break;
                case StoredValues._help:            await aboutHelp.HelpOptionSelected(context);    break;
            }

            //await RootDialog.ShowWelcomeOptions(context);                                           //Return To Start
        }

        
        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_howToDoIt(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"수강신청 방법에 대한 안내입니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            activity.Attachments.Add(new HeroCard
            {
                Title = "수강신청 방법",
                Subtitle = "온라인서비스-학사운영-수강신청",          //Location of information in MJU homepage
                Text = "수강신청 방법",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/mbs/mjukr/images/title/tle5_5_4.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, 
                                                "정보로 이동", 
                                                value: "http://www.mju.ac.kr/mbs/mjukr/subview.jsp?id=mjukr_050504000000") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_schedule(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"수강신청 일정에 대한 안내입니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            activity.Attachments.Add(new HeroCard           
            {
                Title = "수강신청 일정",
                Subtitle = "온라인서비스-공지사항-일반공지",
                Text = "수강신청 일정",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/upload/board/11294/editor/20180130_094627346_91111.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, 
                                                "정보로 이동", 
                                                value: "http://www.mju.ac.kr/mbs/mjukr/jsp/board/view.jsp?spage=1&boardId=11294&boardSeq=79712853&mcategoryId=&id=mjukr_050101000000&search=%EC%88%98%EA%B0%95%EC%8B%A0%EC%B2%AD&column=TITLE&categoryDepth=&categoryId=0") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_regulation(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = $"수강신청 규정에 대한 안내입니다.\n" +
                            $"해당 페이지 3장 5절 제26조를 확인하십시오.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            activity.Attachments.Add(new HeroCard           
            {
                Title = "명지대학교 학칙",
                Subtitle = "2018.05.01 개정",
                Text = "명지대학교 학칙 [ 2018.05.01 ]",
                Images = new List<CardImage> { new CardImage("http://search.mju.ac.kr/RSA/front/images/logo.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, 
                                                "정보로 이동", 
                                                value: "http://law.mju.ac.kr/lmxsrv/law/lawviewer.srv?lawseq=69&hseq=1571&refid=undefined") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_terms(IDialogContext context)
        {
            await context.PostAsync("수강신청 용어정보가 없습니다.ㅠㅠ\n얼른 추가할게요!");
        }
    }
}