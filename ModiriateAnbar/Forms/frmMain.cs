using ModiriateAnbar.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriateAnbar.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            //pnlMain.Controls.Clear();
            //var uc = new ucProduct();
            //pnlMain.Controls.Add(uc);
            ShowUserContrl(new ucProduct());
        }

        private void btnEmpioyeeList_Click(object sender, EventArgs e)
        {
            //pnlMain.Controls.Clear();
            //var uc = new ucEmployee();
            //pnlMain.Controls.Add(uc);
            ShowUserContrl(new ucEmployee());
        }

        private void ShowUserContrl(UserControl uc)
        {

        pnlMain.Controls.Clear();
            
        pnlMain.Controls.Add(uc);

        }

        private void btnProductCategory_Click(object sender, EventArgs e)
        {
            ShowUserContrl(new ucCategoryList());
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            ShowUserContrl(new ucCategory());
        }
    }
}
