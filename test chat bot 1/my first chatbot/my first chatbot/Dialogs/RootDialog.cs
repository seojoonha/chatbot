using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using my_first_chatbot.Helper;
using my_first_chatbot.Forms;
using my_first_chatbot.MessageReply;
using Microsoft.Bot.Builder.FormFlow;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }


        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await ShowWelcomeOptions(context);
        }


        public static async Task ShowWelcomeOptions(IDialogContext context) {
            PromptDialog.Choice<string>(
                context,
                HandelWelcomeOptionSelected,
                StoredValues._welcomeOptionsList,
                "Welcome to the ICT department bot service. What can i help you?",
                "Ooops, what you wrote is not a valid option, please try again",
                3,
                PromptStyle.Auto);
        }


        public static async Task HandelWelcomeOptionSelected(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            switch (value.ToString()) {
                case StoredValues._courseRegistration:  await aboutCourseRegistration.CourseRegistraionOptionSelected(context);     break;
                case StoredValues._courseInformation:   await aboutCourseInfo.CourseInfoOptionSelected(context);                    break;
                case StoredValues._credits:             await aboutCredits.CreditsOptionSelected(context);                          break;
                case StoredValues._others:              await aboutOthers.OtherOptionSelected(context);                             break;
                default:                                await ForUnimplementedOptions(context, value);                              break;
            }

        }
        

        private static async Task ForUnimplementedOptions(IDialogContext context, string selectedOption)       //그 외 말을 했을 때
        {
            var activity = context.MakeMessage();
            activity.Text = $"요청하신 정보는 " + selectedOption + "입니다.\n" +          //"You said: " + selectedOption
                            $"추후 추가예정 입니다.\n";                                   //"Thanks for using AAR!!!. See u soon"
            await context.PostAsync(activity);
        }














        //=================================================================================================================
        //=================================================================================================================
        //=================================================================================================================
        //=================================================================================================================
        //=================================================================================================================
        /*
        private async Task showOptions(IDialogContext context)
        {
            PromptDialog.Choice<string>(
                context,
                this.handelFirstOptionSelection,
                StoredValues.firstOptionsList,
                "Welcome to AAR service. What can i help you?",
                "Ooops, what you wrote is not a valid option, please try again",
                3,
                PromptStyle.Auto);
        }

        private async Task handelFirstOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var selectedOption = await result;
            switch (selectedOption)
            {
                case StoredValues.course_registraion: { await courseRegistraionOptionsSelected(context); break; }
                case StoredValues.graduation_requirement: { await for_unimplemented_options(context, StoredValues.graduation_requirement); break; }
                case StoredValues.graduate_school_info: { await for_unimplemented_options(context, StoredValues.graduate_school_info); break; }
                case StoredValues.phase_complete_subject: { await for_unimplemented_options(context, StoredValues.phase_complete_subject); break; }
                case StoredValues.syllabus: { await for_unimplemented_options(context, StoredValues.syllabus); break; }
                case StoredValues.aggrement_of_terms: { await for_unimplemented_options(context, StoredValues.aggrement_of_terms); break; }
                case StoredValues.cancel_criteria: { await for_unimplemented_options(context, StoredValues.cancel_criteria); break; }
            }
        }

        private async Task for_unimplemented_options(IDialogContext context, string selectedOption)
        {
            await context.PostAsync("You said: " + selectedOption);
            await context.PostAsync("Thanks for using AAR!!!. See u soon");
            await this.showOptions(context);
        }

        private async Task courseRegistraionOptionsSelected(IDialogContext context)
        {

            PromptDialog.Choice<string>(
                context,
                this.handelCourseRegistrationOptionsSelection,
                StoredValues.course_registration_options,
                "Course Registration",
                "Ooops, what you wrote is not a valid option, please try again",
                3,
                PromptStyle.Auto);
        }

        private async Task handelCourseRegistrationOptionsSelection(IDialogContext context, IAwaitable<string> result)
        {
            var selectedOption = await result;
            //await context.PostAsync("wow on the second stage =>" + selectedOption);

            switch (selectedOption)
            {
                case StoredValues.course_registraion_period: { handelCourseRegistrationPeriodOptionSelection(context); break; }
                case StoredValues.how_to_enroll: { handelHowToEnrollOptionSelection(context); break; }
                case StoredValues.enroll: { handelEnrollOptionSelection(context); break;}
                case StoredValues.course_change_period: break;
                case StoredValues.withdrawal: break;
            }

        }
        
        private async Task handelCourseRegistrationPeriodOptionSelection(IDialogContext context)
        {
           
            try
            {
                var reply = context.MakeMessage();
                var attachment = getRegistrationInfoCard();
                reply.Attachments.Add(attachment);
                await context.PostAsync(reply);
            }
            catch (Exception ee)
            {
                string mys = ee.Message;
                await context.PostAsync("error found on redering =>"+ ee.Message);
            }
            await context.PostAsync("Course registration period starts in sep 14 and end on oct 2");

        }

        private Attachment getRegistrationInfoCard()
        {
            var heroCard = new HeroCard
            {
                Title = "MJU Registration Period",
                Subtitle = "Course registration is open for summer semester",
                Text = "The course registration peroid lasts for only 10 days. It starts from Aug - 15 to Aug - 25",
                Images = new List<CardImage> { new CardImage("http://www.mju.ac.kr/mbs/mjukr/images/newdesign/img_01_on.jpg") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Read More", value: "http://www.mju.ac.kr/mbs/mjukr/index.jsp?SWIFT_SESSION_CHK=false") }
            };

            return heroCard.ToAttachment();
        }

        private async Task handelHowToEnrollOptionSelection(IDialogContext context)
        {
            string howtoenroll = "1. login to myiweb" + Environment.NewLine;
            howtoenroll += "2. goto course selection page" + Environment.NewLine;
            howtoenroll += "3. Select the course you want to register and add it to the course list" + Environment.NewLine;
            howtoenroll += "4. save and exit the webpage" + Environment.NewLine;

            await context.PostAsync(howtoenroll);
        }

        private async Task FirstOptionDialogResumeAfter(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("on the call back");
        }


        private void handelEnrollOptionSelection(IDialogContext context)
        {
            //Chain.From(() => FormDialog.FromForm(CourseEnrollForm.BuildEnquiryForm));
            var myform = new FormDialog<CourseEnrollForm>(new CourseEnrollForm(), CourseEnrollForm.BuildEnquiryForm, FormOptions.PromptInStart, null);

            context.Call<CourseEnrollForm>(myform, FirstOptionDialogResumeAfter);

            //context.Call(form, this.FirstOptionDialogResumeAfter);
        }
        */



    }
}