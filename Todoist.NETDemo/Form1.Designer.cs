// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.Designer.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET.Demo
{
    partial class Form1
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginStatusLabel = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.deleteProjectButton = new System.Windows.Forms.Button();
            this.idBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.cacheCountLabel = new System.Windows.Forms.Label();
            this.cacheCountBox = new System.Windows.Forms.TextBox();
            this.isCollapsedLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.userIdBox = new System.Windows.Forms.TextBox();
            this.indentLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.orderLabel = new System.Windows.Forms.Label();
            this.isCollapsedComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.orderBox = new System.Windows.Forms.NumericUpDown();
            this.indentBox = new System.Windows.Forms.NumericUpDown();
            this.colorComboBox = new Todoist.NET.Demo.ColorComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.orderBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indentBox)).BeginInit();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(354, 14);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(78, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E-mail address:";
            // 
            // emailBox
            // 
            this.emailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailBox.Location = new System.Drawing.Point(357, 30);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(115, 20);
            this.emailBox.TabIndex = 1;
            this.emailBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EmailBoxKeyPress);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(354, 53);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordBox.Location = new System.Drawing.Point(357, 69);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(115, 20);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordBoxKeyPress);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.Location = new System.Drawing.Point(397, 92);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // loginStatusLabel
            // 
            this.loginStatusLabel.AutoSize = true;
            this.loginStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 45.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginStatusLabel.Location = new System.Drawing.Point(365, 11);
            this.loginStatusLabel.Name = "loginStatusLabel";
            this.loginStatusLabel.Size = new System.Drawing.Size(0, 70);
            this.loginStatusLabel.TabIndex = 5;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 11);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(176, 82);
            this.listBox.TabIndex = 6;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxSelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Enabled = false;
            this.refreshButton.Location = new System.Drawing.Point(194, 11);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(101, 23);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.Text = "Refresh list";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // createProjectButton
            // 
            this.createProjectButton.Enabled = false;
            this.createProjectButton.Location = new System.Drawing.Point(194, 40);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(101, 23);
            this.createProjectButton.TabIndex = 8;
            this.createProjectButton.Text = "Create project";
            this.createProjectButton.UseVisualStyleBackColor = true;
            this.createProjectButton.Click += new System.EventHandler(this.CreateProjectButtonClick);
            // 
            // deleteProjectButton
            // 
            this.deleteProjectButton.Enabled = false;
            this.deleteProjectButton.Location = new System.Drawing.Point(194, 69);
            this.deleteProjectButton.Name = "deleteProjectButton";
            this.deleteProjectButton.Size = new System.Drawing.Size(101, 23);
            this.deleteProjectButton.TabIndex = 9;
            this.deleteProjectButton.Text = "Delete project";
            this.deleteProjectButton.UseVisualStyleBackColor = true;
            this.deleteProjectButton.Click += new System.EventHandler(this.DeleteProjectButtonClick);
            // 
            // idBox
            // 
            this.idBox.Enabled = false;
            this.idBox.Location = new System.Drawing.Point(88, 99);
            this.idBox.Name = "idBox";
            this.idBox.ReadOnly = true;
            this.idBox.Size = new System.Drawing.Size(100, 20);
            this.idBox.TabIndex = 10;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 102);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(16, 13);
            this.idLabel.TabIndex = 11;
            this.idLabel.Text = "Id";
            // 
            // cacheCountLabel
            // 
            this.cacheCountLabel.AutoSize = true;
            this.cacheCountLabel.Location = new System.Drawing.Point(12, 128);
            this.cacheCountLabel.Name = "cacheCountLabel";
            this.cacheCountLabel.Size = new System.Drawing.Size(71, 13);
            this.cacheCountLabel.TabIndex = 13;
            this.cacheCountLabel.Text = "Cache_count";
            // 
            // cacheCountBox
            // 
            this.cacheCountBox.Enabled = false;
            this.cacheCountBox.Location = new System.Drawing.Point(89, 125);
            this.cacheCountBox.Name = "cacheCountBox";
            this.cacheCountBox.ReadOnly = true;
            this.cacheCountBox.Size = new System.Drawing.Size(100, 20);
            this.cacheCountBox.TabIndex = 12;
            // 
            // isCollapsedLabel
            // 
            this.isCollapsedLabel.AutoSize = true;
            this.isCollapsedLabel.Location = new System.Drawing.Point(12, 154);
            this.isCollapsedLabel.Name = "isCollapsedLabel";
            this.isCollapsedLabel.Size = new System.Drawing.Size(53, 13);
            this.isCollapsedLabel.TabIndex = 15;
            this.isCollapsedLabel.Text = "Collapsed";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(194, 102);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 17;
            this.nameLabel.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.Enabled = false;
            this.nameBox.Location = new System.Drawing.Point(235, 99);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 16;
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Location = new System.Drawing.Point(194, 128);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(43, 13);
            this.userIdLabel.TabIndex = 19;
            this.userIdLabel.Text = "User_id";
            // 
            // userIdBox
            // 
            this.userIdBox.Enabled = false;
            this.userIdBox.Location = new System.Drawing.Point(235, 125);
            this.userIdBox.Name = "userIdBox";
            this.userIdBox.ReadOnly = true;
            this.userIdBox.Size = new System.Drawing.Size(100, 20);
            this.userIdBox.TabIndex = 18;
            // 
            // indentLabel
            // 
            this.indentLabel.AutoSize = true;
            this.indentLabel.Location = new System.Drawing.Point(194, 154);
            this.indentLabel.Name = "indentLabel";
            this.indentLabel.Size = new System.Drawing.Size(37, 13);
            this.indentLabel.TabIndex = 21;
            this.indentLabel.Text = "Indent";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 180);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 23;
            this.colorLabel.Text = "Color";
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(194, 180);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(33, 13);
            this.orderLabel.TabIndex = 26;
            this.orderLabel.Text = "Order";
            // 
            // isCollapsedComboBox
            // 
            this.isCollapsedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.isCollapsedComboBox.Enabled = false;
            this.isCollapsedComboBox.FormattingEnabled = true;
            this.isCollapsedComboBox.Location = new System.Drawing.Point(88, 151);
            this.isCollapsedComboBox.Name = "isCollapsedComboBox";
            this.isCollapsedComboBox.Size = new System.Drawing.Size(100, 21);
            this.isCollapsedComboBox.TabIndex = 27;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(235, 204);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 28;
            this.saveButton.Text = "Save changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // orderBox
            // 
            this.orderBox.Enabled = false;
            this.orderBox.Location = new System.Drawing.Point(235, 178);
            this.orderBox.Name = "orderBox";
            this.orderBox.Size = new System.Drawing.Size(100, 20);
            this.orderBox.TabIndex = 29;
            // 
            // indentBox
            // 
            this.indentBox.Enabled = false;
            this.indentBox.Location = new System.Drawing.Point(235, 152);
            this.indentBox.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.indentBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.indentBox.Name = "indentBox";
            this.indentBox.Size = new System.Drawing.Size(100, 20);
            this.indentBox.TabIndex = 30;
            this.indentBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // colorComboBox
            // 
            this.colorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.colorComboBox.Enabled = false;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(88, 177);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(100, 21);
            this.colorComboBox.TabIndex = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 234);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.indentBox);
            this.Controls.Add(this.orderBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.isCollapsedComboBox);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.indentLabel);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.userIdBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.isCollapsedLabel);
            this.Controls.Add(this.cacheCountLabel);
            this.Controls.Add(this.cacheCountBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.deleteProjectButton);
            this.Controls.Add(this.createProjectButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.loginStatusLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.emailLabel);
            this.Name = "Form1";
            this.Text = "TodoLibDemo";
            ((System.ComponentModel.ISupportInitialize)(this.orderBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indentBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label loginStatusLabel;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button createProjectButton;
        private System.Windows.Forms.Button deleteProjectButton;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label cacheCountLabel;
        private System.Windows.Forms.TextBox cacheCountBox;
        private System.Windows.Forms.Label isCollapsedLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.TextBox userIdBox;
        private System.Windows.Forms.Label indentLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.ComboBox isCollapsedComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown orderBox;
        private System.Windows.Forms.NumericUpDown indentBox;
        private ColorComboBox colorComboBox;

    }
}

