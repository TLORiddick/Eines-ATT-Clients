using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eines_ATT_Clients
{
    public partial class Voucher : UserControl
    {
        private IConfiguration _config;

        public Voucher(IConfiguration config)
        {
            _config = config;
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
        public string ConnectionIP()
        {
            return $"server={_config["SQLParameters:server"]};Uid={_config["SQLParameters:uid"]};Pwd={_config["SQLParameters:pwd"]};database={_config["SQLParameters:dtbs:dpt"]}";
        }
        public string Connection()
        {
            return $"server={_config["SRVPOSParameters:server"]};uid={_config["SRVPOSParameters:uid"]};pwd={_config["SRVPOSParameters:pwd"]};database={_config["SRVPOSParameters:dtbs:d1"]};port={_config["SRVPOSParameters:prt:p1"]}";
        }
        public string ConnectionJournal()
        {
            return $"server={_config["SQLParameters:server"]};Uid={_config["SQLParameters:uid"]};Pwd={_config["SQLParameters:pwd"]};database={_config["SQLParameters:dtbs:jrnl"]}";
        }
        public string ConnectionCupones()
        {
            return $"server={_config["SRVPOSParameters:server"]};uid={_config["SRVPOSParameters:uid"]};pwd={_config["SRVPOSParameters:pwd"]};database={_config["SRVPOSParameters:dtbs:d2"]};port={_config["SRVPOSParameters:prt:p2"]}";
        }

        private Dictionary<int, string> NameCenter = new Dictionary<int, string>()
        {
            [1] = "SUPER U",
            [2] = "MR. BRICOLAGE",
            [3] = "UEXPRESS",
            [4] = "CAPRABO",
            [5] = "MELS",
            [6] = "BOB",
            [7] = "DUTY FREE",
            [8] = "NATURALS",
            [9] = "CAFETERIA",
            [11] = "PARFOIS",
            [12] = "YVES ROCHER",
            [13] = "FOM",
            [14] = "ULANKA",
            [15] = "FRESH",
            [16] = "PARFOIS II",
            [17] = "FOM II",
            [18] = "MUY MUCHO II",
            [19] = "BOB II",
            [20] = "MASSANA"
        };

        public string Get_Type(string typlin, bool underZero)
        {
            string Type = "";
            switch (typlin)
            {
                case "CUP":
                    Type = underZero ? "Cupó cancel·lat" : "Cupó adquirit";
                    break;
                case "CUR":
                    Type = "Cupó utilitzat";
                    break;
                default:
                    break;
            }
            return Type;
        }
        private void ClearScreen()
        {
            ERROR.Visible = false;
            PrintTxt.Clear();
            ClientTxt.Clear();
            VoucherAmountTxt.Clear();
            StateVoucherTxt.Clear();
            ExpirationTxt.Clear();
            ExistServerPosTxt.Clear();
            TiquetPreviewTxt.Clear();
            StateVoucherLbl.ForeColor = Color.White;
            StateVoucherLbl.Font = new Font(StateVoucherLbl.Font, FontStyle.Regular);
            ExistServerPosLbl.ForeColor = Color.White;
            ExistServerPosLbl.Font = new Font(ExistServerPosLbl.Font, FontStyle.Regular);
        }
        private DataTable FindVoucher(string fecha, string numVoucher)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection()))
            {
                try
                {
                    conn.Open();
                    StringBuilder query = new StringBuilder("select fecha as Data, tienda as Botiga, nterm as Caixa, nreb as Tiquet, total as Import, typlin, plu, numero, cliente from ");
                    query.Append(VOUCHER_Dates.Value.Date == DateTime.Now.Date ? "datacap" : "dchistorico");
                    query.Append(" where fecha >= @fecha and numero = @numvoucher and typlin in('CUP', 'CUR') order by fecha, tienda, nterm, nreb, nlinea");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), conn);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@numvoucher", numVoucher);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataTable.Columns.Add("Observacion", typeof(string));
                        return dataTable;

                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"Error al recollir les dades del cupó.\r\n{e.Message}", "Error de cupó", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally { conn.Close(); }

            }
        }
        private void CompleteTicketInfo(DataRow row, string stateVoucher, Color colorVoucher)
        {
            PrintTxt.Text = row["Data"].ToString();
            ClientTxt.Text = row["cliente"].ToString().Trim();
            VoucherAmountTxt.Text = $"{Convert.ToDecimal(row["Import"])} €";
            StateVoucherTxt.Text = stateVoucher;
            StateVoucherLbl.ForeColor = colorVoucher;
            StateVoucherLbl.Font = new Font(StateVoucherLbl.Font, FontStyle.Bold);
        }
        private void ReadFile(string fileVoucher, DataRow row)
        {
            string tempFile = Path.GetTempFileName();
            File.Copy(fileVoucher, tempFile, true);
            using (StreamReader sr = new StreamReader(tempFile, Encoding.Default))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line == null)
                        continue;

                    string[] splitLine = line.Replace("\"", "").Split(',');

                    string offerCode = Array.Find(splitLine, find => find.Contains("codigo"));

                    if (offerCode.Contains(row["plu"].ToString().Trim()))
                    {
                        string EndDate = Array.Find(splitLine, find => find.Contains("fec_fin"));
                        if (string.IsNullOrEmpty(EndDate))
                            continue;

                        EndDate = EndDate.Split(':')[1].Trim();
                        if (string.IsNullOrEmpty(EndDate.Split('/')[2].Trim()))
                            EndDate = $"EndDate{DateTime.Now.Year}";

                        ExpirationTxt.Text = EndDate;
                        string stateVoucher = Convert.ToDateTime(ExpirationTxt.Text) < DateTime.Now ? "Cupó Caducat!" : StateVoucherTxt.Text;
                        CompleteTicketInfo(row, stateVoucher, Color.Red);
                        bool voucherExist = VoucherExists();

                        ExistServerPosTxt.Text = voucherExist ? "Existent" : "No trobat";
                        ExistServerPosLbl.ForeColor = voucherExist ? Color.White : Color.Red;
                        ExistServerPosLbl.Font = new Font(ExistServerPosLbl.Font, voucherExist ? FontStyle.Regular : FontStyle.Bold);
                        break;
                    }
                }
            }
            File.Delete(tempFile);
        }
        private bool VoucherExists()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionCupones()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM cupones WHERE numero = @Voucher";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Voucher", VoucherSerchedTxt.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    return false;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"No s'ha pogut recuperar el cupó de la base de dades.\r\n{e.Message}", "Error Recuperant Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void CercarBtn_Click(object sender, EventArgs e)
        {
            ClearScreen();
            Cursor.Current = Cursors.WaitCursor;
            if (VoucherSerchedTxt.Text != "")
            {
                DataTable dataTable = FindVoucher(VOUCHER_Dates.Value.ToString("yyyyMMdd"), VoucherSerchedTxt.Text.Trim());
                foreach (DataRow row in dataTable.Rows)
                {
                    decimal amount = Convert.ToDecimal(row["Import"]);
                    string typlinString = row["typlin"].ToString().Trim();
                    int.TryParse(row["Botiga"].ToString(), out int numBussiness);

                    row["Botiga"] = NameCenter.TryGetValue(Convert.ToInt32(row["Botiga"]), out string code) ? code : "";
                    row["Observacion"] = Get_Type(typlinString, amount < 0);

                    if (typlinString == "CUP" && amount > 0)
                        CompleteTicketInfo(row, "Pendent d'utilització", Color.DarkOrange);
                    else if (typlinString == "CUR")
                    {
                        CompleteTicketInfo(row, "Cupó utilitzat", Color.Green);
                        continue;
                    }
                    else if (amount < 0)
                    {
                        CompleteTicketInfo(row, "Cupó Cancel·lat", Color.Red);
                        continue;
                    }
                    string GN = $"G{new string('0', 2 - numBussiness.ToString().Length)}{numBussiness}";
                    string fileVoucher = $@"{_config["Paths:GnxServer"]}{GN}\ofertasE.txt";
                    ReadFile(fileVoucher, row);
                }
                dataTable.Columns.Remove("typlin");
                dataTable.Columns.Remove("plu");
                dataTable.Columns.Remove("numero");
                dataTable.Columns.Remove("cliente");
                Voucher_Table.DataSource = dataTable;
                Voucher_Table.ForeColor = Color.Black;
                Voucher_Table.Font = new Font("Microsoft YaHei", 10F);
                Voucher_Table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Voucher_Table.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Voucher_Table.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Voucher_Table.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Voucher_Table.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Voucher_Table.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                GetTicket(Voucher_Table, new DataGridViewCellEventArgs(0, 0));
            }
        }
        private void CompleteTicketPreview(int rowIndex)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionJournal()))
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM tickets WHERE fecha = @Fec AND "/*tienda = @Tie AND */ + "nterm = @Ter AND nreb = @Reb group by tienda, nterm, nreb, nlinea, fecha, num, texto", conn);
                    command.Parameters.AddWithValue("@Fec", Convert.ToDateTime(Voucher_Table.Rows[rowIndex].Cells[0].Value).ToString("yyyy-MM-dd"));
                    //command.Parameters.AddWithValue("@Tie", new string('0', 4 - BN.ToString().Length) + BN);
                    command.Parameters.AddWithValue("@Ter", Voucher_Table.Rows[rowIndex].Cells[2].Value);
                    command.Parameters.AddWithValue("@Reb", Voucher_Table.Rows[rowIndex].Cells[3].Value);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TiquetPreviewTxt.Text += dataReader[6] + Environment.NewLine;
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"Error al trobar el ticket del cupó.\r\n{e.Message}", "Erro de ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private string FileIP(int rowIndex)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionIP()))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT LOC FROM `departaments-cca`.cca where DPT = @BN and TPV = @TPVN";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    string getBussinessNum = NameCenter.FirstOrDefault(x => x.Value == Voucher_Table.Rows[rowIndex].Cells["Botiga"].Value.ToString()).Key.ToString();
                    cmd.Parameters.AddWithValue("@BN", getBussinessNum);
                    cmd.Parameters.AddWithValue("@TPVN", Voucher_Table.Rows[rowIndex].Cells["Caixa"].Value.ToString());
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    string fileIP = "";
                    while (dataReader.Read())
                    {
                        Ping CHK = new Ping();
                        PingReply reply = CHK.Send(dataReader[0].ToString().Trim(), 100);
                        if (reply.Status == IPStatus.Success)
                        {
                            fileIP = $@"\\{dataReader[0].ToString().Trim()}{_config["Paths:Data"]}";
                        }
                    }
                    return fileIP;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"No s'ha trobat la caixa per a recuperar el ticket.\r\n{e.Message}", "Caixa no trobada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";

                }
                finally
                { conn.Close(); }
            }
        }
        private void GetTicket(object sender, DataGridViewCellEventArgs e)
        {
            if (VOUCHER_Dates.Value.Date != DateTime.Now.Date)
            {
                TiquetPreviewTxt.Clear();
                if (Voucher_Table.Rows.Count > 0)
                    CompleteTicketPreview(e.RowIndex);

            }
            else
            {
                if (Voucher_Table.Rows.Count == 0)
                    return;
                string fileIP = FileIP(e.RowIndex);
                string tempFile = Path.GetTempFileName();
                string Texto = string.Empty;
                string botNum = NameCenter.FirstOrDefault(x => x.Value == Voucher_Table.Rows[e.RowIndex].Cells["Botiga"].Value.ToString()).Key.ToString();
                string tpvNum = Voucher_Table.Rows[e.RowIndex].Cells["Caixa"].Value.ToString();
                string tikNum = Voucher_Table.Rows[e.RowIndex].Cells["Tiquet"].Value.ToString();
                string Bot = new string('0', 4 - botNum.Length) + botNum;
                string Tpv = new string('0', 4 - tpvNum.Length) + tpvNum;
                string Tik = new string('0', 4 - tikNum.Length) + tikNum;
                DirectoryInfo dir = new DirectoryInfo(fileIP);
                foreach (var file in dir.GetFiles())
                {
                    if (file.CreationTime.Date.ToString().Substring(0, 10) == PrintTxt.Text.ToString().Substring(0, 10) && file.Name.Contains("journal"))
                    {
                        File.Copy(fileIP + file.Name, tempFile, true);
                        string line = "";
                        using (StreamReader sr = new StreamReader(tempFile, Encoding.Default))
                        {
                            string FindText = Bot + "\t" + Tpv + "\t" + Tik;
                            TiquetPreviewTxt.Text = "";
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Substring(0, 14) == FindText)
                                {
                                    Texto += line.Substring(31, line.Length - 31) + Environment.NewLine;
                                }
                            }
                        }
                    }
                }
                TiquetPreviewTxt.Text = Texto;
            }
        }
    }
}
