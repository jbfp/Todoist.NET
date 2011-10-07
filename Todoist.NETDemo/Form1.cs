using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TodoistDotNet;

namespace TodoistDotNetDemo
{
    public partial class Form1 : Form
    {
        private List<Project> _projects;
        private User _user;

        public Form1()
        {
            InitializeComponent();
            InitializeColorComboBox();
            isCollapsedComboBox.Items.Add("False");
            isCollapsedComboBox.Items.Add("True");
        }

        private void InitializeColorComboBox()
        {
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var greenItem = new ComboBoxItem {Colour = new TodoistColor(TodoistColorEnum.Green).RGB};
            var redItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Red).RGB };
            var orangeItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Orange).RGB };
            var yellowItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Yellow).RGB };
            var blueItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Blue).RGB };
            var mediumGreyItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.MediumGrey).RGB };
            var pinkItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Pink).RGB };
            var lightGreyItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.LightGrey).RGB };
            var flameItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Flame).RGB };
            var goldItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Gold).RGB };
            var lightOpalItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.LightOpal).RGB };
            var brilliantCeruleanItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.BrilliantCerulean).RGB };
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
                ;
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

            listBox.SelectedIndex = 0;
            listBox.Select();
        }

        private void ListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            idBox.Text = _projects[listBox.SelectedIndex].Id.ToString();
            nameBox.Text = _projects[listBox.SelectedIndex].Name;
            cacheCountBox.Text = _projects[listBox.SelectedIndex].CacheCount.ToString();
            isCollapsedComboBox.SelectedIndex = _projects[listBox.SelectedIndex].IsSubProjectsCollapsed ? 1 : 0;
            userIdBox.Text = _projects[listBox.SelectedIndex].OwnerId.ToString();
            indentBox.Text = _projects[listBox.SelectedIndex].Indent.ToString();
            orderBox.Text = _projects[listBox.SelectedIndex].ItemOrder.ToString();
            colorComboBox.SelectedIndex = _projects[listBox.SelectedIndex].Color.TodoistColorEnum.GetHashCode();
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
                                (TodoistColorEnum)colorComboBox.SelectedIndex, 
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
            _user.DeleteProject(_projects[listBox.SelectedIndex].Id);
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