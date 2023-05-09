using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.ShowDialog();
                var file = ofd.OpenFile();
                //readCSV(file);
            }
            dataGridView1.Rows.Add("5","Alex","Plea","02161/334455","2366","1","22.08.2000","100","Bernd","Peters","657","Hasselblad 501 CM body","2235","2","19");   
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
