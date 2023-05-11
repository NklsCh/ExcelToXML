using System.Windows.Forms;

namespace ExcelToXML
{
    internal class Functions
    {
        public void writeCSV(string[,] table, DataGridView dgv)
        {
            for (int i = 0; i < table[i, 0].Length; i++)
            {
                dgv.Columns.Add(table[i, 0].ToString(), table[i, 0].ToString());
            }
        }
    }
}
