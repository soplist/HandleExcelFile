namespace UI
{
    partial class SetDateTypeParameterForm
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
            this.DateTypeParameterGroupBox = new System.Windows.Forms.GroupBox();
            this.RelevanceTwoDateTypeColumnButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.TwoColumnBeRelatedCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.RelationColumnContentGroupBox = new System.Windows.Forms.GroupBox();
            this.currentRelationContentDataGridView = new System.Windows.Forms.DataGridView();
            this.DateTypeParameterGroupBox.SuspendLayout();
            this.RelationColumnContentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentRelationContentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DateTypeParameterGroupBox
            // 
            this.DateTypeParameterGroupBox.Controls.Add(this.RelevanceTwoDateTypeColumnButton);
            this.DateTypeParameterGroupBox.Location = new System.Drawing.Point(12, 12);
            this.DateTypeParameterGroupBox.Name = "DateTypeParameterGroupBox";
            this.DateTypeParameterGroupBox.Size = new System.Drawing.Size(791, 79);
            this.DateTypeParameterGroupBox.TabIndex = 0;
            this.DateTypeParameterGroupBox.TabStop = false;
            // 
            // RelevanceTwoDateTypeColumnButton
            // 
            this.RelevanceTwoDateTypeColumnButton.Location = new System.Drawing.Point(710, 50);
            this.RelevanceTwoDateTypeColumnButton.Name = "RelevanceTwoDateTypeColumnButton";
            this.RelevanceTwoDateTypeColumnButton.Size = new System.Drawing.Size(75, 23);
            this.RelevanceTwoDateTypeColumnButton.TabIndex = 0;
            this.RelevanceTwoDateTypeColumnButton.UseVisualStyleBackColor = true;
            this.RelevanceTwoDateTypeColumnButton.Click += new System.EventHandler(this.RelevanceTwoDateTypeColumnbutton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(728, 364);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TwoColumnBeRelatedCheckedListBox
            // 
            this.TwoColumnBeRelatedCheckedListBox.FormattingEnabled = true;
            this.TwoColumnBeRelatedCheckedListBox.Location = new System.Drawing.Point(12, 109);
            this.TwoColumnBeRelatedCheckedListBox.Name = "TwoColumnBeRelatedCheckedListBox";
            this.TwoColumnBeRelatedCheckedListBox.Size = new System.Drawing.Size(169, 228);
            this.TwoColumnBeRelatedCheckedListBox.TabIndex = 2;
            // 
            // RelationColumnContentGroupBox
            // 
            this.RelationColumnContentGroupBox.Controls.Add(this.currentRelationContentDataGridView);
            this.RelationColumnContentGroupBox.Location = new System.Drawing.Point(219, 109);
            this.RelationColumnContentGroupBox.Name = "RelationColumnContentGroupBox";
            this.RelationColumnContentGroupBox.Size = new System.Drawing.Size(254, 228);
            this.RelationColumnContentGroupBox.TabIndex = 3;
            this.RelationColumnContentGroupBox.TabStop = false;
            this.RelationColumnContentGroupBox.Text = "groupBox1";
            // 
            // currentRelationContentDataGridView
            // 
            this.currentRelationContentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentRelationContentDataGridView.Location = new System.Drawing.Point(7, 21);
            this.currentRelationContentDataGridView.Name = "currentRelationContentDataGridView";
            this.currentRelationContentDataGridView.RowTemplate.Height = 23;
            this.currentRelationContentDataGridView.Size = new System.Drawing.Size(240, 201);
            this.currentRelationContentDataGridView.TabIndex = 0;
            // 
            // SetDateTypeParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 399);
            this.Controls.Add(this.RelationColumnContentGroupBox);
            this.Controls.Add(this.TwoColumnBeRelatedCheckedListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.DateTypeParameterGroupBox);
            this.Name = "SetDateTypeParameterForm";
            this.Text = "SetDateTypeParameterForm";
            this.DateTypeParameterGroupBox.ResumeLayout(false);
            this.RelationColumnContentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentRelationContentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DateTypeParameterGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button RelevanceTwoDateTypeColumnButton;
        private System.Windows.Forms.CheckedListBox TwoColumnBeRelatedCheckedListBox;
        private System.Windows.Forms.GroupBox RelationColumnContentGroupBox;
        private System.Windows.Forms.DataGridView currentRelationContentDataGridView;
    }
}