using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LanSQL
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
                SqlConnection conn;
                string connStr = @"Data Source=WINDOWSPC,49159;Initial Catalog=EVENTDB;Network Library=DBMSSOCN;Integrated Security=false;User Id=sa;Password=hackerone;";
                conn = new SqlConnection(connStr);
                conn.Open();
                string pass = password.Text;
                string query = "update auth set passwd='"+ pass +"' where uname='admin'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Check now!");
            }
            
        }
    }
}
