using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
    partial class InputBoxHelper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.lblPrompt = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtDefaultValue = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblPrompt
			// 
			this.lblPrompt.Location = new System.Drawing.Point(10, 10);
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.Size = new System.Drawing.Size(264, 77);
			this.lblPrompt.TabIndex = 0;
			this.lblPrompt.Text = "label1";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(290, 12);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(60, 22);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(290, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(60, 22);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// txtDefaultValue
			// 
			this.txtDefaultValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDefaultValue.Location = new System.Drawing.Point(10, 90);
			this.txtDefaultValue.Name = "txtDefaultValue";
			this.txtDefaultValue.Size = new System.Drawing.Size(335, 20);
			this.txtDefaultValue.TabIndex = 3;
			// 
			// InputBoxHelper
			// 
			this.ClientSize = new System.Drawing.Size(353, 120);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtDefaultValue);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.lblPrompt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputBoxHelper";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        public Label lblPrompt;
        public Button btnOk;
        public Button btnCancel;
        public TextBox txtDefaultValue;

        #endregion


    }
}

