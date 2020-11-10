using Models;
using Services;
using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class UserAddForm : Form
    {
        private readonly UserService service;

        public UserAddForm()
        {
            InitializeComponent();
            service = new UserService();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var restriction = checkBox.Checked;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Не все поля заполнены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var user = new User
                {
                    Name = name,
                    Password = "",
                    IsBlocked = false,
                    Type = UserEnum.DEFAULT,
                    PasswordRestriction = restriction
                };
                service.AddUser(user);
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
