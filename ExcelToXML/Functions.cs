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
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (StreamWriter writer = new StreamWriter(Path.Combine(docPath, "file.xml")))
                {
                    writer.WriteLine("<?xml version =\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>\r\n<Root>");
                    for (int i = 1; i < table.GetLength(0) - 1; i++)
                    {
                        string template = $"\t<BESTELLUNG>" +
                                          $"\n\t\t<KD_ID>{table[i, 0]}</KD_ID>" +
                                          $"\n\t\t<KD_VORNAME>{table[i, 1]}</KD_VORNAME>" +
                                          $"\n\t\t<KD_NACHNAME>{table[i, 2]}</KD_NACHNAME>" +
                                          $"\n\t\t<KD_TELEFON>{table[i, 3]}</KD_TELEFON>" +
                                          $"\n\t\t<BESTELL_NR>{table[i, 4]}</BESTELL_NR>" +
                                          $"\n\t\t<POSITION>{table[i, 5]}</POSITION>" +
                                          $"\n\t\t<BESTELLDATUM>{table[i, 6]}</BESTELLDATUM>" +
                                          $"\n\t\t<B_ID>{table[i, 7]}</B_ID>" +
                                          $"\n\t\t<B_VORNAME>{table[i, 8]}</B_VORNAME>" +
                                          $"\n\t\t<B_NACHNAME>{table[i, 9]}</B_NACHNAME>" +
                                          $"\n\t\t<B_TELEFON>{table[i, 10]}</B_TELEFON>" +
                                          $"\n\t\t<ARTIKEL>{table[i, 11]}</ARTIKEL>" +
                                          $"\n\t\t<NETTOPREIS>{table[i, 12]}</NETTOPREIS>" +
                                          $"\n\t\t<ANZAHL>{table[i, 13]}</ANZAHL>" +
                                          $"\n\t\t<STEUERSATZ>{table[i, 14]}</STEUERSATZ>" +
                                          $"\n\t</BESTELLUNG>";
                                            
                        writer.WriteLine(template);
                    }
                    writer.WriteLine("</Root>");
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
        }
    }
}
