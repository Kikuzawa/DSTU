using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using KikuzawaRestaurant.Form_View;
namespace KikuzawaRestaurant.Forms
{
    public partial class frmReceiptPreview : Form
    {
        public frmReceiptPreview()
        {
            InitializeComponent();
        }

        frmViewOrderSettlement fvos = new frmViewOrderSettlement();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReceiptPreview_Load(object sender, EventArgs e)
        {
            button1.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
