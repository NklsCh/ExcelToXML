using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToXML
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void readCSV()//var file
        {
            string path = @"C:\Users\tomsa\Desktop\dev\ExcelToXML\ExcelToXML\test.csv";

            using (StreamReader parser = new StreamReader(path))
            {
                Console.WriteLine(parser.ReadToEnd());
            }
        }
    }
}
