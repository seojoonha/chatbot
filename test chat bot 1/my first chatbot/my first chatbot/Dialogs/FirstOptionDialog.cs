using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class FirstOptionDialog : IDialog
    {
        private List<string> options = new List<string> { "Course Registeration", "Course Schedule", "Drop Course" };



        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("test3");
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("test4");
            //var message = await result;


            //PromptDialog.Choice<string>(
            //    context,
            //    this.DisplaySelectedCard,
            //    this.options,
            //    "What card would like to test?",
            //    "Ooops, what you wrote is not a valid option, please try again",
            //    3,
            //    PromptStyle.Auto);

            context.Done(new object());
        }

        private async Task DisplaySelectedCard(IDialogContext context, IAwaitable<string> result)
        {
            //var selectedOption = await result;
            //await context.PostAsync("You said: " + selectedOption);

            //var message = context.MakeMessage();
            //var attachment = GetHeroCard();
            //message.Attachments.Add(attachment);

            //await context.PostAsync(message);

            
        }

        private static Attachment GetHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "BotFramework Hero Card",
                //Subtitle = "Your bots — wherever your users are talking",
                //Text = "Build and connect intelligent bots to interact with your users naturally wherever they are, from text/sms to Skype, Slack, Office 365 mail and other popular services.",
                //Images = new List<CardImage> { new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg") },
                Buttons = new List<CardAction> {
                    new CardAction(ActionTypes.MessageBack, "Get Started", value: "https://docs.microsoft.com/bot-framework"),
                    new CardAction(ActionTypes.MessageBack, "Get Started", value: "https://docs.microsoft.com/bot-framework"),
                    new CardAction(ActionTypes.MessageBack, "Get Started", value: "https://docs.microsoft.com/bot-framework")}
            };

            return heroCard.ToAttachment();
        }

        public void dummyfunc() { }
    }
}