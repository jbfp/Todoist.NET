// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateProjectForm.Designer.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the CreateProjectForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET.Demo
{
    partial class CreateProjectForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.colorComboBox1 = new ColorComboBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.indentLabel = new System.Windows.Forms.Label();
            this.indentBox = new System.Windows.Forms.NumericUpDown();
            this.orderBox = new System.Windows.Forms.NumericUpDown();
            this.orderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.indentBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 169);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(95, 169);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.AutoSize = true;
            this.projectNameLabel.Location = new System.Drawing.Point(9, 9);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(69, 13);
            this.projectNameLabel.TabIndex = 2;
            this.projectNameLabel.Text = "Project name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 25);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(156, 20);
            this.nameBox.TabIndex = 0;
            // 
            // colorComboBox1
            // 
            this.colorComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.colorComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox1.FormattingEnabled = true;
            this.colorComboBox1.Location = new System.Drawing.Point(12, 64);
            this.colorComboBox1.Name = "colorComboBox1";
            this.colorComboBox1.Size = new System.Drawing.Size(156, 21);
            this.colorComboBox1.TabIndex = 1;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 48);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 5;
            this.colorLabel.Text = "Color";
            // 
            // indentLabel
            // 
            this.indentLabel.AutoSize = true;
            this.indentLabel.Location = new System.Drawing.Point(12, 88);
            this.indentLabel.Name = "indentLabel";
            this.indentLabel.Size = new System.Drawing.Size(37, 13);
            this.indentLabel.TabIndex = 6;
            this.indentLabel.Text = "Indent";
            // 
            // indentBox
            // 
            this.indentBox.Location = new System.Drawing.Point(15, 104);
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
            this.indentBox.Size = new System.Drawing.Size(153, 20);
            this.indentBox.TabIndex = 2;
            this.indentBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // orderBox
            // 
            this.orderBox.Location = new System.Drawing.Point(17, 143);
            this.orderBox.Name = "orderBox";
            this.orderBox.Size = new System.Drawing.Size(151, 20);
            this.orderBox.TabIndex = 3;
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(14, 127);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(33, 13);
            this.orderLabel.TabIndex = 8;
            this.orderLabel.Text = "Order";
            // 
            // CreateProjectForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(182, 203);
            this.Controls.Add(this.orderBox);
            this.Controls.Add(this.orderLabel);
            this.Controls.Add(this.indentBox);
            this.Controls.Add(this.indentLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorComboBox1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateProjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.indentBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private ColorComboBox colorComboBox1;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label indentLabel;
        private System.Windows.Forms.NumericUpDown indentBox;
        private System.Windows.Forms.NumericUpDown orderBox;
        private System.Windows.Forms.Label orderLabel;
    }
}