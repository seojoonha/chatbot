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
        public string _leaveOrReadmission;      
        public string _scholarship;
        public string _help;

        // 수강 신청 선택시 메뉴     course registration options
        public string _howToDoIt;          
        public string _schedule;          
        public string _regulation;      
        public string _terms;       

        // 과목 정보 선택시 메뉴     course info options
        public string _openedMajorCourses;
        public string _openedLiberalArts;
        public string _syllabus;            
        public string _lecturerInfo;        
        public string _mandatorySubject; 
        public string _prerequisite;     

        //_liberalArtsCredits
        // 학점 관리 선택시 메뉴     credit options
        public string _currentCredits;        
        public string _majorCredits;
        public string _liberalArtsCredits;
        public string _changeStuNum;


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

        // 처음으로
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