namespace MyFirstSnapIn
{
    partial class InitializeWizard
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
            this.SnapInName = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SnapInName
            // 
            this.SnapInName.Location = new System.Drawing.Point(76, 37);
            this.SnapInName.Name = "SnapInName";
            this.SnapInName.Size = new System.Drawing.Size(134, 20);
            this.SnapInName.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(103, 102);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "Continue\r\n\r\n";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // InitializeWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.SnapInName);
            this.Name = "InitializeWizard";
            this.Text = "InitializeWizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SnapInName;
        private System.Windows.Forms.Button OK;
    }
}