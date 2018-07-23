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
        public string _LiberalSubject;
        public string _popular;

        //인기과목 선택시 메뉴
        /// 1. 공통교양 (구 필수교양)
        /// 2. 학문기초교양 (구 기초교양)
        /// 3. 전공1단계
        /// 4. 핵심교양 (구 선택교양)
        /// 5. 일반교양 (구 균형교양)
        /// 6. 자유선택
        /// 7. 복수전공
        /// 8. 부전공
        public string a;
        public string b;
        public string c;
        public string d;
        public string e;
        public string f;
        public string g;
        public string h;
        public List<string> _popularOptionsList = new List<string>();
        public string _popularOptionSelected;

        //교양과목 선택시 메뉴
        ///1. 공통교양
        ///2. 일반교양
        ///3. 학문기초교양
        ///4. 핵심교양
        public string i;
        public string j;
        public string k;
        public string l;
        public string m;
        public List<string> _liberalOptionsList = new List<string>();
        public string _liberalOptionSelected;

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
        //public string _cancelMessage;



        //모든 정보를 언어에 따라 다르게 주기 위해서
        //for different reply from language select

        //RootDialog + General
        public string _getStudentNumMessage;
        public string _getStudentNumUpdateMessage;
        public string _getStudentNumRetry;
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