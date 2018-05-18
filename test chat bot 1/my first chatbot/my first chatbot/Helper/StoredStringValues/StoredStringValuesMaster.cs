using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper.StoredStringValues
{
    [Serializable]
    public class StoredStringValuesMaster
    {

        // 기본 메뉴    welcome options
        public string _courseRegistration = "수강 신청";
        public string _courseInformation = "과목 정보";
        public string _credits = "학점 관리";
        public string _others = "기타 정보";
        public List<string> _welcomeOptionsList = new List<string>();

        // 수강 신청 선택시 메뉴     course registration options
        public string _howToDoIt = "수강신청 방법";             //웹 연결
        public string _schedule = "수강신청 일정";              //웹 연결
        public string _regulation = "수강신청 규정";            //웹 연결
        public string _terms = "수강신청 용어";                 //우리가 정의? 혹은 웹 연결?
        public List<string> _courseRegistrationOptions = new List<string>();

        // 과목 정보 선택시 메뉴     course info options
        public string _openedCourses = "이번학기 개설과목";   //myiweb에 있는데 우짜지..
        public string _syllabus = "강의계획서";                //이것도..
        public string _lecturerInfo = "강사 정보";             //이것도..
        public string _mandatorySubject = "필수과목 정보";      //이건 어떻게 가능
        public string _prerequisite = "선수과목 정보";          //이것도 탐색
        public List<string> _courseInfoOptions = new List<string>();

        // 학점 관리 선택시 메뉴     credit options
        public string _currentCredits = "나의 이수학점";        //개인별 정보 필요
        public string _majorCredits = "전공 학점";
        public string _electiveCredits = "교양 학점";
        public string _changeStuNum = "학번 재설정";
        public List<string> _creditsOptions = new List<string>();

        // 기타 정보 선택시 메뉴     others options
        public string _leaveOrRejoin = "휴학 및 복학";         //웹 연결
        public string _scholarship = "장학금 관련";            //웹 연결
        public List<string> _othersOption = new List<string>();

        // 도움말 선택시 메뉴       help options
        public string _introduction = "AAR안내";
        public string _requestInformationCorrection = "정보수정요청";
        public string _contactMaster = "관리자 연결";
        public string _convertLanguage = "한국어";
        public List<string> _helpOptionsList = new List<string>();

        // 처음으로 혹은 도움말      goto start and help
        public string _gotostart = "처음으로";
        public string _help = "도움말";


        public StoredStringValuesMaster()
        {
            _welcomeOptionsList = new List<string> { _courseRegistration, _courseInformation, _credits, _others, _help };
            _courseRegistrationOptions = new List<string> { _howToDoIt, _schedule, _regulation, _terms, _gotostart, _help };
            _courseInfoOptions = new List<string> { _openedCourses, _syllabus, _lecturerInfo, _mandatorySubject, _prerequisite, _gotostart, _help };
            _creditsOptions = new List<string> { _currentCredits, _majorCredits, _electiveCredits, _changeStuNum, _gotostart, _help };
            _othersOption = new List<string> { _leaveOrRejoin, _scholarship, _gotostart, _help };
            _helpOptionsList = new List<string> { _introduction, _requestInformationCorrection, _contactMaster, _convertLanguage, _gotostart };

        }

        //모든 정보를 언어에 따라 다르게 주기 위해서
        //for diffrent reply from language select

        //RootDialog + General
        public string _getStudentNumMessage = $"안녕하세요 명지대학교 AAR3입니다.\n" +
                                $"맞춤형 정보제공을 위해 학번을 입력해 주세요.\n" +
                            $"입력하신 학번은 저장되지 않습니다.\n" +
                            $"테스트용 학번 : 60131937.\n";
        public string _getStudentNumUpdateMessage = @"Student number info updated to";
        public string _welcomeMessage = $"안녕하세요 명지대학교 AAR3입니다.\n" +
                                $"궁금하신 정보를 선택해 주세요.\n" +
                            $"학점 관리항목은 학번입력이 필요합니다.\n" +
                            $"If you go to [도움말] -> [English]\n" + 
                            $"You can convert language :).\n";
        public string _invalidSelectionMessage = "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.";
        public string _goToButton = "정보로 이동";

        //aboutCourseInfo
        public string _courseInfoSelected = "강의 정보를 선택하셨습니다.\n세부항목을 선택해주세요.";

        public string _reply_OpenedCourses = $"이번학기 개설강의에 대한 안내입니다.\n" +
                            $"Myiweb내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


        public string _reply_Syllabus = $"강의계획서에 대한 안내입니다.\n" +
                            $"Myiweb내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


        public string _reply_LecturerInfo = $"강사 정보에 대한 안내입니다.\n" +
                            $"Eclass내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


        public string _reply_MandatorySubject = $"필수과목 정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";


        public string _reply_Prerequisite = $"선수과목 정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";


        //aboutCourseRegistration
        public string _courseRegistrationSelected = "수강 신청을 선택하셨습니다.\n세부항목을 선택해주세요.";


        public string _reply_HowToDoIt = $"수강신청 방법에 대한 안내입니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


        public string _reply_Schedule = $"수강신청 일정에 대한 안내입니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


        public string _reply_Regulation = $"수강신청 규정에 대한 안내입니다.\n" +
                            $"해당 페이지 3장 5절 제26조를 확인하십시오.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


        public string _reply_Terms = $"수강신청관련 용어정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";


        //aboutCredits
        public string _creditsOptionSelected = "학점 관리를 선택하셨습니다.\n세부항목을 선택해주세요.";


        public string _reply_CurrentCredits = $"나의 이수학점에 대한 안내입니다.\n" +
                            $"이수하신 총 학점은 : ";


        public string _reply_MajorCredits = $"전공 학점에 대한 안내입니다.\n" +
                            $"이수하신 전공 학점은 : ";


        public string _reply_ElectiveCredits = $"선택 학점에 대한 안내입니다.\n" + 
                            $"이수하신 교양 학점은 : ";


        public string _reply_ChangeStuNum = $"학번정보가 초기화 되었습니다.\n" +
                            $"다시한번 학점관리를 선택해 주세요.\n";


        //aboutOthers
        public string _otherOptionSelected = "기타 정보를 선택하셨습니다.\n세부항목을 선택해주세요.";


        public string _reply_LeaveOrRejoin = $"휴학 및 복학정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";


        public string _reply_Scholarship = $"장학금 관련정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";


        //aboutHelp
        public string _helpOptionSelected = "AAR3 도움말입니다. 무엇을 도와드릴까요?";


        public string _reply_Introduction = $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3는 학생들의 수강신청 및 학점관리를 도울 수 있습니다..\n" +
                            $"궁금하신 정보를 선택하시면 해당 정보페이지로 연결됩니다.\n" +
                            $"선택 도중에 처음으로 돌아가고 싶으시면 처음으로를 눌러주세요.\n" +
                            $"추후 추가예정 입니다.\n";


        public string _reply_RequestInformationCorrection = $"장학금 관련정보에 대한 안내입니다.\n" +
                            $"추후 추가예정 입니다.\n";

        public string _reply_ContactMaster = $"관리자와 상담을 요청하실 수 있습니다.\n" +
                            $"추후 추가예정 입니다.\n";


    }
}