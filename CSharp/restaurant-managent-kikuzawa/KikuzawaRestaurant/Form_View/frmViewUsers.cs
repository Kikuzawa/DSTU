using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KikuzawaRestaurant.Classes;
namespace KikuzawaRestaurant.Form_View
{
    public partial class frmViewUsers : Form
    {
        public frmViewUsers()
        {
            InitializeComponent();
        }
        clsView viewClass = new clsView();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewUsers_Load(object sender, EventArgs e)
        {
            viewClass.viewUsers(dataGridView1);
        }
    }
}
