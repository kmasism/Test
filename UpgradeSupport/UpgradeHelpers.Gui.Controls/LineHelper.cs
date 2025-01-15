using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
    public partial class LineHelper : Label
    {
        private static int m_bottom;
        private static int m_right;

        #region "Public Methods"
        public static int GetX1(Label label) => label.Left;

        public static void SetX1(Label label, int value)
        {
            label.AutoSize = false;
            label.Left = value;
            label.Width = label.Right - label.Left;
            if (label.Width == 0)
            {
                label.SetBounds(label.Left, label.Location.Y, 10, label.Height);
            }
            else
            {
                label.SetBounds(label.Left, label.Location.Y, label.Width, label.Height);
            }
        }

        public static int GetX2(Label label) => m_right;

        public static void SetX2(Label label, int value)
        {
            label.AutoSize = false;
            m_right = value;
            label.Width = value - label.Left;
            if (label.Width == 0)
            {
                label.SetBounds(label.Location.X, label.Location.Y, 10, label.Height);
            }
            else
            {
                label.SetBounds(label.Location.X, label.Location.Y, label.Width, label.Height);
            }
        }

        public static int GetY1(Label label) => label.Top;

        public static void SetY1(Label label, int value)
        {
            label.AutoSize = false;
            label.Top = value;
            label.Height = label.Bottom - label.Top;
            if (label.Height == 0)
            {
                label.SetBounds(label.Location.X, label.Top, label.Width, 10);
            }
            else
            {
                label.SetBounds(label.Location.X, label.Top, label.Width, label.Height);
            }
        }

        public static int GetY2(Label label) => m_bottom;

        public static void SetY2(Label label, int value)
        {
            label.AutoSize = false;
            m_bottom = value;
            label.Height = value - label.Top;
            if (label.Height == 0)
            {
                label.SetBounds(label.Location.X, label.Location.Y, label.Width, 10);
            }
            else
            {
                label.SetBounds(label.Location.X, label.Location.Y, label.Width, label.Height);
            }
        }
        #endregion
    }
}
