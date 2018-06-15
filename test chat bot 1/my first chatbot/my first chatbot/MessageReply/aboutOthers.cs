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
    public static class aboutOthers
    {
        public static async Task OtherOptionSelected(IDialogContext context)
        {

            await context.PostAsync(RootDialog._storedvalues._typePleaseOthers);
            context.Call(new LuisDialog(), HandleOtherOptionSelection);

        }
        public static async Task HandleOtherOptionSelection(IDialogContext context, IAwaitable<Activity> result)
        {

            var message = await result;

            switch (message.Text)
            {
                case "1": await Reply_leaveOrReadmission(context); break;
                case "2": await Reply_scholarship(context); break;
                case "3": await aboutHelp.HelpOptionSelected(context); break;
                default:
                    {
                        await context.PostAsync(message);
                    }
                    break;
            }
        }


        //================================================================================================================================================
        //Last Phase Option

        public static async Task Reply_leaveOrReadmission(IDialogContext context)
        {


            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_leaveOrReadmission;

            activity.Attachments.Add(new HeroCard
            {
                Title = "휴학 및 복학관련 정보입니다.",
                Subtitle = "휴학 및 복학관련 정보입니다.",          //Location of information in MJU homepage
                Text = "휴학 및 복학관련 정보입니다.\n",
                Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=1YXE91epV_0_l8_lsgkXn1f9rYeF4_DfG") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

        public static async Task Reply_scholarship(IDialogContext context)
        {
            var activity = context.MakeMessage();
            activity.Text = RootDialog._storedvalues._reply_Scholarship;

            activity.Attachments.Add(new HeroCard
            {
                Title = "장학금관련 정보입니다.",
                Subtitle = "장학금관련 정보입니다.",          //Location of information in MJU homepage
                Text = "장학금관련 정보입니다.\n",
                Images = new List<CardImage> { new CardImage("http://www.kimaworld.net/data/file/char/3076632059_6ySVa5o9_EBAA85ECA7801.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl,
                                                RootDialog._storedvalues._goToButton,
                                                value: "https://drive.google.com/open?id=112Fs5ZE3ek3AzQBiCrKLXLuLxkWCPvo_") }
            }.ToAttachment());

            await context.PostAsync(activity);
        }

    }
}