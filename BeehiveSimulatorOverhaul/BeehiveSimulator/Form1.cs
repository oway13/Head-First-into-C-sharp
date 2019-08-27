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
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Printing;

namespace BeehiveSimulator
{
    public partial class Form1 : Form
    {
        private World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;

        private HiveForm hiveForm = new HiveForm();
        private FieldForm fieldForm = new FieldForm();
        private Renderer renderer;

        public Form1()
        {
            InitializeComponent();
            MoveChildForms();
            hiveForm.Show(this);
            fieldForm.Show(this);
            ResetSimulator();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());
        }

        private void MoveChildForms()
        {
            hiveForm.Location = new Point(Location.X + Width + 40, Location.Y);
            fieldForm.Location = new Point(Location.X, Location.Y + Math.Max(Height, hiveForm.Height) + 20);
        }

        private void UpdateStats(TimeSpan frameDuration)
        {
            Bees.Text = world.Bees.Count.ToString();
            Flowers.Text = world.Flowers.Count.ToString();
            HoneyInHive.Text = String.Format("{0:f3}", world.Hive.Honey);
            double nectar = 0;
            foreach (Flower flower in world.Flowers)
                nectar += flower.Nectar;
            NectarInFlowers.Text = String.Format("{0:f3}", nectar);
            FramesRun.Text = framesRun.ToString();
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                FrameRate.Text = string.Format("{0:f0} ({1:f1}ms)", 1000 / milliSeconds, milliSeconds);
            else
                FrameRate.Text = "N/A";
        }

        private void RunFrame(object sender, EventArgs e)
        {
            framesRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStats(frameDuration);
            hiveForm.Invalidate();
            fieldForm.Invalidate();
        }

        private void startSim_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                startSim.Text = "Resume Simulation";
                timer1.Stop();
            }
            else
            {
                startSim.Text = "Pause Simulation";
                timer1.Start();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            ResetSimulator();
            if (!timer1.Enabled)
                startSim.Text = "Start Simulation";
            UpdateStats(new TimeSpan());
        }

        private void SendMessage(int ID, string Message)
        {
            statusStrip1.Items[0].Text = "Bee #" + ID + ": " + Message;
            var beeGroups =
                from bee in world.Bees
                group bee by bee.CurrentState into beeGroup
                orderby beeGroup.Key
                select beeGroup;
            listBox1.Items.Clear();
            foreach(var group in beeGroups)
            {
                string s;
                if (group.Count() == 1)
                    s = "";
                else
                    s = "s";
                listBox1.Items.Add(group.Key.ToString() + ": " + group.Count() + " bee" + s);
                if(group.Key == BeeState.Idle && group.Count() == world.Bees.Count() && framesRun > 0)
                {
                    listBox1.Items.Add("Simulation ended: all bees are idle");
                    toolStrip1.Items[0].Text = "Simulation Ended";
                    statusStrip1.Items[0].Text = "Simulation Ended";
                    timer1.Enabled = false;
                }
            }
        }

        private void ResetSimulator()
        {
            framesRun = 0;
            world = new World(new BeeMessage(SendMessage));
            renderer = new Renderer(world, hiveForm, fieldForm);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFramesRun = framesRun;

            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Simulator File (*.bees)|*.bees";
            openDialog.CheckFileExists = true;
            openDialog.CheckPathExists = true;
            openDialog.Title = "Choose a file with a simulation to load";
            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using(Stream input = File.OpenRead(openDialog.FileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        world = (World)bf.Deserialize(input);
                        framesRun = (int)bf.Deserialize(input);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Unable to read the simulator file\r\n" + ex.Message, "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world = currentWorld;
                    framesRun = currentFramesRun;
                }
            }
            world.Hive.MessageSender = new BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
                bee.MessageSender = new BeeMessage(SendMessage);
            if (enabled)
                timer1.Start();

            renderer = new Renderer(world, hiveForm, fieldForm);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Simulator File (*.bees)|*.bees";
            saveDialog.CheckPathExists = true;
            saveDialog.Title = "Choose a file to save the current simulation";
            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream output = File.Create(saveDialog.FileName))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(output, world);
                        bf.Serialize(output, framesRun);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Unable to save the simulator file\r\n" + ex.Message, "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            if (enabled)
                timer1.Start();
            
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            PrintDocument document = new PrintDocument();
            PrintPreviewDialog preview = new PrintPreviewDialog();
            document.PrintPage += Document_PrintPage;
            preview.Document = document;
            preview.ShowDialog(this);

            if (enabled)
                timer1.Start();
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Size stringSize;
            using(Font arial24bold = new Font("Arial", 24, FontStyle.Bold))
            {
                stringSize = Size.Ceiling(g.MeasureString("Bee Simulator", arial24bold));
                g.FillEllipse(Brushes.Gray, new Rectangle(e.MarginBounds.X + 2, e.MarginBounds.Y + 2, stringSize.Width + 30, stringSize.Height + 30));
                g.FillEllipse(Brushes.Black, new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, stringSize.Width + 30, stringSize.Height + 30));
                g.DrawString("Bee Simulator", arial24bold, Brushes.Gray, e.MarginBounds.X + 17, e.MarginBounds.Y + 17);
                g.DrawString("Bee Simulator", arial24bold, Brushes.White, e.MarginBounds.X + 15, e.MarginBounds.Y + 15);
            }
            int tableX = e.MarginBounds.X + (int)stringSize.Width + 50;
            int tableWidth = e.MarginBounds.X + e.MarginBounds.Width - tableX - 20;
            int firstColumnX = tableX + 2;
            int secondColumnX = tableX + (tableWidth / 2) + 5;
            int tableY = e.MarginBounds.Y;

            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Bees", Bees.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Flowers", Flowers.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Honey In Hive", HoneyInHive.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Nectar in Flowers", NectarInFlowers.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Frames Run", FramesRun.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX, secondColumnX, tableY, "Frame Rate", FrameRate.Text);

            g.DrawRectangle(Pens.Black, tableX, e.MarginBounds.Y, tableWidth, tableY - e.MarginBounds.Y);
            g.DrawLine(Pens.Black, secondColumnX, e.MarginBounds.Y, secondColumnX, tableY);

            using (Pen blackPen = new Pen(Brushes.Black, 2))
            using (Bitmap hiveBitmap = new Bitmap(hiveForm.ClientSize.Width, hiveForm.ClientSize.Height))
            using(Bitmap fieldBitmap = new Bitmap(fieldForm.ClientSize.Width, fieldForm.ClientSize.Height))
            {
                using(Graphics hiveGraphics = Graphics.FromImage(hiveBitmap))
                {
                    renderer.PaintHive(hiveGraphics);
                }
                int hiveWidth = e.MarginBounds.Width / 2;
                int hiveHeight = (int)(((float)hiveBitmap.Height / (float)hiveBitmap.Width) * hiveWidth);
                int hiveTop = tableY + 15;
                int hiveX = (e.MarginBounds.Width / 4) + e.MarginBounds.X;
                g.DrawImage(hiveBitmap, hiveX, hiveTop, hiveWidth, hiveHeight);
                g.DrawRectangle(blackPen, hiveX, hiveTop, hiveWidth, hiveHeight);

                using(Graphics fieldGraphics = Graphics.FromImage(fieldBitmap))
                {
                    renderer.PaintField(fieldGraphics);
                }
                int fieldWidth = e.MarginBounds.Width;
                int fieldHeight = (int)(((float)fieldBitmap.Height / (float)fieldBitmap.Width) * fieldWidth);
                int fieldBottom = e.MarginBounds.Y + e.MarginBounds.Height;
                int fieldTop = fieldBottom - fieldHeight;
                g.DrawImage(fieldBitmap, e.MarginBounds.X, fieldTop, fieldWidth, fieldHeight);
                g.DrawRectangle(blackPen, e.MarginBounds.X, fieldTop, fieldWidth, fieldHeight);
            }
           

        }

        private int PrintTableRow(Graphics printGraphics, int tableX, int tableWidth, int firstColumnX, 
                                  int secondColumnX, int tableY, string firstColumn, string secondColumn)
        {
            Font arial12 = new Font("Arial", 12);
            Size stringSize = Size.Ceiling(printGraphics.MeasureString(firstColumn, arial12));
            tableY += 4;
            printGraphics.DrawString(firstColumn, arial12, Brushes.Black, firstColumnX, tableY);
            printGraphics.DrawString(secondColumn, arial12, Brushes.Black, secondColumnX, tableY);
            tableY += 17;
            printGraphics.DrawLine(Pens.Black, tableX, tableY, tableX + tableWidth, tableY);
            arial12.Dispose();
            return tableY;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            renderer.AnimateBees();
        }
    }
}
