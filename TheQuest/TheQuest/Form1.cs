using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheQuest
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        public void UpdateCharacters()
        {
            player.Location = game.PlayerLocation;
            playerHitPoint.Text = game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach(Enemy enemy in game.Enemies)
            {
                if(enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoint.Text = enemy.HitPoints.ToString();
                    if(enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoint.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoint.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }
            bat.Visible = showBat;
            ghost.Visible = showGhost;
            ghoul.Visible = showGhoul;
            batHitPoint.Visible = showBat;
            ghostHitPoint.Visible = showGhost;
            ghoulHitPoint.Visible = showGhoul;

            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;
            Control weaponControl = null; ;
            switch (game.WeaponInRoom.Name)
            {
                case "sword":
                    weaponControl = sword;
                    break;
                case "blue potion":
                    weaponControl = bluePotion;
                    break;
                case "bow":
                    weaponControl = bow;
                    break;
                case "red potion":
                    weaponControl = redPotion;
                    break;
                case "mace":
                    weaponControl = mace;
                    break;
            }
            weaponControl.Visible = true;

            pictureBox10.Visible = game.CheckPlayerInventory("sword");
            pictureBox11.Visible = game.CheckPlayerInventory("blue potion");
            pictureBox12.Visible = game.CheckPlayerInventory("bow");
            pictureBox13.Visible = game.CheckPlayerInventory("red potion");
            pictureBox14.Visible = game.CheckPlayerInventory("mace");

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("YOU DIED");
                Application.Exit();
            }

            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("sword"))
            {
                pictureBox10.BorderStyle = BorderStyle.FixedSingle;

                pictureBox11.BorderStyle = BorderStyle.None;
                pictureBox12.BorderStyle = BorderStyle.None;
                pictureBox13.BorderStyle = BorderStyle.None;
                pictureBox14.BorderStyle = BorderStyle.None;
                game.Equip("sword");

                attackUp.Text = "Up";
                attackDown.Enabled = true;
                attackLeft.Enabled = true;
                attackRight.Enabled = true;
            }   
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("blue potion"))
            {
                pictureBox11.BorderStyle = BorderStyle.FixedSingle;

                pictureBox10.BorderStyle = BorderStyle.None;
                pictureBox12.BorderStyle = BorderStyle.None;
                pictureBox13.BorderStyle = BorderStyle.None;
                pictureBox14.BorderStyle = BorderStyle.None;
                game.Equip("blue potion");

                attackUp.Text = "Drink";
                attackDown.Enabled = false;
                attackLeft.Enabled = false;
                attackRight.Enabled = false;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("bow"))
            {
                pictureBox12.BorderStyle = BorderStyle.FixedSingle;

                pictureBox11.BorderStyle = BorderStyle.None;
                pictureBox10.BorderStyle = BorderStyle.None;
                pictureBox13.BorderStyle = BorderStyle.None;
                pictureBox14.BorderStyle = BorderStyle.None;
                game.Equip("bow");

                attackUp.Text = "Up";
                attackDown.Enabled = true;
                attackLeft.Enabled = true;
                attackRight.Enabled = true;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("red potion"))
            {
                pictureBox13.BorderStyle = BorderStyle.FixedSingle;

                pictureBox11.BorderStyle = BorderStyle.None;
                pictureBox12.BorderStyle = BorderStyle.None;
                pictureBox10.BorderStyle = BorderStyle.None;
                pictureBox14.BorderStyle = BorderStyle.None;
                game.Equip("red potion");

                attackUp.Text = "Drink";
                attackDown.Enabled = false;
                attackLeft.Enabled = false;
                attackRight.Enabled = false;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("mace"))
            {
                pictureBox14.BorderStyle = BorderStyle.FixedSingle;

                pictureBox11.BorderStyle = BorderStyle.None;
                pictureBox12.BorderStyle = BorderStyle.None;
                pictureBox13.BorderStyle = BorderStyle.None;
                pictureBox10.BorderStyle = BorderStyle.None;
                game.Equip("mace");

                attackUp.Text = "Up";
                attackDown.Enabled = true;
                attackLeft.Enabled = true;
                attackRight.Enabled = true;
            }
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void attackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void attackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void attackRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void attackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }
    }
}
