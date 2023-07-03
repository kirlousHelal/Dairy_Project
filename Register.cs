using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairy_Project
{
    public partial class Register : Form
    {
        OracleConnection con;
        string ordb = "data source=ORCL;user id=scott;password=tiger;";
        public Register()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
            textBox3.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char gen;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Users values(:id,:name,:password,:email,:phone,:gender)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", textBox1.Text);
            cmd.Parameters.Add("name", textBox2.Text);
            cmd.Parameters.Add("password", textBox3.Text);
            cmd.Parameters.Add("email", textBox4.Text);
            cmd.Parameters.Add("phone", textBox5.Text);
            if (radioButton1.Checked == true)
            {
                gen = 'M';
                
            }
            else if (radioButton2.Checked == true)
            {
                gen = 'F';
            }
            else
            {
                gen = ' ';
            }
            
           cmd.Parameters.Add("gender", gen.ToString());
           int r = cmd.ExecuteNonQuery();
           if(r!=-1)
            {
                MessageBox.Show("the new data was inserted successfully");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm rg = new MainForm();
            rg.Show();
        }
    }
}
