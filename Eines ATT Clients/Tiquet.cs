using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.NetworkInformation;

namespace Eines_ATT_Clients
{

    public partial class Tiquet : UserControl
    {

        public Tiquet()
        {
            Hide();
            InitializeComponent();
            TICKET_TABLE.ForeColor = System.Drawing.Color.Black;
            MySqlConnection connection = new MySqlConnection(Connection());
            StringBuilder Command = new StringBuilder();
            Command.Append("SELECT DSC FROM `departaments-cca`.cca group by DSC order by DPT");
            MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
            connection.Close();
            connection.Open();
            MySqlDataReader DPT = CMD.ExecuteReader();
            while (DPT.Read())
            {
                DPTBox.Items.Add(DPT[0].ToString().Trim());
            }
            DPT.Close();
            connection.Close();

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
        public string ConnectionAXCAIXES()
        {
            string connectionString = "datasource=srvfidelia;port=3306;username=root;password=gnxpos;database=stocks;";
            if (PURCHASE_Date.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                connectionString = "datasource=srvpos;port=3306;username=root;password=gnxpos;database=stocks;";
            }

            return connectionString;
        }
        private void DPTBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            TPVBox.Items.Clear();
            MySqlConnection connection = new MySqlConnection(Connection());
            StringBuilder Command = new StringBuilder();
            Command.Append("SELECT TPV FROM `departaments-cca`.cca where DSC = '" + DPTBox.Text + "' order by DPT");
            MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
            connection.Close();
            connection.Open();
            MySqlDataReader DPT = CMD.ExecuteReader();
            bool checkindex = false;
            while (DPT.Read())
            {
                string TPVResult = TPV(DPT[0].ToString().Trim());
                if (TPVResult != "")
                {
                    foreach (var index in TPVBox.Items)
                    {
                        if (index == TPVResult)
                        {
                            checkindex = true;
                        }
                    }
                    if (!checkindex)
                    {
                        TPVBox.Items.Add(TPVResult);
                    }
                    else
                    {
                        checkindex = false;
                    }
                }
            }
            DPT.Close();
            connection.Close();
        }
        private object GetPayment_Name(string Payment_Name)
        {
            switch (Payment_Name)
            {
                case "FE0":
                    Payment_Name = "Efectiu";
                    break;
                case "FE1":
                    Payment_Name = "Datafon";
                    break;
                case "FE2":
                    Payment_Name = "Fidelia";
                    break;
                case "FE3":
                    Payment_Name = "Punts CPB";
                    break;
                case "FE4":
                    Payment_Name = "";
                    break;
                case "FE5":
                    Payment_Name = "Targeta crèdit";
                    break;
                case "FE6":
                    Payment_Name = "Euros Fidelia";
                    break;
                case "FE7":
                    Payment_Name = "Targeta Regal";
                    break;
                default:
                    break;
            }
            return Payment_Name;
        }
        private void TICKET_TABLE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedrowindex = TICKET_TABLE.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = TICKET_TABLE.Rows[selectedrowindex];
            string a = Convert.ToString(selectedRow.Cells[0].Value) + "\t" + Convert.ToString(selectedRow.Cells[1].Value);
            string b = selectedRow.Cells[0].Value.ToString() + "\t" + new string('0', 4 - (Convert.ToInt32(selectedRow.Cells[1].Value) + 1).ToString().Length) + (Convert.ToInt32(selectedRow.Cells[1].Value) + 1).ToString();
            TICKETS_LIST.Focus();
            int Point_Start = TICKETS_LIST.Find(a) - 5;
            int Point_End = TICKETS_LIST.Find(b) - Point_Start;
            TICKETS_LIST.Select(Point_Start, Point_End - 5);


        }
        public string TPV(string NTPV)
        {
            switch (NTPV)
            {
                case "1":
                case "3":
                    NTPV = "CAIXES MULTIMEDIA";
                    break;
                case "2":
                    NTPV = NTPV + " - FUJI";
                    break;
                case "9":
                case "14":
                    NTPV = "CAIXES JUGUETTOS/ABACUS";
                    break;
                case "15":
                    NTPV = NTPV + " - TEXTURA";
                    break;
                case "18":
                case "23":
                    NTPV = NTPV + " - MUY MUCHO";
                    break;
                case "19":
                    NTPV = NTPV + " - NAËLLE";
                    break;
                case "20":
                case "21":
                    NTPV = NTPV + " - MODA";
                    break;
                case "22":
                    NTPV = NTPV + " - INFORMÀTICA";
                    break;
                case "24":
                    NTPV = NTPV + " - TWINNER";
                    break;
                case "25":
                case "26":
                case "27":
                    NTPV = NTPV + " - FLECA";
                    break;
                case "50":
                case "51":
                case "52":
                case "53":
                case "54":
                case "55":
                case "56":
                case "57":
                case "58":
                case "59":
                case "60":
                case "62":
                case "70":
                case "71":
                case "72":
                    NTPV = "CAIXES ALIMENTACIÓ";
                    break;
                case "61":
                    NTPV = NTPV + " - LA REAL";
                    break;
                case "201":
                case "202":
                case "203":
                    NTPV = "CAIXES MR. BRICOLAGE";
                    break;
                case "301":
                case "302":
                case "303":
                case "304":
                    NTPV = "CAIXES UEXPRESS";
                    break;
                case "401":
                case "402":
                case "403":
                case "404":
                case "405":
                case "406":
                case "407":
                case "408":
                case "411":
                case "412":
                case "413":
                case "414":
                    NTPV = "CAIXES CAPRABO";
                    break;
                case "30":
                    NTPV = NTPV + " - MELS";
                    break;
                case "11":
                    NTPV = NTPV + " - BOB";
                    break;
                case "5":
                case "6":
                case "7":
                    NTPV = "CAIXES DUTY FREE";
                    break;
                case "65":
                case "81":
                    NTPV = NTPV + " - NATTURALS";
                    break;
                case "63":
                case "64":
                case "66":
                    NTPV = "CAIXES CAFETERIA";
                    break;
                case "13":
                    NTPV = NTPV + " - PARFOIS";
                    break;
                case "12":
                    NTPV = NTPV + " - YVES ROCHER";
                    break;
                case "40":
                    NTPV = NTPV + " - FOM";
                    break;
                case "45":
                    NTPV = NTPV + " - ULANKA";
                    break;
                case "501":
                case "502":
                case "503":
                case "504":
                    NTPV = "CAIXES FRESH";
                    break;
                case "601":
                    NTPV = NTPV + " - PARFOIS II";
                    break;
                default:
                    NTPV = "";
                    break;
            }
            return NTPV;
        }
        public void ONETPV(int[] number)
        {
            try
            {
                string Texto = "";
                DataTable dataTable = new DataTable();
                DataRow rowTable = dataTable.NewRow();
                TICKETS_LIST.Text = "";
                string control = "";
                decimal amount = 0;
                rowTable.Delete();
                dataTable.Columns.Add("Caixa");
                dataTable.Columns.Add("Núm Tiquet");
                dataTable.Columns.Add("Forma de pagament");
                dataTable.Columns.Add("Import", typeof(decimal));

                foreach (int Num in number)
                {
                    MySqlConnection connectionTable = new MySqlConnection(ConnectionAXCAIXES());
                    StringBuilder CommandTable = new StringBuilder();
                    CommandTable.Append("SELECT nterm, nreb, typlin, total FROM datacap where fecha = '" + Convert.ToDateTime(PURCHASE_Date.Text).ToString("yyyyMMdd") + "' and nterm = '" + new string('0', 4 - Num.ToString().Length) + Num.ToString() + "' and typlin like 'FE%' order by tienda, nterm, nreb, nlinea");
                    MySqlCommand CMD = new MySqlCommand(CommandTable.ToString(), connectionTable);
                    connectionTable.Close();
                    connectionTable.Open();
                    MySqlDataReader TABLE = CMD.ExecuteReader();
                    while (TABLE.Read())
                    {
                        if (TABLE[1].ToString() == control)
                        {
                            rowTable.SetField(3, amount + Convert.ToDecimal(TABLE[3]));
                        }
                        else
                        {
                            rowTable = dataTable.NewRow();
                            rowTable[0] = TABLE[0].ToString();
                            rowTable[1] = TABLE[1].ToString();
                            control = rowTable[1].ToString();
                            rowTable[2] = GetPayment_Name(TABLE[2].ToString());
                            rowTable[3] = Convert.ToDecimal(TABLE[3].ToString());
                            amount = Convert.ToDecimal(rowTable[3]);
                            dataTable.Rows.Add(rowTable);
                        }
                    }
                    TABLE.Close();
                    connectionTable.Close();
                }
                TICKET_TABLE.DataSource = dataTable;
                TICKET_TABLE.Font = new Font("Century Gothic", 10F);
                TICKET_TABLE.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TICKET_TABLE.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TICKET_TABLE.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TICKET_TABLE.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                foreach (int Num in number)
                {
                    MySqlConnection connectionIP = new MySqlConnection(Connection());
                    StringBuilder CommandIP = new StringBuilder();
                    CommandIP.Append("SELECT LOC, LOC2 FROM `departaments-cca`.cca where DSC = '" + DPTBox.Text + "' and TPV = '" + Num.ToString() + "';");
                    MySqlCommand CMDIP = new MySqlCommand(CommandIP.ToString(), connectionIP);
                    connectionIP.Close();
                    connectionIP.Open();
                    MySqlDataReader IP = CMDIP.ExecuteReader();
                    string FileIP = "";
                    while (IP.Read())
                    {

                        if (PURCHASE_Date.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                            FileIP = @"\\srvpos\GEINSA\GnxServer\" + IP[1].ToString().Trim() + @"\";
                        }
                        else
                        {
                            Ping CHK = new Ping();
                            PingReply reply = CHK.Send(IP[0].ToString().Trim(), 1000);
                            if (reply.Status == IPStatus.Success)
                            {
                                FileIP = @"\\" + IP[0].ToString().Trim() + @"\geinsa\GnxPOS\Bckup\";
                            }
                        }
                    }
                    if (FileIP == "") { break; }
                    DirectoryInfo dir = new DirectoryInfo(FileIP);
                    foreach (var file in dir.GetFiles())
                    {
                        if (file.CreationTime.Date.ToString().Substring(0, 10) == PURCHASE_Date.Text.ToString().Substring(0, 10) && file.Name.Contains("journal"))
                        {
                            if (File.Exists(Directory.GetCurrentDirectory() + @"\journal-copy.txt"))
                            {
                                File.Delete(Directory.GetCurrentDirectory() + @"\journal-copy.txt");
                            }
                            File.Copy(FileIP + file.Name, Directory.GetCurrentDirectory() + @"\journal-copy.txt");
                            using (StreamReader sr = File.OpenText(Directory.GetCurrentDirectory() + @"\journal-copy.txt"))
                            {
                                Texto += sr.ReadToEnd();
                            }
                        }
                    }
                }
                TICKETS_LIST.Text = Texto;

                if (Texto != "")
                {
                    errorlbl.Text = "";
                }
            }
            catch (Exception)
            {
                errorlbl.Text = "ERROR! Envieu un correu a Fran d'informatica";
            }
        }
        private void GOBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            errorlbl.Text = "";
            int[] TPV;
            try
            {

                switch (TPVBox.Text)
                {
                    case "CAIXES MULTIMEDIA":
                        TPV = new int[] { 1, 3 };
                        break;
                    case "CAIXES JUGUETTOS/ABACUS":
                        TPV = new int[] { 9, 14 };
                        break;
                    case "CAIXES ALIMENTACIÓ":
                        TPV = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 62 };
                        break;
                    case "CAIXES MR. BRICOLAGE":
                        TPV = new int[] { 201, 202, 203 };
                        break;
                    case "CAIXES UEXPRESS":
                        TPV = new int[] { 301, 302, 303, 304 };
                        break;
                    case "CAIXES CAPRABO":
                        TPV = new int[] { 401, 402, 403, 404, 405, 406, 407, 408, 411, 412, 413, 414 };
                        break;
                    case "CAIXES DUTY FREE":
                        TPV = new int[] { 5, 6, 7 };
                        break;
                    case "CAIXES CAFETERIA":
                        TPV = new int[] { 63, 64, 66 };
                        break;
                    case "CAIXES FRESH":
                        TPV = new int[] { 501, 502, 503, 504 };
                        break;
                    default:
                        TPV = new int[] { Convert.ToInt32(TPVBox.Text.Substring(0, TPVBox.Text.IndexOf("-") - 1).Trim()) };
                        break;
                }
                ONETPV(TPV);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception)
            {

                errorlbl.Text = "ERROR! Ha de seleccionar una data, el departament i la caixa";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Control_Screen CS = (Control_Screen)this.ParentForm;
            StartTimeTK.Interval = 1;
            StartTimeTK.Start();

            CS.TIQUETBtn.Image = Properties.Resources.icons8_purchase_order_50px;
            Hide();
        }

        private void StartTimeTK_Tick(object sender, EventArgs e)
        {
            Control_Screen CS = (Control_Screen)this.ParentForm;
            CS.LEFTBar.Size = new Size(CS.LEFTBar.Width + 20, CS.LEFTBar.Height);
            if (CS.LEFTBar.Width >= 245)
            {
                CS.LEFTBar.Width = 245;
                StartTimeTK.Stop();
            }
        }
    }
}