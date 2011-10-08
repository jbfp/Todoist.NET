#region License

// Copyright (c) 2011 Jakob Pedersen
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Todoist.NET.Demo
{
    public partial class Form1 : Form
    {
        private IEnumerable<Project> _projects;
        private User _user;

        public Form1()
        {
            InitializeComponent();
            InitializeColorComboBox();
            isCollapsedComboBox.Items.Add("False");
            isCollapsedComboBox.Items.Add("True");
            listBox.SelectionMode = SelectionMode.One;
        }

        private void InitializeColorComboBox()
        {
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var greenItem = new ComboBoxItem {Color = new Color(TodoistColor.Green).Rgb};
            var redItem = new ComboBoxItem {Color = new Color(TodoistColor.Red).Rgb};
            var orangeItem = new ComboBoxItem {Color = new Color(TodoistColor.Orange).Rgb};
            var yellowItem = new ComboBoxItem {Color = new Color(TodoistColor.Yellow).Rgb};
            var blueItem = new ComboBoxItem {Color = new Color(TodoistColor.Blue).Rgb};
            var mediumGreyItem = new ComboBoxItem {Color = new Color(TodoistColor.MediumGrey).Rgb};
            var pinkItem = new ComboBoxItem {Color = new Color(TodoistColor.Pink).Rgb};
            var lightGreyItem = new ComboBoxItem {Color = new Color(TodoistColor.LightGrey).Rgb};
            var flameItem = new ComboBoxItem {Color = new Color(TodoistColor.Flame).Rgb};
            var goldItem = new ComboBoxItem {Color = new Color(TodoistColor.Gold).Rgb};
            var lightOpalItem = new ComboBoxItem {Color = new Color(TodoistColor.LightOpal).Rgb};
            var brilliantCeruleanItem = new ComboBoxItem
                                            {Color = new Color(TodoistColor.BrilliantCerulean).Rgb};
            colorComboBox.Items.AddRange(new object[]
                                             {
                                                 greenItem, redItem, orangeItem, yellowItem,
                                                 blueItem, mediumGreyItem, pinkItem, lightGreyItem,
                                                 flameItem, goldItem, lightOpalItem, brilliantCeruleanItem
                                             });
            colorComboBox.SelectedIndex = 0;
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            _projects = new List<Project>();
            _user = new User();

            try
            {
                if (String.IsNullOrWhiteSpace(emailBox.Text) || String.IsNullOrWhiteSpace(passwordBox.Text))
                    return;

                _user.Login(emailBox.Text, passwordBox.Text);
            }
            catch (LoginFailedException loginFailedException)
            {
                MessageBox.Show(loginFailedException.Message);
                return;
            }

            _projects = _user.GetProjects();

            listBox.Items.Clear();
            foreach (Project project in _projects)
            {
                listBox.Items.Add(project.Name);
            }

            refreshButton.Enabled = true;
            createProjectButton.Enabled = true;
            deleteProjectButton.Enabled = true;

            idBox.Enabled = true;
            cacheCountBox.Enabled = true;
            isCollapsedComboBox.Enabled = true;
            colorComboBox.Enabled = true;
            nameBox.Enabled = true;
            userIdBox.Enabled = true;
            indentBox.Enabled = true;
            orderBox.Enabled = true;
            saveButton.Enabled = true;

            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;

            Project __project = _projects.First();

            listBox.Select();
        }

        private void ListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            idBox.Text = _projects.ElementAt(listBox.SelectedIndex).Id.ToString();
            nameBox.Text = _projects.ElementAt(listBox.SelectedIndex).Name;
            cacheCountBox.Text = _projects.ElementAt(listBox.SelectedIndex).CacheCount.ToString();
            isCollapsedComboBox.SelectedIndex = _projects.ElementAt(listBox.SelectedIndex).IsSubprojectsCollapsed ? 1 : 0;
            userIdBox.Text = _projects.ElementAt(listBox.SelectedIndex).OwnerId.ToString();
            indentBox.Text = _projects.ElementAt(listBox.SelectedIndex).Indent.ToString();
            orderBox.Text = _projects.ElementAt(listBox.SelectedIndex).ItemOrder.ToString();
            colorComboBox.SelectedIndex = _projects.ElementAt(listBox.SelectedIndex).Color.TodoistColor.GetHashCode();
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            _projects = _user.GetProjects();
            listBox.Items.Clear();
            foreach (Project project in _projects)
            {
                listBox.Items.Add(project.Name);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            _user.UpdateProject(Convert.ToInt32(idBox.Text),
                                nameBox.Text,
                                (TodoistColor) colorComboBox.SelectedIndex,
                                Convert.ToInt32(indentBox.Value),
                                Convert.ToInt32(orderBox.Value),
                                Convert.ToBoolean(isCollapsedComboBox.SelectedIndex));
            RefreshButtonClick(sender, e);
        }

        private void EmailBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
                LoginButtonClick(sender, new EventArgs());
            return;
        }

        private void PasswordBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
                LoginButtonClick(sender, new EventArgs());
            return;
        }

        private void DeleteProjectButtonClick(object sender, EventArgs e)
        {
            _user.DeleteProject(_projects.ElementAt(listBox.SelectedIndex).Id);
            RefreshButtonClick(sender, e);
        }

        private void CreateProjectButtonClick(object sender, EventArgs e)
        {
            var createProjectForm = new CreateProjectForm(_user);
            createProjectForm.ShowDialog();
            RefreshButtonClick(sender, e);
        }
    }
}