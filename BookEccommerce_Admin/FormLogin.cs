using ClassLibrary_RepositoryDLL.Services;
using ClassLibrary_RepositoryDLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_RepositoryDLL.Services.Admin;

namespace BookEccommerce_Admin
{
    public partial class FormLogin : Form
    {
        public AccountManagementService accountManagement = new AccountManagementService();
        public FormLogin()
        {
            InitializeComponent();
            txt_password.PasswordChar = '•';
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            CancelEventArgs oc = new CancelEventArgs();
            oc.Cancel = true;
            if (string.IsNullOrEmpty(txt_username.Text))
            {
                errorProvider1.SetError(txt_username, "Your username is left blank");
            }
            else if (string.IsNullOrEmpty(txt_password.Text))
            {
                errorProvider1.SetError(txt_password, "Your password is left blank");
            }
            else if (txt_password.Text.Trim().Length < 8)
            {
                errorProvider1.SetError(txt_password, "Password must be at least 8 characters");
            }
            else
            {
                errorProvider1.SetError(txt_username, null);
                errorProvider1.SetError(txt_password, null);
                oc.Cancel = false;
                Account account = new Account()
                {
                    Username = txt_username.Text,
                    Password = txt_password.Text,
                };

                bool result = accountManagement.checkLogin(account.Username, account.Password);
                if (result == true)
                {
                    MessageBox.Show("Login successfully, it's moving to Admin Form");
                    this.Hide();
                    FrmDashboard frmAdmin = new FrmDashboard();
                    frmAdmin.Show();
                }
                else
                    MessageBox.Show("Login uncessfully, please check it again");
            }
        }
    }
}

