using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Forms
{
    public partial class PasswordAddForm : Form
    {
        public string Password { get; set; }
        private readonly bool restrict;

        public PasswordAddForm(bool restrict)
        {
            this.restrict = restrict;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Password = textBoxPassword.Text;
            var repeat = textBoxRepeat.Text;

            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(repeat))
            {
                MessageBox.Show("Не все поля заполнены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Password.Equals(repeat))
            {
                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (restrict)
            {
                const string reg = @"^[^\s\d]*$";
                if (!Regex.IsMatch(Password, reg))
                {
                    MessageBox.Show("Пароль не соответствует ограничению", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
