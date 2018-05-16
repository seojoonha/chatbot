using my_first_chatbot.Helper.StoredStringValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
    [Serializable]
    public class StoredValues_en : StoredStringValuesMaster
    {


        public StoredValues_en()
        {
            // 기본 메뉴    welcome options
            _courseRegistration = "Course Registration";
            _courseInformation = "Course Information";
            _credits = "Credits";
            _others = "Others";

            // 수강 신청 선택시 메뉴     course registration options
            _howToDoIt = "How to register";             //웹 연결
            _schedule = "Schedule";              //웹 연결
            _regulation = "Regulation";            //웹 연결
            _terms = "Terms";                 //우리가 정의? 혹은 웹 연결?

            // 과목 정보 선택시 메뉴     course info options
            _openedCourses = "Opened Courses";   //myiweb에 있는데 우짜지..
            _syllabus = "Syllabus";                //이것도..
            _lecturerInfo = "Lecture Info";             //이것도..
            _mandatorySubject = "Mandatory Subject";      //이건 어떻게 가능
            _prerequisite = "Prerequisite";          //이것도 탐색

            // 학점 관리 선택시 메뉴     credit options
            _currentCredits = "Current Credits";        //개인별 정보 필요
            _majorCredits = "Major Credits";
            _electiveCredits = "Elective Credits";

            // 기타 정보 선택시 메뉴     others options
            _leaveOrRejoin = "Leave Or Rejoin";         //웹 연결
            _scholarship = "Scholarship";            //웹 연결

            // 도움말 선택시 메뉴       help options
            _introduction = "AAR Guidance";
            _requestInformationCorrection = "정보수정요청";
            _contactMaster = "관리자 연결";

            // 처음으로 혹은 도움말      goto start and help
            _gotostart = "Go To Start";
            _help = "Help";

            _welcomeOptionsList = new List<string> { _courseRegistration, _courseInformation, _credits, _others, _help };
            _courseRegistrationOptions = new List<string> { _howToDoIt, _schedule, _regulation, _terms, _gotostart, _help };
            _courseInfoOptions = new List<string> { _openedCourses, _syllabus, _lecturerInfo, _mandatorySubject, _prerequisite, _gotostart, _help };
            _creditsOptions = new List<string> { _currentCredits, _majorCredits, _electiveCredits, _gotostart, _help };
            _othersOption = new List<string> { _leaveOrRejoin, _scholarship, _gotostart, _help };
            _helpOptionsList = new List<string> { _introduction, _requestInformationCorrection, _contactMaster, _gotostart };

        }

    }
}