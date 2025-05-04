using LibrarySystem324.Model;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool ok = true;

            DataTable dt = DBEngine.GetTable("select * from user where upper(email)='" + txtLoginID.Text.ToUpper()
        + "' and userPassword='" + txtPassword.Text + "'");

            ok=dt.Rows.Count > 0;
            if (ok)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            char c = '\u2022';                      // or "\u25cf"
            txtPassword.PasswordChar = c;
        }
    }
}
