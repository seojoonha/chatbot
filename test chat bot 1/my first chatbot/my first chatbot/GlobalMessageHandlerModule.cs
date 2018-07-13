//using Autofac;
//using my_first_chatbot.Dialogs;
//using Microsoft.Bot.Builder.Dialogs.Internals;
//using Microsoft.Bot.Builder.Scorables;
//using Microsoft.Bot.Connector;

//namespace my_first_chatbot
//{
//    public class GlobalMessageHandlerModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            base.Load(builder);

//            builder
//                .Register(c => new CancelScorable(c.Resolve<IDialogTask>()))
//                .As<IScorable<IActivity, double>>()
//                .InstancePerLifetimeScope();
//        }
//    }
//}