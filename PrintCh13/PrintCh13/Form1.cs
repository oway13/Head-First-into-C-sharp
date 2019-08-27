using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PrintCh13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += Document_PrintPage;
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = document;
            preview.ShowDialog(this);
        }

        bool firstPage = true;
        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.SkyBlue, ClientRectangle);
            using(Font font = new Font("Arial", 36, FontStyle.Bold))
            {
                if (firstPage)
                {
                    e.Graphics.DrawString("First Page", Font, Brushes.Black, 0, 0);
                    e.HasMorePages = true;
                    firstPage = false;
                }
                else
                {
                    e.Graphics.DrawString("Second Page", Font, Brushes.Black, 0, 0);
                    firstPage = true;
                }
            }
        }
    }
}
