using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelToXML;

namespace ExcelToXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine("Form Intialized");
        }
        public static string[,] readCSV(System.IO.Stream file, string path)
        {
            using (StreamReader parser = new StreamReader(path))
            {
                string[] rows = parser.ReadToEnd().Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
                int rowLength = rows[0].Split(',').Length;
                string[,] table = new string[rows.Length, rowLength];
                string header = rows[0];
                for(int i = 0; i < rows.Length - 1; i++) // Iterating over each row
                {
                    string[] cells = rows[i].Split(',');
                    for(int y = 0; y < rowLength; y++) // Iterating over each cell in row
                    {
                        table[i, y] = cells[y].Trim(); // Adding cells to 2D Array
                    }
                }
                return table;
            }

        }
    }
}
