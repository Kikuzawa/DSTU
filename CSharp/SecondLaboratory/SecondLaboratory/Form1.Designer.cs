using System;

namespace Windows7Calculator
{
    partial class Form1
    {
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.zeroButton = new System.Windows.Forms.Button();
            this.decimalButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.eightButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.equalsButton = new System.Windows.Forms.Button();
            this.cButton = new System.Windows.Forms.Button();
            this.ceButton = new System.Windows.Forms.Button();
            this.eraseButton = new System.Windows.Forms.Button();
            this.PlusMinusButton = new System.Windows.Forms.Button();
            this.percentButton = new System.Windows.Forms.Button();
            this.fracButton = new System.Windows.Forms.Button();
            this.MCButton = new System.Windows.Forms.Button();
            this.sqrtButton = new System.Windows.Forms.Button();
            this.MRButton = new System.Windows.Forms.Button();
            this.MSButton = new System.Windows.Forms.Button();
            this.MPlusButton = new System.Windows.Forms.Button();
            this.MMinusButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.calculatorScreen = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zeroButton
            // 
            this.zeroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zeroButton.BackColor = System.Drawing.Color.White;
            this.zeroButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroButton.ForeColor = System.Drawing.Color.Navy;
            this.zeroButton.Location = new System.Drawing.Point(13, 328);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(90, 35);
            this.zeroButton.TabIndex = 0;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = false;
            this.zeroButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // decimalButton
            // 
            this.decimalButton.BackColor = System.Drawing.Color.White;
            this.decimalButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decimalButton.ForeColor = System.Drawing.Color.Navy;
            this.decimalButton.Location = new System.Drawing.Point(102, 229);
            this.decimalButton.Margin = new System.Windows.Forms.Padding(4);
            this.decimalButton.Name = "decimalButton";
            this.decimalButton.Size = new System.Drawing.Size(41, 35);
            this.decimalButton.TabIndex = 1;
            this.decimalButton.Text = ".";
            this.decimalButton.UseVisualStyleBackColor = false;
            this.decimalButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.BackColor = System.Drawing.Color.White;
            this.plusButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusButton.ForeColor = System.Drawing.Color.Navy;
            this.plusButton.Location = new System.Drawing.Point(151, 229);
            this.plusButton.Margin = new System.Windows.Forms.Padding(4);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(41, 35);
            this.plusButton.TabIndex = 2;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = false;
            this.plusButton.Click += new System.EventHandler(this.operationButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.BackColor = System.Drawing.Color.White;
            this.oneButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneButton.ForeColor = System.Drawing.Color.Navy;
            this.oneButton.Location = new System.Drawing.Point(4, 184);
            this.oneButton.Margin = new System.Windows.Forms.Padding(4);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(41, 35);
            this.oneButton.TabIndex = 3;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // twoButton
            // 
            this.twoButton.BackColor = System.Drawing.Color.White;
            this.twoButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoButton.ForeColor = System.Drawing.Color.Navy;
            this.twoButton.Location = new System.Drawing.Point(53, 184);
            this.twoButton.Margin = new System.Windows.Forms.Padding(4);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(41, 35);
            this.twoButton.TabIndex = 4;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = false;
            this.twoButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // threeButton
            // 
            this.threeButton.BackColor = System.Drawing.Color.White;
            this.threeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threeButton.ForeColor = System.Drawing.Color.Navy;
            this.threeButton.Location = new System.Drawing.Point(102, 184);
            this.threeButton.Margin = new System.Windows.Forms.Padding(4);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(41, 35);
            this.threeButton.TabIndex = 5;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = false;
            this.threeButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.BackColor = System.Drawing.Color.White;
            this.minusButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minusButton.ForeColor = System.Drawing.Color.Navy;
            this.minusButton.Location = new System.Drawing.Point(151, 184);
            this.minusButton.Margin = new System.Windows.Forms.Padding(4);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(41, 35);
            this.minusButton.TabIndex = 6;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = false;
            this.minusButton.Click += new System.EventHandler(this.operationButton_Click);
            // 
            // fourButton
            // 
            this.fourButton.BackColor = System.Drawing.Color.White;
            this.fourButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fourButton.ForeColor = System.Drawing.Color.Navy;
            this.fourButton.Location = new System.Drawing.Point(4, 139);
            this.fourButton.Margin = new System.Windows.Forms.Padding(4);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(41, 35);
            this.fourButton.TabIndex = 7;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = false;
            this.fourButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.BackColor = System.Drawing.Color.White;
            this.fiveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveButton.ForeColor = System.Drawing.Color.Navy;
            this.fiveButton.Location = new System.Drawing.Point(53, 139);
            this.fiveButton.Margin = new System.Windows.Forms.Padding(4);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(41, 35);
            this.fiveButton.TabIndex = 8;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = false;
            this.fiveButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // sixButton
            // 
            this.sixButton.BackColor = System.Drawing.Color.White;
            this.sixButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sixButton.ForeColor = System.Drawing.Color.Navy;
            this.sixButton.Location = new System.Drawing.Point(102, 139);
            this.sixButton.Margin = new System.Windows.Forms.Padding(4);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(41, 35);
            this.sixButton.TabIndex = 9;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = false;
            this.sixButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.BackColor = System.Drawing.Color.White;
            this.multiplyButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplyButton.ForeColor = System.Drawing.Color.Navy;
            this.multiplyButton.Location = new System.Drawing.Point(151, 139);
            this.multiplyButton.Margin = new System.Windows.Forms.Padding(4);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(41, 35);
            this.multiplyButton.TabIndex = 10;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = false;
            this.multiplyButton.Click += new System.EventHandler(this.operationButton_Click);
            // 
            // sevenButton
            // 
            this.sevenButton.BackColor = System.Drawing.Color.White;
            this.sevenButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sevenButton.ForeColor = System.Drawing.Color.Navy;
            this.sevenButton.Location = new System.Drawing.Point(4, 94);
            this.sevenButton.Margin = new System.Windows.Forms.Padding(4);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(41, 35);
            this.sevenButton.TabIndex = 11;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = false;
            this.sevenButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // eightButton
            // 
            this.eightButton.BackColor = System.Drawing.Color.White;
            this.eightButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eightButton.ForeColor = System.Drawing.Color.Navy;
            this.eightButton.Location = new System.Drawing.Point(53, 94);
            this.eightButton.Margin = new System.Windows.Forms.Padding(4);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(41, 35);
            this.eightButton.TabIndex = 12;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = false;
            this.eightButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // nineButton
            // 
            this.nineButton.BackColor = System.Drawing.Color.White;
            this.nineButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nineButton.ForeColor = System.Drawing.Color.Navy;
            this.nineButton.Location = new System.Drawing.Point(102, 94);
            this.nineButton.Margin = new System.Windows.Forms.Padding(4);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(41, 35);
            this.nineButton.TabIndex = 13;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = false;
            this.nineButton.Click += new System.EventHandler(this.numberButton_Click);
            // 
            // divideButton
            // 
            this.divideButton.BackColor = System.Drawing.Color.White;
            this.divideButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divideButton.ForeColor = System.Drawing.Color.Navy;
            this.divideButton.Location = new System.Drawing.Point(151, 94);
            this.divideButton.Margin = new System.Windows.Forms.Padding(4);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(41, 35);
            this.divideButton.TabIndex = 14;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = false;
            this.divideButton.Click += new System.EventHandler(this.operationButton_Click);
            // 
            // equalsButton
            // 
            this.equalsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equalsButton.BackColor = System.Drawing.Color.White;
            this.equalsButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equalsButton.ForeColor = System.Drawing.Color.Navy;
            this.equalsButton.Location = new System.Drawing.Point(209, 283);
            this.equalsButton.Margin = new System.Windows.Forms.Padding(4);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(38, 80);
            this.equalsButton.TabIndex = 15;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = false;
            this.equalsButton.Click += new System.EventHandler(this.equalsButton_Click);
            // 
            // cButton
            // 
            this.cButton.BackColor = System.Drawing.Color.White;
            this.cButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton.ForeColor = System.Drawing.Color.Navy;
            this.cButton.Location = new System.Drawing.Point(102, 49);
            this.cButton.Margin = new System.Windows.Forms.Padding(4);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(41, 35);
            this.cButton.TabIndex = 16;
            this.cButton.Text = "C";
            this.cButton.UseVisualStyleBackColor = false;
            this.cButton.Click += new System.EventHandler(this.cButton_Click);
            // 
            // ceButton
            // 
            this.ceButton.BackColor = System.Drawing.Color.White;
            this.ceButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceButton.ForeColor = System.Drawing.Color.Navy;
            this.ceButton.Location = new System.Drawing.Point(53, 49);
            this.ceButton.Margin = new System.Windows.Forms.Padding(4);
            this.ceButton.Name = "ceButton";
            this.ceButton.Size = new System.Drawing.Size(41, 35);
            this.ceButton.TabIndex = 17;
            this.ceButton.Text = "CE";
            this.ceButton.UseVisualStyleBackColor = false;
            this.ceButton.Click += new System.EventHandler(this.ceButton_Click);
            // 
            // eraseButton
            // 
            this.eraseButton.BackColor = System.Drawing.Color.White;
            this.eraseButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseButton.ForeColor = System.Drawing.Color.Navy;
            this.eraseButton.Location = new System.Drawing.Point(3, 48);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(43, 35);
            this.eraseButton.TabIndex = 20;
            this.eraseButton.Text = "⇐";
            this.eraseButton.UseVisualStyleBackColor = false;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // PlusMinusButton
            // 
            this.PlusMinusButton.BackColor = System.Drawing.Color.White;
            this.PlusMinusButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlusMinusButton.ForeColor = System.Drawing.Color.Navy;
            this.PlusMinusButton.Location = new System.Drawing.Point(151, 49);
            this.PlusMinusButton.Margin = new System.Windows.Forms.Padding(4);
            this.PlusMinusButton.Name = "PlusMinusButton";
            this.PlusMinusButton.Size = new System.Drawing.Size(41, 35);
            this.PlusMinusButton.TabIndex = 21;
            this.PlusMinusButton.Text = "±";
            this.PlusMinusButton.UseVisualStyleBackColor = false;
            this.PlusMinusButton.Click += new System.EventHandler(this.PlusMinusButton_Click);
            // 
            // percentButton
            // 
            this.percentButton.BackColor = System.Drawing.Color.White;
            this.percentButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentButton.ForeColor = System.Drawing.Color.Navy;
            this.percentButton.Location = new System.Drawing.Point(200, 94);
            this.percentButton.Margin = new System.Windows.Forms.Padding(4);
            this.percentButton.Name = "percentButton";
            this.percentButton.Size = new System.Drawing.Size(41, 35);
            this.percentButton.TabIndex = 22;
            this.percentButton.Text = "%";
            this.percentButton.UseVisualStyleBackColor = false;
            this.percentButton.Click += new System.EventHandler(this.percentButton_Click);
            // 
            // fracButton
            // 
            this.fracButton.BackColor = System.Drawing.Color.White;
            this.fracButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fracButton.ForeColor = System.Drawing.Color.Navy;
            this.fracButton.Location = new System.Drawing.Point(200, 139);
            this.fracButton.Margin = new System.Windows.Forms.Padding(4);
            this.fracButton.Name = "fracButton";
            this.fracButton.Size = new System.Drawing.Size(41, 35);
            this.fracButton.TabIndex = 23;
            this.fracButton.Text = "1/x";
            this.fracButton.UseVisualStyleBackColor = false;
            this.fracButton.Click += new System.EventHandler(this.fracButton_Click);
            // 
            // MCButton
            // 
            this.MCButton.BackColor = System.Drawing.Color.White;
            this.MCButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MCButton.ForeColor = System.Drawing.Color.Navy;
            this.MCButton.Location = new System.Drawing.Point(4, 4);
            this.MCButton.Margin = new System.Windows.Forms.Padding(4);
            this.MCButton.Name = "MCButton";
            this.MCButton.Size = new System.Drawing.Size(41, 35);
            this.MCButton.TabIndex = 24;
            this.MCButton.Text = "MC";
            this.MCButton.UseVisualStyleBackColor = false;
            this.MCButton.Click += new System.EventHandler(this.powerButton_Click);
            // 
            // sqrtButton
            // 
            this.sqrtButton.BackColor = System.Drawing.Color.White;
            this.sqrtButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqrtButton.ForeColor = System.Drawing.Color.Navy;
            this.sqrtButton.Location = new System.Drawing.Point(200, 49);
            this.sqrtButton.Margin = new System.Windows.Forms.Padding(4);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new System.Drawing.Size(41, 35);
            this.sqrtButton.TabIndex = 25;
            this.sqrtButton.Text = "√";
            this.sqrtButton.UseVisualStyleBackColor = false;
            this.sqrtButton.Click += new System.EventHandler(this.sqrtButton_Click);
            // 
            // MRButton
            // 
            this.MRButton.BackColor = System.Drawing.Color.White;
            this.MRButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MRButton.ForeColor = System.Drawing.Color.Navy;
            this.MRButton.Location = new System.Drawing.Point(53, 4);
            this.MRButton.Margin = new System.Windows.Forms.Padding(4);
            this.MRButton.Name = "MRButton";
            this.MRButton.Size = new System.Drawing.Size(41, 35);
            this.MRButton.TabIndex = 26;
            this.MRButton.Text = "MR";
            this.MRButton.UseVisualStyleBackColor = false;
            this.MRButton.Click += new System.EventHandler(this.MRButton_Click);
            // 
            // MSButton
            // 
            this.MSButton.BackColor = System.Drawing.Color.White;
            this.MSButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSButton.ForeColor = System.Drawing.Color.Navy;
            this.MSButton.Location = new System.Drawing.Point(102, 4);
            this.MSButton.Margin = new System.Windows.Forms.Padding(4);
            this.MSButton.Name = "MSButton";
            this.MSButton.Size = new System.Drawing.Size(41, 35);
            this.MSButton.TabIndex = 27;
            this.MSButton.Text = "MS";
            this.MSButton.UseVisualStyleBackColor = false;
            this.MSButton.Click += new System.EventHandler(this.MSButton_Click_1);
            // 
            // MPlusButton
            // 
            this.MPlusButton.BackColor = System.Drawing.Color.White;
            this.MPlusButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MPlusButton.ForeColor = System.Drawing.Color.Navy;
            this.MPlusButton.Location = new System.Drawing.Point(151, 4);
            this.MPlusButton.Margin = new System.Windows.Forms.Padding(4);
            this.MPlusButton.Name = "MPlusButton";
            this.MPlusButton.Size = new System.Drawing.Size(41, 35);
            this.MPlusButton.TabIndex = 28;
            this.MPlusButton.Text = "M+";
            this.MPlusButton.UseVisualStyleBackColor = false;
            this.MPlusButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MMinusButton
            // 
            this.MMinusButton.BackColor = System.Drawing.Color.White;
            this.MMinusButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MMinusButton.ForeColor = System.Drawing.Color.Navy;
            this.MMinusButton.Location = new System.Drawing.Point(200, 4);
            this.MMinusButton.Margin = new System.Windows.Forms.Padding(4);
            this.MMinusButton.Name = "MMinusButton";
            this.MMinusButton.Size = new System.Drawing.Size(41, 35);
            this.MMinusButton.TabIndex = 29;
            this.MMinusButton.Text = "M-";
            this.MMinusButton.UseVisualStyleBackColor = false;
            this.MMinusButton.Click += new System.EventHandler(this.MMinusButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.MCButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MRButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.MSButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.fracButton, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.plusButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.minusButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.decimalButton, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.sqrtButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.threeButton, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.percentButton, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.twoButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.multiplyButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.oneButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.MMinusButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.sixButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.MPlusButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.fiveButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.divideButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.fourButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.eraseButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nineButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.PlusMinusButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.eightButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ceButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.sevenButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cButton, 2, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 99);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(245, 274);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(9, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 19);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Дополнительно";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // calculatorScreen
            // 
            this.calculatorScreen.AcceptsTab = true;
            this.calculatorScreen.BackColor = System.Drawing.Color.White;
            this.calculatorScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.calculatorScreen.Location = new System.Drawing.Point(13, 31);
            this.calculatorScreen.Margin = new System.Windows.Forms.Padding(4);
            this.calculatorScreen.MaximumSize = new System.Drawing.Size(245, 60);
            this.calculatorScreen.MinimumSize = new System.Drawing.Size(230, 60);
            this.calculatorScreen.Name = "calculatorScreen";
            this.calculatorScreen.ReadOnly = true;
            this.calculatorScreen.Size = new System.Drawing.Size(237, 47);
            this.calculatorScreen.TabIndex = 1;
            this.calculatorScreen.Text = "0";
            this.calculatorScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.calculatorScreen.WordWrap = false;
            this.calculatorScreen.TextChanged += new System.EventHandler(this.calculatorScreen_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.zeroButton);
            this.panel1.Controls.Add(this.equalsButton);
            this.panel1.Controls.Add(this.calculatorScreen);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 391);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(279, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 332);
            this.panel2.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(20, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "В";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(20, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Из";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выберите тип преобразуемой единицы";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox2.Location = new System.Drawing.Point(20, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(354, 21);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Location = new System.Drawing.Point(20, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(354, 21);
            this.textBox1.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "inches",
            "centimeters"});
            this.comboBox3.Location = new System.Drawing.Point(20, 282);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(354, 23);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "inches",
            "centimeters"});
            this.comboBox2.Location = new System.Drawing.Point(20, 174);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(354, 23);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "length"});
            this.comboBox1.Location = new System.Drawing.Point(20, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(537, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Конвертировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(280, 407);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор";
            this.Load += new System.EventHandler(this.CalculatorUI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        

        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button decimalButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button equalsButton;
        private System.Windows.Forms.Button cButton;
        private System.Windows.Forms.Button ceButton;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.Button PlusMinusButton;
        private System.Windows.Forms.Button percentButton;
        private System.Windows.Forms.Button fracButton;
        private System.Windows.Forms.Button MCButton;
        private System.Windows.Forms.Button sqrtButton;
        private System.Windows.Forms.Button MRButton;
        private System.Windows.Forms.Button MSButton;
        private System.Windows.Forms.Button MPlusButton;
        private System.Windows.Forms.Button MMinusButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox calculatorScreen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}