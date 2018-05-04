using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
    public static class StoredValues
    {
        //first level options
        public const string course_registraion = "Course Reg.";
        public const string graduation_requirement = "Graduation Requirement";
        public const string graduate_school_info = "Graduate school info";
        public const string phase_complete_subject = "Phase Compelete Subject";
        public const string syllabus = "Syllabus";
        public const string aggrement_of_terms = "Aggrement of Therms";
        public const string cancel_criteria = "Cancel class criteria";

        // course registration options
        public const string course_registraion_period = "Course Registration Period";
        public const string how_to_enroll = "How to enroll";
        public const string enroll = "register course";
        public const string course_change_period = "Course Change Period";
        public const string withdrawal = "Withdrawal Period";

        public static List<string> firstOptionsList = new List<string> {
            course_registraion,graduation_requirement,graduate_school_info,phase_complete_subject,syllabus,aggrement_of_terms,cancel_criteria
        };

        public static List<string> course_registration_options = new List<string> {
            course_registraion_period,how_to_enroll,enroll,course_change_period,withdrawal
        };
    }
}