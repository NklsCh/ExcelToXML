using System;
using System.Windows.Forms;
using ExcelToXML;

namespace ExcelToXML
{
    public partial class FormMainWindow : Form
    {
        public FormMainWindow()
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.ShowDialog();
            var file = ofd.OpenFile();
            //readCSV(file, patV;
            Functions f = new Functions();
            //f.writeCSV(file, dataGridView1);  
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
