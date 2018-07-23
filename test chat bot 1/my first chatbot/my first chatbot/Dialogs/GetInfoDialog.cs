using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using my_first_chatbot.Helper;
using my_first_chatbot.Forms;
using my_first_chatbot.MessageReply;
using Microsoft.Bot.Builder.FormFlow;
using my_first_chatbot.Helper.StoredStringValues;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class GetInfoDialog : IDialog<bool>
    {
        private int attempts = 3;
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            int number;

            //학번을 8자리 숫자로만 입력받음
            if (Int32.TryParse(message.Text, out number) && (message.Text.Length == 8) && !(number==0))
            {
                if(RootDialog.stuNum == 0)
                {
                    await context.PostAsync("학번이 설정되었습니다\n");
                }
                else
                {
                    await context.PostAsync("학번이 변경되었습니다.\n");
                }
                RootDialog.stuNum = number;
                context.Done(true);
            }
            else
            {
                --attempts;
                if (attempts > 0)
                {
                    await context.PostAsync(RootDialog._storedvalues._getStudentNumRetry);

                    context.Wait(this.MessageReceivedAsync);
                }
                else
                {
                    context.Done(false);
                }
            }
        }
    }
}