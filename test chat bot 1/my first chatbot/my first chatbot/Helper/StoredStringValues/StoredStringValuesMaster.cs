using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper.StoredStringValues
{
    [Serializable]
    public class StoredStringValuesMaster
    {
        public string _printLine = "\n----------\n";
        // 기본 메뉴    welcome options
        public string _courseRegistration = "수강 신청";
        public string _courseInformation = "과목 정보";
        public string _credits = "학점 관리";
        public string _others = "기타 정보";
        public string _typeself = "직접 입력하기";
        public List<string> _welcomeOptionsList = new List<string>();

        // 수강 신청 선택시 메뉴     course registration options
        public string _howToDoIt = "수강신청 방법";             //웹 연결
        public string _schedule = "수강신청 일정";              //웹 연결
        public string _regulation = "수강신청 규정";            //웹 연결
        public string _terms = "수강신청 용어";                 //우리가 정의? 혹은 웹 연결?
        public List<string> _courseRegistrationOptions = new List<string>();

        // 과목 정보 선택시 메뉴     course info options
        public string _openedMajorCourses = "이번학기 전공개설과목";
        public string _openedLiberalArts = "이번학기 교양개설과목";   //myiweb에 있는데 우짜지..
        public string _syllabus = "강의계획서";                //이것도..
        public string _lecturerInfo = "강사 정보";             //이것도..
        public string _mandatorySubject = "필수과목 정보";      //이건 어떻게 가능
        public string _prerequisite = "선수과목 정보";          //이것도 탐색
        public List<string> _courseInfoOptions = new List<string>();
        //_liberalArtsCredits
        // 학점 관리 선택시 메뉴     credit options
        public string _currentCredits = "나의 이수학점";        //개인별 정보 필요
        public string _majorCredits = "전공 학점";
        public string _liberalArtsCredits = "교양 학점";
        public string _changeStuNum = "학번 재설정";
        public List<string> _creditsOptions = new List<string>();

        // 기타 정보 선택시 메뉴     others options
        public string _leaveOrReadmission = "휴학 및 복학";         //웹 연결
        public string _scholarship = "장학금 관련";            //웹 연결
        public List<string> _othersOption = new List<string>();

        // 직접 입력 메뉴     typeself options
        public string _typePleaseWelcome = $"▶ 안녕하세요 AAR 챗봇서비스\n      입니다.\n" +
                                    $"▶ 문의 내용의 번호를 선택하시\n      거나 질문을 입력해주세요.\n\n" +
                                    $"▶ 1. 수강신청정보\n" +
                                    $"▶ 2. 과목정보\n" +
                                    $"▶ 3. 학점관리\n" +
                                    $"▶ 4. 기타정보\n" +
                                    $"▶ 5. 도움말\n" +

                                    $" ※ 명지대학교 홈페이지\n" +
                                    $" ■ https://www.mju.ac.kr \n" +
                                    $" ※ Github for AAR\n" +
                                    $" ■ https://github.com/MJUKJE/chatbot/blob/dev/README.md \n" +

                                    $"▶ 학점 관리항목은\n      학번입력이 필요합니다.\n" +
                                    $"▶ [처음으로]나 초기메뉴를 입력시\n      처음으로 돌아가실 수 있습니다.\n" +
                                    $"▶ Please type in 'English' if you wish to chat in English. :D \n" +
                                    $"▶ 추후 계속 업데이트 예정.\n";


        public string _typePleaseCourseRegistration = $"▶ 수강신청정보 메뉴 입니다.\n" +
                                    $"▶ 문의 내용의 번호를 선택하시\n      거나 질문을 입력해주세요.\n\n" +
                                    $"▶ 1. 수강신청 방법\n" +
                                    $"▶ 2. 수강신청 일정\n" +
                                    $"▶ 3. 수강신청 규정\n" +
                                    $"▶ 4. 수강신청 용어\n" +
                                    $"▶ 5. 처음으로\n" +
                                    $"▶ 6. 도움말\n\n" +

                                    $"▶ Please type in 'English' if you wish to chat in English. :D \n" +
                                    $"▶ 추후 계속 업데이트 예정.\n";


        public string _typePleaseCourseInfo = $"▶ 강의정보 메뉴 입니다.\n" +
                                    $"▶ 문의 내용의 번호를 선택하시\n      거나 질문을 입력해주세요.\n\n" +
                                    $"▶ 1. 이번학기 전공개설과목\n" +
                                    $"▶ 2. 이번학기 교양개설과목\n" +
                                    $"▶ 3. 강의계획서\n" +
                                    $"▶ 4. 강사 정보\n" +
                                    $"▶ 5. 필수과목 정보\n" +
                                    $"▶ 6. 선수과목 정보\n" +
                                    $"▶ 7. 처음으로\n" +
                                    $"▶ 8. 도움말\n\n" +

                                    $"▶ Please type in 'English' if you wish to chat in English. :D \n" +
                                    $"▶ 추후 계속 업데이트 예정.\n";


        //public string _typePleaseCredits
        //구현예정
        public string _typePleaseCredits = $"▶ 학점관리 메뉴 입니다.\n" +
                                   $"▶ 문의 내용의 번호를 선택하시\n      거나 질문을 입력해주세요.\n\n" +
                                   $"▶ 1. 나의 이수학점\n" +
                                   $"▶ 2. 전공 학점\n" +
                                   $"▶ 3. 교양 학점\n" +
                                   $"▶ 4. 학번 재설정\n" +
                                   $"▶ 5. 처음으로\n" +
                                   $"▶ 6. 도움말\n\n" +

                                   $"▶ Please type in 'English' if you wish to chat in English. :D \n" +
                                   $"▶ 추후 계속 업데이트 예정.\n";



        public string _typePleaseOthers = $"▶ 기타 메뉴 입니다.\n" +
                           $"▶ 문의 내용의 번호를 선택하시\n      거나 질문을 입력해주세요.\n\n" +
                           $"▶ 1. 휴학 및 복학\n" +
                           $"▶ 2. 장학금 관련\n" +
                           $"▶ 3. 처음으로\n" +
                           $"▶ 4. 도움말\n\n" +

                           $"▶ Please type in 'English' if you wish to chat in English. :D \n" +
                           $"▶ 추후 계속 업데이트 예정.\n";



        public string _typePleaseHelp = $"▶ 도움말 메뉴 입니다.\n" +
                            $"▶ 문의 내용의 번호를 선택하시\n      거나 질문을 입력해주세요.\n\n" +
                            $"▶ 1. AAR안내\n" +
                            $"▶ 2. 정보수정 요청\n" +
                            $"▶ 3. 관리자 연결\n" +
                            $"▶ 4. 처음으로\n" +

                            $"▶ Please type in 'English' if you wish to chat in English. :D \n" +
                            $"▶ 추후 계속 업데이트 예정.\n";

        public string _sorryMessage = $"▶말씀을 이해하지 못했습니다.\n" +
                                        $"▶문의하신 내용에 대해 다음에는\n" +
                                        $"▶안내드릴 수 있도록 열심히\n" +
                                        $"▶학습하겠습니다.\n\n" +
                                        $"■ 각종 문의 및 상담\n" +
                                        $"▶ Github페이지\n" +
                                        $"▶ https://github.com/MJUKJE/chatbot/blob/dev/README.md \n" +
                                        $"▶ 관리자 Email로 문의\n" +
                                        $"▶ Email : jasen0324@gmail.com\n";

        // 도움말 선택시 메뉴       help options
        public string _introduction = "AAR안내";
        public string _requestInformationCorrection = "정보수정요청";
        public string _contactMaster = "관리자 연결";
        public string _convertLanguage = "English";
        public List<string> _helpOptionsList = new List<string>();

        // 처음으로 혹은 도움말      goto start and help
        public string _gotostart = "처음으로";
        public string _help = "도움말";


        public StoredStringValuesMaster()
        {
            _welcomeOptionsList = new List<string> { _courseRegistration, _courseInformation, _credits, _others, _typeself, _help };
            _courseRegistrationOptions = new List<string> { _howToDoIt, _schedule, _regulation, _terms, _gotostart, _help };
            _courseInfoOptions = new List<string> { _openedMajorCourses, _openedLiberalArts, _syllabus, _lecturerInfo, _mandatorySubject, _prerequisite, _gotostart, _help };
            _creditsOptions = new List<string> { _currentCredits, _majorCredits, _liberalArtsCredits, _changeStuNum, _gotostart, _help };
            _othersOption = new List<string> { _leaveOrReadmission, _scholarship, _gotostart, _help };
            _helpOptionsList = new List<string> { _introduction, _requestInformationCorrection, _contactMaster, _convertLanguage, _gotostart };

        }

        //모든 정보를 언어에 따라 다르게 주기 위해서
        //for diffrent reply from language select

        //RootDialog + General
        public string _getStudentNumMessage = $"안녕하세요 명지대학교 AAR입니다.\n" +
                                $"맞춤형 정보제공을 위해 학번을 입력해 주세요.\n" +
                            $"입력하신 학번은 저장되지 않습니다.\n" +
                            $"테스트용 학번 : 60131937.\n";
        public string _getStudentNumUpdateMessage = $"학번 정보가 변경되었습니다.\n" +
                            $"변경된 학번 : ";
        public string _getStudentNumFail = $"잘못된 형식입니다.\n" +
                                    $"학번을 다시 입력해 주세요.(e.g. '60131937')";
        public string _welcomeMessage = 
                            $"안녕하세요 명지대학교 AAR입니다.\n" +
                            $"궁금하신 정보의 번호나 내용을 입력해 주세요.\n" +
                            $"학점 관리항목은 학번입력이 필요합니다.\n" +
                            $"Please type in 'English' if you wish to chat in English :D\n";

        public string _invalidSelectionMessage = "잘못된 옵션을 선택하셨어요ㅠㅠ 다시해주세요.";
        public string _goToButton = "정보로 이동";

        //aboutCourseInfo
        public string _courseInfoSelected = "강의 정보를 선택하셨습니다.\n세부항목을 선택해주세요.";


        public string _reply_OpenedMajorCourses = $"이번학기 개설전공강의에 대한 안내입니다.\n";


        public string _reply_openedLiberalArts = $"이번학기 개설강의에 대한 안내입니다.\n";


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


        public string _reply_Terms = $"수강신청관련 용어정보에 대한 안내입니다.\n";


        //aboutCredits
        public string _creditsOptionSelected = "학점 관리를 선택하셨습니다.\n세부항목을 선택해주세요.";


        public string _reply_CurrentCredits = $"나의 이수학점에 대한 안내입니다.\n" +
                            $"이수하신 총 학점은 : ";


        public string _reply_MajorCredits = $"전공 학점에 대한 안내입니다.\n" +
                            $"이수하신 전공 학점은 : ";


        public string _reply_LiberalArtsCredits = $"교양 학점에 대한 안내입니다.\n" +
                            $"이수하신 교양 학점은 : ";


        public string _reply_ChangeStuNum = $"재설정을 원하시는 학번을 입력해주세요.\n" +
                            $"현재 설정되어 있는 학번은 : ";


        //aboutOthers
        public string _otherOptionSelected = "기타 정보를 선택하셨습니다.\n세부항목을 선택해주세요.";


        public string _reply_leaveOrReadmission = $"휴학 및 복학정보에 대한 안내입니다.\n";


        public string _reply_Scholarship = $"장학금 관련정보에 대한 안내입니다.\n";


        //aboutHelp
        public string _helpOptionSelected = "AAR3 도움말입니다. 무엇을 도와드릴까요?";


        public string _reply_Introduction = $"AAR3에 대한 안내입니다.\n" +
                            $"AAR3는 학생들의 수강신청 및 학점관리를 도울 수 있습니다..\n" +
                            $"궁금하신 정보를 선택하시면 해당 정보페이지로 연결됩니다.\n" +
                            $"선택 도중에 처음으로 돌아가고 싶으시면 처음으로를 눌러주세요.\n" +
                            $"추후 추가예정 입니다.\n";


        public string _reply_RequestInformationCorrection = $"정보수정요청을 하실수 있습니다.\n" +
                            $"추후 추가예정 입니다.\n";

        public string _reply_ContactMaster = $"관리자와 상담을 요청하실 수 있습니다.\n" +
                            $"추후 추가예정 입니다.\n";


    }
}