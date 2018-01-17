using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 员工考勤信息
{
    public class PM
    {
        private int _id;
        //员工号
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        //姓名
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //年龄
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        //性别
        public SEX sex;
        //资历
        private string _zili;

        public string Zili
        {
            get { return _zili; }
            set { _zili = value; }
        }
        ////评分的方法
        //public void Rating(SE se, string PmPingjia, int PmPopularity)
        //{
        //    se.PmPopularity = PmPopularity;
        //    se.PmPingjia = PmPingjia;
        //}
    }
}
