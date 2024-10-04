namespace KikuzawaRestaurant.Forms
{
    partial class frmSettlement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettlement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblGetSymbol = new System.Windows.Forms.Label();
            this.lblUsedCurrency = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCash = new System.Windows.Forms.TabPage();
            this.btnCashout = new System.Windows.Forms.Button();
            this.cboSelectCurrency = new System.Windows.Forms.ComboBox();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.lblCurcsonvertFrom = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRateTimesAmtPaid = new System.Windows.Forms.TextBox();
            this.lblUsedCurr = new System.Windows.Forms.Label();
            this.lblcustCurrency = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblConverTo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReceiptNum = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPosPaid = new System.Windows.Forms.Button();
            this.txtPosPaid = new System.Windows.Forms.TextBox();
            this.posEelectronicType = new System.Windows.Forms.ComboBox();
            this.cboPOSCurrency = new System.Windows.Forms.ComboBox();
            this.txtAcctNum = new System.Windows.Forms.TextBox();
            this.txtAcctName = new System.Windows.Forms.TextBox();
            this.posCurChoice = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmtPAid = new System.Windows.Forms.TextBox();
            this.txtCustOwes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAmtToPay = new System.Windows.Forms.TextBox();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCash.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.lblGetSymbol);
            this.groupBox1.Controls.Add(this.lblUsedCurrency);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.txtAmtPAid);
            this.groupBox1.Controls.Add(this.txtCustOwes);
            this.groupBox1.Location = new System.Drawing.Point(338, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 447);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dateTimePicker1);
            this.groupBox5.Location = new System.Drawing.Point(7, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(149, 49);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Payment Date And Time";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // lblGetSymbol
            // 
            this.lblGetSymbol.AutoSize = true;
            this.lblGetSymbol.Location = new System.Drawing.Point(163, 45);
            this.lblGetSymbol.Name = "lblGetSymbol";
            this.lblGetSymbol.Size = new System.Drawing.Size(43, 13);
            this.lblGetSymbol.TabIndex = 2;
            this.lblGetSymbol.Text = "curPaid";
            // 
            // lblUsedCurrency
            // 
            this.lblUsedCurrency.AutoSize = true;
            this.lblUsedCurrency.Location = new System.Drawing.Point(163, 22);
            this.lblUsedCurrency.Name = "lblUsedCurrency";
            this.lblUsedCurrency.Size = new System.Drawing.Size(48, 13);
            this.lblUsedCurrency.TabIndex = 2;
            this.lblUsedCurrency.Text = "curInuse";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCash);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 84);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(302, 331);
            this.tabControl1.TabIndex = 1;
            // 
            // tabCash
            // 
            this.tabCash.Controls.Add(this.btnCashout);
            this.tabCash.Controls.Add(this.cboSelectCurrency);
            this.tabCash.Controls.Add(this.cboPaymentType);
            this.tabCash.Controls.Add(this.lblCurcsonvertFrom);
            this.tabCash.Controls.Add(this.label9);
            this.tabCash.Controls.Add(this.txtRateTimesAmtPaid);
            this.tabCash.Controls.Add(this.lblUsedCurr);
            this.tabCash.Controls.Add(this.lblcustCurrency);
            this.tabCash.Controls.Add(this.label11);
            this.tabCash.Controls.Add(this.lblConverTo);
            this.tabCash.Controls.Add(this.label7);
            this.tabCash.Controls.Add(this.label6);
            this.tabCash.Controls.Add(this.label5);
            this.tabCash.Controls.Add(this.label4);
            this.tabCash.Controls.Add(this.txtReceiptNum);
            this.tabCash.Location = new System.Drawing.Point(4, 22);
            this.tabCash.Name = "tabCash";
            this.tabCash.Padding = new System.Windows.Forms.Padding(3);
            this.tabCash.Size = new System.Drawing.Size(294, 305);
            this.tabCash.TabIndex = 0;
            this.tabCash.Text = "Cash";
            this.tabCash.UseVisualStyleBackColor = true;
            // 
            // btnCashout
            // 
            this.btnCashout.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashout.Image = global::KikuzawaRestaurant.Properties.Resources.payment_icon;
            this.btnCashout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashout.Location = new System.Drawing.Point(156, 247);
            this.btnCashout.Name = "btnCashout";
            this.btnCashout.Size = new System.Drawing.Size(120, 45);
            this.btnCashout.TabIndex = 3;
            this.btnCashout.Text = "Paid";
            this.btnCashout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCashout.UseVisualStyleBackColor = true;
            this.btnCashout.Click += new System.EventHandler(this.btnCashout_Click);
            // 
            // cboSelectCurrency
            // 
            this.cboSelectCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectCurrency.FormattingEnabled = true;
            this.cboSelectCurrency.Location = new System.Drawing.Point(156, 95);
            this.cboSelectCurrency.Name = "cboSelectCurrency";
            this.cboSelectCurrency.Size = new System.Drawing.Size(132, 21);
            this.cboSelectCurrency.TabIndex = 1;
            this.cboSelectCurrency.SelectedIndexChanged += new System.EventHandler(this.cboSelectCurrency_SelectedIndexChanged);
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(139, 6);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(149, 21);
            this.cboPaymentType.TabIndex = 1;
            // 
            // lblCurcsonvertFrom
            // 
            this.lblCurcsonvertFrom.AutoSize = true;
            this.lblCurcsonvertFrom.Location = new System.Drawing.Point(71, 153);
            this.lblCurcsonvertFrom.Name = "lblCurcsonvertFrom";
            this.lblCurcsonvertFrom.Size = new System.Drawing.Size(45, 13);
            this.lblCurcsonvertFrom.TabIndex = 2;
            this.lblCurcsonvertFrom.Text = "curFrom";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "1";
            // 
            // txtRateTimesAmtPaid
            // 
            this.txtRateTimesAmtPaid.Location = new System.Drawing.Point(152, 212);
            this.txtRateTimesAmtPaid.Name = "txtRateTimesAmtPaid";
            this.txtRateTimesAmtPaid.ReadOnly = true;
            this.txtRateTimesAmtPaid.Size = new System.Drawing.Size(136, 20);
            this.txtRateTimesAmtPaid.TabIndex = 0;
            // 
            // lblUsedCurr
            // 
            this.lblUsedCurr.AutoSize = true;
            this.lblUsedCurr.Location = new System.Drawing.Point(169, 153);
            this.lblUsedCurr.Name = "lblUsedCurr";
            this.lblUsedCurr.Size = new System.Drawing.Size(47, 13);
            this.lblUsedCurr.TabIndex = 2;
            this.lblUsedCurr.Text = "curUsed";
            // 
            // lblcustCurrency
            // 
            this.lblcustCurrency.AutoSize = true;
            this.lblcustCurrency.Location = new System.Drawing.Point(103, 215);
            this.lblcustCurrency.Name = "lblcustCurrency";
            this.lblcustCurrency.Size = new System.Drawing.Size(43, 13);
            this.lblcustCurrency.TabIndex = 2;
            this.lblcustCurrency.Text = "custCur";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 14);
            this.label11.TabIndex = 2;
            this.label11.Text = "Amount Paid";
            // 
            // lblConverTo
            // 
            this.lblConverTo.AutoSize = true;
            this.lblConverTo.Location = new System.Drawing.Point(136, 153);
            this.lblConverTo.Name = "lblConverTo";
            this.lblConverTo.Size = new System.Drawing.Size(35, 13);
            this.lblConverTo.TabIndex = 2;
            this.lblConverTo.Text = "curTo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "Select the Currency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Receipt Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Payment Type";
            // 
            // txtReceiptNum
            // 
            this.txtReceiptNum.Location = new System.Drawing.Point(156, 45);
            this.txtReceiptNum.Name = "txtReceiptNum";
            this.txtReceiptNum.ReadOnly = true;
            this.txtReceiptNum.Size = new System.Drawing.Size(132, 20);
            this.txtReceiptNum.TabIndex = 0;
            this.txtReceiptNum.TextChanged += new System.EventHandler(this.txtReceiptNum_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPosPaid);
            this.tabPage2.Controls.Add(this.txtPosPaid);
            this.tabPage2.Controls.Add(this.posEelectronicType);
            this.tabPage2.Controls.Add(this.cboPOSCurrency);
            this.tabPage2.Controls.Add(this.txtAcctNum);
            this.tabPage2.Controls.Add(this.txtAcctName);
            this.tabPage2.Controls.Add(this.posCurChoice);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Point Of Sale";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnPosPaid
            // 
            this.btnPosPaid.Enabled = false;
            this.btnPosPaid.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosPaid.Image = global::KikuzawaRestaurant.Properties.Resources.payment_icon;
            this.btnPosPaid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPosPaid.Location = new System.Drawing.Point(160, 247);
            this.btnPosPaid.Name = "btnPosPaid";
            this.btnPosPaid.Size = new System.Drawing.Size(127, 39);
            this.btnPosPaid.TabIndex = 9;
            this.btnPosPaid.Text = "Paid";
            this.btnPosPaid.UseVisualStyleBackColor = true;
            this.btnPosPaid.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPosPaid
            // 
            this.txtPosPaid.Location = new System.Drawing.Point(167, 159);
            this.txtPosPaid.MaxLength = 10;
            this.txtPosPaid.Name = "txtPosPaid";
            this.txtPosPaid.Size = new System.Drawing.Size(121, 20);
            this.txtPosPaid.TabIndex = 8;
            this.txtPosPaid.TextChanged += new System.EventHandler(this.txtPosPaid_TextChanged);
            this.txtPosPaid.Leave += new System.EventHandler(this.txtPosPaid_Leave);
            // 
            // posEelectronicType
            // 
            this.posEelectronicType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.posEelectronicType.FormattingEnabled = true;
            this.posEelectronicType.Location = new System.Drawing.Point(125, 85);
            this.posEelectronicType.Name = "posEelectronicType";
            this.posEelectronicType.Size = new System.Drawing.Size(163, 21);
            this.posEelectronicType.TabIndex = 2;
            // 
            // cboPOSCurrency
            // 
            this.cboPOSCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPOSCurrency.FormattingEnabled = true;
            this.cboPOSCurrency.Location = new System.Drawing.Point(125, 115);
            this.cboPOSCurrency.Name = "cboPOSCurrency";
            this.cboPOSCurrency.Size = new System.Drawing.Size(163, 21);
            this.cboPOSCurrency.TabIndex = 2;
            this.cboPOSCurrency.SelectedIndexChanged += new System.EventHandler(this.cboPOSCurrency_SelectedIndexChanged);
            // 
            // txtAcctNum
            // 
            this.txtAcctNum.Location = new System.Drawing.Point(125, 54);
            this.txtAcctNum.MaxLength = 13;
            this.txtAcctNum.Name = "txtAcctNum";
            this.txtAcctNum.Size = new System.Drawing.Size(163, 20);
            this.txtAcctNum.TabIndex = 1;
            this.txtAcctNum.TextChanged += new System.EventHandler(this.txtAcctNum_TextChanged);
            this.txtAcctNum.Leave += new System.EventHandler(this.txtAcctNum_Leave);
            // 
            // txtAcctName
            // 
            this.txtAcctName.Location = new System.Drawing.Point(125, 18);
            this.txtAcctName.MaxLength = 50;
            this.txtAcctName.Name = "txtAcctName";
            this.txtAcctName.Size = new System.Drawing.Size(163, 20);
            this.txtAcctName.TabIndex = 1;
            this.txtAcctName.TextChanged += new System.EventHandler(this.txtAcctName_TextChanged);
            this.txtAcctName.Leave += new System.EventHandler(this.txtAcctName_Leave);
            // 
            // posCurChoice
            // 
            this.posCurChoice.AutoSize = true;
            this.posCurChoice.Location = new System.Drawing.Point(106, 162);
            this.posCurChoice.Name = "posCurChoice";
            this.posCurChoice.Size = new System.Drawing.Size(55, 13);
            this.posCurChoice.TabIndex = 0;
            this.posCurChoice.Text = "curChoice";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 162);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Amount Paying";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Pay In Currency";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Electronic Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Account Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Name";
            // 
            // txtAmtPAid
            // 
            this.txtAmtPAid.Location = new System.Drawing.Point(212, 45);
            this.txtAmtPAid.MaxLength = 10;
            this.txtAmtPAid.Name = "txtAmtPAid";
            this.txtAmtPAid.Size = new System.Drawing.Size(122, 20);
            this.txtAmtPAid.TabIndex = 0;
            this.txtAmtPAid.TextChanged += new System.EventHandler(this.txtAmtPAid_TextChanged);
            this.txtAmtPAid.Leave += new System.EventHandler(this.txtAmtPAid_Leave);
            // 
            // txtCustOwes
            // 
            this.txtCustOwes.Location = new System.Drawing.Point(212, 19);
            this.txtCustOwes.Name = "txtCustOwes";
            this.txtCustOwes.ReadOnly = true;
            this.txtCustOwes.Size = new System.Drawing.Size(122, 20);
            this.txtCustOwes.TabIndex = 0;
            this.txtCustOwes.TextChanged += new System.EventHandler(this.txtCustOwes_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(2, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(683, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::KikuzawaRestaurant.Properties.Resources.cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(550, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(278, 27);
            this.label12.TabIndex = 2;
            this.label12.Text = "Receipt Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAmtToPay);
            this.groupBox3.Controls.Add(this.txtBill);
            this.groupBox3.Controls.Add(this.txtReceiptNo);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(10, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 130);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // txtAmtToPay
            // 
            this.txtAmtToPay.Location = new System.Drawing.Point(176, 94);
            this.txtAmtToPay.Name = "txtAmtToPay";
            this.txtAmtToPay.ReadOnly = true;
            this.txtAmtToPay.Size = new System.Drawing.Size(145, 20);
            this.txtAmtToPay.TabIndex = 1;
            // 
            // txtBill
            // 
            this.txtBill.Location = new System.Drawing.Point(176, 56);
            this.txtBill.Name = "txtBill";
            this.txtBill.ReadOnly = true;
            this.txtBill.Size = new System.Drawing.Size(145, 20);
            this.txtBill.TabIndex = 1;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(176, 25);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(145, 20);
            this.txtReceiptNo.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 14);
            this.label16.TabIndex = 0;
            this.label16.Text = "Amount Paying";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(130, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "curPay";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Receipt #:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "Bill Amount";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnView);
            this.groupBox4.Controls.Add(this.btnVoid);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(2, 222);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 229);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cancel Transaction";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::KikuzawaRestaurant.Properties.Resources.Start_Menu_Search;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(6, 165);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(96, 48);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnView, "Helps to view the transaction");
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoid.Image = global::KikuzawaRestaurant.Properties.Resources.delete_file;
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(212, 165);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(96, 48);
            this.btnVoid.TabIndex = 6;
            this.btnVoid.Text = "Void";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnVoid, "Helps to void the initial payment type\r\nand set a new one");
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(302, 138);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // frmSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 507);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSettlement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ORDER SETTLEMENT - Kikuzawa RESTAURANT";
            this.Load += new System.EventHandler(this.frmSettlement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCash.ResumeLayout(false);
            this.tabCash.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAmtPAid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCash;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblGetSymbol;
        private System.Windows.Forms.Label lblUsedCurrency;
        private System.Windows.Forms.ComboBox cboSelectCurrency;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label lblCurcsonvertFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRateTimesAmtPaid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblConverTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtAmtToPay;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblUsedCurr;
        private System.Windows.Forms.Button btnPosPaid;
        private System.Windows.Forms.TextBox txtPosPaid;
        private System.Windows.Forms.ComboBox posEelectronicType;
        private System.Windows.Forms.ComboBox cboPOSCurrency;
        private System.Windows.Forms.TextBox txtAcctNum;
        private System.Windows.Forms.TextBox txtAcctName;
        private System.Windows.Forms.Label posCurChoice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblcustCurrency;
        public System.Windows.Forms.TextBox txtCustOwes;
        public System.Windows.Forms.TextBox txtReceiptNum;
        private System.Windows.Forms.Button btnCashout;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}