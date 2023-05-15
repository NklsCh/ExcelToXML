using System.IO;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExcelToXML
{
    internal class Functions
    {
        public void writeCSV(string[,] data, DataGridView dgv)
        {
            string[] header = new string[data.GetLength(1)];
            bool Empty = true;
            if (header.Length < 1) return;

            //Write the column names
            for (int i = 0; i <= header.Length - 1; i++)
            {
                dgv.Columns.Add(data[0, i], data[0, i]);
                dgv.Columns[i].ReadOnly = true;
            }

            //Fill in the data rows
            for (int i = 1; i < data.GetLength(0); i++)
            {
                var row = new DataGridViewRow();
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = data[i, j] });
                }
                dgv.Rows.Add(row);
            }

            //Deletes empty rows
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                Empty = true;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null && dgv.Rows[i].Cells[j].Value.ToString() != "")
                    {
                        Empty = false;
                        break;
                    }
                }
                if (Empty)
                {
                    dgv.Rows.RemoveAt(i);
                }
            }
        }
        public string[,] readCSV(System.IO.Stream file, string path)
        {
            StreamReader parser = new StreamReader(path);
            string[] rows = parser.ReadToEnd().Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
            int rowLength = rows[0].Split(';').Length;
            string[,] table = new string[rows.Length, rowLength];
            string header = rows[0];
            for (int i = 0; i < rows.Length - 1; i++) // Iterating over each row
            {
                string[] cells = rows[i].Split(';');
                for (int y = 0; y < rowLength; y++) // Iterating over each cell in row
                {
                    table[i, y] = cells[y].Trim(); // Adding cells to 2D Array
                }
            }
            return table;
        }

        public void genXML(string[,] table)
        {
            string KD_ID = "";string KD_Vorname = "";string KD_Nachname = "";int KD_Telefon = 0;int Bestell_NR = 0;int Position = 0;string Bestelldatum = "";int B_ID = 0;string B_Vorname = "";string B_Nachname = "";int B_Telefon = 0;string Artikel = "";int Nettopreis = 0;int Anzahl = 0;int Steuersatz = 0;

            string template = $"<Bestellung Nummer {Bestell_NR}> \n<Kunden ID {KD_ID}> \n\t<Vorname>{KD_Vorname}</Vorname> \n\t<Nachname>{KD_Nachname}</Nachname>" +
                              $" \n\t<Telefon>{KD_Telefon}</Telefon> \n</Kunden ID> \n<Bestellung> \n\t<Position>" +
                              $"{Position}</Position> \n\t<Bestelldatum>{Bestelldatum}</Bestelldatum> \n</Bestellung>" +
                              $"\n<Bearbeiter ID {B_ID}> \n\t<Vorname>{B_Vorname}</Vorname> \n\t<Nachname>{B_Nachname}</Nachname>" +
                              $" \n\t<Telefon>{B_Telefon}</Telefon> \n</Bearbeiter ID> \n<Artikel {Artikel}> \n\t<Nettopreis>{Nettopreis}" +
                              $"</Nettopreis> \n\t<Anzahl>{Anzahl}</Anzahl> \n\t<Steuersatz>{Steuersatz}</Steuersatz> \n</Artikel> \n</Bestellung Nummer>";

            try{
                using (StreamWriter writer = new StreamWriter(@"C:\Users\SATO02\Desktop\newfile.xml"))
                {
                    for (int i = 1; i < table.GetLength(1) - 1; i++)
                    {
                        KD_ID = table[i, 0];
                        KD_Vorname = table[i, 1]; KD_Nachname = table[i, 2]; KD_Telefon = Convert.ToInt32(table[i, 3]); Bestell_NR = Convert.ToInt32(table[i, 4]); Position = Convert.ToInt32(table[i, 5]); Bestelldatum = table[i, 6]; B_ID = Convert.ToInt32(table[i, 7]); B_Vorname = table[i, 8]; B_Nachname = table[i, 9]; B_Telefon = Convert.ToInt32(table[i, 10]); Artikel = table[i, 11]; Nettopreis = Convert.ToInt32(table[i, 12]); Anzahl = Convert.ToInt32(table[i, 13]); Steuersatz = Convert.ToInt32(table[i, 14]);
                        writer.WriteLine(template);
                    }
                }
            }
            catch(Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
        }
    }
}
