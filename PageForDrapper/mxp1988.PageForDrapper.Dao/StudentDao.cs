using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mxp1988.PageForDapper.Models;
using mxp1988.PageForDapper.Models.Common;

namespace mxp1988.PageForDapper.Dao
{
    public class StudentDao
    {
        private string connectStr = "";

        public StudentDao()
        {
            connectStr= System.Configuration.ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        }
        /// <summary>
        /// 批量插入学生
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public int InsertBatchStudent(List<Student> students)
        {
            string sql = @"insert into student (Number,Name,Sex,Email) values (@Number,@Name,@Sex,@Email)";
            return DatabaseHelper<SqlConnection>.ExecuteNonQuery(connectStr, sql, students);
        }
        /// <summary>
        /// 根据分页实体获取分页数据
        /// </summary>
        /// <param name="pageCriteria">分页实体</param>
        /// <returns></returns>
        public PageDataView<Student> GetPageList(PageCriteria pageCriteria)
        {
            return DatabaseHelper<SqlConnection>.GetPageListForSQL<Student>(connectStr, pageCriteria);
        }
    }
}
