using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//DataColumn和DataRow需要
using System.Windows.Forms;//DataGridView需要

namespace MySQLTest_3
{
    class MyData
    {
        public static System.Data.DataTable GetDgvToTable(DataGridView dgv)//将DataGridView控件中的内容转化成System.Data.DataTable
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)//列强制转换
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)//循环行
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static string GetFileExtByFileName(string filename)//通过文件名获取文件扩展名
        {
            try
            {
                string fileext = string.Empty;
                fileext = filename.Substring(filename.LastIndexOf(".") + 1);//获取文件扩展名
                fileext = fileext.ToLower();//将所有后缀扩展名转化为小写，便于比较
                return fileext;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        public static bool DateTimeRemoveTime(System.Data.DataTable dt)//将System.Data.DataTable中时间所在列进行处理，去除时间只留日期(System.Data.DataTable传递的为引用值，类似于地址，结果会影响传入的类，不需要通过返回DataTable来实现改变)
        {
            try
            {
                string str = string.Empty;
                for (int count = 0; count < dt.Rows.Count - 1; count++)//因为最后一行为空数据所以最后一行不处理(count < dt.Rows.Count - 1)，否则最后一行在执行Convert.ToDateTime函数时会出现无法转化的异常
                {
                    str = Convert.ToDateTime(dt.Rows[count][2].ToString().Trim()).ToString("yyyy-MM-dd");//去除时间只留日期
                    dt.Rows[count][2] = str;
                }
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return false;
            }
        }

        public static bool DataConvert(System.Data.DataTable dt)//此函数主要针对于通过文件导入后，部分格式不正确的数据显示到“导入失败的信息显示”中，尤其出现“(数据格式有误)”时，之前的函数无法将这些数据导出到文件，此函数主要完成此部分的处理
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)//因为最后一行为空数据所以最后一行不处理(i < dt.Rows.Count - 1)，否则最后一行在执行Convert.ToDateTime函数时会出现无法转化的异常
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        try
                        {
                            if (j == 2)//对成果时间的数据格式的单独转化
                            {
                                dt.Rows[i][j] = Convert.ToDateTime(dt.Rows[i][j].ToString().Trim()).ToString("yyyy-MM-dd");//去除时间只留日期
                            }
                            else if (j == 5)//对成果支撑基金的格式的单独转化
                            {
                                dt.Rows[i][j] = Convert.ToDouble(dt.Rows[i][j].ToString().Trim());
                            }
                            else//其他字段格式不需要转化
                            {
                                dt.Rows[i][j] = dt.Rows[i][j].ToString();
                            }
                        }
                        catch (Exception ex_2)//格式转化出错
                        {
                            dt.Rows[i][j] = "(数据格式有误)".ToString();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex_1)
            {
                //MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return false;
            }
        }
    }
}
