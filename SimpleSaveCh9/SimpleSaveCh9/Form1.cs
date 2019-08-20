using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimpleSaveCh9
{
    public partial class Form1 : Form
    {
        private string name;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.InitialDirectory = @"C:\Desktop\c# learning\";
            openFileDialog1.InitialDirectory = @"C:\Desktop\c# learning\";

            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
                Text = name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
                Text = name;
            }

        }
    }
}
