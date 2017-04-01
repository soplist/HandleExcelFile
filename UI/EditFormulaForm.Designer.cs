namespace UI
{
    partial class EditFormulaForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.CalculateDependentVariablesGroupBox = new System.Windows.Forms.GroupBox();
            this.variablesLabel = new System.Windows.Forms.Label();
            this.CalculateDependentVariablesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(519, 21);
            this.textBox1.TabIndex = 0;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(456, 164);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // CalculateDependentVariablesGroupBox
            // 
            this.CalculateDependentVariablesGroupBox.Controls.Add(this.variablesLabel);
            this.CalculateDependentVariablesGroupBox.Location = new System.Drawing.Point(13, 13);
            this.CalculateDependentVariablesGroupBox.Name = "CalculateDependentVariablesGroupBox";
            this.CalculateDependentVariablesGroupBox.Size = new System.Drawing.Size(518, 63);
            this.CalculateDependentVariablesGroupBox.TabIndex = 2;
            this.CalculateDependentVariablesGroupBox.TabStop = false;
            // 
            // variablesLabel
            // 
            this.variablesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variablesLabel.Location = new System.Drawing.Point(3, 17);
            this.variablesLabel.Name = "variablesLabel";
            this.variablesLabel.Size = new System.Drawing.Size(512, 43);
            this.variablesLabel.TabIndex = 0;
            // 
            // EditFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 199);
            this.Controls.Add(this.CalculateDependentVariablesGroupBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.textBox1);
            this.Name = "EditFormulaForm";
            this.Text = "EditFormulaForm";
            this.CalculateDependentVariablesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.GroupBox CalculateDependentVariablesGroupBox;
        private System.Windows.Forms.Label variablesLabel;
    }
}