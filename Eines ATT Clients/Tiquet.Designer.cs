namespace Eines_ATT_Clients
{
    partial class Tiquet
    {

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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DPTBox = new System.Windows.Forms.ComboBox();
            this.DPTLbl = new System.Windows.Forms.Label();
            this.TITLETiquet = new System.Windows.Forms.Label();
            this.TICKETS_LIST = new System.Windows.Forms.RichTextBox();
            this.TPVBox = new System.Windows.Forms.ComboBox();
            this.TPVLbl = new System.Windows.Forms.Label();
            this.TICKET_TABLE = new System.Windows.Forms.DataGridView();
            this.PURCHASE_Date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.GOBtn = new System.Windows.Forms.Button();
            this.errorlbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StartTimeTK = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TICKET_TABLE)).BeginInit();
            this.SuspendLayout();
            // 
            // DPTBox
            // 
            this.DPTBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPTBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DPTBox.FormattingEnabled = true;
            this.DPTBox.Location = new System.Drawing.Point(15, 87);
            this.DPTBox.Name = "DPTBox";
            this.DPTBox.Size = new System.Drawing.Size(224, 29);
            this.DPTBox.TabIndex = 0;
            this.DPTBox.SelectedIndexChanged += new System.EventHandler(this.DPTBox_SelectedIndexChanged);
            // 
            // DPTLbl
            // 
            this.DPTLbl.AutoSize = true;
            this.DPTLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPTLbl.Location = new System.Drawing.Point(11, 65);
            this.DPTLbl.Name = "DPTLbl";
            this.DPTLbl.Size = new System.Drawing.Size(206, 19);
            this.DPTLbl.TabIndex = 1;
            this.DPTLbl.Text = "SEL·LECCIÓ DE DEPARTAMENT";
            // 
            // TITLETiquet
            // 
            this.TITLETiquet.AutoSize = true;
            this.TITLETiquet.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TITLETiquet.Location = new System.Drawing.Point(9, 10);
            this.TITLETiquet.Name = "TITLETiquet";
            this.TITLETiquet.Size = new System.Drawing.Size(230, 32);
            this.TITLETiquet.TabIndex = 2;
            this.TITLETiquet.Text = "CERCAR TIQUETS";
            // 
            // TICKETS_LIST
            // 
            this.TICKETS_LIST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TICKETS_LIST.BackColor = System.Drawing.Color.White;
            this.TICKETS_LIST.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TICKETS_LIST.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TICKETS_LIST.Location = new System.Drawing.Point(483, 141);
            this.TICKETS_LIST.Name = "TICKETS_LIST";
            this.TICKETS_LIST.ReadOnly = true;
            this.TICKETS_LIST.Size = new System.Drawing.Size(506, 455);
            this.TICKETS_LIST.TabIndex = 3;
            this.TICKETS_LIST.Text = "";
            // 
            // TPVBox
            // 
            this.TPVBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TPVBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TPVBox.FormattingEnabled = true;
            this.TPVBox.Location = new System.Drawing.Point(271, 87);
            this.TPVBox.Name = "TPVBox";
            this.TPVBox.Size = new System.Drawing.Size(224, 29);
            this.TPVBox.TabIndex = 0;
            // 
            // TPVLbl
            // 
            this.TPVLbl.AutoSize = true;
            this.TPVLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPVLbl.Location = new System.Drawing.Point(267, 65);
            this.TPVLbl.Name = "TPVLbl";
            this.TPVLbl.Size = new System.Drawing.Size(131, 19);
            this.TPVLbl.TabIndex = 1;
            this.TPVLbl.Text = "SEL·LECCIÓ CAIXA";
            // 
            // TICKET_TABLE
            // 
            this.TICKET_TABLE.AllowUserToAddRows = false;
            this.TICKET_TABLE.AllowUserToResizeColumns = false;
            this.TICKET_TABLE.AllowUserToResizeRows = false;
            this.TICKET_TABLE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TICKET_TABLE.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TICKET_TABLE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TICKET_TABLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TICKET_TABLE.DefaultCellStyle = dataGridViewCellStyle4;
            this.TICKET_TABLE.Location = new System.Drawing.Point(15, 141);
            this.TICKET_TABLE.MultiSelect = false;
            this.TICKET_TABLE.Name = "TICKET_TABLE";
            this.TICKET_TABLE.RowHeadersVisible = false;
            this.TICKET_TABLE.Size = new System.Drawing.Size(447, 455);
            this.TICKET_TABLE.TabIndex = 4;
            this.TICKET_TABLE.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TICKET_TABLE_CellContentClick);
            // 
            // PURCHASE_Date
            // 
            this.PURCHASE_Date.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.PURCHASE_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PURCHASE_Date.Location = new System.Drawing.Point(527, 86);
            this.PURCHASE_Date.Name = "PURCHASE_Date";
            this.PURCHASE_Date.Size = new System.Drawing.Size(127, 29);
            this.PURCHASE_Date.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "DATA DEL TICKET";
            // 
            // GOBtn
            // 
            this.GOBtn.BackgroundImage = global::Eines_ATT_Clients.Properties.Resources.icons8_google_web_search_50px;
            this.GOBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GOBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GOBtn.FlatAppearance.BorderSize = 0;
            this.GOBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.GOBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GOBtn.Location = new System.Drawing.Point(677, 73);
            this.GOBtn.Name = "GOBtn";
            this.GOBtn.Size = new System.Drawing.Size(56, 54);
            this.GOBtn.TabIndex = 7;
            this.GOBtn.UseVisualStyleBackColor = true;
            this.GOBtn.Click += new System.EventHandler(this.GOBtn_Click);
            // 
            // errorlbl
            // 
            this.errorlbl.AutoSize = true;
            this.errorlbl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorlbl.ForeColor = System.Drawing.Color.Red;
            this.errorlbl.Location = new System.Drawing.Point(12, 120);
            this.errorlbl.Name = "errorlbl";
            this.errorlbl.Size = new System.Drawing.Size(0, 15);
            this.errorlbl.TabIndex = 8;
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
            this.button1.Location = new System.Drawing.Point(976, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 28);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartTimeTK
            // 
            this.StartTimeTK.Tick += new System.EventHandler(this.StartTimeTK_Tick);
            // 
            // Tiquet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorlbl);
            this.Controls.Add(this.GOBtn);
            this.Controls.Add(this.PURCHASE_Date);
            this.Controls.Add(this.TICKET_TABLE);
            this.Controls.Add(this.TICKETS_LIST);
            this.Controls.Add(this.TITLETiquet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TPVLbl);
            this.Controls.Add(this.DPTLbl);
            this.Controls.Add(this.TPVBox);
            this.Controls.Add(this.DPTBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Tiquet";
            this.Size = new System.Drawing.Size(1004, 612);
            ((System.ComponentModel.ISupportInitialize)(this.TICKET_TABLE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox DPTBox;
        public System.Windows.Forms.Label DPTLbl;
        public System.Windows.Forms.Label TITLETiquet;
        public System.Windows.Forms.RichTextBox TICKETS_LIST;
        public System.Windows.Forms.ComboBox TPVBox;
        public System.Windows.Forms.Label TPVLbl;
        public System.Windows.Forms.DataGridView TICKET_TABLE;
        public System.Windows.Forms.DateTimePicker PURCHASE_Date;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button GOBtn;
        public System.Windows.Forms.Label errorlbl;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer StartTimeTK;
        private System.ComponentModel.IContainer components;
    }
}
