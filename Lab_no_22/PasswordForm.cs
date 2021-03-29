#region Using namespaces

using System;
using System.Windows.Forms;

#endregion

namespace Lab_no_22
{
    public partial class PasswordForm : Form
    {
        private readonly Action _checkPassword;

        public PasswordForm(Action checkPassword)
        {
            _checkPassword = checkPassword;
            InitializeComponent();
        }

        private void buttonApplyPassword_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "superpassword") return;

            _checkPassword();
            Close();
        }
    }
}