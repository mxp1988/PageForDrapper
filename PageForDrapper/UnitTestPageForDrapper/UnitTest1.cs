using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mxp1988.PageForDapper.Models;
using mxp1988.PageForDapper.Dao;

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
                student.Sex = new Random().Next(0, 3);
                student.Email = i.ToString().PadLeft(4, '0') + "@student.com";
                list.Add(student);
            }
            int count = new StudentDao().InsertBatchStudent(list);
            Console.WriteLine(string.Format("本次共插入{0}位学生",count));
        }
        [TestMethod]
        public void TestPage()
        {

        }
    }
}
