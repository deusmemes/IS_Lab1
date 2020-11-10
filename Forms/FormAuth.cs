using Models;
using Services;
using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class FormAuth : Form
    {
        private readonly FileService _fileService;
        private readonly UserService _userService;
        private int countAuth = 0;

        public FormAuth()
        {
            InitializeComponent();
            _fileService = new FileService();
            _userService = new UserService();

            _userService.LoadUsers(_fileService.GetDataFromFile(FilePathsEnum.TEMP, false));
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {

        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (countAuth == 3)
            {
                Close();
            }

            var name = textBoxName.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Не все поля заполнены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var dataUser = _userService.GetUser(name);

                if (dataUser == null)
                {
                    throw new Exception("Пользователь с таким именем не найден");
                }

                var user = new User
                {
                    Name = dataUser.Name,
                    Password = dataUser.Password,
                    Type = dataUser.Type,
                    IsBlocked = dataUser.IsBlocked,
                    PasswordRestriction = dataUser.PasswordRestriction
                };

                if (dataUser.Password == HashService.Md4Hash(""))
                {
                    var passwordForm = new PasswordAddForm(user.PasswordRestriction);
                    var result = passwordForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        user.Password = HashService.Md4Hash(passwordForm.Password);
                        _userService.UpdateUser(user);
                        _userService.Auth(user);
                        new UsersForm().Show();
                        countAuth = 0;
                    }
                }
                else
                {
                    var passwordForm = new PasswordForm();
                    var result = passwordForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        user.Password = HashService.Md4Hash(passwordForm.Password);
                        _userService.Auth(user);
                        new UsersForm().Show();
                        countAuth = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                countAuth++;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
