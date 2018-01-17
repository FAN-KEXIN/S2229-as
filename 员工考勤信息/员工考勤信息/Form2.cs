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
    public partial class Form2 : Form
    {
        public Form1 frm;
        public SE hh;
        public Form2(Form1 Fm)
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            frm = Fm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region 文本框的值
                SE pr = new SE();
                pr.Id = this.textBox1.Text.Trim();//员工号
                pr.Age = Int32.Parse(this.textBox2.Text.Trim());//年龄
                pr.Name = this.textBox3.Text.Trim();//姓名
                //性别
                if (this.comboBox1.Text == "男")
                {
                    pr.Sex = SEX.男;
                }
                else
                {
                    pr.Sex = SEX.女;
                }
                #endregion
                #region 工号唯一验证
                foreach (SE item in frm.list)
                {
                    if (item.Id ==this.textBox1.Text)
                    {
                        MessageBox.Show("此工号已存在！");
                        return;
                    }

                }
                frm.list.Add(pr);
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.frm.BindGrid();
            }
        }
        //修改事件
        private void button2_Click(object sender, EventArgs e)
        {
            
            hh.Id = this.textBox1.Text.Trim();//员工号
            hh.Age = Int32.Parse(this.textBox2.Text.Trim());//年龄
            hh.Name = this.textBox3.Text.Trim();//姓名
            //性别
            if (this.comboBox1.Text == "男")
            {
                hh.Sex = SEX.男;
            }
            else
            {
                hh.Sex = SEX.女;
            }
            this.frm.BindGrid();
        }
    }
}
