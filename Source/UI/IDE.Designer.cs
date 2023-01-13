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
            this.runCodeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.registersFlow = new System.Windows.Forms.FlowLayoutPanel();
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
            this.TextInput.Location = new System.Drawing.Point(11, 12);
            this.TextInput.Name = "TextInput";
            this.TextInput.Size = new System.Drawing.Size(669, 519);
            this.TextInput.TabIndex = 0;
            this.TextInput.Text = "";
            // 
            // registersGroup
            // 
            this.registersGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registersGroup.Controls.Add(this.registersFlow);
            this.registersGroup.Controls.Add(this.resetButton);
            this.registersGroup.Location = new System.Drawing.Point(701, 12);
            this.registersGroup.Name = "registersGroup";
            this.registersGroup.Size = new System.Drawing.Size(250, 224);
            this.registersGroup.TabIndex = 1;
            this.registersGroup.TabStop = false;
            this.registersGroup.Text = "Registers";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(7, 189);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(231, 29);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // runCodeButton
            // 
            this.runCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runCodeButton.Location = new System.Drawing.Point(701, 467);
            this.runCodeButton.Name = "runCodeButton";
            this.runCodeButton.Size = new System.Drawing.Size(250, 29);
            this.runCodeButton.TabIndex = 2;
            this.runCodeButton.Text = "Run Code";
            this.runCodeButton.UseVisualStyleBackColor = true;
            this.runCodeButton.Click += new System.EventHandler(this.runCodeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultBox);
            this.groupBox1.Location = new System.Drawing.Point(701, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 188);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(6, 27);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(238, 156);
            this.resultBox.TabIndex = 0;
            this.resultBox.Text = "";
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(701, 501);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(115, 29);
            this.loadButton.TabIndex = 11;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(832, 500);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(119, 29);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // registersFlow
            // 
            this.registersFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.registersFlow.Location = new System.Drawing.Point(6, 26);
            this.registersFlow.Name = "registersFlow";
            this.registersFlow.Size = new System.Drawing.Size(238, 157);
            this.registersFlow.TabIndex = 16;
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(963, 541);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.runCodeButton);
            this.Controls.Add(this.registersGroup);
            this.Controls.Add(this.TextInput);
            this.Name = "IDE";
            this.Text = "UnaRisc";
            this.registersGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox TextInput;
        private GroupBox registersGroup;
        private Button runCodeButton;
        private GroupBox groupBox1;
        private RichTextBox resultBox;
        private Button resetButton;
        private Button loadButton;
        private Button saveButton;
        private FlowLayoutPanel registersFlow;
    }
}