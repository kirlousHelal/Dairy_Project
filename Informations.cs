using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
    public partial class Informations : Form
    {
        OracleConnection con;
        string ordb = "data source=ORCL;user id=scott;password=tiger;";
        
        public Informations()
        {
            InitializeComponent();
        }

        private void Informations_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(ordb);
            con.Open();
    
            comboBox1.Select();
           

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select userID from Users where USNAME=:name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", Login.Username);

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                   comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "GETDATA";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("input",comboBox1.Text);
            cmd.Parameters.Add("output1",OracleDbType.Varchar2,2000).Direction=ParameterDirection.Output;
            cmd.Parameters.Add("output2",OracleDbType.Varchar2,2000).Direction=ParameterDirection.Output;
            cmd.Parameters.Add("output3",OracleDbType.Varchar2,2000).Direction=ParameterDirection.Output;
            cmd.Parameters.Add("output4",OracleDbType.Varchar2,2000).Direction=ParameterDirection.Output;
            cmd.Parameters.Add("output5",OracleDbType.Varchar2,2000).Direction=ParameterDirection.Output;
            try
            {
                int r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
          
            //if (r!=-1)
            {

                textBox1.Text = Convert.ToString(cmd.Parameters["output1"].Value); ;
                textBox2.Text = Convert.ToString(cmd.Parameters["output2"].Value); ;
                textBox3.Text = Convert.ToString(cmd.Parameters["output3"].Value); ;
                textBox4.Text = Convert.ToString(cmd.Parameters["output4"].Value); ;
                textBox5.Text = Convert.ToString(cmd.Parameters["output5"].Value); ;
            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "MULTIPULEROWS";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("input", comboBox1.Text);
            cmd.Parameters.Add("output", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
        }

        private void comboBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DairyApp rg = new DairyApp();
            rg.Show();
        }
    }
}
