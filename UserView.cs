using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Dairy_Project
{
    public partial class UserView : Form
    {
        UsersReport ur;
        public UserView()
        {
            InitializeComponent();
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            ur = new UsersReport();

            foreach (ParameterDiscreteValue v in ur.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ur.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = ur;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DairyApp rg = new DairyApp();
            rg.Show();
        }
    }
}
