﻿using my_first_chatbot.Helper.StoredStringValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
    [Serializable]
    public class StoredValues_en : StoredStringValuesMaster
    {


        public StoredValues_en()        //생성자로 멤버 초기화
        {
            _printLine = "\n----------\n";
            // 기본 메뉴    welcome options
            _courseRegistration = "Course Registration";
            _courseInformation = "Course Information";
            _credits = "Credits";
            _others = "Others";
            _typeself = "Enter yourself";

            // 수강 신청 선택시 메뉴     course registration options
            _howToDoIt = "How to register";             //웹 연결
            _schedule = "Schedule";              //웹 연결
            _regulation = "Regulation";            //웹 연결
            _terms = "Terms";                 //우리가 정의? 혹은 웹 연결?

            // 과목 정보 선택시 메뉴     course info options
            _openedLiberalArts = "Opened LiberalArts";   //myiweb에 있는데 우짜지..
            _openedMajorCourses = "Opened Major";
            _syllabus = "Syllabus";                //이것도..
            _lecturerInfo = "Lecture Info";             //이것도..
            _mandatorySubject = "Mandatory Subject";      //이건 어떻게 가능
            _prerequisite = "Prerequisite";          //이것도 탐색

            // 학점 관리 선택시 메뉴     credit options
            _currentCredits = "Current Credits";        //개인별 정보 필요
            _majorCredits = "Major Credits";
            _liberalArtsCredits = "Liberal Arts credits";
            _changeStuNum = "Resetting StuNum";

            // 기타 정보 선택시 메뉴     others options
            _leaveOrReadmission = "Leave Or Readmission";         //웹 연결
            _scholarship = "Scholarship";            //웹 연결

            // 직접 입력하기 선택시 메뉴     typeself options
            _typePlease = $"Please enter your information yourself\n" +
                                    $"- Example-\n" +
                                    $"[Course Registration]\n" +
                                    $"[Course Information]\n" +
                                    $"[Credits]\n" +
                                    $"[Others]\n" +
                                    $"We are going to implement Depth 3 later.\n";

            // 도움말 선택시 메뉴       help options
            _introduction = "AAR Guidance";
            _requestInformationCorrection = "requestInformationCorrection";
            _contactMaster = "Contact to Master";
            _convertLanguage = "한국어";

            // 처음으로 혹은 도움말      goto start and help
            _gotostart = "Go To Start";
            _help = "Help";

            _welcomeOptionsList = new List<string> { _courseRegistration, _courseInformation, _credits, _others, _typeself, _help };
            _courseRegistrationOptions = new List<string> { _howToDoIt, _schedule, _regulation, _terms, _gotostart, _help };
            _courseInfoOptions = new List<string> { _openedMajorCourses, _openedLiberalArts, _syllabus, _lecturerInfo, _mandatorySubject, _prerequisite, _gotostart, _help };
            _creditsOptions = new List<string> { _currentCredits, _majorCredits, _liberalArtsCredits, _changeStuNum, _gotostart, _help };
            _othersOption = new List<string> { _leaveOrReadmission, _scholarship, _gotostart, _help };
            _helpOptionsList = new List<string> { _introduction, _requestInformationCorrection, _contactMaster, _convertLanguage, _gotostart };


            //모든 정보를 언어에 따라 다르게 주기 위해서
            //for diffrent reply from language select

            //RootDialog + General
            _getStudentNumMessage = $"Myongji University AAR.\n" +
                                $"Please enter your student ID for personalized information\n" +
                            $"Test number: 60131937.\n";
            _getStudentNumUpdateMessage = $"Student number info updated\n" +
                            $"Updated Student number is : ";
            _getStudentNumFail = $"Wrong Format.\n" +
                            $"What is your Student ID(e.g. '60131937') ?";
            _welcomeMessage = $"Myongji University AAR.\n" +
                                $"Please select the information you are interested in.\n" +
                                $"You can enter text if you choose to type it yourself.\n" +
                            $"Credits management entry requires student number\n" +
                            $"메뉴에서 [Help] -> [한국어]를 선택하시면 언어변환이 가능합니다 :).\n";
            _invalidSelectionMessage = "You have chosen the wrong option.";
            _goToButton = "Goto Info";

            //aboutCourseInfo
            _courseInfoSelected = "You have selected lecture information.\nPlease select details.";

            _reply_openedLiberalArts = $"This is a guide for this semester opened LiberalArts.\n";

            _reply_OpenedMajorCourses = $"This is a guide for this semester opened Major.\n";


            _reply_Syllabus = $"This is a guide for syllabus.\n" +
                                $"This is information in Myiweb, so login is required.\n" +
                                $"This links to the desktop site, which does not exist on the mobile page.\n";


            _reply_LecturerInfo = $"This is a guide for LecturerInfo.\n" +
                                $"This is information in Myiweb, so login is required.\n" +
                                $"This links to the desktop site, which does not exist on the mobile page.\n";


            _reply_MandatorySubject = $"This is a guide for required course information \n";


            _reply_Prerequisite = $"This is a guide for prerequisite information \n";


            //aboutCourseRegistration
            _courseRegistrationSelected = "You have selected to enroll.\nPlease select the details.";


            _reply_HowToDoIt = $"Instructions on how to enroll\n" +
                                $"This links to the desktop site, which does not exist on the mobile page.\n";


            _reply_Schedule = $"Instructions for the course registration.\n" +
                                $"This links to the desktop site, which does not exist on the mobile page.\n";


            _reply_Regulation = $"Instructions for course registration\n" +
                                $"Please check page 3, section 5, article 26 of this page.\n" +
                                $"This links to the desktop site, which does not exist on the mobile page.\n";


            _reply_Terms = $"This is a guide to information about course registration.\n";


            //aboutCredits
            _creditsOptionSelected = "You have selected credit management.\nPlease select the details.";


            _reply_CurrentCredits = $"Guide to my graduation.\n" +
                            $"Total credits earned are : ";


            _reply_MajorCredits = $"Guide to major credit.\n" +
                                $"Specialization credits for the undergraduate courses are : ";


            _reply_LiberalArtsCredits = $"Guidance on Liberal Arts credits.\n" +
                                $"Liberal Arts credits are : ";


            _reply_ChangeStuNum = $"Please enter the student number you wish to reset\n" +
                            $"The current student number is : ";


            //aboutOthers
            _otherOptionSelected = "You have selected other information.\nPlease select the details.";


            _reply_leaveOrReadmission = $"This is information about the leave and returning information. \n";


            _reply_Scholarship = $"Information on scholarship information. \n";


            //aboutHelp
            _helpOptionSelected = "AAR3 help, what can I do for you?";


            _reply_Introduction = $"A guide to AAR3\n" +
                                $"AAR3 can help you to apply for water and manage your credit.\n" +
                                $"Select the data in the archive.\n" +
                                $"The selection has now returned to the beginning.\n" +
                                $"Added later \n";


            _reply_RequestInformationCorrection = $"You can request to modify the information.\n" +
                                    $"We plan to add it later.\n";

            _reply_ContactMaster = $"You can ask for a consultation with the administrator.\n" +
                                     $"We plan to add it later.\n";
        }

    }
}