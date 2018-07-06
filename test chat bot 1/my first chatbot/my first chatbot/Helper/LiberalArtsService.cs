using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace my_first_chatbot.Helper
{
  public class LiberalArtsService
  {
    public List<LiberalArts> list;
    public static StudentInfoService studentinfo = new StudentInfoService();

    public LiberalArtsService()
    {
      this.list = readLiberalArts();
    }

    private List<LiberalArts> readLiberalArts()
    {
      var mylist = new List<LiberalArts>();
      string path = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, @"data\LiberalArts\");

      DirectoryInfo di = new DirectoryInfo(path);

      foreach (FileInfo Fi in di.GetFiles())
      {
        string mypath = path + Fi.Name;
        var rows = File.ReadAllLines(mypath).Select(a => a.Split(','));
        var myrows = rows.ToList();

        var sync = new object();
        myrows.RemoveAt(0);

        Parallel.ForEach(myrows, row =>
        {
          LiberalArts LA = new LiberalArts();
          LA.CourseType = row[0].ToString();
          LA.CourseNumber = row[1].ToString();
          LA.CourseName = row[2].ToString();

          lock (sync)
          {
            mylist.Add(LA);// here you can add or remove items from the fileInfo list
          }

        });
      }

      return mylist;
    }




    /// <summary>
    /// 해당 학생의 들을 수 있는 강의 개수 메세지 만들기
    /// </summary>
    /// <param name="StuNum"></param>
    /// <returns></returns>
    public string LiberalArtsView(int StuNum)
    {

      /*
       * csv 파일 읽기 문제인지 CourseNumber가 강의 이름으로 출력되는 현상 발견
       */

      string Reply_Message = "현재 정보통신과가 들을 수 있는 교양 과목은 총 " + this.list.Count() + "개이며,\n"
                             + StuNum.ToString() + "님이 들을 수 있는\n"
                             + "강의 목록은 총";

      Reply_Message += "공통교양은 " + GetListCount(StuNum, "공통교양 (구 필수교양)") + "개\n"
                       + "일반교양은 " + GetListCount(StuNum, "일반교양(구 균형교양)") + "개\n"
                       + "학문기초교양은 " + GetListCount(StuNum, "학문기초교양 (구 기초교양)") + "개\n"
                       + "핵심교양은 " + GetListCount(StuNum, "핵심교양 (구 선택교양)") + "개\n가있습니다.\n\n";
      if ((GetListCount(StuNum, "공통교양 (구 필수교양)") + GetListCount(StuNum, "일반교양(구 균형교양)") + GetListCount(StuNum, "학문기초교양 (구 기초교양)") + GetListCount(StuNum, "핵심교양 (구 선택교양)")) == 0)
        Reply_Message = "더 이상 들을 강의가 없습니다.\n";
      return Reply_Message;
    }

    /// <summary>
    /// 해당 학생의 들을 수 있는 강의 개수
    /// </summary>
    /// <param name="StuNum"></param>
    /// <param name="keyword"></param>
    /// <returns></returns>
    public int GetListCount(int StuNum, string keyword)
    {
      List<StudentInfo> student = studentinfo.totalElectiveListen(StuNum);
      List<LiberalArts> templist = this.list;

      for (int i = 0; i < templist.Count(); i++)
        for (int j = 0; j < student.Count(); j++)
          if (templist.ElementAt(i).CourseNumber == student.ElementAt(j).CourseName) templist.RemoveAt(i);

      var LiberList = from list in templist
                      where list.CourseType == keyword
                      select list;

      return LiberList.Count();
    }

    /// <summary>
    /// 해당 학생의 들을 수 있는 강의 리스트 작성
    /// </summary>
    /// <param name="StuNum"></param>
    /// <param name="keyword"></param>
    /// <returns></returns>
    public string GetList(int StuNum, string keyword)
    {
      String Reply_Message = keyword + " 안내입니다.\n\n";

      List<StudentInfo> student = studentinfo.totalElectiveListen(StuNum);
      List<LiberalArts> templist = this.list;

      for (int i = 0; i < templist.Count(); i++)
        for (int j = 0; j < student.Count(); j++)
          if (templist.ElementAt(i).CourseNumber == student.ElementAt(j).CourseName) templist.RemoveAt(i);

      if (templist.Count() == 0)
      {
        Reply_Message = "학번이 잘못되었습니다.\n";
        return Reply_Message;
      }
      var LiberList = from list in templist
                      where list.CourseType == keyword
                      select list;

      Reply_Message += StuNum + "님이 들을 수 있는\n강의의 수는" + LiberList.Count() + "개 입니다.\n\nList\n\n";
      for (int i = 0; i < LiberList.Count(); i++) Reply_Message += LiberList.ElementAt(i).CourseType + "\n" + LiberList.ElementAt(i).CourseNumber + "\n\n";
      return Reply_Message;
    }

    public string LiberalArtsGetList(int StuNum, int number)
    {

      string Reply_msg = null;
      if (StuNum == 0)
      {
        Reply_msg = "학번이 잘못되었습니다.\n";
        return Reply_msg;
      }
      try
      {    /// 리스트에서 목록을 제거하고 진행해야하므로 분리
        switch (number)
        {
          case 1:
            Reply_msg = GetList(StuNum, "공통교양 (구 필수교양)");
            break;
          case 2:
            Reply_msg = GetList(StuNum, "일반교양 (구 균형교양)");
            break;
          case 3:
            Reply_msg = GetList(StuNum, "학문기초교양 (구 기초교양)");
            break;
          case 4:
            Reply_msg = GetList(StuNum, "핵심교양 (구 선택교양)");
            break;
        }
        Reply_msg += "\n";
        return Reply_msg;
      }
      catch (Exception e)
      {
        Reply_msg = e.ToString();
        return Reply_msg;
      }
    }
  }
}