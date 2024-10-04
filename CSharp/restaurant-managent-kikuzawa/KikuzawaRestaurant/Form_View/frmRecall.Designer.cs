namespace KikuzawaRestaurant.Form_View
{
    partial class btnCancel
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearcsh = new System.Windows.Forms.TextBox();
            this.cboSearcshMode = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDineIn = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkTakeAway = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkNoCharge = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnDatSearcsh = new System.Windows.Forms.Button();
            this.btnMyOrder = new System.Windows.Forms.Button();
            this.btnRecall = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "[All Receipt, All Order]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearcsh);
            this.groupBox1.Controls.Add(this.cboSearcshMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(73, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::KikuzawaRestaurant.Properties.Resources.Start_Menu_Search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(454, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearcsh
            // 
            this.txtSearcsh.Location = new System.Drawing.Point(245, 28);
            this.txtSearcsh.Name = "txtSearcsh";
            this.txtSearcsh.Size = new System.Drawing.Size(203, 20);
            this.txtSearcsh.TabIndex = 2;
            // 
            // cboSearcshMode
            // 
            this.cboSearcshMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearcshMode.FormattingEnabled = true;
            this.cboSearcshMode.Items.AddRange(new object[] {
            "Firstname",
            "Lastname",
            "Receipt number"});
            this.cboSearcshMode.Location = new System.Drawing.Point(83, 27);
            this.cboSearcshMode.Name = "cboSearcshMode";
            this.cboSearcshMode.Size = new System.Drawing.Size(156, 21);
            this.cboSearcshMode.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(73, 189);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(597, 196);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDineIn);
            this.groupBox2.Location = new System.Drawing.Point(73, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 38);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // chkDineIn
            // 
            this.chkDineIn.AutoSize = true;
            this.chkDineIn.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDineIn.Location = new System.Drawing.Point(35, 11);
            this.chkDineIn.Name = "chkDineIn";
            this.chkDineIn.Size = new System.Drawing.Size(76, 20);
            this.chkDineIn.TabIndex = 0;
            this.chkDineIn.Text = "Dine In";
            this.chkDineIn.UseVisualStyleBackColor = true;
            this.chkDineIn.CheckedChanged += new System.EventHandler(this.chkDineIn_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkTakeAway);
            this.groupBox3.Location = new System.Drawing.Point(286, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 38);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // chkTakeAway
            // 
            this.chkTakeAway.AutoSize = true;
            this.chkTakeAway.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTakeAway.Location = new System.Drawing.Point(30, 13);
            this.chkTakeAway.Name = "chkTakeAway";
            this.chkTakeAway.Size = new System.Drawing.Size(90, 20);
            this.chkTakeAway.TabIndex = 0;
            this.chkTakeAway.Text = "Take Away";
            this.chkTakeAway.UseVisualStyleBackColor = true;
            this.chkTakeAway.CheckedChanged += new System.EventHandler(this.chkTakeAway_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkNoCharge);
            this.groupBox4.Location = new System.Drawing.Point(497, 145);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 38);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // chkNoCharge
            // 
            this.chkNoCharge.AutoSize = true;
            this.chkNoCharge.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoCharge.Location = new System.Drawing.Point(30, 12);
            this.chkNoCharge.Name = "chkNoCharge";
            this.chkNoCharge.Size = new System.Drawing.Size(90, 20);
            this.chkNoCharge.TabIndex = 0;
            this.chkNoCharge.Text = "No Charge";
            this.chkNoCharge.UseVisualStyleBackColor = true;
            this.chkNoCharge.CheckedChanged += new System.EventHandler(this.chkNoCharge_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dateTimePicker1);
            this.groupBox5.Location = new System.Drawing.Point(73, 391);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 40);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // btnDatSearcsh
            // 
            this.btnDatSearcsh.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatSearcsh.Image = global::KikuzawaRestaurant.Properties.Resources.Start_Menu_Search;
            this.btnDatSearcsh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatSearcsh.Location = new System.Drawing.Point(187, 391);
            this.btnDatSearcsh.Name = "btnDatSearcsh";
            this.btnDatSearcsh.Size = new System.Drawing.Size(82, 40);
            this.btnDatSearcsh.TabIndex = 5;
            this.btnDatSearcsh.Text = "Search";
            this.btnDatSearcsh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnDatSearcsh, "Select date from the date option on the left\r\nside of this button and click\r\nsear" +
        "ch");
            this.btnDatSearcsh.UseVisualStyleBackColor = true;
            this.btnDatSearcsh.Click += new System.EventHandler(this.btnDatSearcsh_Click);
            // 
            // btnMyOrder
            // 
            this.btnMyOrder.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyOrder.Image = global::KikuzawaRestaurant.Properties.Resources.Office_Customer_Male_Light_icon;
            this.btnMyOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyOrder.Location = new System.Drawing.Point(275, 391);
            this.btnMyOrder.Name = "btnMyOrder";
            this.btnMyOrder.Size = new System.Drawing.Size(106, 40);
            this.btnMyOrder.TabIndex = 5;
            this.btnMyOrder.Text = "My Order";
            this.btnMyOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMyOrder.UseVisualStyleBackColor = true;
            this.btnMyOrder.Click += new System.EventHandler(this.btnMyOrder_Click);
            // 
            // btnRecall
            // 
            this.btnRecall.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecall.Location = new System.Drawing.Point(479, 391);
            this.btnRecall.Name = "btnRecall";
            this.btnRecall.Size = new System.Drawing.Size(89, 40);
            this.btnRecall.TabIndex = 5;
            this.btnRecall.Text = "Recall";
            this.toolTip1.SetToolTip(this.btnRecall, "Click on the item in the grid to select \r\nand click recall to select payment");
            this.btnRecall.UseVisualStyleBackColor = true;
            this.btnRecall.Click += new System.EventHandler(this.btnRecall_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::KikuzawaRestaurant.Properties.Resources.cancel;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(571, 391);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "Cancel";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Receipt List";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(387, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "Split";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 459);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnRecall);
            this.Controls.Add(this.btnMyOrder);
            this.Controls.Add(this.btnDatSearcsh);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "btnCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRecall";
            this.Load += new System.EventHandler(this.frmRecall_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearcsh;
        private System.Windows.Forms.ComboBox cboSearcshMode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDineIn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkTakeAway;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkNoCharge;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnDatSearcsh;
        private System.Windows.Forms.Button btnMyOrder;
        private System.Windows.Forms.Button btnRecall;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}