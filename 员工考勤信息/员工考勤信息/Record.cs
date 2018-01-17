using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 员工考勤信息
{
    public class Record
    {
        //签到时间
        public DateTime SignInTime { get; set; }
        //签退时间
        public DateTime SignOutTime { get; set; }
        //工号
        public string ID { get; set; }
        //员工姓名
        public string Name { get; set; }

    }
}
