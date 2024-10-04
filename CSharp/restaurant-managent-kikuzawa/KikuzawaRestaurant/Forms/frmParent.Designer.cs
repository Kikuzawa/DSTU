namespace KikuzawaRestaurant
{
    partial class frmParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParent));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statGetUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statGetDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNocharge = new System.Windows.Forms.Button();
            this.btnTakeAway = new System.Windows.Forms.Button();
            this.btnDineIn = new System.Windows.Forms.Button();
            this.btnRecall = new System.Windows.Forms.Button();
            this.btnVorder = new System.Windows.Forms.Button();
            this.btnVUsers = new System.Windows.Forms.Button();
            this.btnVtaxes = new System.Windows.Forms.Button();
            this.btnVProdTypes = new System.Windows.Forms.Button();
            this.btnVProducts = new System.Windows.Forms.Button();
            this.btnVLogins = new System.Windows.Forms.Button();
            this.btnVsalesRports = new System.Windows.Forms.Button();
            this.btnVEmployee = new System.Windows.Forms.Button();
            this.btnAddPOSCurrency = new System.Windows.Forms.Button();
            this.btnVPOS = new System.Windows.Forms.Button();
            this.btnVCurrency = new System.Windows.Forms.Button();
            this.btnAddMenus = new System.Windows.Forms.Button();
            this.btnAddMenuGroup = new System.Windows.Forms.Button();
            this.btnCuurency = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnRegEmployee = new System.Windows.Forms.Button();
            this.btnAddUsers = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnBakup = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statGetUser,
            this.toolStripStatusLabel2,
            this.statGetDate,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel7});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Username";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statGetUser
            // 
            this.statGetUser.ForeColor = System.Drawing.Color.White;
            this.statGetUser.Name = "statGetUser";
            this.statGetUser.Size = new System.Drawing.Size(86, 17);
            this.statGetUser.Text = "getUsername";
            this.statGetUser.Click += new System.EventHandler(this.statGetUser_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel2.Text = "Date";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // statGetDate
            // 
            this.statGetDate.ForeColor = System.Drawing.Color.White;
            this.statGetDate.Name = "statGetDate";
            this.statGetDate.Size = new System.Drawing.Size(54, 17);
            this.statGetDate.Text = "getDate";
            this.statGetDate.Click += new System.EventHandler(this.statGetDate_Click);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel6.Text = "Outlet";
            this.toolStripStatusLabel6.Click += new System.EventHandler(this.toolStripStatusLabel6_Click);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel4.Text = "Created";
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.IsLink = true;
            this.toolStripStatusLabel5.LinkColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(123, 17);
            this.toolStripStatusLabel5.Text = "Developer\'s contact";
            this.toolStripStatusLabel5.Click += new System.EventHandler(this.toolStripStatusLabel5_Click);
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel7.Text = "Restaurant Kikuzawa";
            this.toolStripStatusLabel7.Click += new System.EventHandler(this.toolStripStatusLabel7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnNocharge);
            this.groupBox1.Controls.Add(this.btnTakeAway);
            this.groupBox1.Controls.Add(this.btnDineIn);
            this.groupBox1.Controls.Add(this.btnRecall);
            this.groupBox1.Location = new System.Drawing.Point(24, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 382);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Receipt";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnNocharge
            // 
            this.btnNocharge.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNocharge.Image = global::KikuzawaRestaurant.Properties.Resources.Fruits_Strawberries_icon2;
            this.btnNocharge.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNocharge.Location = new System.Drawing.Point(12, 213);
            this.btnNocharge.Name = "btnNocharge";
            this.btnNocharge.Size = new System.Drawing.Size(132, 77);
            this.btnNocharge.TabIndex = 0;
            this.btnNocharge.Text = "No Charge";
            this.btnNocharge.UseVisualStyleBackColor = true;
            this.btnNocharge.Click += new System.EventHandler(this.btnNocharge_Click);
            // 
            // btnTakeAway
            // 
            this.btnTakeAway.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeAway.Image = global::KikuzawaRestaurant.Properties.Resources.gift_icon;
            this.btnTakeAway.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTakeAway.Location = new System.Drawing.Point(12, 130);
            this.btnTakeAway.Name = "btnTakeAway";
            this.btnTakeAway.Size = new System.Drawing.Size(132, 77);
            this.btnTakeAway.TabIndex = 0;
            this.btnTakeAway.Text = "Take Away";
            this.btnTakeAway.UseVisualStyleBackColor = true;
            this.btnTakeAway.Click += new System.EventHandler(this.btnTakeAway_Click);
            // 
            // btnDineIn
            // 
            this.btnDineIn.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDineIn.Image = global::KikuzawaRestaurant.Properties.Resources.Coffee_icon2;
            this.btnDineIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDineIn.Location = new System.Drawing.Point(12, 47);
            this.btnDineIn.Name = "btnDineIn";
            this.btnDineIn.Size = new System.Drawing.Size(132, 77);
            this.btnDineIn.TabIndex = 0;
            this.btnDineIn.Text = "Dine In";
            this.btnDineIn.UseVisualStyleBackColor = true;
            this.btnDineIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecall
            // 
            this.btnRecall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRecall.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecall.Image = global::KikuzawaRestaurant.Properties.Resources.payment_icon1;
            this.btnRecall.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecall.Location = new System.Drawing.Point(12, 296);
            this.btnRecall.Name = "btnRecall";
            this.btnRecall.Size = new System.Drawing.Size(132, 77);
            this.btnRecall.TabIndex = 0;
            this.btnRecall.Text = "Settlement";
            this.btnRecall.UseVisualStyleBackColor = false;
            this.btnRecall.Click += new System.EventHandler(this.btnRecall_Click);
            // 
            // btnVorder
            // 
            this.btnVorder.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVorder.Location = new System.Drawing.Point(138, 130);
            this.btnVorder.Name = "btnVorder";
            this.btnVorder.Size = new System.Drawing.Size(126, 77);
            this.btnVorder.TabIndex = 3;
            this.btnVorder.Text = "View Order Info.";
            this.btnVorder.UseVisualStyleBackColor = true;
            this.btnVorder.Click += new System.EventHandler(this.btnVorder_Click);
            // 
            // btnVUsers
            // 
            this.btnVUsers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVUsers.Location = new System.Drawing.Point(270, 47);
            this.btnVUsers.Name = "btnVUsers";
            this.btnVUsers.Size = new System.Drawing.Size(126, 77);
            this.btnVUsers.TabIndex = 3;
            this.btnVUsers.Text = "View Users";
            this.btnVUsers.UseVisualStyleBackColor = true;
            this.btnVUsers.Click += new System.EventHandler(this.btnVUsers_Click);
            // 
            // btnVtaxes
            // 
            this.btnVtaxes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVtaxes.Location = new System.Drawing.Point(6, 47);
            this.btnVtaxes.Name = "btnVtaxes";
            this.btnVtaxes.Size = new System.Drawing.Size(126, 77);
            this.btnVtaxes.TabIndex = 3;
            this.btnVtaxes.Text = "View Taxes";
            this.btnVtaxes.UseVisualStyleBackColor = true;
            this.btnVtaxes.Click += new System.EventHandler(this.btnVtaxes_Click);
            // 
            // btnVProdTypes
            // 
            this.btnVProdTypes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVProdTypes.Location = new System.Drawing.Point(270, 213);
            this.btnVProdTypes.Name = "btnVProdTypes";
            this.btnVProdTypes.Size = new System.Drawing.Size(126, 77);
            this.btnVProdTypes.TabIndex = 3;
            this.btnVProdTypes.Text = "View Menu Group";
            this.btnVProdTypes.UseVisualStyleBackColor = true;
            this.btnVProdTypes.Click += new System.EventHandler(this.btnVProdTypes_Click);
            // 
            // btnVProducts
            // 
            this.btnVProducts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVProducts.Location = new System.Drawing.Point(138, 213);
            this.btnVProducts.Name = "btnVProducts";
            this.btnVProducts.Size = new System.Drawing.Size(126, 77);
            this.btnVProducts.TabIndex = 3;
            this.btnVProducts.Text = "View Menus";
            this.btnVProducts.UseVisualStyleBackColor = true;
            this.btnVProducts.Click += new System.EventHandler(this.btnVProducts_Click);
            // 
            // btnVLogins
            // 
            this.btnVLogins.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVLogins.Location = new System.Drawing.Point(139, 130);
            this.btnVLogins.Name = "btnVLogins";
            this.btnVLogins.Size = new System.Drawing.Size(126, 77);
            this.btnVLogins.TabIndex = 3;
            this.btnVLogins.Text = "View Logins";
            this.btnVLogins.UseVisualStyleBackColor = true;
            this.btnVLogins.Click += new System.EventHandler(this.btnVLogins_Click);
            // 
            // btnVsalesRports
            // 
            this.btnVsalesRports.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVsalesRports.Location = new System.Drawing.Point(270, 130);
            this.btnVsalesRports.Name = "btnVsalesRports";
            this.btnVsalesRports.Size = new System.Drawing.Size(126, 77);
            this.btnVsalesRports.TabIndex = 3;
            this.btnVsalesRports.Text = "Sales Report";
            this.btnVsalesRports.UseVisualStyleBackColor = true;
            this.btnVsalesRports.Click += new System.EventHandler(this.btnVsalesRports_Click);
            // 
            // btnVEmployee
            // 
            this.btnVEmployee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVEmployee.Image = global::KikuzawaRestaurant.Properties.Resources.Groups_Meeting_Dark_icon;
            this.btnVEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVEmployee.Location = new System.Drawing.Point(7, 130);
            this.btnVEmployee.Name = "btnVEmployee";
            this.btnVEmployee.Size = new System.Drawing.Size(126, 77);
            this.btnVEmployee.TabIndex = 2;
            this.btnVEmployee.Text = "View Employee";
            this.btnVEmployee.UseVisualStyleBackColor = true;
            this.btnVEmployee.Click += new System.EventHandler(this.btnVEmployee_Click);
            // 
            // btnAddPOSCurrency
            // 
            this.btnAddPOSCurrency.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPOSCurrency.Location = new System.Drawing.Point(138, 213);
            this.btnAddPOSCurrency.Name = "btnAddPOSCurrency";
            this.btnAddPOSCurrency.Size = new System.Drawing.Size(126, 77);
            this.btnAddPOSCurrency.TabIndex = 2;
            this.btnAddPOSCurrency.Text = "Create POS Currency";
            this.btnAddPOSCurrency.UseVisualStyleBackColor = true;
            this.btnAddPOSCurrency.Click += new System.EventHandler(this.btnAddPOSCurrency_Click);
            // 
            // btnVPOS
            // 
            this.btnVPOS.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVPOS.Location = new System.Drawing.Point(6, 130);
            this.btnVPOS.Name = "btnVPOS";
            this.btnVPOS.Size = new System.Drawing.Size(126, 77);
            this.btnVPOS.TabIndex = 2;
            this.btnVPOS.Text = "View POS ";
            this.btnVPOS.UseVisualStyleBackColor = true;
            this.btnVPOS.Click += new System.EventHandler(this.btnVPOS_Click);
            // 
            // btnVCurrency
            // 
            this.btnVCurrency.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVCurrency.Location = new System.Drawing.Point(6, 213);
            this.btnVCurrency.Name = "btnVCurrency";
            this.btnVCurrency.Size = new System.Drawing.Size(126, 77);
            this.btnVCurrency.TabIndex = 2;
            this.btnVCurrency.Text = "View Currency";
            this.btnVCurrency.UseVisualStyleBackColor = true;
            this.btnVCurrency.Click += new System.EventHandler(this.btnVCurrency_Click);
            // 
            // btnAddMenus
            // 
            this.btnAddMenus.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMenus.Image = global::KikuzawaRestaurant.Properties.Resources.contacts_icon;
            this.btnAddMenus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddMenus.Location = new System.Drawing.Point(7, 296);
            this.btnAddMenus.Name = "btnAddMenus";
            this.btnAddMenus.Size = new System.Drawing.Size(126, 77);
            this.btnAddMenus.TabIndex = 2;
            this.btnAddMenus.Text = "Add Menu";
            this.btnAddMenus.UseVisualStyleBackColor = true;
            this.btnAddMenus.Click += new System.EventHandler(this.btnAddMenus_Click);
            // 
            // btnAddMenuGroup
            // 
            this.btnAddMenuGroup.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMenuGroup.Location = new System.Drawing.Point(139, 296);
            this.btnAddMenuGroup.Name = "btnAddMenuGroup";
            this.btnAddMenuGroup.Size = new System.Drawing.Size(126, 77);
            this.btnAddMenuGroup.TabIndex = 2;
            this.btnAddMenuGroup.Text = "Add Menu Group";
            this.btnAddMenuGroup.UseVisualStyleBackColor = true;
            this.btnAddMenuGroup.Click += new System.EventHandler(this.btnAddMenuGroup_Click);
            // 
            // btnCuurency
            // 
            this.btnCuurency.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuurency.Image = global::KikuzawaRestaurant.Properties.Resources.conversion_of_currency_icon;
            this.btnCuurency.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCuurency.Location = new System.Drawing.Point(6, 213);
            this.btnCuurency.Name = "btnCuurency";
            this.btnCuurency.Size = new System.Drawing.Size(126, 77);
            this.btnCuurency.TabIndex = 0;
            this.btnCuurency.Text = "Add Currency";
            this.btnCuurency.UseVisualStyleBackColor = true;
            this.btnCuurency.Click += new System.EventHandler(this.btnCuurency_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.Image = global::KikuzawaRestaurant.Properties.Resources.Security_icon;
            this.btnChangePass.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChangePass.Location = new System.Drawing.Point(7, 379);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(126, 77);
            this.btnChangePass.TabIndex = 0;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnRegEmployee
            // 
            this.btnRegEmployee.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegEmployee.Image = global::KikuzawaRestaurant.Properties.Resources.Office_Customer_Male_Light_icon;
            this.btnRegEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegEmployee.Location = new System.Drawing.Point(7, 47);
            this.btnRegEmployee.Name = "btnRegEmployee";
            this.btnRegEmployee.Size = new System.Drawing.Size(126, 77);
            this.btnRegEmployee.TabIndex = 0;
            this.btnRegEmployee.Text = "Employee Registration";
            this.btnRegEmployee.UseVisualStyleBackColor = true;
            this.btnRegEmployee.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUsers.Image = global::KikuzawaRestaurant.Properties.Resources.Usergroup;
            this.btnAddUsers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddUsers.Location = new System.Drawing.Point(139, 47);
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.Size = new System.Drawing.Size(126, 77);
            this.btnAddUsers.TabIndex = 0;
            this.btnAddUsers.Text = "Add Users";
            this.btnAddUsers.UseVisualStyleBackColor = true;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(6, 296);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(126, 77);
            this.button10.TabIndex = 4;
            this.button10.Text = "View Settlement";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(138, 296);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 77);
            this.button8.TabIndex = 4;
            this.button8.Text = "View Freeze Items";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::KikuzawaRestaurant.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(692, 527);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 77);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(138, 47);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(126, 77);
            this.button11.TabIndex = 0;
            this.button11.Text = "View Tax Sales";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(270, 296);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(126, 77);
            this.button9.TabIndex = 0;
            this.button9.Text = "View Net Sale";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnBakup
            // 
            this.btnBakup.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBakup.Image = global::KikuzawaRestaurant.Properties.Resources.data_management_icon__2_;
            this.btnBakup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBakup.Location = new System.Drawing.Point(138, 379);
            this.btnBakup.Name = "btnBakup";
            this.btnBakup.Size = new System.Drawing.Size(126, 77);
            this.btnBakup.TabIndex = 0;
            this.btnBakup.Text = "Database Backup";
            this.btnBakup.UseVisualStyleBackColor = true;
            this.btnBakup.Click += new System.EventHandler(this.btnBakup_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(264, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Restaurant Kikuzawa";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnVsalesRports);
            this.groupBox4.Controls.Add(this.btnVUsers);
            this.groupBox4.Controls.Add(this.btnVorder);
            this.groupBox4.Controls.Add(this.btnVtaxes);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.btnVProdTypes);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.btnVProducts);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.btnVCurrency);
            this.groupBox4.Controls.Add(this.btnVPOS);
            this.groupBox4.Location = new System.Drawing.Point(199, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(403, 382);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(118, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Information";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnAddMenuGroup);
            this.groupBox3.Controls.Add(this.btnChangePass);
            this.groupBox3.Controls.Add(this.btnBakup);
            this.groupBox3.Controls.Add(this.btnAddMenus);
            this.groupBox3.Controls.Add(this.btnAddPOSCurrency);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnRegEmployee);
            this.groupBox3.Controls.Add(this.btnAddUsers);
            this.groupBox3.Controls.Add(this.btnVEmployee);
            this.groupBox3.Controls.Add(this.btnCuurency);
            this.groupBox3.Controls.Add(this.btnVLogins);
            this.groupBox3.Location = new System.Drawing.Point(624, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 464);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Other settings";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBox1.Location = new System.Drawing.Point(36, 455);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(566, 149);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::KikuzawaRestaurant.Properties.Resources.a1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(931, 641);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmParent";
            this.Load += new System.EventHandler(this.frmParent_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel statGetUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statGetDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNocharge;
        private System.Windows.Forms.Button btnTakeAway;
        private System.Windows.Forms.Button btnDineIn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnRecall;
        public System.Windows.Forms.Button btnCuurency;
        public System.Windows.Forms.Button btnChangePass;
        public System.Windows.Forms.Button btnRegEmployee;
        public System.Windows.Forms.Button btnAddUsers;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button button11;
        public System.Windows.Forms.Button button9;
        public System.Windows.Forms.Button btnBakup;
        public System.Windows.Forms.Button btnVEmployee;
        public System.Windows.Forms.Button btnAddPOSCurrency;
        public System.Windows.Forms.Button btnVPOS;
        public System.Windows.Forms.Button btnVCurrency;
        public System.Windows.Forms.Button btnAddMenus;
        public System.Windows.Forms.Button btnAddMenuGroup;
        public System.Windows.Forms.Button btnVorder;
        public System.Windows.Forms.Button btnVUsers;
        public System.Windows.Forms.Button btnVtaxes;
        public System.Windows.Forms.Button btnVProdTypes;
        public System.Windows.Forms.Button btnVProducts;
        public System.Windows.Forms.Button btnVsalesRports;
        public System.Windows.Forms.Button btnVLogins;
        public System.Windows.Forms.Button button10;
        public System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}