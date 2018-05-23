using Microsoft.Bot.Builder.FormFlow;
using System;

namespace my_first_chatbot.Forms
{
    [Serializable]
    public class CourseEnrollForm
    {
        [Prompt("What's your Student ID?")]
        public int studentID { get; set; }
        [Prompt("please input your Password")]
        public string password { get; set; }

        //[Prompt("which course you want to register {||}")]
        public CourseList CourseName { get; set; }
               
        public enum CourseList
        {
            Algorithm, Machine_learning, Digital_Signal_Processing
        }

        public static IForm<CourseEnrollForm> BuildEnquiryForm()
        {
            return new FormBuilder<CourseEnrollForm>()
                //.Field("studentID")
                //.Field("password")
                //.AddRemainingFields()
                .Build();
        }
    }
}