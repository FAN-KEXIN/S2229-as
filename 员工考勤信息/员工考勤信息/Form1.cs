using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 员工考勤信息
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<SE> list = new List<SE>();

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Form2 from = new Form2(this);
            from.button2.Visible = false;
            from.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = new BindingList<SE>(list);
           
        }
        //刷新dgv数据
        public void BindGrid()
        {
            this.dataGridView1.DataSource = new BindingList<SE>(list);
        }
        
        List<SE> tempList = new List<SE>();//用临时列表保存查询到的信息
        //查询事件
        private void button1_Click(object sender, EventArgs e)
        {
            tempList.Clear();                                                                             
            foreach (SE item in this.list)
            {
                if (item.Id.IndexOf(this.textBox1.Text.Trim()) != -1)
                {
                    tempList.Add(item);
                    break;
                }
                else
                {
                    MessageBox.Show("没有这个员工！");
                }
            }
            this.dataGridView1.DataSource = new BindingList<SE>(tempList);
        }
        //修改事件
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            string up = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            foreach (SE item in this.list)
            {
                if (item.Id == up)
                {
                    Form2 from = new Form2(this);
                    from.textBox1.Text = item.Id;
                    from.textBox2.Text = item.Name;
                    from.textBox3.Text = item.Age.ToString();
                   if (from.comboBox1.Text == "男")
                      {
                         item.Sex = SEX.男;
                          }
                     else
                 {
                     item.Sex = SEX.女;
                  }
                    from.hh = item;
                    from.button1.Visible = false;
                    from.Show();

                }
            }
        }
        //删除事件
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            //选中dgv里的员工号
            string de=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult resu;
            resu = MessageBox.Show("确定删除吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (resu == DialogResult.Yes)
            {
                foreach (SE item in this.list)
                {
                    if (item.Id == de)
                    {
                        //删除操作
                        list.Remove(item);
                        break;
                    }
                }
                BindGrid();
            }
            
        }
        //打卡记录Dictionary
        public static Dictionary<string, Record> recordList = new Dictionary<string, Record>();

        //签到
        private void 签到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count!=1)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            //确定没有签过到
            string workNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            MessageBox.Show(workNo);
            foreach (string id in recordList.Keys)
            {
                if (workNo==id)
                {
                    MessageBox.Show("您已经签到了！");
                    return;
                }
            }
                //执行签到
                Record record = new Record();
                record.ID = workNo;
                record.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                record.SignInTime = DateTime.Now;
                recordList.Add(record.ID, record);
                MessageBox.Show("签到成功！");
            
        }

        private void 签退ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            string ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bool isOut = false;//标识是否已经签到过
            foreach (string key in recordList.Keys)
            {
                if (key==ID)
                {
                    //执行签到，设置签退时间
                    recordList[key].SignOutTime = DateTime.Now;
                    MessageBox.Show("签退成功");
                    isOut = true;
                    break;
                }
            }
            if (!isOut)
            {
                MessageBox.Show("抱歉，尚未签到");
            }
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            Form3 b = new Form3();
            b.Show();
        }
    }
}
