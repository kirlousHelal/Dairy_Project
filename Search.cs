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
    public partial class Search : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder build;
        DataSet ds;
        String con;

        public Search()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {
            con = "data source=ORCl; user id=scott; password=tiger;";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = @"select diaryid, diaryname,DiaryCategory from diary   where diaryid=:id";

            adapter = new OracleDataAdapter(cmd, con);
            adapter.SelectCommand.Parameters.Add("id", textBox1.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            build = new OracleCommandBuilder(adapter);
           // adapter.UpdateCommand = build.GetUpdateCommand();
            adapter.Update(ds.Tables[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DairyApp rg = new DairyApp();
            rg.Show();
        }
    }
}
