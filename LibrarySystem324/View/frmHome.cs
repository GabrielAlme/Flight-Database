using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem324.View
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog(this) != DialogResult.OK) { 
                Application.Exit();
            }

        }

        private void btnScheduleEditor_Click(object sender, EventArgs e)
        {
            frmBook frm=new frmBook();
            frm.ShowDialog(this);
        }
    }
}
