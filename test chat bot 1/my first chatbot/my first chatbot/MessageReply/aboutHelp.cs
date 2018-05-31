﻿using Microsoft.Bot.Builder.Dialogs;
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
    public static class aboutHelp
    {
        public static async Task HelpOptionSelected(IDialogContext context)
        {
            //텍스트 입력방식
            await context.PostAsync(RootDialog._storedvalues._typePleaseHelp);
            context.Call(new LuisDialog(), HandleHelpOptionSelection);

            //버튼방식
            //PromptDialog.Choice<string>(
            //    context,
            //    HandleHelpOptionSelected,
            //    RootDialog._storedvalues._helpOptionsList,
            //    RootDialog._storedvalues._helpOptionSelected,           //선택시 출력되는 메시지 정의
            //    RootDialog._storedvalues._invalidSelectionMessage + "[ERROR] : ShowHelpOptions",    //오류시 표시될 메시지 정의
            //    1,
            //    PromptStyle.Auto);
        }


        public static async Task HandleHelpOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {

            //텍스트 입력방식
            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_introduction(context); break;
                case "2": await Reply_requestInformationCorrection(context); break;
                case "3": await Reply_contactMaster(context); break;
                case "4": break;//go to start
                default:
                    {
                        await context.PostAsync(message);
                    }
                    break;
            }
            await RootDialog.ShowWelcomeOptions(context);

            //버튼방식
            //var value = await result;
            //if (value.ToString() == RootDialog._storedvalues._gotostart) await RootDialog.ShowWelcomeOptions(context);          //웰컴이 두번 불러지는 문제인가?
            //else
            //{
            //    if (value.ToString() == RootDialog._storedvalues._introduction) await Reply_introduction(context);     //이거 룻다이알로그에 스토얼 가져와서 인듯
            //    else if (value.ToString() == RootDialog._storedvalues._requestInformationCorrection) await Reply_requestInformationCorrection(context);
            //    else if (value.ToString() == RootDialog._storedvalues._contactMaster) await Reply_contactMaster(context);
            //    else if (value.ToString() == RootDialog._storedvalues._convertLanguage)
            //    {
            //        if (RootDialog._storedvalues._convertLanguage == "한국어") RootDialog._storedvalues = new StoredValues_kr();   //for convert en to kr
            //        else RootDialog._storedvalues = new StoredValues_en();                                  //for convert kr to en
            //    }

            //    //await RootDialog.ShowWelcomeOptions(context);                  //Return To Start
            //    await HelpOptionSelected(context);
            //}

        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_introduction(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Introduction;
            await context.PostAsync(activity);
        }

        public static async Task Reply_requestInformationCorrection(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_RequestInformationCorrection;

            await context.PostAsync(activity);
        }

        public static async Task Reply_contactMaster(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_ContactMaster;

            await context.PostAsync(activity);
        }


    }
}