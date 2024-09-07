namespace FirstLaboratory
{
    partial class FormTask1
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
            this.BtnCloseForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCloseForm
            // 
            this.BtnCloseForm.Location = new System.Drawing.Point(259, 155);
            this.BtnCloseForm.Name = "BtnCloseForm";
            this.BtnCloseForm.Size = new System.Drawing.Size(75, 23);
            this.BtnCloseForm.TabIndex = 0;
            this.BtnCloseForm.Text = "Close Form";
            this.BtnCloseForm.UseVisualStyleBackColor = true;
            this.BtnCloseForm.Click += new System.EventHandler(this.BtnCloseForm_Click);
            // 
            // FormTask1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.BtnCloseForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTask1";
            this.Text = "FormTask1";
            this.Load += new System.EventHandler(this.FormTask1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCloseForm;
    }
}