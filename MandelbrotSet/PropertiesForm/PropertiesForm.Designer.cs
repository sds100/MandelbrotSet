namespace MandelbrotSet.PropertiesForm
{
    partial class PropertiesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPointX = new System.Windows.Forms.TextBox();
            this.textBoxPointY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numUpDownMagnification = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMagnification)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "png width:";
            // 
            // numUpDownWidth
            // 
            this.numUpDownWidth.Location = new System.Drawing.Point(74, 140);
            this.numUpDownWidth.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownWidth.Name = "numUpDownWidth";
            this.numUpDownWidth.Size = new System.Drawing.Size(114, 20);
            this.numUpDownWidth.TabIndex = 4;
            this.numUpDownWidth.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // numUpDownHeight
            // 
            this.numUpDownHeight.Location = new System.Drawing.Point(74, 170);
            this.numUpDownHeight.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownHeight.Name = "numUpDownHeight";
            this.numUpDownHeight.Size = new System.Drawing.Size(114, 20);
            this.numUpDownHeight.TabIndex = 5;
            this.numUpDownHeight.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "png height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File name:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(74, 203);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(114, 20);
            this.textBoxFileName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = ".png";
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonExport.Location = new System.Drawing.Point(128, 272);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Directory:";
            // 
            // labelDirectory
            // 
            this.labelDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(16, 126);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(0, 13);
            this.labelDirectory.TabIndex = 11;
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChooseFolder.Location = new System.Drawing.Point(12, 272);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(101, 23);
            this.buttonChooseFolder.TabIndex = 12;
            this.buttonChooseFolder.Text = "Choose folder";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Focus point:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Y";
            // 
            // textBoxPointX
            // 
            this.textBoxPointX.Location = new System.Drawing.Point(102, 12);
            this.textBoxPointX.Name = "textBoxPointX";
            this.textBoxPointX.Size = new System.Drawing.Size(240, 20);
            this.textBoxPointX.TabIndex = 1;
            // 
            // textBoxPointY
            // 
            this.textBoxPointY.Location = new System.Drawing.Point(102, 38);
            this.textBoxPointY.Name = "textBoxPointY";
            this.textBoxPointY.Size = new System.Drawing.Size(240, 20);
            this.textBoxPointY.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Magnification:";
            // 
            // numUpDownMagnification
            // 
            this.numUpDownMagnification.DecimalPlaces = 5;
            this.numUpDownMagnification.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.numUpDownMagnification.Location = new System.Drawing.Point(102, 73);
            this.numUpDownMagnification.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.numUpDownMagnification.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownMagnification.Name = "numUpDownMagnification";
            this.numUpDownMagnification.Size = new System.Drawing.Size(120, 20);
            this.numUpDownMagnification.TabIndex = 3;
            this.numUpDownMagnification.ThousandsSeparator = true;
            this.numUpDownMagnification.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Export:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Or press \"Enter\" to apply.";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(267, 68);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 25;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // PropertiesForm
            // 
            this.AcceptButton = this.buttonApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(374, 307);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numUpDownMagnification);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxPointY);
            this.Controls.Add(this.textBoxPointX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonChooseFolder);
            this.Controls.Add(this.labelDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numUpDownHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numUpDownWidth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PropertiesForm";
            this.Text = "Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertiesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMagnification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownWidth;
        private System.Windows.Forms.NumericUpDown numUpDownHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Button buttonChooseFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPointX;
        private System.Windows.Forms.TextBox textBoxPointY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numUpDownMagnification;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonApply;
    }
}