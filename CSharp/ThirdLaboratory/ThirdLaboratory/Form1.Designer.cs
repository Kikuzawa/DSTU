namespace ThirdLaboratory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.randowButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.createMatrixButton = new System.Windows.Forms.Button();
            this.nLinesBox = new System.Windows.Forms.TextBox();
            this.mLinesBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.plusSizeButton = new System.Windows.Forms.Button();
            this.minusSizeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.task9Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.completeTextBox = new System.Windows.Forms.TextBox();
            this.task13Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minusSizeButton);
            this.groupBox1.Controls.Add(this.plusSizeButton);
            this.groupBox1.Controls.Add(this.randowButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.createMatrixButton);
            this.groupBox1.Controls.Add(this.nLinesBox);
            this.groupBox1.Controls.Add(this.mLinesBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 277);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод";
            // 
            // randowButton
            // 
            this.randowButton.Location = new System.Drawing.Point(12, 200);
            this.randowButton.Name = "randowButton";
            this.randowButton.Size = new System.Drawing.Size(69, 50);
            this.randowButton.TabIndex = 4;
            this.randowButton.Text = "Заполнить матрицу";
            this.randowButton.UseVisualStyleBackColor = true;
            this.randowButton.Click += new System.EventHandler(this.randowButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите M строк";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите N столбцов";
            // 
            // createMatrixButton
            // 
            this.createMatrixButton.Location = new System.Drawing.Point(12, 137);
            this.createMatrixButton.Name = "createMatrixButton";
            this.createMatrixButton.Size = new System.Drawing.Size(69, 50);
            this.createMatrixButton.TabIndex = 2;
            this.createMatrixButton.Text = "Создать  матрицу";
            this.createMatrixButton.UseVisualStyleBackColor = true;
            this.createMatrixButton.Click += new System.EventHandler(this.createMatrixButton_Click);
            // 
            // nLinesBox
            // 
            this.nLinesBox.Location = new System.Drawing.Point(126, 78);
            this.nLinesBox.Name = "nLinesBox";
            this.nLinesBox.Size = new System.Drawing.Size(101, 20);
            this.nLinesBox.TabIndex = 1;
            this.nLinesBox.Text = "3";
            // 
            // mLinesBox
            // 
            this.mLinesBox.Location = new System.Drawing.Point(126, 49);
            this.mLinesBox.Name = "mLinesBox";
            this.mLinesBox.Size = new System.Drawing.Size(101, 20);
            this.mLinesBox.TabIndex = 0;
            this.mLinesBox.Text = "3";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(274, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(500, 500);
            this.dataGridView1.TabIndex = 1;
            // 
            // plusSizeButton
            // 
            this.plusSizeButton.Location = new System.Drawing.Point(174, 137);
            this.plusSizeButton.Name = "plusSizeButton";
            this.plusSizeButton.Size = new System.Drawing.Size(53, 50);
            this.plusSizeButton.TabIndex = 5;
            this.plusSizeButton.Text = "+";
            this.plusSizeButton.UseVisualStyleBackColor = true;
            this.plusSizeButton.Click += new System.EventHandler(this.plusSizeButton_Click);
            // 
            // minusSizeButton
            // 
            this.minusSizeButton.Location = new System.Drawing.Point(174, 193);
            this.minusSizeButton.Name = "minusSizeButton";
            this.minusSizeButton.Size = new System.Drawing.Size(53, 50);
            this.minusSizeButton.TabIndex = 5;
            this.minusSizeButton.Text = "-";
            this.minusSizeButton.UseVisualStyleBackColor = true;
            this.minusSizeButton.Click += new System.EventHandler(this.minusSizeButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.task13Button);
            this.groupBox2.Controls.Add(this.completeTextBox);
            this.groupBox2.Controls.Add(this.task9Button);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 207);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задания";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // task9Button
            // 
            this.task9Button.Location = new System.Drawing.Point(25, 95);
            this.task9Button.Name = "task9Button";
            this.task9Button.Size = new System.Drawing.Size(30, 30);
            this.task9Button.TabIndex = 1;
            this.task9Button.Text = "9";
            this.task9Button.UseVisualStyleBackColor = true;
            this.task9Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Введите значение";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // completeTextBox
            // 
            this.completeTextBox.Location = new System.Drawing.Point(12, 172);
            this.completeTextBox.Name = "completeTextBox";
            this.completeTextBox.ReadOnly = true;
            this.completeTextBox.Size = new System.Drawing.Size(214, 20);
            this.completeTextBox.TabIndex = 4;
            // 
            // task13Button
            // 
            this.task13Button.Location = new System.Drawing.Point(61, 95);
            this.task13Button.Name = "task13Button";
            this.task13Button.Size = new System.Drawing.Size(30, 30);
            this.task13Button.TabIndex = 5;
            this.task13Button.Text = "13";
            this.task13Button.UseVisualStyleBackColor = true;
            this.task13Button.Click += new System.EventHandler(this.task13Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Результат";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Лабораторная 3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createMatrixButton;
        private System.Windows.Forms.TextBox nLinesBox;
        private System.Windows.Forms.TextBox mLinesBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button randowButton;
        private System.Windows.Forms.Button minusSizeButton;
        private System.Windows.Forms.Button plusSizeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button task9Button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox completeTextBox;
        private System.Windows.Forms.Button task13Button;
        private System.Windows.Forms.Label label4;
    }
}

