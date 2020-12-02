using System.ComponentModel;

namespace Eines_ATT_Clients
{
    
    partial class Control_Screen
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control_Screen));
            this.TOPBar = new System.Windows.Forms.Panel();
            this.CCA = new System.Windows.Forms.PictureBox();
            this.USERLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.USERIcon = new System.Windows.Forms.Label();
            this.MINBtn = new System.Windows.Forms.Button();
            this.MAX_NORBtn = new System.Windows.Forms.Button();
            this.CLOSEBtn = new System.Windows.Forms.Button();
            this.LEFTBar = new System.Windows.Forms.Panel();
            this.CUPONESBtn = new System.Windows.Forms.Button();
            this.TIQUETBtn = new System.Windows.Forms.Button();
            this.BOTTOMBar = new System.Windows.Forms.Panel();
            this.CopyRightsLbl = new System.Windows.Forms.Label();
            this.MiddlePanel = new System.Windows.Forms.Panel();
            this.ErrorLOGIN = new System.Windows.Forms.Label();
            this.LOGO = new System.Windows.Forms.Label();
            this.LOGIN = new System.Windows.Forms.Label();
            this.LOGINTXT = new System.Windows.Forms.TextBox();
            this.AcceptLOGIN = new System.Windows.Forms.Button();
            this.StartTime = new System.Windows.Forms.Timer(this.components);
            this.TOPBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCA)).BeginInit();
            this.LEFTBar.SuspendLayout();
            this.BOTTOMBar.SuspendLayout();
            this.MiddlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TOPBar
            // 
            this.TOPBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(146)))));
            this.TOPBar.Controls.Add(this.CCA);
            this.TOPBar.Controls.Add(this.USERLbl);
            this.TOPBar.Controls.Add(this.label1);
            this.TOPBar.Controls.Add(this.USERIcon);
            this.TOPBar.Controls.Add(this.MINBtn);
            this.TOPBar.Controls.Add(this.MAX_NORBtn);
            this.TOPBar.Controls.Add(this.CLOSEBtn);
            this.TOPBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOPBar.Location = new System.Drawing.Point(0, 0);
            this.TOPBar.Name = "TOPBar";
            this.TOPBar.Size = new System.Drawing.Size(1185, 40);
            this.TOPBar.TabIndex = 0;
            // 
            // CCA
            // 
            this.CCA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CCA.Image = global::Eines_ATT_Clients.Properties.Resources.CCA;
            this.CCA.Location = new System.Drawing.Point(554, -4);
            this.CCA.Name = "CCA";
            this.CCA.Size = new System.Drawing.Size(100, 48);
            this.CCA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CCA.TabIndex = 5;
            this.CCA.TabStop = false;
            // 
            // USERLbl
            // 
            this.USERLbl.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERLbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.USERLbl.Location = new System.Drawing.Point(275, 0);
            this.USERLbl.Name = "USERLbl";
            this.USERLbl.Size = new System.Drawing.Size(187, 40);
            this.USERLbl.TabIndex = 1;
            this.USERLbl.Text = "UserName";
            this.USERLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "EINES CCA";
            // 
            // USERIcon
            // 
            this.USERIcon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.USERIcon.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_businesswoman_32px2;
            this.USERIcon.Location = new System.Drawing.Point(241, 0);
            this.USERIcon.Name = "USERIcon";
            this.USERIcon.Size = new System.Drawing.Size(33, 40);
            this.USERIcon.TabIndex = 1;
            // 
            // MINBtn
            // 
            this.MINBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MINBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MINBtn.FlatAppearance.BorderSize = 0;
            this.MINBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MINBtn.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_subtract_16px;
            this.MINBtn.Location = new System.Drawing.Point(1030, 0);
            this.MINBtn.Name = "MINBtn";
            this.MINBtn.Size = new System.Drawing.Size(49, 40);
            this.MINBtn.TabIndex = 4;
            this.MINBtn.UseVisualStyleBackColor = true;
            this.MINBtn.Click += new System.EventHandler(this.MINBtn_Click);
            // 
            // MAX_NORBtn
            // 
            this.MAX_NORBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MAX_NORBtn.BackgroundImage = global::Eines_ATT_Clients.Properties.Resources.icons8_full_screen_16px;
            this.MAX_NORBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MAX_NORBtn.FlatAppearance.BorderSize = 0;
            this.MAX_NORBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MAX_NORBtn.Location = new System.Drawing.Point(1083, 0);
            this.MAX_NORBtn.Name = "MAX_NORBtn";
            this.MAX_NORBtn.Size = new System.Drawing.Size(49, 40);
            this.MAX_NORBtn.TabIndex = 3;
            this.MAX_NORBtn.UseVisualStyleBackColor = true;
            this.MAX_NORBtn.Click += new System.EventHandler(this.MAX_NORBtn_Click);
            // 
            // CLOSEBtn
            // 
            this.CLOSEBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CLOSEBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CLOSEBtn.FlatAppearance.BorderSize = 0;
            this.CLOSEBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.CLOSEBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLOSEBtn.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_delete_16px;
            this.CLOSEBtn.Location = new System.Drawing.Point(1136, 0);
            this.CLOSEBtn.Name = "CLOSEBtn";
            this.CLOSEBtn.Size = new System.Drawing.Size(49, 40);
            this.CLOSEBtn.TabIndex = 3;
            this.CLOSEBtn.UseVisualStyleBackColor = true;
            this.CLOSEBtn.Click += new System.EventHandler(this.CLOSEBtn_Click);
            // 
            // LEFTBar
            // 
            this.LEFTBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.LEFTBar.Controls.Add(this.CUPONESBtn);
            this.LEFTBar.Controls.Add(this.TIQUETBtn);
            this.LEFTBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFTBar.Location = new System.Drawing.Point(0, 40);
            this.LEFTBar.Name = "LEFTBar";
            this.LEFTBar.Size = new System.Drawing.Size(245, 635);
            this.LEFTBar.TabIndex = 1;
            // 
            // CUPONESBtn
            // 
            this.CUPONESBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CUPONESBtn.FlatAppearance.BorderSize = 0;
            this.CUPONESBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.CUPONESBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CUPONESBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CUPONESBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.CUPONESBtn.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_voucher_50px;
            this.CUPONESBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CUPONESBtn.Location = new System.Drawing.Point(-2, 64);
            this.CUPONESBtn.Name = "CUPONESBtn";
            this.CUPONESBtn.Size = new System.Drawing.Size(257, 60);
            this.CUPONESBtn.TabIndex = 0;
            this.CUPONESBtn.Text = "Comprobació de &cupons";
            this.CUPONESBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CUPONESBtn.UseVisualStyleBackColor = true;
            this.CUPONESBtn.Click += new System.EventHandler(this.CUPONESBtn_Click);
            // 
            // TIQUETBtn
            // 
            this.TIQUETBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TIQUETBtn.FlatAppearance.BorderSize = 0;
            this.TIQUETBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.TIQUETBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TIQUETBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIQUETBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TIQUETBtn.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_purchase_order_50px;
            this.TIQUETBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TIQUETBtn.Location = new System.Drawing.Point(-1, 0);
            this.TIQUETBtn.Name = "TIQUETBtn";
            this.TIQUETBtn.Size = new System.Drawing.Size(255, 60);
            this.TIQUETBtn.TabIndex = 0;
            this.TIQUETBtn.Text = "Comprobacio de &tiquets";
            this.TIQUETBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TIQUETBtn.UseVisualStyleBackColor = true;
            this.TIQUETBtn.Click += new System.EventHandler(this.TIQUETBtn_Click);
            // 
            // BOTTOMBar
            // 
            this.BOTTOMBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BOTTOMBar.Controls.Add(this.CopyRightsLbl);
            this.BOTTOMBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BOTTOMBar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BOTTOMBar.Location = new System.Drawing.Point(245, 650);
            this.BOTTOMBar.Name = "BOTTOMBar";
            this.BOTTOMBar.Size = new System.Drawing.Size(940, 25);
            this.BOTTOMBar.TabIndex = 2;
            // 
            // CopyRightsLbl
            // 
            this.CopyRightsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyRightsLbl.AutoSize = true;
            this.CopyRightsLbl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyRightsLbl.Location = new System.Drawing.Point(811, 5);
            this.CopyRightsLbl.Name = "CopyRightsLbl";
            this.CopyRightsLbl.Size = new System.Drawing.Size(126, 15);
            this.CopyRightsLbl.TabIndex = 0;
            this.CopyRightsLbl.Text = "2019 - Franky\'s System";
            this.CopyRightsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.MiddlePanel.Controls.Add(this.ErrorLOGIN);
            this.MiddlePanel.Controls.Add(this.LOGO);
            this.MiddlePanel.Controls.Add(this.LOGIN);
            this.MiddlePanel.Controls.Add(this.LOGINTXT);
            this.MiddlePanel.Controls.Add(this.AcceptLOGIN);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePanel.Location = new System.Drawing.Point(245, 40);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(940, 610);
            this.MiddlePanel.TabIndex = 3;
            // 
            // ErrorLOGIN
            // 
            this.ErrorLOGIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ErrorLOGIN.AutoSize = true;
            this.ErrorLOGIN.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLOGIN.ForeColor = System.Drawing.Color.Red;
            this.ErrorLOGIN.Location = new System.Drawing.Point(350, 289);
            this.ErrorLOGIN.Name = "ErrorLOGIN";
            this.ErrorLOGIN.Size = new System.Drawing.Size(0, 16);
            this.ErrorLOGIN.TabIndex = 4;
            // 
            // LOGO
            // 
            this.LOGO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LOGO.ForeColor = System.Drawing.Color.White;
            this.LOGO.Image = global::Eines_ATT_Clients.Properties.Resources.icons8_lock_20px;
            this.LOGO.Location = new System.Drawing.Point(348, 239);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(21, 21);
            this.LOGO.TabIndex = 3;
            this.LOGO.Visible = false;
            // 
            // LOGIN
            // 
            this.LOGIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LOGIN.AutoSize = true;
            this.LOGIN.ForeColor = System.Drawing.Color.White;
            this.LOGIN.Location = new System.Drawing.Point(375, 239);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(62, 21);
            this.LOGIN.TabIndex = 2;
            this.LOGIN.Text = "LOGIN";
            this.LOGIN.Visible = false;
            // 
            // LOGINTXT
            // 
            this.LOGINTXT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LOGINTXT.Location = new System.Drawing.Point(352, 263);
            this.LOGINTXT.Name = "LOGINTXT";
            this.LOGINTXT.PasswordChar = '·';
            this.LOGINTXT.Size = new System.Drawing.Size(234, 27);
            this.LOGINTXT.TabIndex = 1;
            this.LOGINTXT.Visible = false;
            this.LOGINTXT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKey);
            // 
            // AcceptLOGIN
            // 
            this.AcceptLOGIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AcceptLOGIN.FlatAppearance.BorderSize = 0;
            this.AcceptLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptLOGIN.ForeColor = System.Drawing.Color.White;
            this.AcceptLOGIN.Location = new System.Drawing.Point(407, 306);
            this.AcceptLOGIN.Name = "AcceptLOGIN";
            this.AcceptLOGIN.Size = new System.Drawing.Size(124, 38);
            this.AcceptLOGIN.TabIndex = 0;
            this.AcceptLOGIN.Text = "Acceptar";
            this.AcceptLOGIN.UseVisualStyleBackColor = true;
            this.AcceptLOGIN.Visible = false;
            this.AcceptLOGIN.Click += new System.EventHandler(this.Accept_Click);
            // 
            // StartTime
            // 
            this.StartTime.Tick += new System.EventHandler(this.StartTime_Tick);
            // 
            // Control_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 675);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BOTTOMBar);
            this.Controls.Add(this.LEFTBar);
            this.Controls.Add(this.TOPBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Control_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TOPBar.ResumeLayout(false);
            this.TOPBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCA)).EndInit();
            this.LEFTBar.ResumeLayout(false);
            this.BOTTOMBar.ResumeLayout(false);
            this.BOTTOMBar.PerformLayout();
            this.MiddlePanel.ResumeLayout(false);
            this.MiddlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel TOPBar;
        public System.Windows.Forms.Panel LEFTBar;
        public System.Windows.Forms.Panel BOTTOMBar;
        public System.Windows.Forms.Button MAX_NORBtn;
        public System.Windows.Forms.Button CLOSEBtn;
        public System.Windows.Forms.Button MINBtn;
        public System.Windows.Forms.Button CUPONESBtn;
        public System.Windows.Forms.Button TIQUETBtn;
        public System.Windows.Forms.Panel MiddlePanel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label CopyRightsLbl;
        public System.Windows.Forms.Label USERIcon;
        public System.Windows.Forms.Label USERLbl;
        public System.Windows.Forms.Button AcceptLOGIN;
        public System.Windows.Forms.Label LOGO;
        public System.Windows.Forms.Label LOGIN;
        public System.Windows.Forms.TextBox LOGINTXT;
        public System.Windows.Forms.Label ErrorLOGIN;
        public System.Windows.Forms.Timer StartTime;
        private IContainer components;
        private System.Windows.Forms.PictureBox CCA;
    }
}

