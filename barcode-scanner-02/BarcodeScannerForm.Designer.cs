namespace barcode_scanner_00
{
    partial class BarcodeScannerForm
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
            this.pictureBoxBC = new System.Windows.Forms.PictureBox();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.textBoxIndex0 = new System.Windows.Forms.TextBox();
            this.textBoxIndex1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBC
            // 
            this.pictureBoxBC.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBoxBC.Location = new System.Drawing.Point(63, 35);
            this.pictureBoxBC.Name = "pictureBoxBC";
            this.pictureBoxBC.Size = new System.Drawing.Size(360, 75);
            this.pictureBoxBC.TabIndex = 0;
            this.pictureBoxBC.TabStop = false;
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBoxQR.Location = new System.Drawing.Point(63, 158);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(360, 360);
            this.pictureBoxQR.TabIndex = 0;
            this.pictureBoxQR.TabStop = false;
            // 
            // textBoxIndex0
            // 
            this.textBoxIndex0.Location = new System.Drawing.Point(499, 276);
            this.textBoxIndex0.Name = "textBoxIndex0";
            this.textBoxIndex0.PlaceholderText = "Scan";
            this.textBoxIndex0.Size = new System.Drawing.Size(128, 31);
            this.textBoxIndex0.TabIndex = 1;
            // 
            // textBoxIndex1
            // 
            this.textBoxIndex1.Location = new System.Drawing.Point(499, 328);
            this.textBoxIndex1.Name = "textBoxIndex1";
            this.textBoxIndex1.PlaceholderText = "Scan";
            this.textBoxIndex1.Size = new System.Drawing.Size(128, 31);
            this.textBoxIndex1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "[0]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "[1]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Parsed Scan";
            // 
            // BarcodeScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 550);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIndex1);
            this.Controls.Add(this.textBoxIndex0);
            this.Controls.Add(this.pictureBoxQR);
            this.Controls.Add(this.pictureBoxBC);
            this.Name = "BarcodeScannerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan codes to test...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxBC;
        private PictureBox pictureBoxQR;
        private TextBox textBoxIndex0;
        private TextBox textBoxIndex1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}