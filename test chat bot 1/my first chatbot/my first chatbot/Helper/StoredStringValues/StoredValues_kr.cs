﻿using my_first_chatbot.Helper.StoredStringValues;
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
            _printLine = "\n----------\n";
            // 기본 메뉴    welcome options
            _courseRegistration = "수강 신청";
            _courseInformation = "과목 정보";
            _credits = "학점 관리";
            _leaveOrReadmission = "휴학 및 복학";  
            _scholarship = "장학금";
            _help = "도움말";

            // 수강 신청 선택시 메뉴     course registration options
            _howToDoIt = "수강신청 방법";      
            _schedule = "수강신청 일정";       
            _regulation = "수강신청 규정";  
            _terms = "수강신청 용어";             

            // 과목 정보 선택시 메뉴     course info options
            _openedMajorCourses = "이번학기 개설전공";
            _openedLiberalArts = "이번학기 개설교양";
            _syllabus = "강의계획서";           
            _lecturerInfo = "강사 정보";      
            _mandatorySubject = "필수과목 정보"; 
            _prerequisite = "선수과목 정보";     

            // 학점 관리 선택시 메뉴     credit options
            _currentCredits = "나의 이수학점";   
            _majorCredits = "전공 학점";
            _liberalArtsCredits = "교양 학점";
            _changeStuNum = "학번 재설정";

            // 도움말 선택시 메뉴       help options
            _introduction = "AAR안내";
            _requestInformationCorrection = "정보수정요청";
            _contactMaster = "관리자 연결";


            // 직접 입력하기 선택시 메뉴     typeself options
            _typePleaseWelcome =
                                    $"안녕하세요 AAR 챗봇서비스입니다.\n" +
                                    $"문의 내용의 번호를 선택하시거나 질문을 입력해주세요.\n\n" +
                                    $"1. 수강신청정보\n" +
                                    $"2. 과목정보\n" +
                                    $"3. 학점관리\n" +
                                    $"4. 휴학 및 복학\n"+
                                    $"5. 장학금\n"+
                                    $"6. 도움말\n";
            //+
            //$"Please type in 'English' if you wish to chat in English. \n\n" +
            //$" 명지대학교 홈페이지\n" +
            //$" https://www.mju.ac.kr \n";



            _typePleaseCourseRegistration =
                                    $"수강신청정보 메뉴 입니다.\n" +
                                    $"문의 내용의 번호를 선택하시거나 질문을 입력해주세요.\n\n" +
                                    $"1. 수강신청 방법\n" +
                                    $"2. 수강신청 일정\n" +
                                    $"3. 수강신청 규정\n" +
                                    $"4. 수강신청 용어\n\n" +
                                    $"처음으로 돌아가시려면 '취소'를 입력해주세요.\n";


            _typePleaseCourseInfo =
                                    $"강의정보 메뉴 입니다.\n" +
                                    $"문의 내용의 번호를 선택하시거나 질문을 입력해주세요.\n\n" +
                                    $"1. 이번학기 전공개설과목\n" +
                                    $"2. 이번학기 교양개설과목\n" +
                                    $"3. 강의계획서\n" +
                                    $"4. 강사 정보\n" +
                                    $"5. 필수과목 정보\n" +
                                    $"6. 선수과목 정보\n\n" +
                                    $"처음으로 돌아가시려면 '취소'를 입력해주세요.\n";

            _typePleaseCredits =
                                    $"학점관리 메뉴 입니다.\n" +
                                    $"문의 내용의 번호를 선택하시거나 질문을 입력해주세요.\n\n" +
                                    $"1. 나의 이수학점\n" +
                                    $"2. 전공 학점\n" +
                                    $"3. 교양 학점\n" +
                                    $"4. 학번 재설정\n\n" +
                                    $"처음으로 돌아가시려면 '취소'를 입력해주세요.\n";


            _typePleaseHelp =
                                    $"도움말 메뉴 입니다.\n" +
                                    $"문의 내용의 번호를 선택하시거나 질문을 입력해주세요.\n\n" +
                                    $"1. AAR안내\n" +
                                    $"2. 정보수정 요청\n" +
                                    $"3. 관리자 연결\n" +
                                    $"처음으로 돌아가시려면 '취소'를 입력해주세요.\n";


            _sorryMessage =
                                    $"말씀을 이해하지 못했어요.\n" +
                                    $"다음에는 이해할 수 있도록 열심히 학습하겠습니다.\n";


            _askAgain =
                                    $"혹시 찾으시는 메뉴가 이 중에 있나요?\n" +
                                    $"원하는 메뉴를 다시 한 번 입력해 주세요.\n";



            // 처음으로
            _cancelMessage = "초기 메뉴로 돌아갑니다. 아무 키나 눌러주세요.";


            //모든 정보를 언어에 따라 다르게 주기 위해서
            //for different reply from language select

            //RootDialog + General
            _getStudentNumMessage =
                                    $"학점 정보 메뉴입니다.\n" +
                                    $"학번을 입력해 주세요.\n" +
                                    $"학번 입력 예시 : 12345678.\n";
            _getStudentNumUpdateMessage =
                                    $"학번 정보가 변경되었습니다.\n" +
                                    $"변경된 학번 : \n";
            _getStudentNumFail =
                                    $"잘못된 형식입니다.\n" +
                                    $"학번을 다시 입력해 주세요.(e.g. '12345678')\n" +
                                    $"처음으로 돌아가시려면 '취소'를 입력해주세요.\n";


            _goToButton = $"여기를 눌러주세요";


            //aboutCourseRegistration
            _reply_HowToDoIt =
                                    $"수강신청 방법에 대한 안내입니다.\n";


            _reply_Schedule =
                                    $"수강신청 일정에 대한 안내입니다.\n";


            _reply_Regulation =
                                    $"수강신청 규정에 대한 안내입니다.\n" +
                                    $"해당 페이지 3장 5절 제26조를 확인하세요.\n" +
                                    $"아래 링크는 데스크탑 사이트로 연결됩니다.\n";


            _reply_Terms = 
                                    $"수강신청관련 용어정보에 대한 안내입니다.\n";


            //aboutCourseInfo
            _reply_OpenedMajorCourses = $"이번학기 개설전공강의에 대한 안내입니다.\n";


            _reply_openedLiberalArts = $"이번학기 개설강의에 대한 안내입니다.\n";


            _reply_Syllabus =
                                    $"강의계획서에 대한 안내입니다.\n";
                                    


            _reply_LecturerInfo =
                                    $"강사 정보에 대한 안내입니다.\n" +
                                    $"아래 링크는 데스크탑 사이트로 연결됩니다.\n";


            _reply_MandatorySubject =
                                    $"필수과목 정보에 대한 안내입니다.\n";


            _reply_Prerequisite =
                                    $"선수과목 정보에 대한 안내입니다.\n";


            //aboutCredits
            _reply_CurrentCredits =
                                    $"나의 이수학점에 대한 안내입니다.\n" +
                                    $"이수하신 총 학점은 : ";


            _reply_MajorCredits =
                                    $"전공 학점에 대한 안내입니다.\n" +
                                    $"이수하신 전공 학점은 : ";


            _reply_LiberalArtsCredits =
                                    $"교양 학점에 대한 안내입니다.\n" +
                                    $"이수하신 교양 학점은 : ";


            _reply_ChangeStuNum =
                                    $"재설정을 원하시는 학번을 입력해주세요.\n" +
                                    $"현재 설정되어 있는 학번은 : ";


            //aboutOthers
            _reply_leaveOrReadmission = $"휴학 및 복학정보에 대한 안내입니다.\n";


            _reply_Scholarship = $"장학금 관련정보에 대한 안내입니다.\n";


            //aboutHelp
            _reply_Introduction =
                                    $"AAR에 대한 안내입니다.\n" +
                                    $"AAR은 학생들의 수강신청 및 학점관리를 도울 수 있습니다.\n" +
                                    $"궁금하신 정보를 선택하시면 해당 정보페이지로 연결됩니다.\n" +
                                    $"선택 도중에 처음으로 돌아가고 싶으시면 '취소'를 입력해 주세요.\n";


            _reply_RequestInformationCorrection =
                                    $"정보수정요청을 하실수 있습니다.\n" +
                                    $"Github페이지\n" +
                                    $"▶ https://github.com/MJUKJE/chatbot/blob/dev/README.md \n" +
                                    $"▶ 관리자 Email로 문의\n" +
                                    $"Email : jasen0324@gmail.com\n";

            _reply_ContactMaster =
                                    $"관리자와 상담을 요청하실 수 있습니다.\n" +
                                    $"Github페이지\n" +
                                    $"▶ https://github.com/MJUKJE/chatbot/blob/dev/README.md \n" +
                                    $"▶ 관리자 Email로 문의\n" +
                                    $"Email : jasen0324@gmail.com\n";
        }

    }
}