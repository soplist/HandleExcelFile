namespace UI
{
    partial class GetExcelFileForm
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
            this.chooseExcelFileButton = new System.Windows.Forms.Button();
            this.ExcelFilePathlabel = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseExcelFileButton
            // 
            this.chooseExcelFileButton.Location = new System.Drawing.Point(171, 107);
            this.chooseExcelFileButton.Name = "chooseExcelFileButton";
            this.chooseExcelFileButton.Size = new System.Drawing.Size(75, 23);
            this.chooseExcelFileButton.TabIndex = 0;
            this.chooseExcelFileButton.UseVisualStyleBackColor = true;
            this.chooseExcelFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExcelFilePathlabel
            // 
            this.ExcelFilePathlabel.AutoSize = true;
            this.ExcelFilePathlabel.Location = new System.Drawing.Point(12, 51);
            this.ExcelFilePathlabel.Name = "ExcelFilePathlabel";
            this.ExcelFilePathlabel.Size = new System.Drawing.Size(0, 12);
            this.ExcelFilePathlabel.TabIndex = 1;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(252, 107);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 2;
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(336, 107);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // GetExcelFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 142);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.ExcelFilePathlabel);
            this.Controls.Add(this.chooseExcelFileButton);
            this.Name = "GetExcelFileForm";
            this.Text = "GetExcelFileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseExcelFileButton;
        private System.Windows.Forms.Label ExcelFilePathlabel;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button cancelButton;
    }
}