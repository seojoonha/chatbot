using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
    public static class StoredValues
    {
        // 기본 메뉴    welcome options
        public const string _courseRegistration                 = "수강 신청";
        public const string _courseInformation                  = "과목 정보";
        public const string _credits                            = "학점 관리";
        public const string _others                             = "기타 정보";
        public static List<string> _welcomeOptionsList          = new List<string> { _courseRegistration, _courseInformation, _credits, _others, _help };

        // 수강 신청 선택시 메뉴     course registration options
        public const string _howToDoIt                          = "수강신청 방법";             //웹 연결
        public const string _schedule                           = "수강신청 일정";              //웹 연결
        public const string _regulation                         = "수강신청 규정";            //웹 연결
        public const string _terms                              = "수강신청 용어";                 //우리가 정의? 혹은 웹 연결?
        public static List<string> _courseRegistrationOptions   = new List<string> { _howToDoIt, _schedule, _regulation, _terms, _gotostart, _help };

        // 과목 정보 선택시 메뉴     course info options
        public const string _openedCourses                      = "이번학기 개설과목";   //myiweb에 있는데 우짜지..
        public const string _syllabus                           = "강의계획서";                //이것도..
        public const string _lecturerInfo                       = "강사 정보";             //이것도..
        public const string _mandatorySubject                   = "필수과목 정보";      //이건 어떻게 가능
        public const string _prerequisite                       = "선수과목 정보";          //이것도 탐색
        public static List<string> _courseInfoOptions           = new List<string> { _openedCourses, _syllabus, _lecturerInfo, _mandatorySubject, _prerequisite, _gotostart, _help };

        // 학점 관리 선택시 메뉴     credit options
        public const string _currentCredits                     = "나의 이수학점";        //개인별 정보 필요
        public const string _majorCredits                       = "전공 학점";
        public const string _electiveCredits                    = "선택 학점";
        public static List<string> _creditsOptions              = new List<string> { _currentCredits, _majorCredits, _electiveCredits, _gotostart, _help };

        // 기타 정보 선택시 메뉴     others options
        public const string _leaveOrRejoin                      = "휴학 및 복학";         //웹 연결
        public const string _scholarship                        = "장학금 관련";            //웹 연결
        public static List<string> _othersOption                = new List<string> { _leaveOrRejoin, _scholarship, _gotostart, _help };

        // 도움말 선택시 메뉴       help options
        public const string _introduction                       = "AAR안내";         
        public const string _requestInformationCorrection       = "정보수정요청";
        public const string _contactMaster                      = "관리자 연결";
        public static List<string> _helpOptionsList             = new List<string> { _introduction, _requestInformationCorrection, _contactMaster, _gotostart };

        // 처음으로 혹은 도움말      goto start and help
        public const string _gotostart                          = "처음으로";          
        public const string _help                               = "도움말";                  

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