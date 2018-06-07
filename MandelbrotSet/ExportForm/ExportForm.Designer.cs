namespace MandelbrotSet.ExportForm
{
    partial class ExportForm
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
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPointX = new System.Windows.Forms.TextBox();
            this.textBoxPointY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numUpDownMagnification = new System.Windows.Forms.NumericUpDown();
            this.buttonUseCurrentOptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMagnification)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPreview.Location = new System.Drawing.Point(422, 32);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "png width:";
            // 
            // numUpDownWidth
            // 
            this.numUpDownWidth.Location = new System.Drawing.Point(75, 11);
            this.numUpDownWidth.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numUpDownWidth.Name = "numUpDownWidth";
            this.numUpDownWidth.Size = new System.Drawing.Size(114, 20);
            this.numUpDownWidth.TabIndex = 2;
            // 
            // numUpDownHeight
            // 
            this.numUpDownHeight.Location = new System.Drawing.Point(75, 41);
            this.numUpDownHeight.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numUpDownHeight.Name = "numUpDownHeight";
            this.numUpDownHeight.Size = new System.Drawing.Size(114, 20);
            this.numUpDownHeight.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "png height:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Preview";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File name:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(75, 74);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(114, 20);
            this.textBoxFileName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = ".png";
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(547, 314);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Directory:";
            // 
            // labelDirectory
            // 
            this.labelDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(16, 147);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(0, 13);
            this.labelDirectory.TabIndex = 11;
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Location = new System.Drawing.Point(16, 147);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(101, 23);
            this.buttonChooseFolder.TabIndex = 12;
            this.buttonChooseFolder.Text = "Choose folder";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mandelbrot Set options:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Focus point:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Y";
            // 
            // textBoxPointX
            // 
            this.textBoxPointX.Location = new System.Drawing.Point(111, 232);
            this.textBoxPointX.Name = "textBoxPointX";
            this.textBoxPointX.Size = new System.Drawing.Size(240, 20);
            this.textBoxPointX.TabIndex = 19;
            this.textBoxPointX.TextChanged += new System.EventHandler(this.MandelbrotSetParams_ValueChanged);
            // 
            // textBoxPointY
            // 
            this.textBoxPointY.Location = new System.Drawing.Point(111, 258);
            this.textBoxPointY.Name = "textBoxPointY";
            this.textBoxPointY.Size = new System.Drawing.Size(240, 20);
            this.textBoxPointY.TabIndex = 20;
            this.textBoxPointY.TextChanged += new System.EventHandler(this.MandelbrotSetParams_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Magnification:";
            // 
            // numUpDownMagnification
            // 
            this.numUpDownMagnification.Location = new System.Drawing.Point(111, 293);
            this.numUpDownMagnification.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numUpDownMagnification.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownMagnification.Name = "numUpDownMagnification";
            this.numUpDownMagnification.Size = new System.Drawing.Size(120, 20);
            this.numUpDownMagnification.TabIndex = 22;
            this.numUpDownMagnification.ThousandsSeparator = true;
            this.numUpDownMagnification.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownMagnification.ValueChanged += new System.EventHandler(this.MandelbrotSetParams_ValueChanged);
            // 
            // buttonUseCurrentOptions
            // 
            this.buttonUseCurrentOptions.Location = new System.Drawing.Point(158, 194);
            this.buttonUseCurrentOptions.Name = "buttonUseCurrentOptions";
            this.buttonUseCurrentOptions.Size = new System.Drawing.Size(121, 23);
            this.buttonUseCurrentOptions.TabIndex = 23;
            this.buttonUseCurrentOptions.Text = "Use current options";
            this.buttonUseCurrentOptions.UseVisualStyleBackColor = true;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 349);
            this.Controls.Add(this.buttonUseCurrentOptions);
            this.Controls.Add(this.numUpDownMagnification);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxPointY);
            this.Controls.Add(this.textBoxPointX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonChooseFolder);
            this.Controls.Add(this.labelDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numUpDownHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numUpDownWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.Text = "Export Mandelbrot Set";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMagnification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownWidth;
        private System.Windows.Forms.NumericUpDown numUpDownHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Button buttonChooseFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPointX;
        private System.Windows.Forms.TextBox textBoxPointY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numUpDownMagnification;
        private System.Windows.Forms.Button buttonUseCurrentOptions;
    }
}