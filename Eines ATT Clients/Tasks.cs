using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace Eines_ATT_Clients
{
    public partial class Control_Screen : Form
    {
        private IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();
        public Button TICKET
        {
            get { return TIQUETBtn; }
        }
        public static string GETUSER { get; set; }
        public Control_Screen()
        {
            InitializeComponent();
            CopyRightsLbl.Text = DateTime.Now.Year.ToString() + " - Franky's System " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            CopyRightsLbl.Location = new Point(BOTTOMBar.Width - TextRenderer.MeasureText(CopyRightsLbl.Text, CopyRightsLbl.Font).Width, CopyRightsLbl.Location.Y);
        }
        private void CLOSEBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MAX_NORBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                MAX_NORBtn.BackgroundImage = Properties.Resources.icons8_normal_screen_16px;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                MAX_NORBtn.BackgroundImage = Properties.Resources.icons8_full_screen_16px;
                WindowState = FormWindowState.Normal;
            }
        }
        private void MINBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public string Paper;
        public static string nuser { get; set; }
        public string Connection()
        {
            return $"server={config["SQLParameters:server"]};Uid={config["SQLParameters:uid"]};Pwd={config["SQLParameters:pwd"]};database={config["SQLParameters:dtbs:dpt"]}";
        }
        private bool FindUser(string userPWD)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection()))
            {
                connection.Open();
                try
                {
                    StringBuilder Command = new StringBuilder();
                    Command.Append("SELECT Empleado FROM `departaments-cca`.allowed where ID = @ID;");
                    MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
                    CMD.Parameters.AddWithValue("@ID", LOGINTXT.Text);
                    MySqlDataReader USER = CMD.ExecuteReader();
                    if (USER.HasRows)
                    {
                        while (USER.Read())
                        {
                            USERLbl.Text = USER[0].ToString();
                            GETUSER = USERLbl.Text;
                            break;
                        }
                    }
                    else return false;
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al connectar amb la base de dades: " + ex.Message, "Error de connexió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            nuser = LOGINTXT.Text;
            ErrorLOGIN.Text = "";
            try
            {
                if (!FindUser(LOGINTXT.Text))
                {
                    ErrorLOGIN.Text = "Usuari no trobat";
                    return;
                }
                Control Ctrl = null;
                if (Paper == "Voucher")
                {
                    Ctrl = new Voucher(config);
                    CUPONESBtn.Image = Properties.Resources.icons8_voucher_50px_1;
                }
                else
                {
                    Ctrl = new Tiquet(config);
                    TIQUETBtn.Image = Properties.Resources.icons8_purchase_order_50px_1;
                }
                LOGINStatus(Paper, false);
                OpenUserControl(Ctrl);
            }
            catch (Exception)
            {
                nuser = string.Empty;
                ErrorLOGIN.Text = "Usuari no trobat";
            }
        }
        private void TIQUETBtn_Click(object sender, EventArgs e)
        {
            CUPONESBtn.Image = Properties.Resources.icons8_voucher_50px;
            if (USERLbl.Text == "UserName")
            {
                LOGINStatus("Tiquet", true);
            }
            else
            {
                OpenUserControl(new Tiquet(config));
                TIQUETBtn.Image = Properties.Resources.icons8_purchase_order_50px_1;
            }

        }
        private void EnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Accept_Click(sender, e);
            }
        }
        private void StartTime_Tick(object sender, EventArgs e)
        {
            LEFTBar.Size = new Size(LEFTBar.Width - 20, LEFTBar.Height);
            if (LEFTBar.Width <= 55)
            {
                LEFTBar.Width = 55;
                StartTime.Stop();
            }
        }
        private void LOGINStatus(string paper, bool condition)
        {
            Paper = paper;
            AcceptLOGIN.Visible = condition;
            LOGIN.Visible = condition;
            LOGINTXT.Visible = condition;
            LOGO.Visible = condition;
            if (condition)
            {
                LOGINTXT.Focus();
            }
        }
        private void OpenUserControl(Control ctrl)
        {
            MiddlePanel.Controls.Clear();
            MiddlePanel.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
            StartTime.Interval = 1;
            StartTime.Start();
            ctrl.Show();
        }
        private void CUPONESBtn_Click(object sender, EventArgs e)
        {
            TIQUETBtn.Image = Properties.Resources.icons8_purchase_order_50px;
            if (USERLbl.Text == "UserName")
            {
                LOGINStatus("Voucher", true);
            }
            else
            {
                OpenUserControl(new Voucher(config));
                CUPONESBtn.Image = Properties.Resources.icons8_voucher_50px_1;
            }
        }
    }
}