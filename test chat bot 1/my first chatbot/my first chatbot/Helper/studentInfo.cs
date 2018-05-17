using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_first_chatbot.Helper
{
        public class StudentInfo
    {
            private string _fullName { get; set; }
            private string _studentNumber { get; set; }
            private string _yearOfRegistration { get; set; }
            private string _yearCourseTaken { get; set; }
            private string _semesterCourseTake { get; set; }
            private string _courseType { get; set; }
            private string _courseName { get; set; }
            private string _koreanCourseNumber { get; set; }
            private string _courseNumber { get; set; }
            private double _credit { get; set; }
            private string _isStuding { get; set; }

            public StudentInfo() { }


            public string FullName { get { return _fullName; } set { _fullName = value; } }
            public string StudentNumber { get { return _studentNumber; } set { _studentNumber = value; } }
            public string YearOfRegistration { get { return _yearOfRegistration; } set { _yearOfRegistration = value; } }
            public string YearCourseTaken { get { return _yearCourseTaken; } set { _yearCourseTaken = value; } }
            public string SemesterCourseTake { get { return _semesterCourseTake; } set { _semesterCourseTake = value; } }
            public string CourseType { get { return _courseType; } set { _courseType = value; } }
            public string CourseName { get { return _courseName; } set { _courseName = value; } }
            public string KoreanCourseNumber { get { return _koreanCourseNumber; } set { _koreanCourseNumber = value; } }
            public string CourseNumber { get { return _courseNumber; } set { _courseNumber = value; } }
            public double Credit { get { return _credit; } set { _credit = value; } }
            public string IsStuding { get { return _isStuding; } set { _isStuding = value; } }
        }
    
}
