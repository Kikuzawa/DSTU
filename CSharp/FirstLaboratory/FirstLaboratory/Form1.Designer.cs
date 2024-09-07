namespace FirstLaboratory
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnTask1 = new System.Windows.Forms.Button();
            this.BtnTask2 = new System.Windows.Forms.Button();
            this.BtnTask3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnTask1
            // 
            this.BtnTask1.Location = new System.Drawing.Point(162, 142);
            this.BtnTask1.Name = "BtnTask1";
            this.BtnTask1.Size = new System.Drawing.Size(187, 54);
            this.BtnTask1.TabIndex = 0;
            this.BtnTask1.Text = "Задание 1";
            this.BtnTask1.UseVisualStyleBackColor = true;
            this.BtnTask1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnTask2
            // 
            this.BtnTask2.Location = new System.Drawing.Point(163, 229);
            this.BtnTask2.Name = "BtnTask2";
            this.BtnTask2.Size = new System.Drawing.Size(187, 54);
            this.BtnTask2.TabIndex = 1;
            this.BtnTask2.Text = "Задание 2";
            this.BtnTask2.UseVisualStyleBackColor = true;
            this.BtnTask2.Click += new System.EventHandler(this.BtnTask2_Click);
            // 
            // BtnTask3
            // 
            this.BtnTask3.Location = new System.Drawing.Point(162, 320);
            this.BtnTask3.Name = "BtnTask3";
            this.BtnTask3.Size = new System.Drawing.Size(187, 54);
            this.BtnTask3.TabIndex = 2;
            this.BtnTask3.Text = "Задание 3";
            this.BtnTask3.UseVisualStyleBackColor = true;
            this.BtnTask3.Click += new System.EventHandler(this.BtnTask3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnTask3);
            this.Controls.Add(this.BtnTask2);
            this.Controls.Add(this.BtnTask1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Laboratory 1 - Котелевец К.А. ВКБ31";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnTask1;
        private System.Windows.Forms.Button BtnTask2;
        private System.Windows.Forms.Button BtnTask3;
        private System.Windows.Forms.Button button1;
    }
}

