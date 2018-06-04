using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace my_first_chatbot.Dialogs
{
    [Serializable]
    public class CancelDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {

            context.PostAsync(RootDialog._storedvalues._cancelMessage);
            context.Done<object>(null);
        }
    }
}