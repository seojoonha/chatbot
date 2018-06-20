using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper.StoredStringValues
{
    [Serializable]
    public class StoredStringValuesMaster
    {
        public string _printLine;
        // 기본 메뉴    welcome options
        public string _courseRegistration;
        public string _courseInformation;
        public string _credits;
        public string _others;
        public string _typeself;

        // 수강 신청 선택시 메뉴     course registration options
        public string _howToDoIt;             //웹 연결
        public string _schedule;              //웹 연결
        public string _regulation;            //웹 연결
        public string _terms;                 //우리가 정의? 혹은 웹 연결?

        // 과목 정보 선택시 메뉴     course info options
        public string _openedMajorCourses;
        public string _openedLiberalArts;   //myiweb에 있는데 우짜지..
        public string _syllabus;                //이것도..
        public string _lecturerInfo;             //이것도..
        public string _mandatorySubject;      //이건 어떻게 가능
        public string _prerequisite;          //이것도 탐색

        //_liberalArtsCredits
        // 학점 관리 선택시 메뉴     credit options
        public string _currentCredits;        //개인별 정보 필요
        public string _majorCredits;
        public string _liberalArtsCredits;
        public string _changeStuNum;

        // 기타 정보 선택시 메뉴     others options
        public string _leaveOrReadmission;         //웹 연결
        public string _scholarship;            //웹 연결

        // 직접 입력 메뉴     typeself options
        public string _typePleaseWelcome;
        public string _typePleaseCourseRegistration;
        public string _typePleaseCourseInfo;
        public string _typePleaseCredits;
        public string _typePleaseOthers;
        public string _typePleaseHelp;
        public string _sorryMessage;
        public string _askAgain;

        // 도움말 선택시 메뉴       help options
        public string _introduction;
        public string _requestInformationCorrection;
        public string _contactMaster;
        public string _convertLanguage;

        // 처음으로 혹은 도움말      goto start and help
        public string _gotostart;
        public string _help;
        public string _cancelMessage;



        //모든 정보를 언어에 따라 다르게 주기 위해서
        //for different reply from language select

        //RootDialog + General
        public string _getStudentNumMessage;
        public string _getStudentNumUpdateMessage;
        public string _getStudentNumFail;
        public string _goToButton;

        //aboutCourseInfo
        public string _reply_OpenedMajorCourses;
        public string _reply_openedLiberalArts;
        public string _reply_Syllabus;
        public string _reply_LecturerInfo;
        public string _reply_MandatorySubject;
        public string _reply_Prerequisite;

        //aboutCourseRegistration
        public string _reply_HowToDoIt;
        public string _reply_Schedule;
        public string _reply_Regulation;
        public string _reply_Terms;

        //aboutCredits
        public string _reply_CurrentCredits;
        public string _reply_MajorCredits;
        public string _reply_LiberalArtsCredits;
        public string _reply_ChangeStuNum;

        //aboutOthers
        public string _reply_leaveOrReadmission;
        public string _reply_Scholarship;

        //aboutHelp
        public string _reply_Introduction;
        public string _reply_RequestInformationCorrection;
        public string _reply_ContactMaster;

    }
}