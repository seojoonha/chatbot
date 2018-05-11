using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
    public static class StoredValues
    {
        // welcome options
        public const string _courseRegistration = "Course Registration";
        public const string _courseInformation = "Course Information";
        public const string _credits = "Credits";
        public const string _others = "Others";
        public static List<string> _welcomeOptionsList = new List<string> { _courseRegistration, _courseInformation , _credits, _others };

        // course registration options
        public const string _howToDoIt = "How to register";
        public const string _schedule = "Schedule";
        public const string _regulation = "Regulation";
        public const string _terms = "Terms";
        public static List<string> _courseRegistrationOptions = new List<string> {_howToDoIt,_schedule,_regulation,_terms };

        // course info options
        public const string _openedCourses = "Opened Courses";
        public const string _syllabus = "Syllabus";
        public const string _lectureInfo = "Lecture info";
        public const string _mandatorySubject = "Mandatory Subject";
        public const string _prerequisite = "Prerequisite";
        public static List<string> _courseInfoOptions = new List<string> { _openedCourses,_syllabus,_lectureInfo,_mandatorySubject,_prerequisite };

        // credit options
        public const string _currentCredits = "Current Credits";
        public const string _majorCredits = "Major Credits";
        public const string _electiveCredits = "Elective Credits";
        public static List<string> _creditsOptions = new List<string> { _currentCredits, _majorCredits, _electiveCredits };

        //others options
        public const string _leaveOrRejoin = "Leave Or Rejoin";
        public const string _scholarship = "Scholarship";
        public static List<string> _othersOption = new List<string> { _leaveOrRejoin,_scholarship};

        //======================================================================================================

        public const string course_registraion = "Course Reg.";
        public const string graduation_requirement = "Graduation Requirement";
        public const string graduate_school_info = "Graduate school info";
        public const string phase_complete_subject = "Phase Compelete Subject";
        public const string syllabus = "Syllabus";
        public const string aggrement_of_terms = "Aggrement of Therms";
        public const string cancel_criteria = "Cancel class criteria";

        
        public const string course_registraion_period = "Period";
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