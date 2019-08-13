using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardDrawingCh8
{
    public partial class Form1 : Form
    {
        Random rand;
        int suit;
        int value;
        Card card;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            suit = rand.Next(4);
            value = rand.Next(1, 14);
            card = new Card((Suits)suit, (Values)value);
            cardLabel.Text = card.Name;

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            suit = rand.Next(4);
            value = rand.Next(1, 14);
            card = new Card((Suits)suit, (Values)value);
            cardLabel.Text = card.Name;
        }
    }
}
