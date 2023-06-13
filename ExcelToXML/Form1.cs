using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using ExcelToXML;

namespace ExcelToXML
{
    public partial class FormMainWindow : Form
    {
        System.IO.Stream file;
        string filename;
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
            filename = ofd.FileName;
            file = ofd.OpenFile();
            Functions f = new Functions();
            f.writeCSV(f.readCSV(file, ofd.FileName), dataGridView1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions f = new Functions();
            f.genXML(f.readCSV(file, filename));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormMainWindow_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
