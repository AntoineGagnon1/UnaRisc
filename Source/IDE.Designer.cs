namespace UnaRisc
{
    partial class IDE
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
            this.TextInput = new System.Windows.Forms.RichTextBox();
            this.registersGroup = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.r5Decimal = new System.Windows.Forms.TextBox();
            this.r4Decimal = new System.Windows.Forms.TextBox();
            this.r3Decimal = new System.Windows.Forms.TextBox();
            this.r2Decimal = new System.Windows.Forms.TextBox();
            this.r1Decimal = new System.Windows.Forms.TextBox();
            this.r5Input = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.r4Input = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.r3Input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.r2Input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.r1Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.runCodeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.registersGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextInput
            // 
            this.TextInput.AcceptsTab = true;
            this.TextInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextInput.Location = new System.Drawing.Point(10, 9);
            this.TextInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextInput.Name = "TextInput";
            this.TextInput.Size = new System.Drawing.Size(586, 390);
            this.TextInput.TabIndex = 0;
            this.TextInput.Text = "";
            // 
            // registersGroup
            // 
            this.registersGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registersGroup.Controls.Add(this.resetButton);
            this.registersGroup.Controls.Add(this.r5Decimal);
            this.registersGroup.Controls.Add(this.r4Decimal);
            this.registersGroup.Controls.Add(this.r3Decimal);
            this.registersGroup.Controls.Add(this.r2Decimal);
            this.registersGroup.Controls.Add(this.r1Decimal);
            this.registersGroup.Controls.Add(this.r5Input);
            this.registersGroup.Controls.Add(this.label5);
            this.registersGroup.Controls.Add(this.r4Input);
            this.registersGroup.Controls.Add(this.label4);
            this.registersGroup.Controls.Add(this.r3Input);
            this.registersGroup.Controls.Add(this.label3);
            this.registersGroup.Controls.Add(this.r2Input);
            this.registersGroup.Controls.Add(this.label2);
            this.registersGroup.Controls.Add(this.r1Input);
            this.registersGroup.Controls.Add(this.label1);
            this.registersGroup.Location = new System.Drawing.Point(613, 2);
            this.registersGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registersGroup.Name = "registersGroup";
            this.registersGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registersGroup.Size = new System.Drawing.Size(219, 168);
            this.registersGroup.TabIndex = 1;
            this.registersGroup.TabStop = false;
            this.registersGroup.Text = "Registers";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(6, 142);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(202, 22);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // r5Decimal
            // 
            this.r5Decimal.Location = new System.Drawing.Point(144, 118);
            this.r5Decimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r5Decimal.Name = "r5Decimal";
            this.r5Decimal.Size = new System.Drawing.Size(64, 23);
            this.r5Decimal.TabIndex = 14;
            // 
            // r4Decimal
            // 
            this.r4Decimal.Location = new System.Drawing.Point(144, 94);
            this.r4Decimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r4Decimal.Name = "r4Decimal";
            this.r4Decimal.Size = new System.Drawing.Size(64, 23);
            this.r4Decimal.TabIndex = 13;
            // 
            // r3Decimal
            // 
            this.r3Decimal.Location = new System.Drawing.Point(144, 69);
            this.r3Decimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r3Decimal.Name = "r3Decimal";
            this.r3Decimal.Size = new System.Drawing.Size(64, 23);
            this.r3Decimal.TabIndex = 12;
            // 
            // r2Decimal
            // 
            this.r2Decimal.Location = new System.Drawing.Point(144, 44);
            this.r2Decimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r2Decimal.Name = "r2Decimal";
            this.r2Decimal.Size = new System.Drawing.Size(64, 23);
            this.r2Decimal.TabIndex = 11;
            // 
            // r1Decimal
            // 
            this.r1Decimal.Location = new System.Drawing.Point(144, 20);
            this.r1Decimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r1Decimal.Name = "r1Decimal";
            this.r1Decimal.Size = new System.Drawing.Size(64, 23);
            this.r1Decimal.TabIndex = 10;
            // 
            // r5Input
            // 
            this.r5Input.Location = new System.Drawing.Point(30, 118);
            this.r5Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r5Input.Name = "r5Input";
            this.r5Input.Size = new System.Drawing.Size(110, 23);
            this.r5Input.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "r5";
            // 
            // r4Input
            // 
            this.r4Input.Location = new System.Drawing.Point(30, 94);
            this.r4Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r4Input.Name = "r4Input";
            this.r4Input.Size = new System.Drawing.Size(110, 23);
            this.r4Input.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "r4";
            // 
            // r3Input
            // 
            this.r3Input.Location = new System.Drawing.Point(30, 69);
            this.r3Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r3Input.Name = "r3Input";
            this.r3Input.Size = new System.Drawing.Size(110, 23);
            this.r3Input.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "r3";
            // 
            // r2Input
            // 
            this.r2Input.Location = new System.Drawing.Point(30, 44);
            this.r2Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r2Input.Name = "r2Input";
            this.r2Input.Size = new System.Drawing.Size(110, 23);
            this.r2Input.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "r2";
            // 
            // r1Input
            // 
            this.r1Input.Location = new System.Drawing.Point(30, 20);
            this.r1Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.r1Input.Name = "r1Input";
            this.r1Input.Size = new System.Drawing.Size(110, 23);
            this.r1Input.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "r1";
            // 
            // runCodeButton
            // 
            this.runCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runCodeButton.Location = new System.Drawing.Point(613, 376);
            this.runCodeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.runCodeButton.Name = "runCodeButton";
            this.runCodeButton.Size = new System.Drawing.Size(219, 22);
            this.runCodeButton.TabIndex = 2;
            this.runCodeButton.Text = "Run Code";
            this.runCodeButton.UseVisualStyleBackColor = true;
            this.runCodeButton.Click += new System.EventHandler(this.runCodeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultBox);
            this.groupBox1.Location = new System.Drawing.Point(613, 230);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(219, 141);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(5, 20);
            this.resultBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(209, 118);
            this.resultBox.TabIndex = 0;
            this.resultBox.Text = "";
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(843, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.runCodeButton);
            this.Controls.Add(this.registersGroup);
            this.Controls.Add(this.TextInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IDE";
            this.Text = "UnaRisc";
            this.registersGroup.ResumeLayout(false);
            this.registersGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox TextInput;
        private GroupBox registersGroup;
        private Label label1;
        private TextBox r1Input;
        private TextBox r5Input;
        private Label label5;
        private TextBox r4Input;
        private Label label4;
        private TextBox r3Input;
        private Label label3;
        private TextBox r2Input;
        private Label label2;
        private Button runCodeButton;
        private GroupBox groupBox1;
        private RichTextBox resultBox;
        private TextBox r5Decimal;
        private TextBox r4Decimal;
        private TextBox r3Decimal;
        private TextBox r2Decimal;
        private TextBox r1Decimal;
        private Button resetButton;
    }
}