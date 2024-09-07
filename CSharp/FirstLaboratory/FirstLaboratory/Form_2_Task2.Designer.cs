namespace FirstLaboratory
{
    partial class Form_2_Task2
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
            this.BtnGoToForm1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGoToForm1
            // 
            this.BtnGoToForm1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnGoToForm1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnGoToForm1.Location = new System.Drawing.Point(653, 365);
            this.BtnGoToForm1.Name = "BtnGoToForm1";
            this.BtnGoToForm1.Size = new System.Drawing.Size(101, 42);
            this.BtnGoToForm1.TabIndex = 0;
            this.BtnGoToForm1.Text = "GREENPEACE";
            this.BtnGoToForm1.UseVisualStyleBackColor = false;
            this.BtnGoToForm1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_2_Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnGoToForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_2_Task2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form_2_Task2";
            this.Load += new System.EventHandler(this.Form_2_Task2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGoToForm1;
    }
}