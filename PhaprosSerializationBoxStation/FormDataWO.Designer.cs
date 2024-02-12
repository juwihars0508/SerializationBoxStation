
namespace PhaprosSerializationBoxStation
{
    partial class FormDataWO
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbwoNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.SelectData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvWorkOrder = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddWo = new System.Windows.Forms.Button();
            this.btnSaveWo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_MainMenu = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PhaprosSerializationBoxStation.Properties.Resources.logoProline;
            this.pictureBox1.Location = new System.Drawing.Point(12, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(154, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 24);
            this.panel2.TabIndex = 33;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(596, 4);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 15);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "TIME";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(456, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(91, 15);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "LINA MAWARDI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(24, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "CREATE WORK ORDER";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.tbwoNo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbProductCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbQty);
            this.panel1.Location = new System.Drawing.Point(12, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 178);
            this.panel1.TabIndex = 35;
            // 
            // tbwoNo
            // 
            this.tbwoNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbwoNo.Enabled = false;
            this.tbwoNo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbwoNo.Location = new System.Drawing.Point(151, 19);
            this.tbwoNo.Name = "tbwoNo";
            this.tbwoNo.Size = new System.Drawing.Size(137, 26);
            this.tbwoNo.TabIndex = 14;
            this.tbwoNo.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Batch";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(122, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = ":";
            this.label9.Visible = false;
            // 
            // tbProductCode
            // 
            this.tbProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProductCode.Enabled = false;
            this.tbProductCode.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductCode.Location = new System.Drawing.Point(151, 95);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.Size = new System.Drawing.Size(137, 26);
            this.tbProductCode.TabIndex = 10;
            this.tbProductCode.Text = "-";
            this.tbProductCode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Product Code";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = ":";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Wo No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Qty Items";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(122, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = ":";
            this.label6.Visible = false;
            // 
            // tbQty
            // 
            this.tbQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQty.Enabled = false;
            this.tbQty.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQty.Location = new System.Drawing.Point(151, 136);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(137, 26);
            this.tbQty.TabIndex = 7;
            this.tbQty.Text = "1";
            this.tbQty.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 129);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(142, 18);
            this.label26.TabIndex = 36;
            this.label26.Text = "Create Work Order";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectData});
            this.dgvProduct.Location = new System.Drawing.Point(378, 150);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(504, 150);
            this.dgvProduct.TabIndex = 37;
            this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick_1);
            // 
            // SelectData
            // 
            this.SelectData.FalseValue = "false";
            this.SelectData.HeaderText = "Choice Data";
            this.SelectData.Name = "SelectData";
            this.SelectData.ReadOnly = true;
            this.SelectData.TrueValue = "true";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(381, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 18);
            this.label10.TabIndex = 38;
            this.label10.Text = "Select Product";
            // 
            // dgvWorkOrder
            // 
            this.dgvWorkOrder.AllowUserToAddRows = false;
            this.dgvWorkOrder.AllowUserToDeleteRows = false;
            this.dgvWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrder.Location = new System.Drawing.Point(379, 325);
            this.dgvWorkOrder.Name = "dgvWorkOrder";
            this.dgvWorkOrder.ReadOnly = true;
            this.dgvWorkOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkOrder.Size = new System.Drawing.Size(503, 133);
            this.dgvWorkOrder.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(382, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 18);
            this.label11.TabIndex = 40;
            this.label11.Text = "Data Work Order";
            // 
            // btnAddWo
            // 
            this.btnAddWo.BackColor = System.Drawing.Color.Lime;
            this.btnAddWo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddWo.FlatAppearance.BorderSize = 0;
            this.btnAddWo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWo.Location = new System.Drawing.Point(12, 338);
            this.btnAddWo.Name = "btnAddWo";
            this.btnAddWo.Size = new System.Drawing.Size(75, 23);
            this.btnAddWo.TabIndex = 41;
            this.btnAddWo.Text = "Add";
            this.btnAddWo.UseVisualStyleBackColor = false;
            this.btnAddWo.Click += new System.EventHandler(this.btnAddWo_Click);
            // 
            // btnSaveWo
            // 
            this.btnSaveWo.BackColor = System.Drawing.Color.Lime;
            this.btnSaveWo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveWo.FlatAppearance.BorderSize = 0;
            this.btnSaveWo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveWo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveWo.Location = new System.Drawing.Point(108, 338);
            this.btnSaveWo.Name = "btnSaveWo";
            this.btnSaveWo.Size = new System.Drawing.Size(75, 23);
            this.btnSaveWo.TabIndex = 42;
            this.btnSaveWo.Text = "Save";
            this.btnSaveWo.UseVisualStyleBackColor = false;
            this.btnSaveWo.Click += new System.EventHandler(this.btnSaveWo_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_MainMenu
            // 
            this.btn_MainMenu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_MainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MainMenu.FlatAppearance.BorderSize = 0;
            this.btn_MainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MainMenu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MainMenu.Location = new System.Drawing.Point(794, 550);
            this.btn_MainMenu.Name = "btn_MainMenu";
            this.btn_MainMenu.Size = new System.Drawing.Size(88, 38);
            this.btn_MainMenu.TabIndex = 43;
            this.btn_MainMenu.Text = "Main Menu";
            this.btn_MainMenu.UseVisualStyleBackColor = false;
            this.btn_MainMenu.Click += new System.EventHandler(this.btn_MainMenu_Click);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::PhaprosSerializationBoxStation.Properties.Resources.minimize_button_icon;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Location = new System.Drawing.Point(841, 31);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(41, 23);
            this.btnMin.TabIndex = 44;
            this.btnMin.Text = "-";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Visible = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // FormDataWO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PhaprosSerializationBoxStation.Properties.Resources.BC_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btn_MainMenu);
            this.Controls.Add(this.btnSaveWo);
            this.Controls.Add(this.btnAddWo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvWorkOrder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataWO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.Resize += new System.EventHandler(this.Form5_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbwoNo;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvWorkOrder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddWo;
        private System.Windows.Forms.Button btnSaveWo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectData;
        private System.Windows.Forms.Button btn_MainMenu;
        private System.Windows.Forms.Button btnMin;
    }
}