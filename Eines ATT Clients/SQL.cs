using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Eines_ATT_Clients
{
    public class SQL
    {
        private readonly IConfiguration _config;
        public SQL(IConfiguration config)
        {
            _config = config;
        }
        public string Connection(string server, string user, string pass, string dtbs, string port)
        {
            string database = string.IsNullOrEmpty(dtbs) ? "" : $"database={dtbs};";
            string prt = string.IsNullOrEmpty(port) ? "" : $"port={port};";
            return $"server={server};Uid={user};Pwd={pass};{database}{prt}";
        }
        public string AllowedBussiness(string employee)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection(
                _config["SQLParameters:server"],
                _config["SQLParameters:uid"],
                _config["SQLParameters:pwd"],
                _config["SQLParameters:dtbs:dpt"],
                null)))
            {
                conn.Open();
                try
                {
                    string query = "SELECT `1`,`2`,`3`,`4`,`5`,`6`,`7`,`8`,`9`,`11`,`12`,`13`,`14`,`15`,`16`,`17`,`18`,`19`,`20` FROM allowed WHERE Empleado = @empl";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@empl", employee);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    string result = string.Empty;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            result = string.Join(";", Enumerable.Range(0, dr.FieldCount).Select(i => dr.GetValue(i)));
                        }
                    }
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }

            }
        }
        public List<string> GetDepartmentName(string departmentNum)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection(
                _config["SQLParameters:server"],
                _config["SQLParameters:uid"],
                _config["SQLParameters:pwd"],
                _config["SQLParameters:dtbs:dpt"],
                null)))
            {
                conn.Open();
                try
                {
                    List<string> result = new List<string>();
                    string query = "SELECT DSC FROM cca where DPT = @dpt group by DSC order by DPT";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dpt", departmentNum);
                    MySqlDataReader DPT = cmd.ExecuteReader();
                    while (DPT.Read())
                    {
                        result.Add(DPT[0].ToString().Trim());
                    }
                    DPT.Close();
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
                finally { conn.Close(); }
            }
        }
        public DataTable CompleteTable(DateTime today, bool entryExit, string[] terms, string clientCode)
        {

            using (MySqlConnection conn = new MySqlConnection(Connection(
                today.Date == DateTime.Today.Date ? _config["DatacapParameters:server:s1"] : _config["DatacapParameters:server:s2"],
                _config["DatacapParameters:uid"],
                _config["DatacapParameters:pwd"],
                _config["DatacapParameters:dtbs:d1"],
                today.Date == DateTime.Today.Date ? _config["DatacapParameters:prt:p1"] : null)))
            {
                conn.Open();
                try
                {
                    StringBuilder CommandTable = new StringBuilder();
                    CommandTable.Append($"SELECT nterm as Caixa, nreb as 'Núm Tiquet', MAX(hora) as Hora, typlin as 'Forma de pagament', SUM(total) as Import FROM datacap where fecha = @fecha and nterm");
                    CommandTable.Append($" IN({string.Join(",", terms)})");
                    if (clientCode != "")
                        CommandTable.Append(" and cliente like @clientcode");

                    if (entryExit)
                        CommandTable.Append(" and typtra IN('ENT','REC')");

                    CommandTable.Append(" and typlin like 'FE%' and estado = 'A' group by nterm, nreb, typlin order by nterm, nreb, hora;");

                    MySqlCommand cmd = new MySqlCommand(CommandTable.ToString(), conn);
                    cmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(today.Date).ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@clientcode", $"%{clientCode}%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<string> GetFolderTerm(string[] terminals, string department)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection(
                _config["SQLParameters:server"], 
                _config["SQLParameters:uid"], 
                _config["SQLParameters:pwd"], 
                _config["SQLParameters:dtbs:dpt"], 
                null)))
            {
                conn.Open();
                try
                {
                    string query = $"SELECT LOC, LOC2 FROM cca where DSC = @DSC and TPV IN ({string.Join(",", terminals)});";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DSC", department);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    List<string> folderTerm = new List<string>();
                    while (dr.Read())
                    {
                        folderTerm.Add($@"{_config["Paths:GnxServer"]}{dr[1].ToString().Trim()}\");
                    }
                    if (folderTerm.Count == 0)
                        return null;
                    return folderTerm;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void Check_Tiquet(string nreb, string nterm, RichTextBox ticketList, string dateString, out string errorLabel)
        {
            errorLabel = string.Empty;
            using (MySqlConnection conn = new MySqlConnection(Connection(
                _config["SQLParameters:server"], 
                _config["SQLParameters:uid"], 
                _config["SQLParameters:pwd"], 
                _config["SQLParameters:dtbs:jrnl"], 
                null)))
            {
                conn.Open();
                try
                {
                    string query = "SELECT * FROM tickets where fecha = @fecha and nterm = @nterm and nreb = @nreb order by nterm, nreb, nlinea";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.ParseExact(dateString, "yyyyMMdd", CultureInfo.CurrentCulture));
                    cmd.Parameters.AddWithValue("@nreb", nreb);
                    cmd.Parameters.AddWithValue("@nterm", nterm);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ticketList.Text += $"{dr[0].ToString()}\t{dr[1].ToString()}\t{dr[2].ToString()}\t{dr[3].ToString()}\t{Convert.ToDateTime(dr[4]).ToString("dd/MM/yyyy")}\t{dr[5].ToString()}\t{dr[6].ToString()}\r\n";
                    }
                }
                catch (Exception)
                {
                    errorLabel = "Hi ha hagut un problema a l'hora de rescatar el ticket de la caixa";
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void DownloadTicketHistory(string Path, int[] numero, DialogResult result, DataGridViewRow row, string dateString, System.Windows.Forms.ProgressBar progressBar)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection(
                _config["SQLParameters:server"], 
                _config["SQLParameters:uid"], 
                _config["SQLParameters:pwd"], 
                _config["SQLParameters:dtbs:jrnl"], 
                null)))
            {
                conn.Open();
                StringBuilder CommandFDL = new StringBuilder();

                foreach (int nterm in numero)
                {
                    CommandFDL = new StringBuilder();
                    CommandFDL.Append("SELECT *, Count(*) OVER() as lineas FROM tickets where fecha = @fecha and nterm = @nterm ");
                    if (result == DialogResult.Yes)
                    {
                        CommandFDL.Append(" and nreb = @nreb ");
                    }
                    CommandFDL.Append("order by nterm, nreb, nlinea");
                    MySqlCommand CMDFDL = new MySqlCommand(CommandFDL.ToString(), conn);
                    CMDFDL.Parameters.AddWithValue("@fecha", Convert.ToDateTime(dateString));
                    CMDFDL.Parameters.AddWithValue("@nterm", new string('0', 4 - nterm.ToString().Length) + nterm.ToString());
                    if (result == DialogResult.Yes)
                    {
                        CMDFDL.Parameters.AddWithValue("@nreb", row.Cells["Núm Tiquet"].Value.ToString());
                    }
                    MySqlDataReader FDL = CMDFDL.ExecuteReader();
                    if (FDL.HasRows)
                    {
                        while (FDL.Read())
                        {
                            progressBar.Maximum = Convert.ToInt32(FDL["lineas"]);

                            using (StreamWriter SW = new StreamWriter(Path, false))
                            {
                                SW.WriteLine(FDL[0].ToString() + "\t" + FDL[1].ToString() + "\t" + FDL[2].ToString() + "\t" + FDL[3].ToString() + "\t" + Convert.ToDateTime(FDL[4]).ToString("dd/MM/yyyy") + "\t" + FDL[5].ToString() + "\t" + FDL[6].ToString());
                            }
                            progressBar.PerformStep();
                        }
                    }
                }
            }
        }
        public void GetTPV(Tiquet tiquetForm, Dictionary<string, int[]> managerTPV, string departament, out string errorMessage)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection(
                _config["SQLParameters:server"],
                _config["SQLParameters:uid"],
                _config["SQLParameters:pwd"],
                _config["SQLParameters:dtbs:dpt"],
                null)))
            {
                conn.Open();
                errorMessage = string.Empty;
                try
                {
                    
                    string query = "SELECT TPV FROM `departaments-cca`.cca where DSC = @DSC order by DPT, TPV";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DSC", departament);
                    MySqlDataReader DPT = cmd.ExecuteReader();
                    while (DPT.Read())
                    {
                        string newNTPV = /*GetOldNTPV(*/DPT[0].ToString().Trim()/*)*/;

                        if (!managerTPV.TryGetValue(Control_Screen.nuser, out int[] allowedTPVs))
                        {
                            tiquetForm.AddComboBoxItems(newNTPV);
                            continue;
                        }
                        else if (allowedTPVs.ToString().Contains(newNTPV))
                        {
                            tiquetForm.AddComboBoxItems(newNTPV);
                        }
                    }
                    DPT.Close();
                }
                catch (Exception)
                {
                    errorMessage = "ERROR! Envieu un correu a Fran d'informatica";
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
