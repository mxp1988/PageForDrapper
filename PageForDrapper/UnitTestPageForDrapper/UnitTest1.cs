using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mxp1988.PageForDapper.Models;
using mxp1988.PageForDapper.Dao;
using mxp1988.PageForDapper.Models.Common;

namespace UnitTestPageForDrapper
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testInsertStudent()
        {
            List<Student> list = new List<Student>();
            for (int i = 1; i < 100; i++)
            {
                Student student = new Student();
                student.Number = DateTime.Now.ToString("yyyyMMdd") + i.ToString().PadLeft(4, '0');
                student.Name = "学生" + i.ToString().PadLeft(4, '0');
                student.Sex = i%2;
                student.Email = i.ToString().PadLeft(4, '0') + "@student.com";
                list.Add(student);
            }
            int count = new StudentDao().InsertBatchStudent(list);
            Console.WriteLine(string.Format("本次共插入{0}位学生",count));
        }
        [TestMethod]
        public void TestPage()
        {
            PageCriteria pageCriteria=new PageCriteria();
            StringBuilder sb=new StringBuilder();
            sb.Append("Number like @number");
            pageCriteria.ParameterList.Add(new ParameterDict() {ParamName = "number",ParamValue = DateTime.Now.ToString("yyyyMMdd")+"%" });
            sb.Append(" and sex=@sex");
            pageCriteria.ParameterList.Add(new ParameterDict() { ParamName = "sex", ParamValue = 1});
            pageCriteria.Condition = sb.ToString();
            pageCriteria.CurrentPage = 1;
            pageCriteria.Fields = " id,number,name,sex,email ";
            pageCriteria.PageSize = 10;
            pageCriteria.PrimaryKey = " id";
            pageCriteria.Sort = " id desc";
            pageCriteria.TableName = "Student";

            var studentInfo=
            new StudentDao().GetPageList(pageCriteria);
            Console.WriteLine(string.Format("符合条件的学生共有:{0}名,总共有{1}页,当前是第{2}页",studentInfo.TotalNum,studentInfo.TotalPageCount,studentInfo.CurrentPage));
            foreach (var item in studentInfo.Items)
            {
                Console.WriteLine(string.Format("学号:{0}  姓名:{1}",item.Number,item.Name));
            }
        }

        [TestMethod]
        public void TestRand()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(new Random().Next(1,3));
            }
        }
    }
}
