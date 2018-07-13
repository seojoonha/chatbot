using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace my_first_chatbot.Helper
{
    public class POPInfoService
    {
        public List<POPInfo> popInfoList;

        /// <summary>
        /// 1. 공통교양 (구 필수교양)
        /// 2. 학문기초교양 (구 기초교양)
        /// 3. 전공1단계
        /// 4. 핵심교양 (구 선택교양)
        /// 5. 일반교양 (구 균형교양)
        /// 6. 자유선택
        /// 7. 복수전공
        /// 8. 부전공
        /// </summary>
        private string[] subjectlist = new string[3];

        public POPInfoService()
        {
            this.popInfoList = readPOPInfoFile();
        }

        public List<POPInfo> readPOPInfoFile()
        {
            var mylist = new List<POPInfo>();
            string path = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, @"data\count\");

            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo fi in di.GetFiles())                                                  //해당 디렉토리의 파일 읽기
            {
                string mytestpath = path + fi.Name;
                var rows = File.ReadAllLines(mytestpath).Select(a => a.Split(','));
                var myrows = rows.ToList();

                var sync = new object();
                myrows.RemoveAt(0);
                Parallel.ForEach(myrows, row =>
                {
                    POPInfo PI = new POPInfo();
                    PI.CourseType = row[0].ToString();
                    PI.CourseNumber = row[1].ToString();
                    PI.CourseName = row[2].ToString();
                    PI.CourseCount = int.Parse(row[3]);
                    lock (sync)
                    {
                        mylist.Add(PI);// here you can add or remove items from the fileInfo list
                    }


                });

            }
            this.popInfoList = mylist;

            return mylist;
        }


        /// <summary>
        /// TOP 3 과목 리스트를 가져오는 메소드
        /// 예외적으로 목록이 3개 이하일 경우에는 있는 만큼만 가져온다.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        private string Top3(string keyword)
        {
            int count = 0;

            String ReplyMessage = "정보통신과\n\n" + keyword + "\n\n";
            
            var list = from content in this.popInfoList
                       where content.CourseType == keyword
                       select content;

            if (list.Count() > 3) count = 3;
            else count = list.Count();

            for(int i = 1; i < count + 1; i++) ReplyMessage += i.ToString() + "위 강의" + list.ElementAt(i).CourseName + "\n이 수업을 총 " + list.ElementAt(i).CourseCount + "명이 들었습니다.\n\n";

            return ReplyMessage;
        }

        public string totalpopularity(int num)
        {
            string Reply = null;
            if (this.popInfoList == null) return "시스템 상의 문제로 인하여 정보를 불러올 수가 없었습니다.\n";
            try
            {
                /// 1. 공통교양 (구 필수교양)
                /// 2. 학문기초교양 (구 기초교양)
                /// 3. 전공1단계
                /// 4. 핵심교양 (구 선택교양)
                /// 5. 일반교양 (구 균형교양)
                /// 6. 자유선택
                /// 7. 복수전공
                /// 8. 부전공
                       
                switch (num)
                {
                    case 0:
                        Reply = Top3("공통교양 (구 필수교양)");
                        break;

                    case 1:
                        Reply = Top3("학문기초교양 (구 기초교양)");
                        break;

                    case 2:
                        Reply = Top3("전공1단계");
                        break;

                    case 3:
                        Reply = Top3("핵심교양 (구 선택교양)");
                        break;

                    case 4:
                        Reply = Top3("일반교양 (구 균형교양)");
                        break;

                    case 5:
                        Reply = Top3("자유선택");
                        break;

                    //case 6:
                    //    Reply = Top3("복수전공");
                    //    break;

                    //case 7:
                    //    Reply = Top3("부전공");
                    //    break;

                    default:
                        Reply = "시스템 오류로 인하여 목록을 \n불러올 수 없었습니다.\n\n이 문제가 반복된다면 관리자에게 알려주세요.\n\n";
                        break;
                }
                return Reply;
            }
            catch (Exception e)
            {
                return e.Message + "\n\n" + e.ToString();
            }
        }
    }
}