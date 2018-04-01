using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;//MySql数据库处理使用
//using System.Windows.Forms;//MessageBox.Show使用需要

namespace MySQLTest_3
{
    class MyDatabase
    {
        private static string server = "localhost";
        private static string database = "achievementmanage";
        private static string uid = "root";
        private static string pwd = "123456";

        private static string ConnectString = "server=localhost;port=3306;database=achievementmanage;uid=root;pwd=123456";//数据库连接字符串

        public static void SetServer(string serverset)
        {
            server = serverset;
            ConnectString = string.Format("server={0};database={1};uid={2};pwd={3}", server, database, uid, pwd);//数据库连接字符串
        }

        public static void SetDatabase(string databaseset)
        {
            database = databaseset;
            ConnectString = string.Format("server={0};database={1};uid={2};pwd={3}", server, database, uid, pwd);//数据库连接字符串
        }

        public static void SetUid(string uidset)
        {
            uid = uidset;
            ConnectString = string.Format("server={0};database={1};uid={2};pwd={3}", server, database, uid, pwd);//数据库连接字符串
        }

        public static void SetPwd(string pwdset)
        {
            pwd = pwdset;
            ConnectString = string.Format("server={0};database={1};uid={2};pwd={3}", server, database, uid, pwd);//数据库连接字符串
        }

        public static bool TestMyDatabaseConnect()//测试数据库能否连接成功
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectString))//创建数据库连接对象(通过将连接放到using中可以使得数据库使用后自动释放资源，不需要调用con.Close()释放)
                {
                    con.Open();//打开连接
                    return true;//数据库连接成功
                }
            }
            catch (Exception ex)//数据库连接失败
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return false;
            }
        }

        public static DataSet GetDataSetBySql(string sql)//通过sql语句获取数据集对象
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectString))//创建数据库连接对象(通过将连接放到using中可以使得数据库使用后自动释放资源，不需要调用con.Close()释放)
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);//创建适配器对象
                    DataSet ds = new DataSet();//创建数据集对象               
                    adapter.Fill(ds);//填充数据集
                    return ds;//返回数据表
                }
            }
            catch (MySqlException ex)//异常处理
            {
                 System.Windows.Forms.MessageBox.Show(ex.Message);
                 //throw new Exception(ex.Message);
                 return null;
            }
        }

        public static bool UpdateDataBySql(string sql)//通过sql语句更新数据库内的数据
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectString))//创建数据库连接对象(通过将连接放到using中可以使得数据库使用后自动释放资源，不需要调用con.Close()释放)
                {
                    con.Open();//打开连接
                    MySqlCommand comm = new MySqlCommand(sql, con);//创建Command对象
                    if (comm.ExecuteNonQuery() > 0)//执行更新
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }                          
                }
            }
            catch (MySqlException ex)//异常处理
            {
                //MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return false;
            }
        }
    }
}
