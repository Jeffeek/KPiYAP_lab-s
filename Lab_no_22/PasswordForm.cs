using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Close();
        }
    }
}
