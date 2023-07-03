using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairy_Project
{
    public partial class DairyApp : Form
    {
        public DairyApp()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search rg = new Search();
            rg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Informations rg = new Informations();
            rg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserView rg = new UserView();
            rg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DiaryView rg = new DiaryView();
            rg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm rg = new MainForm();
            rg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DairyApp_Load(object sender, EventArgs e)
        {

        }
    }
}
