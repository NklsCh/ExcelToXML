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
    }
}
