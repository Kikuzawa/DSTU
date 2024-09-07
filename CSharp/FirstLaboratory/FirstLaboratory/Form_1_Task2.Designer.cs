namespace FirstLaboratory
{
    partial class Form_1_Task2
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
            this.BtnGoToForm_2_Task2 = new System.Windows.Forms.Button();
            this.BtnGoToForm1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGoToForm_2_Task2
            // 
            this.BtnGoToForm_2_Task2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGoToForm_2_Task2.Location = new System.Drawing.Point(458, 450);
            this.BtnGoToForm_2_Task2.Name = "BtnGoToForm_2_Task2";
            this.BtnGoToForm_2_Task2.Size = new System.Drawing.Size(300, 200);
            this.BtnGoToForm_2_Task2.TabIndex = 0;
            this.BtnGoToForm_2_Task2.Text = "Форма №2";
            this.BtnGoToForm_2_Task2.UseVisualStyleBackColor = true;
            this.BtnGoToForm_2_Task2.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnGoToForm1
            // 
            this.BtnGoToForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGoToForm1.Location = new System.Drawing.Point(1074, 450);
            this.BtnGoToForm1.Name = "BtnGoToForm1";
            this.BtnGoToForm1.Size = new System.Drawing.Size(300, 200);
            this.BtnGoToForm1.TabIndex = 1;
            this.BtnGoToForm1.Text = "🔙";
            this.BtnGoToForm1.UseVisualStyleBackColor = true;
            this.BtnGoToForm1.Click += new System.EventHandler(this.BtnGoToForm1_Click);
            // 
            // Form_1_Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BtnGoToForm1);
            this.Controls.Add(this.BtnGoToForm_2_Task2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_1_Task2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_1_Task2";
            this.Load += new System.EventHandler(this.Form_1_Task2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGoToForm_2_Task2;
        private System.Windows.Forms.Button BtnGoToForm1;
    }
}