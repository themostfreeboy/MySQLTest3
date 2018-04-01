using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySQLTest_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MyDatabase.SetServer(textBox1.Text.Trim());
                MyDatabase.SetDatabase(textBox2.Text.Trim());
                MyDatabase.SetUid(textBox3.Text.Trim());
                MyDatabase.SetPwd(textBox4.Text.Trim());
                if (MyDatabase.TestMyDatabaseConnect() == true)
                {
                    MessageBox.Show("数据库连接成功！");
                    return;
                }
                else
                {
                    MessageBox.Show("数据库连接失败！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！\n" + ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MyDatabase.SetServer(textBox1.Text.Trim());
                MyDatabase.SetDatabase(textBox2.Text.Trim());
                MyDatabase.SetUid(textBox3.Text.Trim());
                MyDatabase.SetPwd(textBox4.Text.Trim());
                if (MyDatabase.TestMyDatabaseConnect() == false)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("数据库连接失败！");
                    return;
                }
                string sql = "select * from " + textBox5.Text.Trim() + ";";
                DataSet ds = MyDatabase.GetDataSetBySql(sql);
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("数据获取成功！");
                return;
            }
            catch (Exception ex)
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("数据获取失败！\n错误信息：\n" + ex.Message);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = "localhost";
            textBox2.Text = "achievementmanage";
            textBox3.Text = "root";
            textBox4.Text = "123456";
            textBox5.Text = "datainfo";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Compare(this.comboBox1.SelectedItem.ToString(), "本地连接") == 0)
            {
                textBox1.Text = "localhost";
                return;
            }
            else if (string.Compare(this.comboBox1.SelectedItem.ToString(), "远程连接") == 0)
            {
                textBox1.Text = "10.205.25.244";
                return;
            }
            else
            {
                MessageBox.Show("选项选择出错！");
                return;
            }
        }
    }
}
