using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KikuzawaRestaurant.Forms;

namespace KikuzawaRestaurant.Forms
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label2.Text = "Restaurant Kikuzawa";
            label1.Text = "v0.1";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           frmLogin  formLogin = new frmLogin();
            progressBar1.Increment(1);

            if (this.progressBar1.Value == 10)
            {
                label3.Visible = true;
                label3.Text = "Starting...";
            }

            else if (this.progressBar1.Value == 60)
            {
                label3.Visible = true;
                label3.Text = "Loading modules...";
            }
            else if (this.progressBar1.Value == 80)
            {
                label3.Visible = true;
                label3.Text = "Processing...";
            }
            else if (this.progressBar1.Value == 90)
            {
                label3.Visible = true;
                label3.Text = "Finishing...";
            }
            else if (this.progressBar1.Value == 100)
            {

                timer1.Stop();
                this.Hide();
                formLogin.Show();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
