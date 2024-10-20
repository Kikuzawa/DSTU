using System;

namespace Laboratory2
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
            this.ButtonLoadFile = new System.Windows.Forms.Button();
            this.loadTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHaffman = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButtonSelectFolderHaffDecode1 = new System.Windows.Forms.Button();
            this.ButtonHaffDecode = new System.Windows.Forms.Button();
            this.saveTextBoxHaffDecode = new System.Windows.Forms.TextBox();
            this.dataGridHaffDecode = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonSelectFolderHaffCode = new System.Windows.Forms.Button();
            this.ButtonHaffCode = new System.Windows.Forms.Button();
            this.saveTextBoxHaffCode = new System.Windows.Forms.TextBox();
            this.dataGridHaffCode = new System.Windows.Forms.DataGridView();
            this.tabPageLZ77 = new System.Windows.Forms.TabPage();
            this.ButtonRunLZ77 = new System.Windows.Forms.Button();
            this.dataGridLZ77 = new System.Windows.Forms.DataGridView();
            this.SaveFileLZ77 = new System.Windows.Forms.Button();
            this.ButtonSelectFolderLZ77 = new System.Windows.Forms.Button();
            this.saveTextBoxLZ77 = new System.Windows.Forms.TextBox();
            this.tabPageLZ78 = new System.Windows.Forms.TabPage();
            this.ButtonRunLZ78 = new System.Windows.Forms.Button();
            this.dataGridLZ78 = new System.Windows.Forms.DataGridView();
            this.SaveFileLZ78 = new System.Windows.Forms.Button();
            this.ButtonSelectFolderLZ78 = new System.Windows.Forms.Button();
            this.saveTextBoxLZ78 = new System.Windows.Forms.TextBox();
            this.tabPageLZW = new System.Windows.Forms.TabPage();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageHaffman.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHaffDecode)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHaffCode)).BeginInit();
            this.tabPageLZ77.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLZ77)).BeginInit();
            this.tabPageLZ78.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLZ78)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonLoadFile);
            this.groupBox1.Controls.Add(this.loadTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1159, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Загрузка файла";
            // 
            // ButtonLoadFile
            // 
            this.ButtonLoadFile.Location = new System.Drawing.Point(1051, 32);
            this.ButtonLoadFile.Name = "ButtonLoadFile";
            this.ButtonLoadFile.Size = new System.Drawing.Size(92, 23);
            this.ButtonLoadFile.TabIndex = 1;
            this.ButtonLoadFile.Text = "Выбрать файл";
            this.ButtonLoadFile.UseVisualStyleBackColor = true;
            this.ButtonLoadFile.Click += new System.EventHandler(this.ButtonLoadFile_Click);
            // 
            // loadTextBox
            // 
            this.loadTextBox.Location = new System.Drawing.Point(16, 34);
            this.loadTextBox.Name = "loadTextBox";
            this.loadTextBox.ReadOnly = true;
            this.loadTextBox.Size = new System.Drawing.Size(1019, 20);
            this.loadTextBox.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHaffman);
            this.tabControl1.Controls.Add(this.tabPageLZ77);
            this.tabControl1.Controls.Add(this.tabPageLZ78);
            this.tabControl1.Controls.Add(this.tabPageLZW);
            this.tabControl1.Location = new System.Drawing.Point(13, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1159, 636);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageHaffman
            // 
            this.tabPageHaffman.Controls.Add(this.groupBox3);
            this.tabPageHaffman.Controls.Add(this.groupBox2);
            this.tabPageHaffman.Location = new System.Drawing.Point(4, 22);
            this.tabPageHaffman.Name = "tabPageHaffman";
            this.tabPageHaffman.Size = new System.Drawing.Size(1151, 610);
            this.tabPageHaffman.TabIndex = 0;
            this.tabPageHaffman.Text = "Хаффман";
            this.tabPageHaffman.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ButtonSelectFolderHaffDecode1);
            this.groupBox3.Controls.Add(this.ButtonHaffDecode);
            this.groupBox3.Controls.Add(this.saveTextBoxHaffDecode);
            this.groupBox3.Controls.Add(this.dataGridHaffDecode);
            this.groupBox3.Location = new System.Drawing.Point(585, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 582);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Декодирование";
            // 
            // ButtonSelectFolderHaffDecode1
            // 
            this.ButtonSelectFolderHaffDecode1.Location = new System.Drawing.Point(378, 33);
            this.ButtonSelectFolderHaffDecode1.Name = "ButtonSelectFolderHaffDecode1";
            this.ButtonSelectFolderHaffDecode1.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelectFolderHaffDecode1.TabIndex = 1;
            this.ButtonSelectFolderHaffDecode1.Text = "Обзор";
            this.ButtonSelectFolderHaffDecode1.UseVisualStyleBackColor = true;
            this.ButtonSelectFolderHaffDecode1.Click += new System.EventHandler(this.ButtonSelectFolderHaff_Click1);
            // 
            // ButtonHaffDecode
            // 
            this.ButtonHaffDecode.Location = new System.Drawing.Point(459, 33);
            this.ButtonHaffDecode.Name = "ButtonHaffDecode";
            this.ButtonHaffDecode.Size = new System.Drawing.Size(89, 23);
            this.ButtonHaffDecode.TabIndex = 1;
            this.ButtonHaffDecode.Text = "Декодировать";
            this.ButtonHaffDecode.UseVisualStyleBackColor = true;
            this.ButtonHaffDecode.Click += new System.EventHandler(this.ButtonHaffDecode_Click);
            // 
            // saveTextBoxHaffDecode
            // 
            this.saveTextBoxHaffDecode.Location = new System.Drawing.Point(7, 36);
            this.saveTextBoxHaffDecode.Name = "saveTextBoxHaffDecode";
            this.saveTextBoxHaffDecode.ReadOnly = true;
            this.saveTextBoxHaffDecode.Size = new System.Drawing.Size(365, 20);
            this.saveTextBoxHaffDecode.TabIndex = 0;
            // 
            // dataGridHaffDecode
            // 
            this.dataGridHaffDecode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHaffDecode.Location = new System.Drawing.Point(7, 62);
            this.dataGridHaffDecode.Name = "dataGridHaffDecode";
            this.dataGridHaffDecode.Size = new System.Drawing.Size(541, 514);
            this.dataGridHaffDecode.TabIndex = 0;
            this.dataGridHaffDecode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHaffDecode_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonSelectFolderHaffCode);
            this.groupBox2.Controls.Add(this.ButtonHaffCode);
            this.groupBox2.Controls.Add(this.saveTextBoxHaffCode);
            this.groupBox2.Controls.Add(this.dataGridHaffCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 582);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кодирование";
            // 
            // ButtonSelectFolderHaffCode
            // 
            this.ButtonSelectFolderHaffCode.Location = new System.Drawing.Point(378, 33);
            this.ButtonSelectFolderHaffCode.Name = "ButtonSelectFolderHaffCode";
            this.ButtonSelectFolderHaffCode.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelectFolderHaffCode.TabIndex = 1;
            this.ButtonSelectFolderHaffCode.Text = "Обзор";
            this.ButtonSelectFolderHaffCode.UseVisualStyleBackColor = true;
            this.ButtonSelectFolderHaffCode.Click += new System.EventHandler(this.ButtonSelectFolderHaff_Click);
            // 
            // ButtonHaffCode
            // 
            this.ButtonHaffCode.Location = new System.Drawing.Point(459, 33);
            this.ButtonHaffCode.Name = "ButtonHaffCode";
            this.ButtonHaffCode.Size = new System.Drawing.Size(89, 23);
            this.ButtonHaffCode.TabIndex = 1;
            this.ButtonHaffCode.Text = "Закодировать";
            this.ButtonHaffCode.UseVisualStyleBackColor = true;
            this.ButtonHaffCode.Click += new System.EventHandler(this.ButtonHaffCode_Click);
            // 
            // saveTextBoxHaffCode
            // 
            this.saveTextBoxHaffCode.Location = new System.Drawing.Point(7, 36);
            this.saveTextBoxHaffCode.Name = "saveTextBoxHaffCode";
            this.saveTextBoxHaffCode.ReadOnly = true;
            this.saveTextBoxHaffCode.Size = new System.Drawing.Size(365, 20);
            this.saveTextBoxHaffCode.TabIndex = 0;
            // 
            // dataGridHaffCode
            // 
            this.dataGridHaffCode.AllowUserToOrderColumns = true;
            this.dataGridHaffCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHaffCode.Location = new System.Drawing.Point(7, 62);
            this.dataGridHaffCode.Name = "dataGridHaffCode";
            this.dataGridHaffCode.Size = new System.Drawing.Size(541, 514);
            this.dataGridHaffCode.TabIndex = 0;
            // 
            // tabPageLZ77
            // 
            this.tabPageLZ77.Controls.Add(this.ButtonRunLZ77);
            this.tabPageLZ77.Controls.Add(this.dataGridLZ77);
            this.tabPageLZ77.Controls.Add(this.SaveFileLZ77);
            this.tabPageLZ77.Controls.Add(this.ButtonSelectFolderLZ77);
            this.tabPageLZ77.Controls.Add(this.saveTextBoxLZ77);
            this.tabPageLZ77.Location = new System.Drawing.Point(4, 22);
            this.tabPageLZ77.Name = "tabPageLZ77";
            this.tabPageLZ77.Size = new System.Drawing.Size(1151, 610);
            this.tabPageLZ77.TabIndex = 1;
            this.tabPageLZ77.Text = "LZ77";
            this.tabPageLZ77.UseVisualStyleBackColor = true;
            // 
            // ButtonRunLZ77
            // 
            this.ButtonRunLZ77.Location = new System.Drawing.Point(12, 542);
            this.ButtonRunLZ77.Name = "ButtonRunLZ77";
            this.ButtonRunLZ77.Size = new System.Drawing.Size(102, 23);
            this.ButtonRunLZ77.TabIndex = 4;
            this.ButtonRunLZ77.Text = "Кодирование";
            this.ButtonRunLZ77.UseVisualStyleBackColor = true;
            // 
            // dataGridLZ77
            // 
            this.dataGridLZ77.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLZ77.Location = new System.Drawing.Point(12, 17);
            this.dataGridLZ77.Name = "dataGridLZ77";
            this.dataGridLZ77.Size = new System.Drawing.Size(1126, 517);
            this.dataGridLZ77.TabIndex = 3;
            // 
            // SaveFileLZ77
            // 
            this.SaveFileLZ77.Location = new System.Drawing.Point(1063, 540);
            this.SaveFileLZ77.Name = "SaveFileLZ77";
            this.SaveFileLZ77.Size = new System.Drawing.Size(75, 23);
            this.SaveFileLZ77.TabIndex = 2;
            this.SaveFileLZ77.Text = "Сохранить";
            this.SaveFileLZ77.UseVisualStyleBackColor = true;
            // 
            // ButtonSelectFolderLZ77
            // 
            this.ButtonSelectFolderLZ77.Location = new System.Drawing.Point(982, 540);
            this.ButtonSelectFolderLZ77.Name = "ButtonSelectFolderLZ77";
            this.ButtonSelectFolderLZ77.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelectFolderLZ77.TabIndex = 1;
            this.ButtonSelectFolderLZ77.Text = "Обзор";
            this.ButtonSelectFolderLZ77.UseVisualStyleBackColor = true;
            // 
            // saveTextBoxLZ77
            // 
            this.saveTextBoxLZ77.Location = new System.Drawing.Point(120, 542);
            this.saveTextBoxLZ77.Name = "saveTextBoxLZ77";
            this.saveTextBoxLZ77.ReadOnly = true;
            this.saveTextBoxLZ77.Size = new System.Drawing.Size(846, 20);
            this.saveTextBoxLZ77.TabIndex = 0;
            // 
            // tabPageLZ78
            // 
            this.tabPageLZ78.Controls.Add(this.ButtonRunLZ78);
            this.tabPageLZ78.Controls.Add(this.dataGridLZ78);
            this.tabPageLZ78.Controls.Add(this.SaveFileLZ78);
            this.tabPageLZ78.Controls.Add(this.ButtonSelectFolderLZ78);
            this.tabPageLZ78.Controls.Add(this.saveTextBoxLZ78);
            this.tabPageLZ78.Location = new System.Drawing.Point(4, 22);
            this.tabPageLZ78.Name = "tabPageLZ78";
            this.tabPageLZ78.Size = new System.Drawing.Size(1151, 610);
            this.tabPageLZ78.TabIndex = 2;
            this.tabPageLZ78.Text = "LZ78";
            this.tabPageLZ78.UseVisualStyleBackColor = true;
            // 
            // ButtonRunLZ78
            // 
            this.ButtonRunLZ78.Location = new System.Drawing.Point(12, 536);
            this.ButtonRunLZ78.Name = "ButtonRunLZ78";
            this.ButtonRunLZ78.Size = new System.Drawing.Size(102, 23);
            this.ButtonRunLZ78.TabIndex = 9;
            this.ButtonRunLZ78.Text = "Кодирование";
            this.ButtonRunLZ78.UseVisualStyleBackColor = true;
            // 
            // dataGridLZ78
            // 
            this.dataGridLZ78.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLZ78.Location = new System.Drawing.Point(12, 11);
            this.dataGridLZ78.Name = "dataGridLZ78";
            this.dataGridLZ78.Size = new System.Drawing.Size(1126, 517);
            this.dataGridLZ78.TabIndex = 8;
            // 
            // SaveFileLZ78
            // 
            this.SaveFileLZ78.Location = new System.Drawing.Point(1063, 534);
            this.SaveFileLZ78.Name = "SaveFileLZ78";
            this.SaveFileLZ78.Size = new System.Drawing.Size(75, 23);
            this.SaveFileLZ78.TabIndex = 7;
            this.SaveFileLZ78.Text = "Сохранить";
            this.SaveFileLZ78.UseVisualStyleBackColor = true;
            // 
            // ButtonSelectFolderLZ78
            // 
            this.ButtonSelectFolderLZ78.Location = new System.Drawing.Point(982, 534);
            this.ButtonSelectFolderLZ78.Name = "ButtonSelectFolderLZ78";
            this.ButtonSelectFolderLZ78.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelectFolderLZ78.TabIndex = 6;
            this.ButtonSelectFolderLZ78.Text = "Обзор";
            this.ButtonSelectFolderLZ78.UseVisualStyleBackColor = true;
            // 
            // saveTextBoxLZ78
            // 
            this.saveTextBoxLZ78.Location = new System.Drawing.Point(120, 536);
            this.saveTextBoxLZ78.Name = "saveTextBoxLZ78";
            this.saveTextBoxLZ78.ReadOnly = true;
            this.saveTextBoxLZ78.Size = new System.Drawing.Size(846, 20);
            this.saveTextBoxLZ78.TabIndex = 5;
            // 
            // tabPageLZW
            // 
            this.tabPageLZW.Location = new System.Drawing.Point(4, 22);
            this.tabPageLZW.Name = "tabPageLZW";
            this.tabPageLZW.Size = new System.Drawing.Size(1151, 610);
            this.tabPageLZW.TabIndex = 3;
            this.tabPageLZW.Text = "LZW";
            this.tabPageLZW.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Laboratory 2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageHaffman.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHaffDecode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHaffCode)).EndInit();
            this.tabPageLZ77.ResumeLayout(false);
            this.tabPageLZ77.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLZ77)).EndInit();
            this.tabPageLZ78.ResumeLayout(false);
            this.tabPageLZ78.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLZ78)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonLoadFile;
        private System.Windows.Forms.TextBox loadTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageHaffman;
        private System.Windows.Forms.TabPage tabPageLZ77;
        private System.Windows.Forms.TabPage tabPageLZ78;
        private System.Windows.Forms.TabPage tabPageLZW;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridHaffDecode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonHaffCode;
        private System.Windows.Forms.DataGridView dataGridHaffCode;
        private System.Windows.Forms.Button ButtonHaffDecode;
        private System.Windows.Forms.TextBox saveTextBoxLZ77;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button SaveFileLZ77;
        private System.Windows.Forms.Button ButtonSelectFolderLZ77;
        private System.Windows.Forms.Button ButtonRunLZ77;
        private System.Windows.Forms.DataGridView dataGridLZ77;
        private System.Windows.Forms.Button ButtonRunLZ78;
        private System.Windows.Forms.DataGridView dataGridLZ78;
        private System.Windows.Forms.Button SaveFileLZ78;
        private System.Windows.Forms.Button ButtonSelectFolderLZ78;
        private System.Windows.Forms.TextBox saveTextBoxLZ78;
        private System.Windows.Forms.Button ButtonSelectFolderHaffCode;
        private System.Windows.Forms.TextBox saveTextBoxHaffCode;
        private System.Windows.Forms.Button ButtonSelectFolderHaffDecode1;
        private System.Windows.Forms.TextBox saveTextBoxHaffDecode;
    }
}

