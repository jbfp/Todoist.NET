using System.Drawing;
using System.Windows.Forms;

namespace TodoistDotNetDemo
{
    internal class ColorComboBox : ComboBox
    {
        public ColorComboBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            DrawItem += ComboBoxItemDrawItem;
        }

        private void ComboBoxItemDrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var current = (ComboBoxItem)Items[e.Index];
            var boundRect = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillRectangle(new SolidBrush(current.Colour), boundRect);
        }
    }

    public struct ComboBoxItem
    {
        public Color Colour { get; set; }
    }
}