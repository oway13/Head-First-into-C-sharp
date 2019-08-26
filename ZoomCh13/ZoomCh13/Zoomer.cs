using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomCh13
{
    public partial class Zoomer : UserControl
    {
        Bitmap photo;
        public Zoomer()
        {
            InitializeComponent();
            photo = new Bitmap(Properties.Resources.ice_ele);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Zoomer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.White), ClientRectangle);
            e.Graphics.DrawImage(photo, 10, 10, trackBar1.Value, trackBar2.Value);
        }
    }
}
