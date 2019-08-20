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

namespace ExcuseManagerCh9
{
    public partial class Form1 : Form
    {
        private Excuse currentExcuse;
        private bool formChanged;
        private string SelectedFolder = "";
        private Random random;
        public Form1()
        {
            InitializeComponent();
            currentExcuse = new Excuse(); //First Load Constructor
            currentExcuse.LastUsed = lastUsed.Value;
            random = new Random();
        }

        private void UpdateForm(bool changed)
        {
            if (!changed)
            {
                description.Text = currentExcuse.Description;
                results.Text = currentExcuse.Results;
                lastUsed.Value = currentExcuse.LastUsed;
                if (!string.IsNullOrEmpty(currentExcuse.ExcusePath))
                    fileDate.Text = File.GetLastWriteTime(currentExcuse.ExcusePath).ToString();
                this.Text = "Excuse Manager";

            }
            else
            {
                Text = "Excuse Manager*";
            }
            this.formChanged = changed;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Description = description.Text;
            UpdateForm(true);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Results = results.Text;
            UpdateForm(true);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            currentExcuse.LastUsed = lastUsed.Value;
            UpdateForm(true);
        }


        //Save
        private void button2_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(description.Text) || String.IsNullOrEmpty(results.Text))
            {
                MessageBox.Show("Please specify an excuse and a result", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            saveFileDialog1.InitialDirectory = SelectedFolder;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = description.Text + ".txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentExcuse.Save(saveFileDialog1.FileName);
                UpdateForm(false);
                MessageBox.Show("Excuse Written");
            }
        }

        //Open
        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                openFileDialog1.InitialDirectory = SelectedFolder;
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FileName = description.Text + ".txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    currentExcuse = new Excuse(openFileDialog1.FileName); //Open File Constructor
                    UpdateForm(false);
                }
            }  
        }

        //Folder
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = SelectedFolder;
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectedFolder = folderBrowserDialog1.SelectedPath;
                button2.Enabled = true;
                button3.Enabled = true;
                randomButton.Enabled = true;
            }
        }

        //Random
        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                currentExcuse = new Excuse(random, SelectedFolder);
                UpdateForm(false);
            }



            currentExcuse = new Excuse(); //Random File Constructor
        }


        private bool CheckChanged()
        {
            if (formChanged)
            {
                DialogResult result = MessageBox.Show("The current excuse has not been saved. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
            }
            return true;
        }
    }
}
