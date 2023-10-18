using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement.PrinterReports
{
    internal class PrintReports
    {
        public static void print<T>(string Title, IEnumerable<T> list, string Footer = "")
        {
            PrintForm printForm = new PrintForm();
            printForm.dataGridView1.DataSource = list;
            DGVPrinter printer = new DGVPrinter();
            printer.Title = Title;//Header
            printer.SubTitle = string.Format("Date :{0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = Footer;
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printForm.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            printForm.dataGridView1.Font = new Font("Arial", 9, FontStyle.Regular);
            printer.PrintDataGridView(printForm.dataGridView1);
        }
    }
}
