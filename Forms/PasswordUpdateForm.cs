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
using Services;

namespace Forms
{
    public partial class PasswordUpdateForm : Form
    {
        private readonly User _user;
        private readonly UserService _service;

        public PasswordUpdateForm(User user)
        {
            _user = user;
            _service = new UserService();
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var oldPassword = textBoxPassword.Text;
            var newPassword = textBoxNew.Text;
            var repeatPassword = textBoxRepeat.Text;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(repeatPassword))
            {
                MessageBox.Show("Не все поля заполнены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_user.Password.Equals(HashService.Md4Hash(oldPassword)))
            {
                MessageBox.Show("Неверно введен текущий пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!newPassword.Equals(repeatPassword))
            {
                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_user.PasswordRestriction)
            {
                const string reg = @"^[^\s\d]*$";
                if (!Regex.IsMatch(newPassword, reg))
                {
                    MessageBox.Show("Пароль не соответствует ограничению", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _user.Password = HashService.Md4Hash(newPassword);
            _service.UpdateUser(_user);
            DialogResult = DialogResult.OK;
        }
    }
}
