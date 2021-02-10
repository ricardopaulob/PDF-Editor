
namespace PDF_Editor.Forms
{
    partial class PdfMetadataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfMetadataForm));
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.grpCustomProperties = new System.Windows.Forms.GroupBox();
            this.gridProperties = new System.Windows.Forms.DataGridView();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCustomProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(12, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(109, 25);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "File Name";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.Location = new System.Drawing.Point(128, 61);
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(655, 66);
            this.txtKeywords.TabIndex = 1;
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(14, 64);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(56, 13);
            this.lblKeywords.TabIndex = 2;
            this.lblKeywords.Text = "Keywords:";
            // 
            // grpCustomProperties
            // 
            this.grpCustomProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCustomProperties.Controls.Add(this.gridProperties);
            this.grpCustomProperties.Location = new System.Drawing.Point(12, 146);
            this.grpCustomProperties.Name = "grpCustomProperties";
            this.grpCustomProperties.Size = new System.Drawing.Size(771, 345);
            this.grpCustomProperties.TabIndex = 3;
            this.grpCustomProperties.TabStop = false;
            this.grpCustomProperties.Text = "Custom Properties";
            // 
            // gridProperties
            // 
            this.gridProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.PropertyValue});
            this.gridProperties.Location = new System.Drawing.Point(6, 19);
            this.gridProperties.Name = "gridProperties";
            this.gridProperties.Size = new System.Drawing.Size(759, 320);
            this.gridProperties.TabIndex = 5;
            this.gridProperties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridProperties_KeyDown);
            // 
            // PropertyName
            // 
            this.PropertyName.HeaderText = "Name";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.Width = 250;
            // 
            // PropertyValue
            // 
            this.PropertyValue.HeaderText = "Value";
            this.PropertyValue.Name = "PropertyValue";
            this.PropertyValue.Width = 250;
            // 
            // PdfMetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 503);
            this.Controls.Add(this.grpCustomProperties);
            this.Controls.Add(this.lblKeywords);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.lblFileName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PdfMetadataForm";
            this.Text = "PdfMetadataForm";
            this.Load += new System.EventHandler(this.PdfMetadataForm_Load);
            this.grpCustomProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.GroupBox grpCustomProperties;
        private System.Windows.Forms.DataGridView gridProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue;
    }
}