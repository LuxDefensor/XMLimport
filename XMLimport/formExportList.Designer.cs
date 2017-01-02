namespace XMLimport
{
    partial class formExportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formExportList));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFromList = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCodes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnSelectFromList
            // 
            this.btnSelectFromList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectFromList.Location = new System.Drawing.Point(352, 76);
            this.btnSelectFromList.Name = "btnSelectFromList";
            this.btnSelectFromList.Size = new System.Drawing.Size(79, 45);
            this.btnSelectFromList.TabIndex = 3;
            this.btnSelectFromList.Text = "добавить";
            this.btnSelectFromList.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(352, 434);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtCodes
            // 
            this.txtCodes.Location = new System.Drawing.Point(12, 76);
            this.txtCodes.Multiline = true;
            this.txtCodes.Name = "txtCodes";
            this.txtCodes.Size = new System.Drawing.Size(334, 381);
            this.txtCodes.TabIndex = 6;
            // 
            // formExportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 471);
            this.ControlBox = false;
            this.Controls.Add(this.txtCodes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSelectFromList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "formExportList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список ИНН для экспорта";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFromList;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCodes;
    }
}