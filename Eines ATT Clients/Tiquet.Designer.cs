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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DPTBox = new System.Windows.Forms.ComboBox();
            this.DPTLbl = new System.Windows.Forms.Label();
            this.TITLETiquet = new System.Windows.Forms.Label();
            this.TICKETS_LIST = new System.Windows.Forms.RichTextBox();
            this.TPVBox = new System.Windows.Forms.ComboBox();
            this.TPVLbl = new System.Windows.Forms.Label();
            this.TICKET_TABLE = new System.Windows.Forms.DataGridView();
            this.PURCHASE_Date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.StartTimeTK = new System.Windows.Forms.Timer(this.components);
            this.CLIENT_CODE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Downloading = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Downloadlbl = new System.Windows.Forms.Label();
            this.Download_File = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GOBtn = new System.Windows.Forms.Button();
            this.Show_Grup = new System.Windows.Forms.CheckBox();
            this.errorlbl = new System.Windows.Forms.Label();
            this.In_Out = new System.Windows.Forms.CheckBox();
            this.Error_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TICKET_TABLE)).BeginInit();
            this.SuspendLayout();
            // 
            // DPTBox
            // 
            this.DPTBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPTBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DPTBox.FormattingEnabled = true;
            this.DPTBox.Location = new System.Drawing.Point(15, 77);
            this.DPTBox.Name = "DPTBox";
            this.DPTBox.Size = new System.Drawing.Size(258, 29);
            this.DPTBox.TabIndex = 0;
            this.DPTBox.SelectedIndexChanged += new System.EventHandler(this.DPTBox_SelectedIndexChanged);
            // 
            // DPTLbl
            // 
            this.DPTLbl.AutoSize = true;
            this.DPTLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPTLbl.Location = new System.Drawing.Point(11, 55);
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
            this.TICKETS_LIST.Location = new System.Drawing.Point(574, 180);
            this.TICKETS_LIST.Name = "TICKETS_LIST";
            this.TICKETS_LIST.ReadOnly = true;
            this.TICKETS_LIST.Size = new System.Drawing.Size(509, 416);
            this.TICKETS_LIST.TabIndex = 3;
            this.TICKETS_LIST.Text = "";
            // 
            // TPVBox
            // 
            this.TPVBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TPVBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TPVBox.FormattingEnabled = true;
            this.TPVBox.Location = new System.Drawing.Point(15, 131);
            this.TPVBox.Name = "TPVBox";
            this.TPVBox.Size = new System.Drawing.Size(258, 29);
            this.TPVBox.TabIndex = 0;
            // 
            // TPVLbl
            // 
            this.TPVLbl.AutoSize = true;
            this.TPVLbl.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPVLbl.Location = new System.Drawing.Point(11, 109);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TICKET_TABLE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.TICKET_TABLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TICKET_TABLE.DefaultCellStyle = dataGridViewCellStyle6;
            this.TICKET_TABLE.Location = new System.Drawing.Point(15, 180);
            this.TICKET_TABLE.MultiSelect = false;
            this.TICKET_TABLE.Name = "TICKET_TABLE";
            this.TICKET_TABLE.RowHeadersVisible = false;
            this.TICKET_TABLE.Size = new System.Drawing.Size(537, 416);
            this.TICKET_TABLE.TabIndex = 4;
            this.TICKET_TABLE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TICKET_TABLE_CellContentClick);
            // 
            // PURCHASE_Date
            // 
            this.PURCHASE_Date.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.PURCHASE_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PURCHASE_Date.Location = new System.Drawing.Point(574, 77);
            this.PURCHASE_Date.Name = "PURCHASE_Date";
            this.PURCHASE_Date.Size = new System.Drawing.Size(164, 29);
            this.PURCHASE_Date.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(570, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "DATA DEL TICKET";
            // 
            // StartTimeTK
            // 
            this.StartTimeTK.Tick += new System.EventHandler(this.StartTimeTK_Tick);
            // 
            // CLIENT_CODE
            // 
            this.CLIENT_CODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CLIENT_CODE.Location = new System.Drawing.Point(574, 131);
            this.CLIENT_CODE.Name = "CLIENT_CODE";
            this.CLIENT_CODE.Size = new System.Drawing.Size(164, 27);
            this.CLIENT_CODE.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(570, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "CODI CLIENT (opcional)";
            // 
            // Downloading
            // 
            this.Downloading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Downloading_DoWork);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(688, 164);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(395, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // Downloadlbl
            // 
            this.Downloadlbl.AutoSize = true;
            this.Downloadlbl.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Downloadlbl.Location = new System.Drawing.Point(571, 161);
            this.Downloadlbl.Name = "Downloadlbl";
            this.Downloadlbl.Size = new System.Drawing.Size(115, 16);
            this.Downloadlbl.TabIndex = 12;
            this.Downloadlbl.Text = "Descarregant caixa";
            this.Downloadlbl.Visible = false;
            // 
            // Download_File
            // 
            this.Download_File.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Download_File.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Download_File.FlatAppearance.BorderSize = 0;
            this.Download_File.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Download_File.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Download_File.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Download_File.Image = global::Eines_ATT_Clients.Properties.Resources.downloading_updates_64px1;
            this.Download_File.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Download_File.Location = new System.Drawing.Point(942, 74);
            this.Download_File.Name = "Download_File";
            this.Download_File.Size = new System.Drawing.Size(101, 80);
            this.Download_File.TabIndex = 13;
            this.Download_File.Text = "Descarregar";
            this.Download_File.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Download_File.UseVisualStyleBackColor = true;
            this.Download_File.Click += new System.EventHandler(this.Download_File_Click);
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
            this.button1.Location = new System.Drawing.Point(1070, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 28);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GOBtn
            // 
            this.GOBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GOBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GOBtn.FlatAppearance.BorderSize = 0;
            this.GOBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.GOBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GOBtn.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GOBtn.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_google_web_search_50px;
            this.GOBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.GOBtn.Location = new System.Drawing.Point(792, 74);
            this.GOBtn.Name = "GOBtn";
            this.GOBtn.Size = new System.Drawing.Size(101, 80);
            this.GOBtn.TabIndex = 7;
            this.GOBtn.Text = "Cercar";
            this.GOBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GOBtn.UseVisualStyleBackColor = true;
            this.GOBtn.Click += new System.EventHandler(this.GOBtn_Click);
            // 
            // Show_Grup
            // 
            this.Show_Grup.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Show_Grup.Location = new System.Drawing.Point(328, 125);
            this.Show_Grup.Name = "Show_Grup";
            this.Show_Grup.Size = new System.Drawing.Size(173, 42);
            this.Show_Grup.TabIndex = 14;
            this.Show_Grup.Text = "AGRUPAR CAIXES\r\nPER SECCIONS";
            this.Show_Grup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Show_Grup.UseVisualStyleBackColor = true;
            this.Show_Grup.CheckedChanged += new System.EventHandler(this.Show_Grup_CheckedChanged);
            // 
            // errorlbl
            // 
            this.errorlbl.AutoSize = true;
            this.errorlbl.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorlbl.Location = new System.Drawing.Point(245, 19);
            this.errorlbl.Name = "errorlbl";
            this.errorlbl.Size = new System.Drawing.Size(45, 21);
            this.errorlbl.TabIndex = 15;
            this.errorlbl.Text = "error";
            this.errorlbl.Visible = false;
            // 
            // In_Out
            // 
            this.In_Out.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.In_Out.Location = new System.Drawing.Point(328, 74);
            this.In_Out.Name = "In_Out";
            this.In_Out.Size = new System.Drawing.Size(173, 42);
            this.In_Out.TabIndex = 16;
            this.In_Out.Text = "VEURE\r\nENTRADES / SORTIDES\r\n";
            this.In_Out.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.In_Out.UseVisualStyleBackColor = true;
            // 
            // Error_Timer
            // 
            this.Error_Timer.Tick += new System.EventHandler(this.Error_Timer_Tick);
            // 
            // Tiquet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.In_Out);
            this.Controls.Add(this.errorlbl);
            this.Controls.Add(this.Show_Grup);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Download_File);
            this.Controls.Add(this.Downloadlbl);
            this.Controls.Add(this.CLIENT_CODE);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GOBtn);
            this.Controls.Add(this.PURCHASE_Date);
            this.Controls.Add(this.TICKET_TABLE);
            this.Controls.Add(this.TICKETS_LIST);
            this.Controls.Add(this.TITLETiquet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
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
            this.Size = new System.Drawing.Size(1098, 612);
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
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer StartTimeTK;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TextBox CLIENT_CODE;
        public System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker Downloading;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Downloadlbl;
        public System.Windows.Forms.Button Download_File;
        private System.Windows.Forms.CheckBox Show_Grup;
        private System.Windows.Forms.Label errorlbl;
        private System.Windows.Forms.CheckBox In_Out;
        private System.Windows.Forms.Timer Error_Timer;
    }
}
