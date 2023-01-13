namespace UnaRisc.Source.UI
{
    partial class RegisterUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DecimalInput = new System.Windows.Forms.TextBox();
            this.UnaInput = new System.Windows.Forms.TextBox();
            this.RegisterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DecimalInput
            // 
            this.DecimalInput.Location = new System.Drawing.Point(159, 3);
            this.DecimalInput.Margin = new System.Windows.Forms.Padding(0);
            this.DecimalInput.Name = "DecimalInput";
            this.DecimalInput.Size = new System.Drawing.Size(73, 27);
            this.DecimalInput.TabIndex = 13;
            // 
            // UnaInput
            // 
            this.UnaInput.Location = new System.Drawing.Point(29, 3);
            this.UnaInput.Margin = new System.Windows.Forms.Padding(0);
            this.UnaInput.Name = "UnaInput";
            this.UnaInput.Size = new System.Drawing.Size(125, 27);
            this.UnaInput.TabIndex = 12;
            // 
            // RegisterName
            // 
            this.RegisterName.AutoSize = true;
            this.RegisterName.Location = new System.Drawing.Point(3, 7);
            this.RegisterName.Margin = new System.Windows.Forms.Padding(0);
            this.RegisterName.Name = "RegisterName";
            this.RegisterName.Size = new System.Drawing.Size(22, 20);
            this.RegisterName.TabIndex = 11;
            this.RegisterName.Text = "r1";
            // 
            // RegisterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DecimalInput);
            this.Controls.Add(this.UnaInput);
            this.Controls.Add(this.RegisterName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "RegisterUI";
            this.Size = new System.Drawing.Size(238, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox DecimalInput;
        private TextBox UnaInput;
        private Label RegisterName;
    }
}
