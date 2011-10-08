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
using System.Windows.Forms;

namespace Todoist.NET.Demo
{
    public partial class CreateProjectForm : Form
    {
        private readonly User _user;

        public CreateProjectForm(User user)
        {
            _user = user;
            InitializeComponent();
            colorComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
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
            colorComboBox1.Items.AddRange(new object[]
                                              {
                                                  greenItem, redItem, orangeItem, yellowItem,
                                                  blueItem, mediumGreyItem, pinkItem, lightGreyItem,
                                                  flameItem, goldItem, lightOpalItem, brilliantCeruleanItem
                                              });
            colorComboBox1.SelectedIndex = 0;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            _user.CreateProject(nameBox.Text,
                                (int) indentBox.Value,
                                (int) orderBox.Value,
                                new Color((TodoistColor) colorComboBox1.SelectedIndex));
            Dispose();
        }
    }
}