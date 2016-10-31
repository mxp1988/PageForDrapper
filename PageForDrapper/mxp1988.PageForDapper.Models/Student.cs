using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxp1988.PageForDapper.Models
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学生id
        /// </summary>
        public  int Id { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public  string Number { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别 0 男 1 女 2 保密
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
