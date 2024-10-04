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
namespace KikuzawaRestaurant.Forms
{
    public partial class frmPopupChange : Form
    {
        public frmPopupChange()
        {
            InitializeComponent();
        }

        clsSelect selectClass = new clsSelect();
        private void frmPopupChange_Load(object sender, EventArgs e)
        {
            selectClass.selectCurrencyUsedFromLabel(label2, "Inused");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
