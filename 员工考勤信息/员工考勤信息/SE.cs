using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 员工考勤信息
{
    public class SE
    {
        private string _id;
        //员工号
        public string Id
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
        private SEX sex;

        public SEX Sex
        {
            get { return sex; }
            set { sex = value; }
        }
       

    }
}
