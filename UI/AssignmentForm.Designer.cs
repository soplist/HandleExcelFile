namespace UI
{
    partial class AssignmentForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.variableGroupBox = new System.Windows.Forms.GroupBox();
            this.columnVariableLabel = new System.Windows.Forms.Label();
            this.selectedColumnDataGridView = new System.Windows.Forms.DataGridView();
            this.SetWeightButton = new System.Windows.Forms.Button();
            this.SetDateTypeParameterButton = new System.Windows.Forms.Button();
            this.variableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColumnDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(694, 361);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(613, 361);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // variableGroupBox
            // 
            this.variableGroupBox.Controls.Add(this.columnVariableLabel);
            this.variableGroupBox.Location = new System.Drawing.Point(14, 12);
            this.variableGroupBox.Name = "variableGroupBox";
            this.variableGroupBox.Size = new System.Drawing.Size(755, 109);
            this.variableGroupBox.TabIndex = 2;
            this.variableGroupBox.TabStop = false;
            // 
            // columnVariableLabel
            // 
            this.columnVariableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnVariableLabel.Location = new System.Drawing.Point(3, 17);
            this.columnVariableLabel.Name = "columnVariableLabel";
            this.columnVariableLabel.Size = new System.Drawing.Size(749, 89);
            this.columnVariableLabel.TabIndex = 0;
            // 
            // selectedColumnDataGridView
            // 
            this.selectedColumnDataGridView.AllowUserToAddRows = false;
            this.selectedColumnDataGridView.AllowUserToDeleteRows = false;
            this.selectedColumnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedColumnDataGridView.Location = new System.Drawing.Point(14, 127);
            this.selectedColumnDataGridView.Name = "selectedColumnDataGridView";
            this.selectedColumnDataGridView.RowTemplate.Height = 23;
            this.selectedColumnDataGridView.Size = new System.Drawing.Size(755, 196);
            this.selectedColumnDataGridView.TabIndex = 3;
            this.selectedColumnDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.selectedColumnDataGridView_CellBeginEdit);
            this.selectedColumnDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectedColumnDataGridView_CellEndEdit);
            // 
            // SetWeightButton
            // 
            this.SetWeightButton.Location = new System.Drawing.Point(694, 329);
            this.SetWeightButton.Name = "SetWeightButton";
            this.SetWeightButton.Size = new System.Drawing.Size(75, 23);
            this.SetWeightButton.TabIndex = 4;
            this.SetWeightButton.UseVisualStyleBackColor = true;
            this.SetWeightButton.Click += new System.EventHandler(this.SetWeightButton_Click);
            // 
            // SetDateTypeParameterButton
            // 
            this.SetDateTypeParameterButton.Location = new System.Drawing.Point(566, 329);
            this.SetDateTypeParameterButton.Name = "SetDateTypeParameterButton";
            this.SetDateTypeParameterButton.Size = new System.Drawing.Size(122, 23);
            this.SetDateTypeParameterButton.TabIndex = 5;
            this.SetDateTypeParameterButton.UseVisualStyleBackColor = true;
            this.SetDateTypeParameterButton.Click += new System.EventHandler(this.SetDateTypeParameterButton_Click);
            // 
            // AssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 396);
            this.Controls.Add(this.SetDateTypeParameterButton);
            this.Controls.Add(this.SetWeightButton);
            this.Controls.Add(this.selectedColumnDataGridView);
            this.Controls.Add(this.variableGroupBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "AssignmentForm";
            this.Text = "AssignmentForm";
            this.variableGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedColumnDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.GroupBox variableGroupBox;
        private System.Windows.Forms.Label columnVariableLabel;
        private System.Windows.Forms.DataGridView selectedColumnDataGridView;
        private System.Windows.Forms.Button SetWeightButton;
        private System.Windows.Forms.Button SetDateTypeParameterButton;
    }
}