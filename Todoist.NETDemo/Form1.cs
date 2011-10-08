// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private IEnumerable<Project> projects;
        private User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.InitializeColorComboBox();
            isCollapsedComboBox.Items.Add("False");
            isCollapsedComboBox.Items.Add("True");
            isGroupComboBox.Items.Add("False");
            isGroupComboBox.Items.Add("True");
            listBox.SelectionMode = SelectionMode.One;
        }

        private void InitializeColorComboBox()
        {
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var greenItem = new ComboBoxItem { Color = new Color(TodoistColor.Green).Rgb };
            var redItem = new ComboBoxItem { Color = new Color(TodoistColor.Red).Rgb };
            var orangeItem = new ComboBoxItem { Color = new Color(TodoistColor.Orange).Rgb };
            var yellowItem = new ComboBoxItem { Color = new Color(TodoistColor.Yellow).Rgb };
            var blueItem = new ComboBoxItem { Color = new Color(TodoistColor.Blue).Rgb };
            var mediumGreyItem = new ComboBoxItem { Color = new Color(TodoistColor.MediumGrey).Rgb };
            var pinkItem = new ComboBoxItem { Color = new Color(TodoistColor.Pink).Rgb };
            var lightGreyItem = new ComboBoxItem { Color = new Color(TodoistColor.LightGrey).Rgb };
            var flameItem = new ComboBoxItem { Color = new Color(TodoistColor.Flame).Rgb };
            var goldItem = new ComboBoxItem { Color = new Color(TodoistColor.Gold).Rgb };
            var lightOpalItem = new ComboBoxItem { Color = new Color(TodoistColor.LightOpal).Rgb };
            var brilliantCeruleanItem = new ComboBoxItem { Color = new Color(TodoistColor.BrilliantCerulean).Rgb };
            colorComboBox.Items.AddRange(
                new object[]
                    {
                                                 greenItem, redItem, orangeItem, yellowItem,
                                                 blueItem, mediumGreyItem, pinkItem, lightGreyItem,
                                                 flameItem, goldItem, lightOpalItem, brilliantCeruleanItem
                                             });
            colorComboBox.SelectedIndex = 0;
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            this.projects = new List<Project>();
            this.user = new User();

            try
            {
                if (string.IsNullOrWhiteSpace(emailBox.Text) || string.IsNullOrWhiteSpace(passwordBox.Text))
                {
                    return;
                }

                this.user.LogOn(emailBox.Text, passwordBox.Text);
            }
            catch (WebException webException)
            {
                MessageBox.Show(webException.Message);
                return;
            }
            catch (LogOnFailedException loginFailedException)
            {
                MessageBox.Show(loginFailedException.Message);
                return;
            }

            this.GetProjects();

            refreshButton.Enabled = true;
            createProjectButton.Enabled = true;
            deleteProjectButton.Enabled = true;

            idBox.Enabled = true;
            cacheCountBox.Enabled = true;
            isCollapsedComboBox.Enabled = true;
            isGroupComboBox.Enabled = true;
            colorComboBox.Enabled = true;
            nameBox.Enabled = true;
            userIdBox.Enabled = true;
            indentBox.Enabled = true;
            orderBox.Enabled = true;
            saveButton.Enabled = true;

            if (listBox.Items.Count > 0)
            {
                listBox.SelectedIndex = 0;
            }

            listBox.Select();
        }

        private void GetProjects()
        {
            this.projects = this.user.GetProjects;
            this.listBox.Items.Clear();
            foreach (var project in this.projects)
            {
                this.listBox.Items.Add(string.Concat(Enumerable.Repeat("   ", project.Indent - 1)) + project.Name);
            }
        }

        private void ListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            idBox.Text = this.projects.ElementAt(listBox.SelectedIndex).Id.ToString();
            nameBox.Text = this.projects.ElementAt(listBox.SelectedIndex).Name;
            cacheCountBox.Text = this.projects.ElementAt(listBox.SelectedIndex).CacheCount.ToString();
            isCollapsedComboBox.SelectedIndex = this.projects.ElementAt(listBox.SelectedIndex).IsSubprojectsCollapsed ? 1 : 0;
            isGroupComboBox.SelectedIndex = this.projects.ElementAt(listBox.SelectedIndex).IsGroup ? 1 : 0;
            userIdBox.Text = this.projects.ElementAt(listBox.SelectedIndex).OwnerId.ToString();
            indentBox.Text = this.projects.ElementAt(listBox.SelectedIndex).Indent.ToString();
            orderBox.Text = this.projects.ElementAt(listBox.SelectedIndex).ItemOrder.ToString();
            colorComboBox.SelectedIndex = this.projects.ElementAt(listBox.SelectedIndex).Color.TodoistColor.GetHashCode();
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            this.GetProjects();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            this.user.UpdateProject(
                Convert.ToInt32(idBox.Text),
                nameBox.Text,
                (TodoistColor)colorComboBox.SelectedIndex,
                Convert.ToInt32(indentBox.Value),
                Convert.ToInt32(orderBox.Value),
                Convert.ToBoolean(isCollapsedComboBox.SelectedIndex),
                Convert.ToBoolean(isGroupComboBox.SelectedIndex));
            this.RefreshButtonClick(sender, e);
        }

        private void EmailBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.LoginButtonClick(sender, new EventArgs());
            }

            return;
        }

        private void PasswordBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.LoginButtonClick(sender, new EventArgs());
            }

            return;
        }

        private void DeleteProjectButtonClick(object sender, EventArgs e)
        {
            this.user.DeleteProject(this.projects.ElementAt(listBox.SelectedIndex).Id);
            this.RefreshButtonClick(sender, e);
        }

        private void CreateProjectButtonClick(object sender, EventArgs e)
        {
            var createProjectForm = new CreateProjectForm(this.user);
            createProjectForm.ShowDialog();
            this.RefreshButtonClick(sender, e);
        }
    }
}