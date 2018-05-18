using my_first_chatbot.Helper.StoredStringValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
    [Serializable]
    public class StoredValues_kr : StoredStringValuesMaster
    {

        public StoredValues_kr()
        {
            // 기본 메뉴    welcome options
            _courseRegistration = "수강 신청";
            _courseInformation = "과목 정보";
            _credits = "학점 관리";
            _graduation = "졸업 정보";
            _others = "기타 정보";

            // 수강 신청 선택시 메뉴     course registration options
            _howToDoIt = "수강신청 방법";             //웹 연결
            _schedule = "수강신청 일정";              //웹 연결
            _regulation = "수강신청 규정";            //웹 연결
            _terms = "수강신청 용어";                 //우리가 정의? 혹은 웹 연결?

            // 과목 정보 선택시 메뉴     course info options
            _openedCourses = "이번학기 개설과목";   //myiweb에 있는데 우짜지..
            _syllabus = "강의계획서";                //이것도..
            _lecturerInfo = "강사 정보";             //이것도..
            _mandatorySubject = "필수과목 정보";      //이건 어떻게 가능
            _prerequisite = "선수과목 정보";          //이것도 탐색

            // 학점 관리 선택시 메뉴     credit options
            _currentCredits = "나의 이수학점";        //개인별 정보 필요
            _majorCredits = "전공 학점";
            _electiveCredits = "교양 학점";
            _changeStuNum = "학번 재설정";

            //졸업정보 선택시 메뉴       graduation options
            _requiredCredits = "졸업요건";            //웹 연결
            _certification = "졸업인증제";              //웹 연결

        // 기타 정보 선택시 메뉴     others options
        _leaveOrRejoin = "휴학 및 복학";         //웹 연결
            _scholarship = "장학금 관련";            //웹 연결

            // 도움말 선택시 메뉴       help options
            _introduction = "AAR안내";
            _requestInformationCorrection = "정보수정요청";
            _contactMaster = "관리자 연결";
            _PCLink = "PC버전 링크";
            _convertLanguage = "English";

            // 처음으로 혹은 도움말      goto start and help
            _gotostart = "처음으로";
            _help = "도움말";

            _welcomeOptionsList = new List<string> { _courseRegistration, _courseInformation, _credits, _graduation, _others, _help };
            _courseRegistrationOptions = new List<string> { _howToDoIt, _schedule, _regulation, _terms, _gotostart, _help };
            _courseInfoOptions = new List<string> { _openedCourses, _syllabus, _lecturerInfo, _mandatorySubject, _prerequisite, _gotostart, _help };
            _creditsOptions = new List<string> { _currentCredits, _majorCredits, _electiveCredits, _changeStuNum, _gotostart, _help };
            _graduationOptions = new List<string> { _requiredCredits, _certification, _gotostart, _help };
            _othersOption = new List<string> { _leaveOrRejoin, _scholarship, _gotostart, _help };
            _helpOptionsList = new List<string> { _introduction, _requestInformationCorrection, _contactMaster, _PCLink, _convertLanguage, _gotostart };
            


            //모든 정보를 언어에 따라 다르게 주기 위해서
            //for diffrent reply from language select

            //RootDialog + General
            _getStudentNumMessage = $"안녕하세요 명지대학교 AAR3입니다.\n" +
                                $"맞춤형 정보제공을 위해 학번을 입력해 주세요.\n" +
                            $"입력하신 학번은 저장되지 않습니다.\n" +
                            $"테스트용 학번 : 60131937.\n";
            _welcomeMessage = $"안녕하세요 명지대학교 AAR3입니다.\n" +
                                $"궁금하신 정보를 선택해 주세요.\n" +
                            $"학점 관리항목은 학번입력이 필요합니다.\n" +
                            $"If you go to [도움말] -> [English]\n" +
                            $"You can convert language :).\n" +
                            $"\nAAR2 변경사항:\n" +
                            $"졸업정보 메뉴 추가\n" +
                            $"모바일,PC링크에 관한 도움말 추가";
            _invalidSelectionMessage = "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.";
            _goToButton = "정보로 이동";

            //aboutCourseInfo
            _courseInfoSelected = "강의 정보를 선택하셨습니다.\n세부항목을 선택해주세요.";

            _reply_OpenedCourses = $"이번학기 개설강의에 대한 안내입니다.\n" +
                                $"Myiweb내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                                $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_Syllabus = $"강의계획서에 대한 안내입니다.\n" +
                                $"Myiweb내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                                $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_LecturerInfo = $"강사 정보에 대한 안내입니다.\n" +
                                $"Eclass내에 존재하는 정보이므로 로그인이 필요합니다.\n" +
                                $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_MandatorySubject = $"필수과목 정보에 대한 안내입니다.\n" +
                                $"추후 추가예정 입니다.\n";


            _reply_Prerequisite = $"선수과목 정보에 대한 안내입니다.\n" +
                                $"추후 추가예정 입니다.\n";


            //aboutCourseRegistration
            _courseRegistrationSelected = "수강 신청을 선택하셨습니다.\n세부항목을 선택해주세요.";


            _reply_HowToDoIt = $"수강신청 방법에 대한 안내입니다.\n" +
                                $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_Schedule = $"수강신청 일정에 대한 안내입니다.\n" +
                                $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_Regulation = $"수강신청 규정에 대한 안내입니다.\n" +
                                $"해당 페이지 3장 5절 제26조를 확인하십시오.\n" +
                                $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_Terms = $"수강신청관련 용어정보에 대한 안내입니다.\n" +
                                $"추후 추가예정 입니다.\n";


            //aboutCredits
            _creditsOptionSelected = "학점 관리를 선택하셨습니다.\n세부항목을 선택해주세요.";


            _reply_CurrentCredits = $"나의 이수학점에 대한 안내입니다.\n" +
                            $"이수하신 총 학점은 : ";


            _reply_MajorCredits = $"전공 학점에 대한 안내입니다.\n" +
                                $"이수하신 전공 학점은 : ";


            _reply_ElectiveCredits = $"선택 학점에 대한 안내입니다.\n" +
                                $"이수하신 교양 학점은 : ";


            _reply_ChangeStuNum = $"학번정보가 초기화 되었습니다.\n" +
                            $"다시한번 학점관리를 선택해 주세요.\n";

            //aboutGraduation
            _graduationOptionSelected = "졸업 정보를 선택하셨습니다. \n세부항목을 선택해주세요.";


            _reply_requiredCredits = $"졸업 요건에 대한 안내입니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";


            _reply_certification = $"졸업 인증제에 대한 안내입니다.\n" +
                            $"모바일 페이지에 존재하지 않는 정보라 데스크탑 사이트로 연결됩니다.\n";

            //aboutOthers
            _otherOptionSelected = "기타 정보를 선택하셨습니다.\n세부항목을 선택해주세요.";


            _reply_LeaveOrRejoin = $"휴학 및 복학정보에 대한 안내입니다.\n" +
                                $"추후 추가예정 입니다.\n";


            _reply_Scholarship = $"장학금 관련정보에 대한 안내입니다.\n" +
                                $"추후 추가예정 입니다.\n";



            //aboutHelp
            _helpOptionSelected = "AAR3 도움말입니다. 무엇을 도와드릴까요?";


            _reply_Introduction = $"AAR3에 대한 안내입니다.\n" +
                                    $"AAR3는 학생들의 수강신청 및 학점관리를 도울 수 있습니다..\n" +
                                    $"궁금하신 정보를 선택하시면 해당 정보페이지로 연결됩니다.\n" +
                                    $"선택 도중에 처음으로 돌아가고 싶으시면 처음으로를 눌러주세요.\n" +
                                    $"추후 추가예정 입니다.\n";


            _reply_RequestInformationCorrection = $"장학금 관련정보에 대한 안내입니다.\n" +
                                    $"추후 추가예정 입니다.\n";

            _reply_ContactMaster = $"관리자와 상담을 요청하실 수 있습니다.\n" +
                                     $"추후 추가예정 입니다.\n";

            _reply_PCLink = $"모바일에서 데스크탑 링크를 탭하시면 모바일 페이지로 넘어가게 되는데요\n" +
                            $"PC버전 버튼을 탭하신 후에 봇으로 돌아와 해당 메뉴의 링크를 탭하시면 데스크탑 페이지를 보실 수 있습니다.";

        }

    }
}