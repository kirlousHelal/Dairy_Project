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
    public partial class DiaryView : Form
    {
        DiaryReport Dr;
        public DiaryView()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void DiaryView_Load(object sender, EventArgs e)
        {
            Dr = new DiaryReport();

            foreach (ParameterDiscreteValue v in Dr.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
            comboBox1.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dr.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = Dr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DairyApp rg = new DairyApp();
            rg.Show();
        }
    }
}
