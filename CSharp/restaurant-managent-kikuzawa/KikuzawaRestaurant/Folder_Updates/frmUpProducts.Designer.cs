namespace KikuzawaRestaurant.Folder_Updates
{
    partial class frmUpProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpProducts));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTax2percsentage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTax3percsentage = new System.Windows.Forms.TextBox();
            this.txtTax1percsentage = new System.Windows.Forms.TextBox();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNetAmt = new System.Windows.Forms.TextBox();
            this.txtTax3Amt = new System.Windows.Forms.TextBox();
            this.txtTax1Amt = new System.Windows.Forms.TextBox();
            this.txtTax2Amt = new System.Windows.Forms.TextBox();
            this.txtProdPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProdDecs = new System.Windows.Forms.TextBox();
            this.cboProSubCate = new System.Windows.Forms.ComboBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KikuzawaRestaurant.Properties.Resources.Button_Ok_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(297, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 50);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTax2percsentage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTax3percsentage);
            this.groupBox2.Controls.Add(this.txtTax1percsentage);
            this.groupBox2.Location = new System.Drawing.Point(22, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 132);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tax Percentages";
            // 
            // txtTax2percsentage
            // 
            this.txtTax2percsentage.Location = new System.Drawing.Point(125, 53);
            this.txtTax2percsentage.Name = "txtTax2percsentage";
            this.txtTax2percsentage.ReadOnly = true;
            this.txtTax2percsentage.Size = new System.Drawing.Size(100, 20);
            this.txtTax2percsentage.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "VAT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tourism Levy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tax_3";
            // 
            // txtTax3percsentage
            // 
            this.txtTax3percsentage.Location = new System.Drawing.Point(125, 90);
            this.txtTax3percsentage.Name = "txtTax3percsentage";
            this.txtTax3percsentage.ReadOnly = true;
            this.txtTax3percsentage.Size = new System.Drawing.Size(100, 20);
            this.txtTax3percsentage.TabIndex = 4;
            // 
            // txtTax1percsentage
            // 
            this.txtTax1percsentage.Location = new System.Drawing.Point(125, 23);
            this.txtTax1percsentage.Name = "txtTax1percsentage";
            this.txtTax1percsentage.ReadOnly = true;
            this.txtTax1percsentage.Size = new System.Drawing.Size(100, 20);
            this.txtTax1percsentage.TabIndex = 4;
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(170, 109);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(201, 20);
            this.txtProdName.TabIndex = 18;
            this.txtProdName.TextChanged += new System.EventHandler(this.txtProdName_TextChanged);
            this.txtProdName.Leave += new System.EventHandler(this.txtProdName_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "Product Name";
            // 
            // txtNetAmt
            // 
            this.txtNetAmt.Location = new System.Drawing.Point(139, 133);
            this.txtNetAmt.Name = "txtNetAmt";
            this.txtNetAmt.ReadOnly = true;
            this.txtNetAmt.Size = new System.Drawing.Size(115, 20);
            this.txtNetAmt.TabIndex = 1;
            // 
            // txtTax3Amt
            // 
            this.txtTax3Amt.Location = new System.Drawing.Point(139, 99);
            this.txtTax3Amt.Name = "txtTax3Amt";
            this.txtTax3Amt.ReadOnly = true;
            this.txtTax3Amt.Size = new System.Drawing.Size(115, 20);
            this.txtTax3Amt.TabIndex = 1;
            // 
            // txtTax1Amt
            // 
            this.txtTax1Amt.Location = new System.Drawing.Point(139, 42);
            this.txtTax1Amt.Name = "txtTax1Amt";
            this.txtTax1Amt.ReadOnly = true;
            this.txtTax1Amt.Size = new System.Drawing.Size(115, 20);
            this.txtTax1Amt.TabIndex = 1;
            // 
            // txtTax2Amt
            // 
            this.txtTax2Amt.Location = new System.Drawing.Point(139, 69);
            this.txtTax2Amt.Name = "txtTax2Amt";
            this.txtTax2Amt.ReadOnly = true;
            this.txtTax2Amt.Size = new System.Drawing.Size(115, 20);
            this.txtTax2Amt.TabIndex = 1;
            // 
            // txtProdPrice
            // 
            this.txtProdPrice.Location = new System.Drawing.Point(139, 16);
            this.txtProdPrice.Name = "txtProdPrice";
            this.txtProdPrice.Size = new System.Drawing.Size(115, 20);
            this.txtProdPrice.TabIndex = 1;
            this.txtProdPrice.TextChanged += new System.EventHandler(this.txtProdPrice_TextChanged);
            this.txtProdPrice.Leave += new System.EventHandler(this.txtProdPrice_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tour. Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Product Net Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tax_3 Amount";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::KikuzawaRestaurant.Properties.Resources.Status_dialog_error_icon;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(506, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 50);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNetAmt);
            this.groupBox1.Controls.Add(this.txtTax3Amt);
            this.groupBox1.Controls.Add(this.txtTax1Amt);
            this.groupBox1.Controls.Add(this.txtTax2Amt);
            this.groupBox1.Controls.Add(this.txtProdPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(460, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 180);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amount Break Down";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Vat Amount";
            // 
            // txtProdDecs
            // 
            this.txtProdDecs.Location = new System.Drawing.Point(168, 144);
            this.txtProdDecs.Multiline = true;
            this.txtProdDecs.Name = "txtProdDecs";
            this.txtProdDecs.Size = new System.Drawing.Size(252, 73);
            this.txtProdDecs.TabIndex = 15;
            // 
            // cboProSubCate
            // 
            this.cboProSubCate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProSubCate.FormattingEnabled = true;
            this.cboProSubCate.Location = new System.Drawing.Point(170, 73);
            this.cboProSubCate.Name = "cboProSubCate";
            this.cboProSubCate.Size = new System.Drawing.Size(199, 21);
            this.cboProSubCate.TabIndex = 14;
            // 
            // cboProductType
            // 
            this.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Items.AddRange(new object[] {
            "[--Select Menu Group--]",
            "Beverage",
            "Food"});
            this.cboProductType.Location = new System.Drawing.Point(168, 37);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(201, 21);
            this.cboProductType.TabIndex = 13;
            this.cboProductType.SelectedIndexChanged += new System.EventHandler(this.cboProductType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Menu Sub-group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Menu group";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(170, 11);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 23;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // frmUpProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 357);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtProdDecs);
            this.Controls.Add(this.cboProSubCate);
            this.Controls.Add(this.cboProductType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUpProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UPDATE PRODUCTS - Kikuzawa Restaurant";
            this.Load += new System.EventHandler(this.frmUpProducts_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtTax2percsentage;
        public System.Windows.Forms.TextBox txtTax3percsentage;
        public System.Windows.Forms.TextBox txtTax1percsentage;
        public System.Windows.Forms.TextBox txtProdName;
        public System.Windows.Forms.TextBox txtNetAmt;
        public System.Windows.Forms.TextBox txtTax3Amt;
        public System.Windows.Forms.TextBox txtTax1Amt;
        public System.Windows.Forms.TextBox txtTax2Amt;
        public System.Windows.Forms.TextBox txtProdPrice;
        public System.Windows.Forms.TextBox txtProdDecs;
        public System.Windows.Forms.ComboBox cboProSubCate;
        public System.Windows.Forms.ComboBox cboProductType;
    }
}