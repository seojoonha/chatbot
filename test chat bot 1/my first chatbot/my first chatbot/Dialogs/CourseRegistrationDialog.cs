using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using my_first_chatbot.Helper;
using Microsoft.Bot.Connector;

namespace my_first_chatbot.Dialogs
{
    public class CourseRegistrationDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("from the dialog");
            context.Wait(showCourseRegistrationOptions);
        }

        public async Task showCourseRegistrationOptions(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            PromptDialog.Choice(
                context,
                this.handelCourseRegistrationOptionSelection,
                StoredValues._courseRegistrationOptions,
                "Course Registration",
                "Ooops, what you wrote is not a valid option, please try again",
                3,
                PromptStyle.Auto);
        }

        private async Task handelCourseRegistrationOptionSelection(IDialogContext context, IAwaitable<string> result)
        {
            var value = await result;

            await context.PostAsync("the selected value is "+ value.ToString());
            context.Done("done");

        }
    }
}