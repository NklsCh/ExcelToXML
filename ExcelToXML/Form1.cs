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
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.ShowDialog();
            var file = ofd.OpenFile();
            Functions f = new Functions();
            f.writeCSV(f.readCSV(file, ofd.FileName), dataGridView1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
