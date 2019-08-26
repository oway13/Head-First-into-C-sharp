﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BeehiveSimulator
{
    public class Renderer
    {
        public Renderer(World world, HiveForm hiveForm, FieldForm fieldForm)
        {
            this.world = world;
            this.hiveForm = hiveForm;
            this.fieldForm = fieldForm;
            fieldForm.Renderer = this;
            hiveForm.Renderer = this;
            InitializeImages();
        }
        private World world;
        private HiveForm hiveForm;
        private FieldForm fieldForm;

        //private List<Flower> deadFlowers = new List<Flower>();

        //private List<Bee> retiredBees = new List<Bee>();

        Bitmap HiveInside;
        Bitmap HiveOutside;
        Bitmap Flower;
        Bitmap[] BeeAnimationLarge;
        Bitmap[] BeeAnimationSmall;
        
        private void InitializeImages()
        {
            HiveOutside = ResizeImage(Properties.Resources.Hive__outside_, 85, 100);
            HiveInside = ResizeImage(Properties.Resources.Hive__inside_, hiveForm.ClientRectangle.Width, hiveForm.ClientRectangle.Height);
            Flower = ResizeImage(Properties.Resources.Flower, 75, 75);
            BeeAnimationLarge = new Bitmap[4];
            BeeAnimationLarge[0] = ResizeImage(Properties.Resources.Bee_animation_1, 40, 40);
            BeeAnimationLarge[1] = ResizeImage(Properties.Resources.Bee_animation_2, 40, 40);
            BeeAnimationLarge[2] = ResizeImage(Properties.Resources.Bee_animation_3, 40, 40);
            BeeAnimationLarge[3] = ResizeImage(Properties.Resources.Bee_animation_4, 40, 40);
            BeeAnimationSmall = new Bitmap[4];
            BeeAnimationSmall[0] = ResizeImage(Properties.Resources.Bee_animation_1, 20, 20);
            BeeAnimationSmall[1] = ResizeImage(Properties.Resources.Bee_animation_2, 20, 20);
            BeeAnimationSmall[2] = ResizeImage(Properties.Resources.Bee_animation_3, 20, 20);
            BeeAnimationSmall[3] = ResizeImage(Properties.Resources.Bee_animation_4, 20, 20);
        }

        //public void Reset()
        //{
        //    foreach (PictureBox flower in flowerLookup.Values)
        //    {
        //        fieldForm.Controls.Remove(flower);
        //        flower.Dispose();
        //    }
        //    foreach (BeeControl bee in beeLookup.Values)
        //    {
        //        hiveForm.Controls.Remove(bee);
        //        fieldForm.Controls.Remove(bee);
        //        bee.Dispose();
        //    }
        //    flowerLookup.Clear();
        //    beeLookup.Clear();
        //}


        //private void MoveBeeFromHiveToField(BeeControl beeControl)
        //{
        //    hiveForm.Controls.Remove(beeControl);
        //    beeControl.Size = new Size(20, 20);
        //    fieldForm.Controls.Add(beeControl);
        //    beeControl.BringToFront();
        //}

        //private void MoveBeeFromFieldToHive(BeeControl beeControl)
        //{
        //    fieldForm.Controls.Remove(beeControl);
        //    beeControl.Size = new Size(40, 40);
        //    hiveForm.Controls.Add(beeControl);
        //    beeControl.BringToFront();
        //}

        //private BeeControl GetBeeControl(Bee bee)
        //{
        //    BeeControl beeControl;
        //    if (!beeLookup.ContainsKey(bee))
        //    {
        //        beeControl = new BeeControl() { Width = 40, Height = 40 };
        //        beeLookup.Add(bee, beeControl);
        //        hiveForm.Controls.Add(beeControl);
        //        beeControl.BringToFront();
        //    }
        //    else
        //        beeControl = beeLookup[bee];
        //    return beeControl;
        //}

        //private void RemoveRetiredBeesAndDeadFlowers()
        //{
        //    foreach (Bee bee in retiredBees)
        //        beeLookup.Remove(bee);
        //    retiredBees.Clear();
        //    foreach (Flower flower in deadFlowers)
        //        flowerLookup.Remove(flower);
        //    deadFlowers.Clear();
        //}

        public static Bitmap ResizeImage(Bitmap picture, int width, int height)
        {
            Bitmap resizedPicture = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedPicture))
            {
                graphics.DrawImage(picture, 0, 0, width, height);
            }
            return resizedPicture;
        }


        private int cell = 0;
        private int frame = 0;
        public void AnimateBees()
        {
            frame++;
            if (frame >= 6)
                frame = 0;
            switch (frame)
            {
                case 0: cell = 0; break;
                case 1: cell = 1; break;
                case 2: cell = 2; break;
                case 3: cell = 3; break;
                case 4: cell = 2; break;
                case 5: cell = 1; break;
                default: cell = 0; break;
            }
            hiveForm.Invalidate();
            fieldForm.Invalidate();
        }

        public void PaintHive(Graphics g)
        {
            g.FillRectangle(Brushes.SkyBlue, hiveForm.ClientRectangle);
            g.DrawImageUnscaled(HiveInside, new Point(0,0));
            foreach(Bee bee in world.Bees)
            {
                if (bee.InsideHive)
                    g.DrawImageUnscaled(BeeAnimationLarge[cell], bee.Location.X, bee.Location.Y);
            }
        }

        public void PaintField(Graphics g)
        {
            using(Pen brownPen = new Pen(Color.Brown, 6.0F)){
                g.FillRectangle(Brushes.SkyBlue,
                            new Rectangle(fieldForm.ClientRectangle.X, fieldForm.ClientRectangle.Y, fieldForm.Width, fieldForm.ClientRectangle.Height / 2));
                g.FillRectangle(Brushes.Green,
                                new Rectangle(fieldForm.ClientRectangle.X, fieldForm.ClientRectangle.Y + fieldForm.ClientRectangle.Height / 2,
                                                fieldForm.Width, fieldForm.ClientRectangle.Height / 2));
                g.FillEllipse(Brushes.Yellow, new Rectangle(fieldForm.ClientRectangle.X + 10, fieldForm.ClientRectangle.Y + 10, 40, 40));
                g.DrawLine(brownPen, new Point(593, 0), new Point(593, 30));
                g.DrawImageUnscaled(HiveOutside, new Point(550, 20));

                foreach (Flower flower in world.Flowers)
                {
                    g.DrawImageUnscaled(Flower, flower.Location.X, flower.Location.Y);
                }

                foreach (Bee bee in world.Bees)
                {
                    if (!bee.InsideHive)
                        g.DrawImageUnscaled(BeeAnimationSmall[cell], bee.Location.X, bee.Location.Y);
                }
            }
            

        }
    }
}
