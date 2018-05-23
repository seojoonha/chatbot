using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    [LuisModel("1c2971cf-2e31-4abb-9f03-0932c48fb838", "adc70e51f80e4c6a8431de30d094042b")]
    public class LuisDialog : LuisDialog<Activity>
    {
        /*public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }*/

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"죄송해요 모르는 말이에요..";
            //await context.PostAsync(activity);
            context.Done(activity);
        }

        [LuisIntent("information")]
        public async Task RequestinformationIntent(IDialogContext context, LuisResult result)
        {
            string strtemp = "";
            for (int i = 0; i < result.Entities.Count; i++)
            {
                strtemp = strtemp + (i + 1) + " Entities Type is" + result.Entities[i].Type + "  Entities Target Text is" + result.Entities[i].Entity + " ###";
            }
            var activity = context.MakeMessage();
            activity.Text = $"{strtemp} your intent is {result.Intents[0].Intent}. that's probablity is {result.Intents[0].Score}%. {result.Entities.Count} is Entities count // you said : {result.Query}";
            context.Done(activity);
        }



        [LuisIntent("greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"안녕하세요 AAR입니다." +
                             $"저는 명지대 정보통신공학과에서 만들었어요.\n";
            //await context.PostAsync(activity);
            context.Done(activity);
        }


        [LuisIntent("guide")]
        public async Task Guide(IDialogContext context, LuisResult result)
        {
            var activity = context.MakeMessage();
            activity.Text = $"안녕하세요. AAR입니다.\n" +
                $"메뉴번호를 입력하시거나 질문을 입력해 주세요.\n\n" +
                $"1. AAR 소개\n" +
                $"2. 나의 학사정보\n" +
                $"3. 나의 과목정보\n" +
                $"4. 특정 과목정보\n" +
                $"5. 명지대학교 홈페이지\n" +
                $"6. 명지대학교 Eclass\n\n" +
                $"메뉴를 다시 보고 싶으실땐 \n[메뉴]혹은 [처음으로]를 입력해 주세요.\n";
            context.Done(activity);
        }

        [LuisIntent("introduction")]
        public async Task Introduce(IDialogContext context, LuisResult result)
        {
            //if (context.Activity.From.Name == "kakao")
            //{
            var activity = context.MakeMessage();
            activity.Text = $"저는 AAR이에요.\n" +
                $"저는 명지대학교 정보통신공학과에서 만들었어요.\n" +
                $"사용한 기술들은 아래와 같아요.\n " +
                $"Microsoft Bot Framework\n" +
                $"Microsoft Azure LUIS\n" +
                $"Visual Studio 2017, C#\n" +
                $"Direct Line REST API 3.0\n" +
                $"Kakao Auto Reply API\n" +
                $"Bot Builder SDK\n";

            activity.Attachments.Add(new HeroCard           //카카오톡에선 제목과 부제목은 나오지 않는다.
            {
                Title = "명지대학교 홈페이지",
                Subtitle = "킹갓더 제네럴 명지대",
                Text = "명지대학교 홈페이지랍니다.",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/mbs/mjukr/images/newdesign/play.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "가즈아", value: "https://www.mju.ac.kr") }
            }.ToAttachment());

            context.Done(activity);
        }
    }
}