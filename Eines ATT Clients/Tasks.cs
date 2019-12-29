using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eines_ATT_Clients
{
    public partial class Control_Screen : Form
    {
        public Button TICKET
        {
            get { return TIQUETBtn; }
        }
        public Control_Screen()
        {
            InitializeComponent();
            CopyRightsLbl.Text = DateTime.Now.Year.ToString() + " - Franky's System";
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
        private string server;
        private string uid;
        private string password;
        public string Connection()
        {
            server = "192.168.29.11";
            uid = "CCA";
            password = "Attclients02";
            string connectionString;
            return connectionString = "SERVER=" + server + ";" + "user id=" + uid + ";" + "PASSWORD=" + password + ";";
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            ErrorLOGIN.Text = "";
            try
            {

                MySqlConnection connection = new MySqlConnection(Connection());
                StringBuilder Command = new StringBuilder();
                Command.Append("SELECT Empleado FROM `departaments-cca`.allowed where ID = '" + LOGINTXT.Text + "';");
                MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
                connection.Close();
                connection.Open();
                MySqlDataReader USER = CMD.ExecuteReader();
                while (USER.Read())
                {
                    USERLbl.Text = USER[0].ToString();
                }
                if (USERLbl.Text != "UserName")
                {
                    
                    Tiquet TK = new Tiquet();
                    AcceptLOGIN.Visible = false;
                    LOGIN.Visible = false;
                    LOGINTXT.Visible = false;
                    LOGO.Visible = false;
                    MiddlePanel.Controls.Add(TK);
                    TK.Dock = DockStyle.Fill;
                    StartTime.Interval = 1;
                    StartTime.Start();
                    TK.Show();
                    TIQUETBtn.Image = Properties.Resources.icons8_purchase_order_50px_1;


                }
                else
                {
                    ErrorLOGIN.Text = "Usuari no trobat";
                }


            }
            catch (Exception)
            {

                ErrorLOGIN.Text = "Usuari no trobat";
            }
        }
        private void TIQUETBtn_Click(object sender, EventArgs e)
        {
            if (USERLbl.Text == "UserName")
            {
                AcceptLOGIN.Visible = true;
                LOGIN.Visible = true;
                LOGINTXT.Visible = true;
                LOGO.Visible = true;
                LOGINTXT.Focus();
            }
            else
            {
                MiddlePanel.Controls.Clear();
                Tiquet TK = new Tiquet();
                MiddlePanel.Controls.Add(TK);
                TK.Dock = DockStyle.Fill;
                StartTime.Interval = 1;
                StartTime.Start();
                TK.Show();
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
    }
}