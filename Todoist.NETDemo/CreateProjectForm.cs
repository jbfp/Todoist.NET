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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Todoist.NET;

namespace Todoist.NET.Demo
{
    public partial class CreateProjectForm : Form
    {
        private User _user;

        public CreateProjectForm(User user)
        {
            _user = user;
            InitializeComponent();
            colorComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            var greenItem = new ComboBoxItem { Colour = new TodoistColor(TodoistColorEnum.Green).RGB };
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
                (int)indentBox.Value, 
                (int)orderBox.Value,
                new TodoistColor((TodoistColorEnum)colorComboBox1.SelectedIndex));
            Dispose();
        }
    }
}
