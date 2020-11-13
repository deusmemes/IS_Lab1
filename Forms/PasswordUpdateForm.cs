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
                ErrorMessage("Не все поля заполнены");
                return;
            }

            if (!_user.Password.Equals(HashService.Md4Hash(oldPassword)))
            {
                ErrorMessage("Неверно введен текущий пароль");
                return;
            }

            if (!newPassword.Equals(repeatPassword))
            {
                ErrorMessage("Пароли не совпадают");
                return;
            }


            if (_user.PasswordRestriction)
            {
                const string reg = @"^[^\s\d]*$";
                if (!Regex.IsMatch(newPassword, reg))
                {
                    ErrorMessage("Пароль не соответствует ограничению");
                    return;
                }
            }

            //_user.Password = HashService.Md4Hash(newPassword);
            _service.UpdatePassword(_user.Name, newPassword);
            DialogResult = DialogResult.OK;
        }

        private static void ErrorMessage(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
