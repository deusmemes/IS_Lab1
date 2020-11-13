using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Services;

namespace Forms
{
    public partial class UsersForm : Form
    {
        private readonly UserService service;
        private readonly User currentUser = Data.GetInstance().CurrentUser;

        public UsersForm()
        {
            InitializeComponent();
            service = new UserService();

            labelCurrentUser.Text = currentUser.Name;

            if (currentUser.Type != UserEnum.DEFAULT) return;
            dataGridView.Visible = false;
            buttonAdd.Visible = false;
            buttonDelete.Visible = false;
            buttonUpdate.Visible = false;
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (currentUser.Type == UserEnum.DEFAULT) return;

            var data = new BindingList<User>();
            var users = service.GetList();
            users.ForEach(user =>
            {
                if (user.Type != UserEnum.ADMIN) data.Add(user);
            });
            dataGridView.DataSource = data;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].Visible = false;
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new UserAddForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 1) return;
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var selectedUserName = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            service.DeleteUser(selectedUserName);
            LoadData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var user = service.GetUser(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
            var form = new FormUser(user);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            var user = Data.GetInstance().CurrentUser;
            var form = new PasswordUpdateForm(user);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InfoForm().Show();
        }
    }
}
