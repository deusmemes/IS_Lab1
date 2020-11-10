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
    public partial class FormUser : Form
    {
        private readonly User _model;
        private readonly UserService _service;

        public FormUser(User user)
        {
            _model = user;
            _service = new UserService();
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _model.IsBlocked = checkBoxBlock.Checked;
            _model.PasswordRestriction = checkBox.Checked;

            try
            {
                _service.UpdateUser(_model);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            checkBox.Checked = _model.PasswordRestriction;
            checkBoxBlock.Checked = _model.IsBlocked;
            textBoxName.Text = _model.Name;
        }
    }
}
