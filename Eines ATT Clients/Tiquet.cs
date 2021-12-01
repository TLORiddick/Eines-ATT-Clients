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
using System.Diagnostics;
using System.Reflection;

namespace Eines_ATT_Clients
{

    public partial class Tiquet : UserControl
    {

        public Tiquet()
        {
            Hide();
            InitializeComponent();
            string Name = Control_Screen.GETUSER;
            MySqlConnection connection = new MySqlConnection(Connection());
            StringBuilder Command = new StringBuilder();
            Command.Append("SELECT `1`,`2`,`3`,`4`,`5`,`6`,`7`,`8`,`9`,`11`,`12`,`13`,`14`,`15`,`16`,`17`,`18` FROM `departaments-cca`.allowed where Empleado = '" + Name + "'");
            MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
            connection.Close();
            connection.Open();
            MySqlDataReader USER = CMD.ExecuteReader();
            string[] lines = new string[USER.VisibleFieldCount];
            while (USER.Read())
            {
                for (int X = 0; X < USER.VisibleFieldCount; X++)
                {
                    lines[X] = USER[X].ToString();
                }

            }
            connection.Close();
            int Y = 1;
            for (int i = 0; i < 17; i++)
            {

                if (lines[i].ToString().Trim() != "NO")
                {
                    if (i >= 9) { Y = 2; }
                    TICKET_TABLE.ForeColor = System.Drawing.Color.Black;
                    StringBuilder Commands = new StringBuilder();
                    Commands.Append("SELECT DSC FROM `departaments-cca`.cca where DPT = '" + (i + Y) + "' group by DSC order by DPT");
                    MySqlCommand CMDs = new MySqlCommand(Commands.ToString(), connection);
                    connection.Close();
                    connection.Open();
                    MySqlDataReader DPT = CMDs.ExecuteReader();
                    while (DPT.Read())
                    {
                        DPTBox.Items.Add(DPT[0].ToString().Trim());
                    }
                    DPT.Close();
                    connection.Close();
                }

            }

        }
        private string server;
        private string uid;
        private string password;

        public string Connection()
        {
            server = "192.168.29.11";
            uid = "CCA";
            password = "Attclients02";
            string connectionString = "SERVER=" + server + ";" + "user id=" + uid + ";" + "PASSWORD=" + password + ";";
            return connectionString;
        }
        public string ConnectionFDL()
        {
            string connectionString = "datasource=srvfidelia;port=3306;username=root;password=gnxpos;database=journal;";
            return connectionString;
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

        private bool ncaja(string resp, string caja)
        {
            bool cajacorrecta;
            cajacorrecta = false;
            switch (resp)
            {
                case "84930":
                    if (caja == "24" || caja == "40" || caja == "701")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "103399":
                    if (caja == "63" || caja == "64" || caja == "66")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "100332":
                    if (caja == "15" || caja == "19" || caja == "20" || caja == "21")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "104250":
                case "98444":
                case "104090":
                case "1635":
                case "103982":
                case "95548":
                case "104500":
                case "103470":
                case "105661":
                case "54992":
                case "78727":
                case "105193":
                case "103784":
                case "100541":
                case "91996":
                case "88561":
                    cajacorrecta = true;                    
                    break;
                case "90875":
                        cajacorrecta = true;
                    break;
                case "77585":
                    if (caja == "9" || caja == "14")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "100372":
                    if (caja == "18" || caja == "710" || caja == "65" || caja == "81")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "93901":
                case "100505":
                    if (caja == "201" || caja == "202" || caja == "203")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "102920":
                    if (caja == "1" || caja == "2" || caja == "3")
                    {
                        cajacorrecta = true;
                    }
                    break;
                case "84638":
                    if (caja == "25" || caja == "26" || caja == "27")
                    {
                        cajacorrecta = true;
                    }
                    break;
                default:
                    break;
            }
            return cajacorrecta;
        }
        private void DPTBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            TPVBox.Items.Clear();
            MySqlConnection connection = new MySqlConnection(Connection());
            connection.Close();
            connection.Open();
            StringBuilder Command = new StringBuilder();
            Command.Append("SELECT TPV FROM `departaments-cca`.cca where DSC = '" + DPTBox.Text + "' order by DPT");
            MySqlCommand CMD = new MySqlCommand(Command.ToString(), connection);
            connection.Close();
            connection.Open();
            MySqlDataReader DPT = CMD.ExecuteReader();
            bool checkindex = false;
            while (DPT.Read())
            {
                bool chkc;
                chkc = ncaja(Control_Screen.nuser, DPT[0].ToString().Trim());
                if (chkc)
                {
                    string TPVResult = string.Empty;
                    if (Show_Grup.Checked)
                    {
                        TPVResult = TPV(DPT[0].ToString().Trim(), true);
                    }
                    else
                    {
                        TPVResult = TPV(DPT[0].ToString().Trim(), false);
                    }
                    if (TPVResult != "")
                    {
                        foreach (string index in TPVBox.Items)
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
            if (PURCHASE_Date.Value.Date == DateTime.Today.Date)
            {
                string a = Convert.ToString(selectedRow.Cells[0].Value) + "\t" + Convert.ToString(selectedRow.Cells[1].Value);
                string b = selectedRow.Cells[0].Value.ToString() + "\t" + new string('0', 4 - (Convert.ToInt32(selectedRow.Cells[1].Value) + 1).ToString().Length) + (Convert.ToInt32(selectedRow.Cells[1].Value) + 1).ToString();
                TICKETS_LIST.Focus();
                int Point_Start = TICKETS_LIST.Find(a) - 5;
                int Point_End = TICKETS_LIST.Find(b) - Point_Start;
                TICKETS_LIST.Select(Point_Start, Point_End - 5);
            }
            else
            {
                string nterm = selectedRow.Cells[0].Value.ToString();
                string nreb = selectedRow.Cells[1].Value.ToString();
                Check_Tiquet(nreb, nterm);
            }
        }
        public string TPV(string NTPV, bool Group)
        {
            if (Group)
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
                    case "701":
                        NTPV = NTPV + " - FOM II";
                        break;
                    case "710":
                        NTPV = NTPV + " - MUY MUCHO II";
                        break;
                    default:
                        NTPV = "";
                        break;
                }
            }
            else
            {
                switch (NTPV)
                {
                    case "1":
                    case "3":
                        NTPV = NTPV + " - MULTIMEDIA";
                        break;
                    case "2":
                        NTPV = NTPV + " - FUJI";
                        break;
                    case "9":
                        NTPV = NTPV + " - ABACUS";
                        break;
                    case "14":
                        NTPV = NTPV + " - JUGUETTOS";
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
                        NTPV = NTPV + " - ALIMENTACIÓ"; 
                        break;
                    case "61":
                        NTPV = NTPV + " - LA REAL";
                        break;
                    case "201":
                    case "202":
                    case "203":
                        NTPV = NTPV + " - MR. BRICOLAGE";
                        break;
                    case "301":
                    case "302":
                    case "303":
                    case "304":
                        NTPV = NTPV + " - UEXPRESS";
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
                        NTPV = NTPV + " - CAPRABO";
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
                        NTPV = NTPV + " - DUTY FREE";
                        break;
                    case "65":
                    case "81":
                        NTPV = NTPV + " - NATTURALS";
                        break;
                    case "63":
                    case "64":
                    case "66":
                        NTPV = NTPV + " - CAFETERIA";
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
                        NTPV = NTPV + " - FRESH";
                        break;
                    case "601":
                        NTPV = NTPV + " - PARFOIS II";
                        break;
                    case "701":
                        NTPV = NTPV + " - FOM II";
                        break;
                    case "710":
                        NTPV = NTPV + " - MUY MUCHO II";
                        break;
                    default:
                        NTPV = "";
                        break;
                }
            }
            
            return NTPV;
        }
        public void ONETPV(int[] number)
        {
            try
            {
                DataTable dataTable = new DataTable();
                DataRow rowTable = dataTable.NewRow();
                TICKETS_LIST.Text = "";
                string control = "";
                decimal amount = 0;
                rowTable.Delete();
                dataTable.Columns.Add("Caixa");
                dataTable.Columns.Add("Núm Tiquet");
                dataTable.Columns.Add("Hora");
                dataTable.Columns.Add("Forma de pagament");
                dataTable.Columns.Add("Import", typeof(decimal));
                string Group_num = string.Empty;
                int n_caixes = 0;
                foreach (int Num in number)
                {
                    if (Group_num != string.Empty)
                    {
                        Group_num += ",";
                        n_caixes++;
                    }
                    Group_num += "'" + new string('0', 4 - Num.ToString().Length) + Num.ToString() + "'";

                }
                MySqlConnection connectionTable = new MySqlConnection(ConnectionAXCAIXES());
                StringBuilder CommandTable = new StringBuilder();
                CommandTable.Append("SELECT nterm, nreb, hora, typlin, total FROM datacap where fecha = @fecha and nterm");
                if (n_caixes == 0)
                {
                    if (CLIENT_CODE.Text == "")
                        CommandTable.Append(" = " + Group_num);
                    else
                        CommandTable.Append(" = " + Group_num + " and cliente like @clientcode");
                }else
                {
                    if (CLIENT_CODE.Text == "")
                        CommandTable.Append(" IN(" + Group_num + ")");
                    else
                        CommandTable.Append(" IN(" + Group_num + ") and cliente like @clientcode");
                }
                if (In_Out.Checked)
                {
                    CommandTable.Append(" and typtra IN('ENT','REC')");
                }
                CommandTable.Append(" and typlin like 'FE%' order by tienda, nterm, nreb, nlinea");

                MySqlCommand CMD = new MySqlCommand(CommandTable.ToString(), connectionTable);
                //CMD.Parameters.Add("@nterm",MySqlDbType.VarChar);
                CMD.Parameters.AddWithValue("@fecha", Convert.ToDateTime(PURCHASE_Date.Text).ToString("yyyyMMdd"));
                //CMD.Parameters.AddWithValue("@nterm", Group_num);
                CMD.Parameters.AddWithValue("@clientcode", "%" + CLIENT_CODE.Text + "%");
                connectionTable.Close();
                connectionTable.Open();
                MySqlDataReader TABLE = CMD.ExecuteReader();
                while (TABLE.Read())
                {
                    if (TABLE[1].ToString() == control)
                    {
                        rowTable.SetField(4, amount + Convert.ToDecimal(TABLE[4]));
                    }
                    else
                    {
                        rowTable = dataTable.NewRow();
                        rowTable[0] = TABLE[0].ToString();
                        rowTable[1] = TABLE[1].ToString();
                        control = rowTable[1].ToString();
                        rowTable[2] = TABLE[2].ToString();
                        rowTable[3] = GetPayment_Name(TABLE[3].ToString());
                        rowTable[4] = Convert.ToDecimal(TABLE[4].ToString());
                        amount = Convert.ToDecimal(rowTable[4]);
                        dataTable.Rows.Add(rowTable);
                    }
                }
                TABLE.Close();
                connectionTable.Close();
                TICKET_TABLE.DataSource = dataTable;
                TICKET_TABLE.Font = new Font("Century Gothic", 10F);
                TICKET_TABLE.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TICKET_TABLE.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TICKET_TABLE.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TICKET_TABLE.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Group_num = string.Empty;
                n_caixes = 0;
                foreach (int Num in number)
                {
                    if (Group_num != string.Empty)
                    {
                        Group_num += ",";
                        n_caixes++;
                    }
                    Group_num += "'" + Num.ToString() + "'";

                }
                MySqlConnection connectionIP = new MySqlConnection(Connection());
                    StringBuilder CommandIP = new StringBuilder();
                if (n_caixes == 0)
                {
                    CommandIP.Append("SELECT LOC, LOC2 FROM `departaments-cca`.cca where DSC = '" + DPTBox.Text + "' and TPV = " + Group_num + ";");
                }
                else
                {
                    CommandIP.Append("SELECT LOC, LOC2 FROM `departaments-cca`.cca where DSC = '" + DPTBox.Text + "' and TPV IN(" + Group_num + ");");
                }
                MySqlCommand CMDIP = new MySqlCommand(CommandIP.ToString(), connectionIP);
                connectionIP.Close();
                connectionIP.Open();
                MySqlDataReader IP = CMDIP.ExecuteReader();
                List<string> FileIP = new List<string>();
                while (IP.Read())
                {

                    if (PURCHASE_Date.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        FileIP.Add(@"\\srvpos\GEINSA\GnxServer\" + IP[1].ToString().Trim() + @"\");
                    }
                }
                if (FileIP.Count == 0) { goto siguiente; }
                foreach (string fl in FileIP)
                {
                    DirectoryInfo dir = new DirectoryInfo(fl);
                
                    foreach (var file in dir.GetFiles())
                    {
                        if (file.CreationTime.Date.ToString().Substring(0, 10) == PURCHASE_Date.Text.ToString().Substring(0, 10) && file.Name.Contains("journal"))
                        {
                            if (File.Exists(Directory.GetCurrentDirectory() + @"\journal-copy.txt"))
                            {
                                File.Delete(Directory.GetCurrentDirectory() + @"\journal-copy.txt");
                            }
                            File.Copy(fl + file.Name, Directory.GetCurrentDirectory() + @"\journal-copy.txt");
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\journal-copy.txt", Encoding.Default))
                            {
                                TICKETS_LIST.Text += sr.ReadToEnd();
                            }
                        }
                    }
                }
            siguiente:;
            }
            catch (Exception)
            {
                errorlbl.Text = "ERROR! Envieu un correu a Fran d'informatica";
                cur_Y = errorlbl.Location.Y;
                errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
                errorlbl.Visible = true;
                errorlbl.ForeColor = Color.Red;
                mov_Y = errorlbl.Location.Y;
                Error_Timer.Interval = 1;
                Error_Timer.Start();
            }
        }
        private void Check_Tiquet(string nreb, string nterm)
        {
            MySqlConnection CNNFDL = new MySqlConnection(ConnectionFDL());
            StringBuilder CommandFDL = new StringBuilder();
            CommandFDL.Append("SELECT * FROM tickets where fecha = @fecha and nterm = @nterm and nreb = @nreb order by nterm, nreb, nlinea");
            MySqlCommand CMDFDL = new MySqlCommand(CommandFDL.ToString(), CNNFDL);
            CMDFDL.Parameters.AddWithValue("@fecha", Convert.ToDateTime(PURCHASE_Date.Text).ToString("yyyyMMdd"));
            CMDFDL.Parameters.AddWithValue("@nreb", nreb);
            CMDFDL.Parameters.AddWithValue("@nterm", nterm);
            CNNFDL.Close();
            CNNFDL.Open();
            MySqlDataReader FDL = CMDFDL.ExecuteReader();
            TICKETS_LIST.Text = string.Empty;
            while (FDL.Read())
            {
                TICKETS_LIST.Text += FDL[0].ToString() + "\t" + FDL[1].ToString() + "\t" + FDL[2].ToString() + "\t" + FDL[3].ToString() + "\t" + FDL[4].ToString() + "\t" + FDL[5].ToString() + "\t" + FDL[6].ToString() + "\r\n";
            }
            //errorlbl.Text = "";
            CNNFDL.Close();
        }
        private void GOBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //errorlbl.Text = "";
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
                        TPV = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 62, 70, 71, 72 };
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
                errorlbl.Text = "Ha de seleccionar OBLIGATORIAMENT el departament, la caixa i la data";
                cur_Y = errorlbl.Location.Y;
                errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
                errorlbl.Visible = true;
                errorlbl.ForeColor = Color.Red;
                mov_Y = errorlbl.Location.Y;
                Error_Timer.Interval = 1;
                Error_Timer.Start();
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

        private void Download_File_Click(object sender, EventArgs e)
        {
            Downloadlbl.Visible = true;
            progressBar1.Visible = true;
            Downloading.RunWorkerAsync();
        }

        private void Downloading_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                if (!(PURCHASE_Date.Value.ToShortDateString() == DateTime.Now.ToShortDateString()))
                {
                    try
                    {
                        FolderBrowserDialog ofd = new FolderBrowserDialog();
                        int[] numero;
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            progressBar1.Value = 1;
                            progressBar1.Step = 1;
                            switch (TPVBox.Text)
                            {
                                case "CAIXES MULTIMEDIA":
                                    numero = new int[] { 1, 3 };
                                    break;
                                case "CAIXES JUGUETTOS/ABACUS":
                                    numero = new int[] { 9, 14 };
                                    break;
                                case "CAIXES ALIMENTACIÓ":
                                    numero = new int[] { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 62, 70, 71, 72 };
                                    break;
                                case "CAIXES MR. BRICOLAGE":
                                    numero = new int[] { 201, 202, 203 };
                                    break;
                                case "CAIXES UEXPRESS":
                                    numero = new int[] { 301, 302, 303, 304 };
                                    break;
                                case "CAIXES CAPRABO":
                                    numero = new int[] { 401, 402, 403, 404, 405, 406, 407, 408, 411, 412, 413, 414 };
                                    break;
                                case "CAIXES DUTY FREE":
                                    numero = new int[] { 5, 6, 7 };
                                    break;
                                case "CAIXES CAFETERIA":
                                    numero = new int[] { 63, 64, 66 };
                                    break;
                                case "CAIXES FRESH":
                                    numero = new int[] { 501, 502, 503, 504 };
                                    break;
                                default:
                                    numero = new int[] { Convert.ToInt32(TPVBox.Text.Substring(0, TPVBox.Text.IndexOf("-") - 1).Trim()) };
                                    break;
                            }
                            string Path = ofd.SelectedPath;
                            MySqlConnection CNNFDL = new MySqlConnection(ConnectionFDL());
                            StringBuilder CommandFDL = new StringBuilder();
                            int count_rows = 0;
                            CNNFDL.Close();
                            foreach (int nterm in numero)
                            {
                                CommandFDL = new StringBuilder();
                                CommandFDL.Append("SELECT COUNT(*) FROM tickets where fecha = @fecha and nterm = @nterm order by nterm, nreb, nlinea");
                                MySqlCommand CMDFDL = new MySqlCommand(CommandFDL.ToString(), CNNFDL);
                                CMDFDL.Parameters.AddWithValue("@fecha", Convert.ToDateTime(PURCHASE_Date.Text).ToString("yyyyMMdd"));
                                CMDFDL.Parameters.AddWithValue("@nterm", new string('0', 4 - nterm.ToString().Length) + nterm.ToString());
                                CNNFDL.Close();
                                CNNFDL.Open();
                                MySqlDataReader FDL = CMDFDL.ExecuteReader();
                                while (FDL.Read())
                                {
                                    count_rows += Convert.ToInt32(FDL[0]);
                                }
                            }
                            CNNFDL.Close();
                            progressBar1.Maximum = count_rows;
                            if (File.Exists(Path + @"\" + TPVBox.Text + ".txt"))
                            {
                                if (File.Exists(Path + @"\" + TPVBox.Text + ".txt.old"))
                                {
                                    File.Delete(Path + @"\" + TPVBox.Text + ".txt.old");
                                }
                                File.Move(Path + @"\" + TPVBox.Text + ".txt", Path + @"\" + TPVBox.Text + ".txt.old");
                            }
                            foreach (int nterm in numero)
                            {
                                CommandFDL = new StringBuilder();
                                CommandFDL.Append("SELECT * FROM tickets where fecha = @fecha and nterm = @nterm order by nterm, nreb, nlinea");
                                MySqlCommand CMDFDL = new MySqlCommand(CommandFDL.ToString(), CNNFDL);
                                CMDFDL.Parameters.AddWithValue("@fecha", Convert.ToDateTime(PURCHASE_Date.Text).ToString("yyyyMMdd"));
                                CMDFDL.Parameters.AddWithValue("@nterm", new string('0', 4 - nterm.ToString().Length) + nterm.ToString());
                                CNNFDL.Close();
                                CNNFDL.Open();
                                //TICKETS_LIST.Text = string.Empty;
                                MySqlDataReader FDL = CMDFDL.ExecuteReader();
                                //int count_rows = Convert.ToInt32(CMDFDL.ExecuteScalar());
                                while (FDL.Read())
                                {
                                    using (StreamWriter SW = File.AppendText(Path + @"\" + TPVBox.Text + ".txt"))
                                    {
                                        SW.WriteLine(FDL[0].ToString() + "\t" + FDL[1].ToString() + "\t" + FDL[2].ToString() + "\t" + FDL[3].ToString() + "\t" + Convert.ToDateTime(FDL[4]).ToString("dd/MM/yyyy") + "\t" + FDL[5].ToString() + "\t" + FDL[6].ToString());
                                    }
                                    progressBar1.PerformStep();
                                }
                                //errorlbl.Text = "";
                            }
                            CNNFDL.Close();
                            errorlbl.Text = "Descarrega Completada";
                            cur_Y = errorlbl.Location.Y;
                            errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
                            errorlbl.Visible = true;
                            errorlbl.ForeColor = Color.Green;
                            mov_Y = errorlbl.Location.Y;
                            Error_Timer.Interval = 1;
                            Error_Timer.Start();
                            //MessageBox.Show("Descarrega Completada", "Completat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Downloadlbl.Visible = false;
                            progressBar1.Visible = false;
                            Process.Start("explorer.exe", Path);
                        }
                        else
                        {
                            Downloadlbl.Visible = false;
                            progressBar1.Visible = false;
                            errorlbl.Text = "Descarrega cancel·lada";
                            cur_Y = errorlbl.Location.Y;
                            errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
                            errorlbl.Visible = true;
                            errorlbl.ForeColor = Color.Red;
                            mov_Y = errorlbl.Location.Y;
                            Error_Timer.Interval = 1;
                            Error_Timer.Start();
                            //MessageBox.Show("");
                            return;
                        }
                    }
                    catch
                    {
                        Downloadlbl.Visible = false;
                        progressBar1.Visible = false;
                        errorlbl.Text = "Ha de seleccionar OBLIGATORIAMENT el departament, la caixa i la data";
                        cur_Y = errorlbl.Location.Y;
                        errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
                        errorlbl.Visible = true;
                        errorlbl.ForeColor = Color.Red;
                        mov_Y = errorlbl.Location.Y;
                        Error_Timer.Interval = 1;
                        Error_Timer.Start();
                        //MessageBox.Show("Empleni els camps obligatoris", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    errorlbl.Text = "No es pot descarregar el diari d'avui";
                    cur_Y = errorlbl.Location.Y;
                    errorlbl.Location = new Point(errorlbl.Location.X, Location.Y - errorlbl.Height);
                    errorlbl.Visible = true;
                    errorlbl.ForeColor = Color.Red;
                    mov_Y = errorlbl.Location.Y;
                    Error_Timer.Interval = 1;
                    Error_Timer.Start();
                    //MessageBox.Show("No es pot descarregar el diari d'avui", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void Show_Grup_CheckedChanged(object sender, EventArgs e)
        {
            if (DPTBox.Text != "")
            {
                DPTBox_SelectedIndexChanged(sender, e);
            }
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