using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eines_ATT_Clients
{

    public partial class Tiquet : UserControl
    {
        private IConfiguration _config;

        public Tiquet(IConfiguration config)
        {
            _config = config;
            Hide();
            InitializeComponent();

            SQL sql = new SQL(_config);
            string lines = sql.AllowedBussiness(Control_Screen.GETUSER);

            for (int i = 0; i < 19; i++)
            {
                if (lines.Split(';')[i].ToString().Trim() != "NO")
                {
                    int Y = i >= 9 ? 2 : 1;
                    TICKET_TABLE.ForeColor = System.Drawing.Color.Black;
                    List<string> list = sql.GetDepartmentName($"{i + Y}");
                    if (list != null)
                        DPTBox.Items.AddRange(list.ToArray());
                }
            }
        }

        private static readonly int[] foodsTPV = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 70, 71, 72 };
        private static readonly int[] toysTPV = new int[] { 9, 14, 157, 158, 159 };
        private static readonly int[] multimediaTPV = new int[] { 1, 2, 3, 120, 121, 122, 123, 124 };
        private static readonly int[] bakeryTPV = new int[] { 25, 26, 27 };
        private static readonly int[] bricolageTPV = new int[] { 201, 202, 203 };
        private static readonly int[] sportsTPV = new int[] { 24, 40, 151, 152, 153, 701 };
        private static readonly int[] fashionTPV = new int[] { 15, 19, 20, 21, 131, 132, 133, 134, 135, 136, 137 };
        private static readonly int[] ulankaTPV = new int[] { 145 };
        private static readonly int[] timeRoadTPV = new int[] { 141 };
        private static readonly int[] parfoisTPV = new int[] { 13, 111, 112, 601 };
        private static readonly int[] cafeteriaTPV = new int[] { 63, 64, 66 };
        private static readonly int[] freshTPV = new int[] { 501, 502, 503, 504 };
        private static readonly int[] natturalsTPV = new int[] { 65, 81 };
        private static readonly int[] laMassanaTPV = new int[] { 730, 731, 732 };
        private static readonly int[] bob2TPV = new int[] { 720 };
        private static readonly int[] muyMuchoTPV = new int[] { 18, 710 };

        private Dictionary<string, int[]> managerTPV = new Dictionary<string, int[]>()
        {
            ["54992"] = foodsTPV,
            ["62081"] = foodsTPV,
            ["77585"] = toysTPV,
            ["84638"] = bakeryTPV,
            ["84930"] = sportsTPV,
            ["91996"] = fashionTPV.Concat(ulankaTPV).Concat(parfoisTPV).Concat(timeRoadTPV).ToArray(),
            ["100505"] = bricolageTPV,
            //["100332"] = fashionTPV.Concat(ulankaTPV).Concat(parfoisTPV).Concat(timeRoadTPV).ToArray(), <-- Usuario jubilado
            ["100372"] = muyMuchoTPV.Concat(natturalsTPV).ToArray(),
            ["101238"] = foodsTPV,
            ["102920"] = multimediaTPV,
            ["103243"] = foodsTPV,
            ["103399"] = cafeteriaTPV,
            ["103942"] = bricolageTPV,
            ["104777"] = parfoisTPV.Concat(ulankaTPV).Concat(timeRoadTPV).ToArray()
        };

        public void AddComboBoxItems(string NTPV)
        {
            string TPVResult = string.Empty;
            terminal.TryGetValue(NTPV, out string terminalName);
            TPVResult = Show_Grup.Checked ? $"CAIXES {terminalName}" : $"{NTPV} - {terminalName}";
            if (!string.IsNullOrEmpty(terminalName))
            {
                if (TPVBox.Items.Contains(TPVResult))
                    return;

                TPVBox.Items.Add(TPVResult);
                return;
            }
        }
        private void DPTBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            TPVBox.Items.Clear();
            SQL sql = new SQL(_config);
            sql.GetTPV(this, managerTPV, DPTBox.Text, out string errorMessage);
            if (string.IsNullOrEmpty(errorMessage))
            {
                ErrorLbl(errorMessage, Color.Red);
                return;
            }
            var elements = TPVBox.Items.Cast<string>();
            string[] sorted = elements
                    .OrderBy(item =>
                    {
                        if (elements.Contains("CAIXES"))
                            return item.Split(' ').ElementAtOrDefault(1)?.Trim() ?? item;

                        return int.TryParse(item.Split('-')[0].Trim(), out int res) ? res.ToString("D10") : item;
                    })
                    .ToArray();
            TPVBox.Items.Clear();
            TPVBox.Items.AddRange(sorted);
        }
        private Dictionary<string, string> PaymentMethod = new Dictionary<string, string>()
        {
            ["FE0"] = "Efectiu",
            ["FE1"] = "Datafon",
            ["FE2"] = "Fidelia",
            ["FE3"] = "Punts CPB",
            ["FE5"] = "Targeta crèdit",
            ["FE6"] = "Euros Fidelia",
            ["FE7"] = "Targeta Regal"
        };

        private void TICKET_TABLE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedrowindex = TICKET_TABLE.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = TICKET_TABLE.Rows[selectedrowindex];
            if (PURCHASE_Date.Value.Date == DateTime.Today.Date)
            {
                string nTerm = selectedRow.Cells["Caixa"].Value?.ToString() ?? "";
                string nReb = selectedRow.Cells["Núm Tiquet"].Value?.ToString() ?? "";

                string searchCurrent = nTerm + "\t" + nReb;

                TICKETS_LIST.Focus();

                int startIndex = TICKETS_LIST.Find(searchCurrent);

                if (startIndex != -1)
                {
                    int safeStart = Math.Max(0, startIndex - 5);

                    int nextTicketNum = Convert.ToInt32(nReb) + 1;
                    string searchNext = nTerm + "\t" + nextTicketNum.ToString().PadLeft(nReb.Length, '0');

                    int endIndex = TICKETS_LIST.Find(searchNext, startIndex + searchCurrent.Length, RichTextBoxFinds.None);

                    int length;
                    if (endIndex != -1)
                    {
                        length = (endIndex - 5) - safeStart;
                    }
                    else
                    {
                        length = TICKETS_LIST.TextLength - safeStart;
                    }

                    if (length > 0)
                    {
                        TICKETS_LIST.Select(safeStart, length);
                        TICKETS_LIST.ScrollToCaret(); // Para que el scroll se mueva al ticket
                    }
                }
                else
                {
                    ErrorLbl("No s'ha trobat el tiquet al diari", Color.Orange);
                }
            }
            else
            {
                string nterm = selectedRow.Cells[0].Value.ToString();
                string nreb = selectedRow.Cells[1].Value.ToString();
                SQL sql = new SQL(_config);
                TICKETS_LIST.Clear();
                sql.Check_Tiquet(nreb, nterm, TICKETS_LIST, PURCHASE_Date.Value.Date.ToString("yyyyMMdd"), out string errorMessage);
                if (errorMessage != null)
                    ErrorLbl(errorMessage, Color.Orange);
            }
        }
        private Dictionary<string, string> terminal = new Dictionary<string, string>()
        {
            ["1"] = "MULTIMEDIA",
            ["2"] = "FUJI",
            ["3"] = "MULTIMEDIA",
            ["9"] = "JUGUETTOS / ABACUS",
            ["14"] = "JUGUETTOS / ABACUS",
            ["15"] = "MODA",
            ["18"] = "MUY MUCHO",
            ["19"] = "MODA",
            ["20"] = "MODA",
            ["21"] = "MODA",
            ["22"] = "INFORMÀTICA",
            ["24"] = "FORUM",
            ["25"] = "FLECA",
            ["26"] = "FLECA",
            ["27"] = "FLECA",
            ["50"] = "ALIMENTACIÓ",
            ["51"] = "ALIMENTACIÓ",
            ["52"] = "ALIMENTACIÓ",
            ["53"] = "ALIMENTACIÓ",
            ["54"] = "ALIMENTACIÓ",
            ["55"] = "ALIMENTACIÓ",
            ["56"] = "ALIMENTACIÓ",
            ["57"] = "ALIMENTACIÓ",
            ["58"] = "ALIMENTACIÓ",
            ["59"] = "ALIMENTACIÓ",
            ["60"] = "ALIMENTACIÓ",
            ["62"] = "ALIMENTACIÓ",
            ["70"] = "ALIMENTACIÓ",
            ["71"] = "ALIMENTACIÓ",
            ["72"] = "ALIMENTACIÓ",
            ["120"] = "MULTIMEDIA",
            ["121"] = "MULTIMEDIA",
            ["122"] = "MULTIMEDIA",
            ["123"] = "MULTIMEDIA",
            ["124"] = "FUJI",
            ["131"] = "MODA",
            ["132"] = "MODA",
            ["133"] = "MODA",
            ["134"] = "MODA",
            ["135"] = "MODA",
            ["136"] = "MODA",
            ["137"] = "MODA",
            ["141"] = "TIMEROAD",
            ["201"] = "MR. BRICOLAGE",
            ["202"] = "MR. BRICOLAGE",
            ["203"] = "MR. BRICOLAGE",
            ["301"] = "UEXPRESS",
            ["302"] = "UEXPRESS",
            ["303"] = "UEXPRESS",
            ["304"] = "UEXPRESS",
            ["401"] = "CAPRABO",
            ["402"] = "CAPRABO",
            ["403"] = "CAPRABO",
            ["404"] = "CAPRABO",
            ["405"] = "CAPRABO",
            ["406"] = "CAPRABO",
            ["407"] = "CAPRABO",
            ["408"] = "CAPRABO",
            ["410"] = "CAPRABO",
            ["411"] = "CAPRABO",
            ["412"] = "CAPRABO",
            ["413"] = "CAPRABO",
            ["414"] = "CAPRABO",
            ["415"] = "CAPRABO",
            ["416"] = "CAPRABO",
            ["5"] = "DUTY FREE",
            ["6"] = "DUTY FREE",
            ["7"] = "DUTY FREE",
            ["8"] = "DUTY FREE",
            ["105"] = "DUTY FREE",
            ["106"] = "DUTY FREE",
            ["107"] = "DUTY FREE",
            ["108"] = "DUTY FREE",
            ["65"] = "NATTURALS",
            ["81"] = "NATTURALS",
            ["63"] = "CAFETERIA",
            ["64"] = "CAFETERIA",
            ["66"] = "CAFETERIA",
            ["13"] = "PARFOIS",
            ["111"] = "PARFOIS",
            ["112"] = "PARFOIS",
            ["40"] = "FOM",
            ["145"] = "ULANKA",
            ["501"] = "FRESH",
            ["502"] = "FRESH",
            ["503"] = "FRESH",
            ["504"] = "FRESH",
            ["601"] = "PARFOIS II",
            ["701"] = "FOM II",
            ["710"] = "MUY MUCHO II",
            ["730"] = "LA MASSANA",
            ["731"] = "LA MASSANA",
            ["732"] = "LA MASSANA",
            ["720"] = "BOB 2",
            ["151"] = "FORUM",
            ["152"] = "FORUM",
            ["153"] = "FORUM",
            ["157"] = "JUGUETTOS / ABACUS",
            ["158"] = "JUGUETTOS / ABACUS",
            ["159"] = "JUGUETTOS / ABACUS"
        };
        private const int _spaceBetween = 22;
        public void ONETPV(int[] number)
        {
            try
            {
                if (number.Count() <= 0)
                {
                    ErrorLbl(Show_Grup.Checked ? "Ha de seleccionar un grup de Caixes per continuar" : "Ha de seleccionar una caixa per continuar", Color.Red);
                    return;
                }
                TICKETS_LIST.Text = "";
                string[] Group_num = number.Select(Num => new string('0', 4 - Num.ToString().Length) + Num.ToString()).ToArray();

                SQL sql = new SQL(_config);
                DataTable dataTable = sql.CompleteTable(PURCHASE_Date.Value.Date, In_Out.Checked, Group_num, CLIENT_CODE.Text);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["Forma de pagament"] = PaymentMethod.TryGetValue(row["Forma de pagament"].ToString().Trim(), out string methodPayment) ? methodPayment : "";//GetPayment_Name(row.Cells["Forma de pagament"].Value.ToString());
                }
                TICKET_TABLE.Columns.Clear();
                TICKET_TABLE.Rows.Clear();
                TICKET_TABLE.DataSource = dataTable;
                TICKET_TABLE.Font = new Font("Century Gothic", 10F);


                DataGridViewCellStyle DGVCS = new DataGridViewCellStyle();
                DGVCS.Font = new Font("Century Gothic", 8F);
                DGVCS.Alignment = DataGridViewContentAlignment.MiddleCenter;
                TICKET_TABLE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                TICKET_TABLE.AutoSize = true;
                TICKET_TABLE.Width = TICKET_TABLE.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
                TICKETS_LIST.Location = new Point(TICKET_TABLE.Location.X + TICKET_TABLE.Width + _spaceBetween, TICKETS_LIST.Location.Y);
                TICKETS_LIST.Width = Width - TICKET_TABLE.Location.X - TICKET_TABLE.Width - _spaceBetween - TICKET_TABLE.Location.X;


                if (PURCHASE_Date.Value.Date == DateTime.Today.Date)
                {
                    Group_num = number.Select(Num => Num.ToString()).ToArray();
                    List<string> foldersTerm = sql.GetFolderTerm(Group_num, DPTBox.Text);
                    if (foldersTerm == null)
                    {
                        ErrorLbl("No s'ha pogut recuperar els diari de la o les caixes", Color.Orange);
                        return;
                    }
                    foreach (string folderTerm in foldersTerm)
                    {
                        DirectoryInfo dir = new DirectoryInfo(folderTerm);

                        if (dir.Exists)
                        {
                            FileInfo file = dir.GetFiles("*journal*").FirstOrDefault();
                            if (file != null)
                            {
                                using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                {
                                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                                        TICKETS_LIST.Text += sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErrorLbl("ERROR! Envieu un correu a Fran d'informatica", Color.Red);
            }
        }
        private void ErrorLbl(string message, Color asignedColor)
        {
            errorlbl.Text = message;
            cur_Y = errorlbl.Location.Y;
            errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
            errorlbl.Visible = true;
            errorlbl.ForeColor = asignedColor;
            mov_Y = errorlbl.Location.Y;
            Error_Timer.Interval = 1;
            Error_Timer.Start();
        }


        private void GOBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TICKET_TABLE.DataSource = null;
            TICKETS_LIST.Clear();
            //errorlbl.Text = "";
            int[] TPV;
            try
            {
                if (Show_Grup.Checked)
                    TPV = terminal.Where(t => t.Value == TPVBox.Text.Replace("CAIXES ", "")).Select(t => int.Parse(t.Key)).ToArray();
                else
                    TPV = new int[] { Convert.ToInt32(TPVBox.Text.Substring(0, TPVBox.Text.IndexOf("-") - 1).Trim()) };
                ONETPV(TPV);
            }
            catch (Exception)
            {
                ErrorLbl("Ha de seleccionar OBLIGATORIAMENT el departament, la caixa i la data", Color.Red);
            }
            Cursor.Current = Cursors.Default;
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

        private void Download_File_Click(object sender, EventArgs e)
        {
            Downloadlbl.Visible = true;
            progressBar1.Visible = true;
            Downloading.RunWorkerAsync();
        }


        private void DownloadTicketToday(string Path, DataGridViewRow row, DialogResult allJournal, int[] termsNum)
        {

            SQL sql = new SQL(_config);
            List<string> foldersTerm = sql.GetFolderTerm(termsNum.Select(tn => tn.ToString()).ToArray(), DPTBox.Text);
            using (StreamWriter sw = new StreamWriter(Path, false))
            {
                foreach (string folderTerm in foldersTerm)
                {
                    DirectoryInfo dir = new DirectoryInfo(folderTerm);
                    FileInfo file = dir.GetFiles("*journal*").FirstOrDefault();
                    using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                        {

                            if (allJournal != DialogResult.Yes)
                            {
                                sw.Write(sr.ReadToEnd());

                                continue;
                            }

                            string tpvNum = row.Cells["Caixa"].Value.ToString();
                            string ticket = row.Cells["Núm Tiquet"].Value.ToString();
                            string searchLine = tpvNum + "\t" + ticket;
                            string line = string.Empty;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains(searchLine))
                                    sw.WriteLine(line);
                            }
                        }
                    }
                }
            }
        }
        private DialogResult Result(DataGridViewRow row)
        {
            DialogResult result = DialogResult.No;
            if (TICKET_TABLE.SelectedCells.Count > 0)
            {
                result = MessageBox.Show($"Vols descarregar solament el ticket {row.Cells["Núm Tiquet"].Value}?", "Descarregar Tiquet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    result = MessageBox.Show("Es descarregaran tots els tiquets de la caixa.", "Descarregar Caixa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return result;
        }

        private void Downloading_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                DataGridViewRow row = TICKET_TABLE.Rows[TICKET_TABLE.SelectedCells[0].RowIndex];
                DialogResult result = Result(row);


                try
                {
                    FolderBrowserDialog ofd = new FolderBrowserDialog();
                    int[] numero;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        progressBar1.Value = 1;
                        progressBar1.Step = 1;

                        if (Show_Grup.Checked)
                            numero = terminal.Where(t => t.Value == TPVBox.Text.Replace("CAIXES ", "")).Select(t => int.Parse(t.Key)).ToArray();
                        else
                            numero = new int[] { Convert.ToInt32(TPVBox.Text.Substring(0, TPVBox.Text.IndexOf("-") - 1).Trim()) };


                        string Path = $"{ofd.SelectedPath}\\{TPVBox.Text}.txt";
                        SQL sql = new SQL(_config);

                        if (PURCHASE_Date.Value.Date < DateTime.Today.Date)
                            sql.DownloadTicketHistory(Path, numero, result, row, PURCHASE_Date.Value.Date.ToString("yyyyMMdd"), progressBar1);
                        else
                            DownloadTicketToday(Path, row, result, numero);

                        ErrorLbl("Descarrega Completada", Color.Green);

                        Downloadlbl.Visible = false;
                        progressBar1.Visible = false;
                        progressBar1.Maximum = 100;
                        Process.Start("explorer.exe", Path);
                    }
                    else
                    {
                        Downloadlbl.Visible = false;
                        progressBar1.Visible = false;

                        ErrorLbl("Descarrega cancel·lada", Color.Orange);
                        return;
                    }
                }
                catch
                {
                    Downloadlbl.Visible = false;
                    progressBar1.Visible = false;

                    ErrorLbl("Ha de seleccionar OBLIGATORIAMENT el departament, la caixa i la data", Color.Red);
                }
            });
        }

        private void Show_Grup_CheckedChanged(object sender, EventArgs e)
        {
            if (DPTBox.Text != "")
                DPTBox_SelectedIndexChanged(sender, e);
        }
        public int mov_Y;
        public int cur_Y;
        private void Error_Timer_Tick(object sender, EventArgs e)
        {
            errorlbl.Location = new Point(errorlbl.Location.X, mov_Y++);
            if (Error_Timer.Interval == 5000)
            {
                errorlbl.Visible = false;
                Error_Timer.Stop();
            }
            if (mov_Y >= cur_Y)
            {
                errorlbl.Location = new Point(errorlbl.Location.X, cur_Y);
                Error_Timer.Interval = 5000;
            }
        }
    }
}