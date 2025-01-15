using System;
using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
    public partial class InputBoxHelper : Form
    {
        public InputBoxHelper()
        {
            InitializeComponent();
        }

		public static string InputBox(string prompt, string title = null, string defaultValue = "", int? posX = null, int? posY = null)
		{
			InputBoxHelper inputBox;
			inputBox = new InputBoxHelper();
			inputBox.lblPrompt.Text = prompt;
			inputBox.Text = title == null? Application.ProductName : title;
			inputBox.txtDefaultValue.Text = defaultValue;

			if (posX.HasValue && posY.HasValue)
			{
				inputBox.StartPosition = FormStartPosition.Manual;
				inputBox.Location = new System.Drawing.Point(posX.Value, posY.Value);
			}
			else
			{
				inputBox.StartPosition = FormStartPosition.CenterScreen;
			}

			inputBox.btnOk.DialogResult = DialogResult.OK;
			inputBox.btnCancel.DialogResult = DialogResult.Cancel;
			if (inputBox.ShowDialog() == DialogResult.OK)
			{
				return inputBox.txtDefaultValue.Text;
			}
			else
			{
				return String.Empty;
			}

		}

	}

}
