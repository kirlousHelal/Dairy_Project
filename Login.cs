using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairy_Project
{
    public partial class Login : Form
    {
        public static String Username;
        OracleConnection con;
        string ordb = "data source=ORCL;user id=scott;password=tiger;";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Register f1 = new Register();
            f1.Show();
            this.Hide();*/

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select PASSWWORD from Users where USNAME=:name";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("name", textBox2.Text);
           // cmd.Parameters.Add("password", textBox5.Text);

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (textBox5.Text==dr[0].ToString())
                {
                    Username = textBox2.Text.ToString();
                    //MessageBox.Show(Username);
                    //MessageBox.Show("Login Successfully");
                    this.Hide();
                    DairyApp rg = new DairyApp();
                    rg.Show(); this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed,Please Enter The Correct Password");
                }
            }
            else
            {
                MessageBox.Show("Please Enter The Correct User Name");
            }

           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rg = new Register();
            rg.Show();
        }
    }
}
