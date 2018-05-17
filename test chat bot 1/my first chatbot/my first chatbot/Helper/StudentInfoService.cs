using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace my_first_chatbot.Helper
{
    public class StudentInfoService
    {
        public  List<StudentInfo> studentInfoList;

        public StudentInfoService() {
            this.studentInfoList = readTheStudentInfoFile();
        }

        public  List<StudentInfo> readTheStudentInfoFile()
        {
            var mylist = new List<StudentInfo>();
            string path = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, @"data\");

            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo fi in di.GetFiles())
            {
                string mytestpath = path + fi.Name;
                var rows = File.ReadAllLines(mytestpath).Select(a => a.Split(','));
                var myrows = rows.ToList();

                var sync = new object();
                myrows.RemoveAt(0);
                myrows.RemoveAt(0);
                Parallel.ForEach(myrows, row =>
                {
                    StudentInfo info = new StudentInfo();
                    info.FullName = row[1].ToString();
                    info.StudentNumber = row[2];
                    info.YearOfRegistration = row[3];
                    info.YearCourseTaken = row[4];
                    info.SemesterCourseTake = row[5];
                    info.CourseType = row[6];
                    info.CourseName = row[7];
                    info.KoreanCourseNumber = row[8];
                    info.CourseNumber = row[9];
                    info.Credit = double.Parse(row[10]);
                    info.IsStuding = row[11];
                    lock (sync)
                    {
                        mylist.Add(info);// here you can add or remove items from the fileInfo list
                    }


                });

            }
            this.studentInfoList = mylist;
            return mylist;
        }

        public  double totalCredits(string studentID)
        {
            var studentinfo = from b in studentInfoList
                              where b.StudentNumber == studentID
                              select b;
            int count = studentinfo.Count();
            double mycredit = studentinfo.Sum(item => item.Credit);
            return mycredit;
        }

        public  double totalMajorCredits(string studentID)
        {
            var studentinfo = from b in studentInfoList
                              where b.StudentNumber == studentID && b.CourseType.Contains("전공")
                              select b;
            int count = studentinfo.Count();
            double mycredit = studentinfo.Sum(item => item.Credit);
            return mycredit;
        }

        public  double totalElectiveCredits(string studentID)
        {
            var studentinfo = from b in studentInfoList
                              where b.StudentNumber == studentID && b.CourseType.Contains("교양")
                              select b;
            int count = studentinfo.Count();
            double mycredit = studentinfo.Sum(item => item.Credit);
            return mycredit;
        }
    }
}