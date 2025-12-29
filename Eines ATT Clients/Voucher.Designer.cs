namespace Eines_ATT_Clients
{
    partial class Voucher
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TITLETiquet = new System.Windows.Forms.Label();
            this.VOUCHER_Date = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StartTimeVC = new System.Windows.Forms.Timer(this.components);
            this.CercarBtn = new System.Windows.Forms.Button();
            this.VoucherSerchedTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExistServerPosLbl = new System.Windows.Forms.Label();
            this.ExistServerPosTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Voucher_Table = new System.Windows.Forms.DataGridView();
            this.EXPIRATIONLbl = new System.Windows.Forms.Label();
            this.ExpirationTxt = new System.Windows.Forms.TextBox();
            this.StateVoucherLbl = new System.Windows.Forms.Label();
            this.StateVoucherTxt = new System.Windows.Forms.TextBox();
            this.VoucherAmountLbl = new System.Windows.Forms.Label();
            this.VoucherAmountTxt = new System.Windows.Forms.TextBox();
            this.ClientLbl = new System.Windows.Forms.Label();
            this.ClientTxt = new System.Windows.Forms.TextBox();
            this.PrintLbl = new System.Windows.Forms.Label();
            this.PrintTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TiquetPreviewTxt = new System.Windows.Forms.RichTextBox();
            this.VOUCHER_Dates = new System.Windows.Forms.DateTimePicker();
            this.ERROR = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Voucher_Table)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TITLETiquet
            // 
            this.TITLETiquet.AutoSize = true;
            this.TITLETiquet.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TITLETiquet.Location = new System.Drawing.Point(9, 10);
            this.TITLETiquet.Name = "TITLETiquet";
            this.TITLETiquet.Size = new System.Drawing.Size(207, 32);
            this.TITLETiquet.TabIndex = 3;
            this.TITLETiquet.Text = "CERCAR CUPÓ";
            // 
            // VOUCHER_Date
            // 
            this.VOUCHER_Date.AutoSize = true;
            this.VOUCHER_Date.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VOUCHER_Date.Location = new System.Drawing.Point(317, 65);
            this.VOUCHER_Date.Name = "VOUCHER_Date";
            this.VOUCHER_Date.Size = new System.Drawing.Size(114, 19);
            this.VOUCHER_Date.TabIndex = 5;
            this.VOUCHER_Date.Text = "DATA DEL CUPÓ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::Eines_ATT_Clients.Properties.Resources.icons8_delete_16px;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(911, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 28);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartTimeVC
            // 
            this.StartTimeVC.Tick += new System.EventHandler(this.StartTimeVC_Tick);
            // 
            // CercarBtn
            // 
            this.CercarBtn.FlatAppearance.BorderSize = 0;
            this.CercarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CercarBtn.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_google_web_search_50px;
            this.CercarBtn.Location = new System.Drawing.Point(473, 60);
            this.CercarBtn.Name = "CercarBtn";
            this.CercarBtn.Size = new System.Drawing.Size(55, 55);
            this.CercarBtn.TabIndex = 12;
            this.CercarBtn.UseVisualStyleBackColor = true;
            this.CercarBtn.Click += new System.EventHandler(this.CercarBtn_Click);
            // 
            // VoucherSerchedTxt
            // 
            this.VoucherSerchedTxt.Location = new System.Drawing.Point(15, 89);
            this.VoucherSerchedTxt.MaxLength = 12;
            this.VoucherSerchedTxt.Name = "VoucherSerchedTxt";
            this.VoucherSerchedTxt.Size = new System.Drawing.Size(300, 27);
            this.VoucherSerchedTxt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "NÚMERO DE CUPÓ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ExistServerPosLbl);
            this.groupBox1.Controls.Add(this.ExistServerPosTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Voucher_Table);
            this.groupBox1.Controls.Add(this.EXPIRATIONLbl);
            this.groupBox1.Controls.Add(this.ExpirationTxt);
            this.groupBox1.Controls.Add(this.StateVoucherLbl);
            this.groupBox1.Controls.Add(this.StateVoucherTxt);
            this.groupBox1.Controls.Add(this.VoucherAmountLbl);
            this.groupBox1.Controls.Add(this.VoucherAmountTxt);
            this.groupBox1.Controls.Add(this.ClientLbl);
            this.groupBox1.Controls.Add(this.ClientTxt);
            this.groupBox1.Controls.Add(this.PrintLbl);
            this.groupBox1.Controls.Add(this.PrintTxt);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(321, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 475);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACIÓ DEL CUPÓ";
            // 
            // ExistServerPosLbl
            // 
            this.ExistServerPosLbl.AutoSize = true;
            this.ExistServerPosLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExistServerPosLbl.Location = new System.Drawing.Point(6, 380);
            this.ExistServerPosLbl.Name = "ExistServerPosLbl";
            this.ExistServerPosLbl.Size = new System.Drawing.Size(154, 19);
            this.ExistServerPosLbl.TabIndex = 21;
            this.ExistServerPosLbl.Text = "EXISTENT AL SERVIDOR";
            // 
            // ExistServerPosTxt
            // 
            this.ExistServerPosTxt.Location = new System.Drawing.Point(6, 402);
            this.ExistServerPosTxt.Name = "ExistServerPosTxt";
            this.ExistServerPosTxt.ReadOnly = true;
            this.ExistServerPosTxt.Size = new System.Drawing.Size(284, 27);
            this.ExistServerPosTxt.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "TIQUETS AMB RELACIÓ DEL CUPÓ";
            // 
            // Voucher_Table
            // 
            this.Voucher_Table.AllowUserToAddRows = false;
            this.Voucher_Table.AllowUserToDeleteRows = false;
            this.Voucher_Table.AllowUserToResizeColumns = false;
            this.Voucher_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Voucher_Table.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Voucher_Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Voucher_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Voucher_Table.DefaultCellStyle = dataGridViewCellStyle2;
            this.Voucher_Table.Location = new System.Drawing.Point(296, 67);
            this.Voucher_Table.Name = "Voucher_Table";
            this.Voucher_Table.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Voucher_Table.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Voucher_Table.RowHeadersVisible = false;
            this.Voucher_Table.Size = new System.Drawing.Size(303, 402);
            this.Voucher_Table.TabIndex = 18;
            this.Voucher_Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GetTicket);
            // 
            // EXPIRATIONLbl
            // 
            this.EXPIRATIONLbl.AutoSize = true;
            this.EXPIRATIONLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXPIRATIONLbl.Location = new System.Drawing.Point(6, 313);
            this.EXPIRATIONLbl.Name = "EXPIRATIONLbl";
            this.EXPIRATIONLbl.Size = new System.Drawing.Size(153, 19);
            this.EXPIRATIONLbl.TabIndex = 17;
            this.EXPIRATIONLbl.Text = "CADUCITAT DEL CUPÓ";
            // 
            // ExpirationTxt
            // 
            this.ExpirationTxt.Location = new System.Drawing.Point(6, 335);
            this.ExpirationTxt.Name = "ExpirationTxt";
            this.ExpirationTxt.ReadOnly = true;
            this.ExpirationTxt.Size = new System.Drawing.Size(284, 27);
            this.ExpirationTxt.TabIndex = 0;
            // 
            // StateVoucherLbl
            // 
            this.StateVoucherLbl.AutoSize = true;
            this.StateVoucherLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateVoucherLbl.Location = new System.Drawing.Point(6, 246);
            this.StateVoucherLbl.Name = "StateVoucherLbl";
            this.StateVoucherLbl.Size = new System.Drawing.Size(115, 19);
            this.StateVoucherLbl.TabIndex = 17;
            this.StateVoucherLbl.Text = "ESTAT DEL CUPÓ";
            // 
            // StateVoucherTxt
            // 
            this.StateVoucherTxt.ForeColor = System.Drawing.Color.Red;
            this.StateVoucherTxt.Location = new System.Drawing.Point(6, 268);
            this.StateVoucherTxt.Name = "StateVoucherTxt";
            this.StateVoucherTxt.ReadOnly = true;
            this.StateVoucherTxt.Size = new System.Drawing.Size(284, 27);
            this.StateVoucherTxt.TabIndex = 0;
            // 
            // VoucherAmountLbl
            // 
            this.VoucherAmountLbl.AutoSize = true;
            this.VoucherAmountLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoucherAmountLbl.Location = new System.Drawing.Point(6, 179);
            this.VoucherAmountLbl.Name = "VoucherAmountLbl";
            this.VoucherAmountLbl.Size = new System.Drawing.Size(126, 19);
            this.VoucherAmountLbl.TabIndex = 17;
            this.VoucherAmountLbl.Text = "VALOR DEL CUPÓ";
            // 
            // VoucherAmountTxt
            // 
            this.VoucherAmountTxt.Location = new System.Drawing.Point(6, 201);
            this.VoucherAmountTxt.Name = "VoucherAmountTxt";
            this.VoucherAmountTxt.ReadOnly = true;
            this.VoucherAmountTxt.Size = new System.Drawing.Size(284, 27);
            this.VoucherAmountTxt.TabIndex = 0;
            // 
            // ClientLbl
            // 
            this.ClientLbl.AutoSize = true;
            this.ClientLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientLbl.Location = new System.Drawing.Point(6, 112);
            this.ClientLbl.Name = "ClientLbl";
            this.ClientLbl.Size = new System.Drawing.Size(244, 19);
            this.ClientLbl.TabIndex = 17;
            this.ClientLbl.Text = "CLIENT QUE VA COMPRAR EL CUPÓ";
            // 
            // ClientTxt
            // 
            this.ClientTxt.Location = new System.Drawing.Point(6, 134);
            this.ClientTxt.Name = "ClientTxt";
            this.ClientTxt.ReadOnly = true;
            this.ClientTxt.Size = new System.Drawing.Size(284, 27);
            this.ClientTxt.TabIndex = 0;
            // 
            // PrintLbl
            // 
            this.PrintLbl.AutoSize = true;
            this.PrintLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintLbl.Location = new System.Drawing.Point(6, 45);
            this.PrintLbl.Name = "PrintLbl";
            this.PrintLbl.Size = new System.Drawing.Size(201, 19);
            this.PrintLbl.TabIndex = 17;
            this.PrintLbl.Text = "DATA D\'IMPRESSIÓ DEL CUPÓ";
            // 
            // PrintTxt
            // 
            this.PrintTxt.Location = new System.Drawing.Point(6, 67);
            this.PrintTxt.Name = "PrintTxt";
            this.PrintTxt.ReadOnly = true;
            this.PrintTxt.Size = new System.Drawing.Size(284, 27);
            this.PrintTxt.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.TiquetPreviewTxt);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(15, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 475);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PRESENTACIÓ TIQUET";
            // 
            // TiquetPreviewTxt
            // 
            this.TiquetPreviewTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TiquetPreviewTxt.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.TiquetPreviewTxt.Location = new System.Drawing.Point(3, 23);
            this.TiquetPreviewTxt.Name = "TiquetPreviewTxt";
            this.TiquetPreviewTxt.ReadOnly = true;
            this.TiquetPreviewTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TiquetPreviewTxt.Size = new System.Drawing.Size(294, 449);
            this.TiquetPreviewTxt.TabIndex = 0;
            this.TiquetPreviewTxt.Text = "";
            // 
            // VOUCHER_Dates
            // 
            this.VOUCHER_Dates.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VOUCHER_Dates.Location = new System.Drawing.Point(321, 89);
            this.VOUCHER_Dates.Name = "VOUCHER_Dates";
            this.VOUCHER_Dates.Size = new System.Drawing.Size(124, 27);
            this.VOUCHER_Dates.TabIndex = 17;
            // 
            // ERROR
            // 
            this.ERROR.AutoSize = true;
            this.ERROR.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.ERROR.ForeColor = System.Drawing.Color.Red;
            this.ERROR.Location = new System.Drawing.Point(534, 93);
            this.ERROR.Name = "ERROR";
            this.ERROR.Size = new System.Drawing.Size(354, 19);
            this.ERROR.TabIndex = 18;
            this.ERROR.Text = "NO S\'HA TROBAT CAP INFORMACIÓ DEL CUPÓ";
            this.ERROR.Visible = false;
            // 
            // Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.ERROR);
            this.Controls.Add(this.VOUCHER_Dates);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VoucherSerchedTxt);
            this.Controls.Add(this.CercarBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VOUCHER_Date);
            this.Controls.Add(this.TITLETiquet);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Voucher";
            this.Size = new System.Drawing.Size(940, 612);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Voucher_Table)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label TITLETiquet;
        public System.Windows.Forms.Label VOUCHER_Date;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer StartTimeVC;
        private System.Windows.Forms.Button CercarBtn;
        private System.Windows.Forms.TextBox VoucherSerchedTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox TiquetPreviewTxt;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Voucher_Table;
        public System.Windows.Forms.Label StateVoucherLbl;
        private System.Windows.Forms.TextBox StateVoucherTxt;
        public System.Windows.Forms.Label VoucherAmountLbl;
        private System.Windows.Forms.TextBox VoucherAmountTxt;
        public System.Windows.Forms.Label ClientLbl;
        private System.Windows.Forms.TextBox ClientTxt;
        public System.Windows.Forms.Label PrintLbl;
        private System.Windows.Forms.TextBox PrintTxt;
        private System.Windows.Forms.DateTimePicker VOUCHER_Dates;
        public System.Windows.Forms.Label EXPIRATIONLbl;
        private System.Windows.Forms.TextBox ExpirationTxt;
        private System.Windows.Forms.Label ERROR;
        public System.Windows.Forms.Label ExistServerPosLbl;
        private System.Windows.Forms.TextBox ExistServerPosTxt;
    }
}
