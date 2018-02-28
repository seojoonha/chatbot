using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using my_first_chatbot.Helper;
using System;

namespace my_first_chatbot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {

            StateClient stateClient = activity.GetStateClient();

            if (activity.Type == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                //return activity.CreateReply($""+activity.Text);
                string botresp = "";
                Rootobject obj = await LUIS.GetEntityFromLUIS(activity.Text);


                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);


                if (obj.intents[0].score > 0.5 && obj.intents[0].intent != "None" && obj.intents.Length > 0)
                {
                    switch (obj.intents[0].intent)
                    {
                        case "Greeting":
                            {
                                botresp = @"Hello, Welcome to AAR service! 안녕하세요 AAR을 이용해 주셔서 감사합니다.";
                                activity.Text = botresp;
                                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()); break;
                            }
                        case "Goodbye":
                            {
                                botresp = "Thanks, have a good day!";
                                activity.Text = botresp;
                                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()); break;
                            }
                        case "Registration":
                            {
                                // store last intet data
                                try
                                {
                                    userData.SetProperty<Rootobject>("UserData", obj);
                                    await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                                }
                                catch (Exception e) { }

                                foreach (var entity in obj.entities)
                                {

                                    if (entity.entity == "electronics") botresp += " You can not take " + entity.entity + " course at this time. first you need to take prerequisite course which is Fundamentals of circuit.\n";
                                    else { botresp += " you can take " + entity.entity + " at this time.\n"; }
                                }


                                activity.Text = botresp;
                                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()); break;
                            }
                        case "Course schedule":
                            {
                                botresp = "Yes, you have class today";
                                activity.Text = botresp;
                                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()); break;
                            }
                        case "Identity":
                            {
                                botresp = @"I’m chatbot and I’ll be an acadamic assistant for you :)
                                안녕하세요 수강신청을 도와드리는 AAR 챗봇입니다.";
                                activity.Text = botresp;
                                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()); break;
                            }
                    }
                }
                else
                {
                    botresp = "Sorry, I am not getting you...";
                    activity.Text = botresp;
                    await Conversation.SendAsync(activity, () => new Dialogs.RootDialog()); 
                }


                try
                {
                    string myUserData = userData.GetProperty<string>("UserData");
                }
                catch (Exception e) { }



            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}