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
    public partial class Voucher : UserControl
    {
        public Voucher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control_Screen CS = (Control_Screen)this.ParentForm;
            StartTimeVC.Interval = 1;
            StartTimeVC.Start();

            CS.CUPONESBtn.Image = Properties.Resources.icons8_voucher_50px;
            Hide();
        }
        private void StartTimeVC_Tick(object sender, EventArgs e)
        {
            Control_Screen CS = (Control_Screen)this.ParentForm;
            CS.LEFTBar.Size = new Size(CS.LEFTBar.Width + 20, CS.LEFTBar.Height);
            if (CS.LEFTBar.Width >= 245)
            {
                CS.LEFTBar.Width = 245;
                StartTimeVC.Stop();
            }
        }
        private string server;
        private string uid;
        private string password;
        public string ConnectionIP()
        {
            server = "192.168.29.11";
            uid = "CCA";
            password = "Attclients02";
            string connectionString;
            return connectionString = "SERVER=" + server + ";" + "user id=" + uid + ";" + "PASSWORD=" + password + ";";
        }
        public string Connection()
        {
            string connectionString = "datasource=srvfidelia;port=3306;username=root;password=gnxpos;database=stocks;";
            if (VOUCHER_Dates.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                connectionString = "datasource=srvpos;port=3306;username=root;password=gnxpos;database=stocks;";
            }

            return connectionString;
        }
        public string Get_NameCenter(int NumberCenter)
        {
            string CenterName = "";
            switch (NumberCenter)
            {
                case 1:
                    CenterName = "SUPER U";
                    break;
                case 2:
                    CenterName = "MR. BRICOLAGE";
                    break;
                case 3:
                    CenterName = "UEXPRESS";
                    break;
                case 4:
                    CenterName = "CAPRABO";
                    break;
                case 5:
                    CenterName = "MELS";
                    break;
                case 6:
                    CenterName = "BOB";
                    break;
                case 7:
                    CenterName = "DUTY FREE";
                    break;
                case 8:
                    CenterName = "NATURALS";
                    break;
                case 9:
                    CenterName = "CAFETERIA";
                    break;
                case 11:
                    CenterName = "PARFOIS";
                    break;
                case 12:
                    CenterName = "YVES ROCHER";
                    break;
                case 13:
                    CenterName = "FOM";
                    break;
                case 14:
                    CenterName = "ULANKA";
                    break;
                case 15:
                    CenterName = "FRESH";
                    break;
                case 16:
                    CenterName = "PARFOIS II";
                    break;
                case 17:
                    CenterName = "FOM II";
                    break;
                case 18:
                    CenterName = "MUY MUCHO II";
                    break;
                default:
                    break;
            }
            return CenterName;
        }
        public string Get_Type(string typlin)
        {
            string Type = "";
            switch (typlin)
            {
                case "CUP":
                    Type = "Cupó adquirit";
                    break;
                case "CUR":
                    Type = "Cupó utilitzat";
                    break;
                case "SUP":
                    Type = "Cupó cancel·lat";
                    break;
                default:
                    break;
            }
            return Type;
        }
        private void CercarBtn_Click(object sender, EventArgs e)
        {
            ERROR.Visible = false;
            PrintTxt.Clear();
            ClientTxt.Clear();
            VoucherAmountTxt.Clear();
            StateVoucherTxt.Clear();
            ExpirationTxt.Clear();
            TiquetPreviewTxt.Clear();
            Cursor.Current = Cursors.WaitCursor;
            if (VoucherSerchedTxt.Text != "")
            {
                try
                {
                    string Texto = "";
                    DataTable dataTable = new DataTable();
                    DataRow rowTable;
                    dataTable.Columns.Add("Data", typeof(DateTime));
                    dataTable.Columns.Add("Botiga");
                    dataTable.Columns.Add("Caixa");
                    dataTable.Columns.Add("Tiquet");
                    dataTable.Columns.Add("Import", typeof(decimal));
                    dataTable.Columns.Add("Observacion");
                    MySqlConnection connection = new MySqlConnection(Connection());
                    StringBuilder Command = new StringBuilder();
                    Command.Append("select tienda, nterm, nreb, typlin, fecha, numero, total, cliente, plu from datacap where fecha >= date('" + VOUCHER_Dates.Value.ToString("yyyyMMdd") + "') and numero = @numvoucher order by fecha, tienda, nterm, nreb, nlinea");
                    MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
                    CMD.Parameters.AddWithValue("@numvoucher", VoucherSerchedTxt.Text.Trim());
                    connection.Close();
                    connection.Open();
                    MySqlDataReader VOUCHER = CMD.ExecuteReader();
                    int BN = 0;
                    int TPVN = 0;
                    int TIKN = 0;
                    while (VOUCHER.Read())
                    {
                        rowTable = dataTable.NewRow();
                        rowTable[0] = Convert.ToDateTime(VOUCHER[4]).ToString("dd/MM/yyyy");
                        rowTable[1] = Get_NameCenter(Convert.ToInt32(VOUCHER[0]));
                        rowTable[2] = VOUCHER[1].ToString().Trim();
                        rowTable[3] = VOUCHER[2].ToString().Trim();
                        rowTable[4] = Convert.ToDecimal(VOUCHER[6]);
                        rowTable[5] = Get_Type(VOUCHER[3].ToString().Trim());
                        string PLU = VOUCHER[8].ToString().Trim();
                        dataTable.Rows.Add(rowTable);
                        if (VOUCHER[3].ToString().Trim() == "CUP")
                        {
                            PrintTxt.Text = Convert.ToDateTime(VOUCHER[4]).ToString("dd/MM/yyyy");
                            ClientTxt.Text = VOUCHER[7].ToString().Trim();
                            VoucherAmountTxt.Text = VOUCHER[6].ToString().Trim() + " €";
                            StateVoucherTxt.Text = "Pendent d'utilització";
                            StateVoucherTxt.ForeColor = Color.DarkOrange;
                            BN = Convert.ToInt32(VOUCHER[0].ToString().Trim());
                            TPVN = Convert.ToInt32(VOUCHER[1].ToString().Trim());
                            TIKN = Convert.ToInt32(VOUCHER[2].ToString().Trim());
                            string GN = "G" + new string('0', 2 - Convert.ToInt32(VOUCHER[0]).ToString().Length) + Convert.ToInt32(VOUCHER[0]);
                            string FileVoucher = @"\\192.168.192.101\GEINSA\GnxServer\" + GN + @"\cupones.txt";
                            if (File.Exists(Directory.GetCurrentDirectory() + @"\cupones-copy.txt"))
                            {
                                File.Delete(Directory.GetCurrentDirectory() + @"\cupones-copy.txt");
                            }
                            File.Copy(FileVoucher, Directory.GetCurrentDirectory() + @"\cupones-copy.txt");
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\cupones-copy.txt", Encoding.Default))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (line.Substring(0,5).Trim() == PLU)
                                    {
                                        ExpirationTxt.Text = line.Substring(49, 10);
                                        if (Convert.ToDateTime(ExpirationTxt.Text) <= DateTime.Now)
                                        {
                                            StateVoucherTxt.ForeColor = Color.DarkRed;
                                            ExpirationTxt.ForeColor = Color.DarkRed;
                                            StateVoucherTxt.Text = "Cupó Caducat!";
                                        }
                                        else
                                        {
                                            StateVoucherTxt.ForeColor = Color.Black;
                                            ExpirationTxt.ForeColor = Color.Black;
                                        }
                                        break;
                                    }
                                }
                                
                            }
                        }
                        else if (VOUCHER[3].ToString().Trim() == "CUR")
                        {
                            StateVoucherTxt.Text = "Cupó utilitzat";
                            StateVoucherTxt.ForeColor = Color.ForestGreen;
                        }
                        else if (VOUCHER[3].ToString().Trim() == "SUP")
                        {
                            StateVoucherTxt.Text = "Cupó Cancel·lat";
                            StateVoucherTxt.ForeColor = Color.DarkRed;
                        }
                    }
                    VOUCHER.Close();
                    connection.Close();
                    Voucher_Table.DataSource = dataTable;
                    Voucher_Table.ForeColor = Color.Black;
                    Voucher_Table.Font = new Font("Century Gothic", 10F);
                    Voucher_Table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Voucher_Table.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Voucher_Table.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Voucher_Table.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Voucher_Table.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Voucher_Table.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    MySqlConnection connectionIP = new MySqlConnection(ConnectionIP());
                    StringBuilder CommandIP = new StringBuilder();
                    CommandIP.Append("SELECT LOC FROM `departaments-cca`.cca where DPT = @BN and TPV = @TPVN;");
                    MySqlCommand CMDIP = new MySqlCommand(CommandIP.ToString(), connectionIP);
                    CMDIP.Parameters.AddWithValue("@BN", BN);
                    CMDIP.Parameters.AddWithValue("@TPVN", TPVN);
                    connectionIP.Close();
                    connectionIP.Open();
                    MySqlDataReader IP = CMDIP.ExecuteReader();
                    string FileIP = "";
                    while (IP.Read())
                    {
                        Ping CHK = new Ping();
                        PingReply reply = CHK.Send(IP[0].ToString().Trim(), 1000);
                        if (reply.Status == IPStatus.Success)
                        {
                            FileIP = @"\\" + IP[0].ToString().Trim() + @"\geinsa\GnxPOS\Bckup\";
                            if (VOUCHER_Dates.Value.ToShortDateString() == DateTime.Today.ToShortDateString())
                            {
                                FileIP = @"\\" + IP[0].ToString().Trim() + @"\geinsa\GnxPOS\Data\";
                            }
                        }
                    }
                    DirectoryInfo dir = new DirectoryInfo(FileIP);
                    foreach (var file in dir.GetFiles())
                    {
                        if (file.CreationTime.Date.ToString().Substring(0, 10) == PrintTxt.Text.ToString().Substring(0, 10) && file.Name.Contains("journal"))
                        {
                            if (File.Exists(Directory.GetCurrentDirectory() + @"\journal-copy.txt"))
                            {
                                File.Delete(Directory.GetCurrentDirectory() + @"\journal-copy.txt");
                            }
                            File.Copy(FileIP + file.Name, Directory.GetCurrentDirectory() + @"\journal-copy.txt");
                            string line = "";
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\journal-copy.txt", Encoding.Default))
                            {
                                string Bot = new string('0', 4 - Convert.ToString(BN).Length) + Convert.ToString(BN);
                                string Tpv = new string('0', 4 - Convert.ToString(TPVN).Length) + Convert.ToString(TPVN);
                                string Tik = new string('0', 4 - Convert.ToString(TIKN).Length) + Convert.ToString(TIKN);
                                string FindText = Bot + "\t" + Tpv + "\t" + Tik;
                                TiquetPreviewTxt.Text = "";
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (line.Substring(0, 14) == FindText)
                                    {
                                        Texto+= line.Substring(31, line.Length - 31) + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }
                    TiquetPreviewTxt.Text = Texto;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    ERROR.Visible = true;
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {

            }
        }
    }
}
