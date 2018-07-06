using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace my_first_chatbot.Helper
{
  public class LiberalArts
  {
    private string _courseType { get; set; }        // 강의 타입
    private string _courseNumber { get; set; }      // 과목 코드
    private string _courseName { get; set; }        // 과목 이름

    public LiberalArts() { }

    public string CourseType { get { return _courseType; } set { _courseType = value; } }
    public string CourseNumber { get { return _courseNumber; } set { _courseNumber = value; } }
    public string CourseName { get { return _courseName; } set { _courseNumber = value; } }
  }
}