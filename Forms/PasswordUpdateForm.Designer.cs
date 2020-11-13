namespace Forms
{
    partial class PasswordUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxRepeat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите новый пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Введите пароль";
            // 
            // textBoxNew
            // 
            this.textBoxNew.Location = new System.Drawing.Point(110, 223);
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.PasswordChar = '*';
            this.textBoxNew.Size = new System.Drawing.Size(251, 26);
            this.textBoxNew.TabIndex = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(146, 396);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(159, 40);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Продолжить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(110, 121);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(251, 26);
            this.textBoxPassword.TabIndex = 7;
            // 
            // textBoxRepeat
            // 
            this.textBoxRepeat.Location = new System.Drawing.Point(110, 323);
            this.textBoxRepeat.Name = "textBoxRepeat";
            this.textBoxRepeat.PasswordChar = '*';
            this.textBoxRepeat.Size = new System.Drawing.Size(251, 26);
            this.textBoxRepeat.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Повторите пароль";
            // 
            // PasswordUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 457);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRepeat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNew);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxPassword);
            this.Name = "PasswordUpdateForm";
            this.Text = "Обновление пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxRepeat;
        private System.Windows.Forms.Label label3;
    }
}