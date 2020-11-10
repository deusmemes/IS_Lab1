using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        public string Password { get; set; }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Поле не заполнено!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
