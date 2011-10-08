// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorComboBox.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the ColorComboBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET.Demo
{
    using System.Drawing;
    using System.Windows.Forms;

    public struct ComboBoxItem
    {
        /// <summary>
        /// Gets or sets Color.
        /// </summary>
        public Color Color { get; set; }
    }

    internal class ColorComboBox : ComboBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorComboBox"/> class.
        /// </summary>
        public ColorComboBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            this.DrawItem += this.ComboBoxItemDrawItem;
        }

        private void ComboBoxItemDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var current = (ComboBoxItem)Items[e.Index];
            var boundRect = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillRectangle(new SolidBrush(current.Color), boundRect);
        }
    }
}