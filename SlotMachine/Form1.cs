using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DECLARING TOTAL, BET AND CREDITS
        public static long credits = 50;
        public static long total = 0;
        public static int bet = 0;

        // DECLARING EACH ITEM
        public static int p1;
        public static int p2;
        public static int p3;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("1.png");
            pictureBox2.Image = Image.FromFile("2.png");
            pictureBox3.Image = Image.FromFile("4.png");
            pictureBox4one.Image = Image.FromFile("2.png");
            pictureBox5one.Image = Image.FromFile("2.png");
            pictureBox6one.Image = Image.FromFile("2.png");
            pictureBox6two.Image = Image.FromFile("1.png");
            pictureBox5two.Image = Image.FromFile("1.png");
            pictureBox4two.Image = Image.FromFile("1.png");
            pictureBox7three.Image = Image.FromFile("3.png");
            pictureBox8three.Image = Image.FromFile("3.png");
            pictureBox9three.Image = Image.FromFile("3.png");
            pictureBox5four.Image = Image.FromFile("2.png");
            pictureBox4four.Image = Image.FromFile("2.png");
            pictureBox6six.Image = Image.FromFile("1.png");
            pictureBox8six.Image = Image.FromFile("1.png");
            pictureBox7five.Image = Image.FromFile("3.png");
            pictureBox9five.Image = Image.FromFile("3.png");
        }

        public static class IntUtil
        {
            private static Random random;

            private static void Init()
            {
                if (random == null) random = new Random();
            }
            public static int Random(int min, int max)
            {
                Init();
                return random.Next(min, max);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //checking if textbox value is int
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);

            if (isNumeric == true)
            {

                bet = n;
                label2.Text = "Bet: " + bet.ToString();

                if (credits == 0)
                {
                    MessageBox.Show("Sorry, you're out of credits!");
                    this.Close();
                }
                else if (credits < bet)
                {
                    MessageBox.Show("Bet must be equal to or lower than Credit balance!");
                }

                else if (credits >= bet)
                {
                    credits = credits - bet;
                    label1.Text = "Credits: " + credits.ToString();

                    for (var i = 0; i < 10; i++)
                    {

                        p1 = IntUtil.Random(1, 5);
                        p2 = IntUtil.Random(1, 5);
                        p3 = IntUtil.Random(1, 5);

                        if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                        pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");

                        if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                        pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");

                        if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                        pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");

                        await Task.Delay(50);
                    }

                    

                    total = 0;

                    //Three of a kind combos
                    if (p1 == 3 & p2 == 3 & p3 == 3) total = total + (bet * 3);
                    else if (p1 == 1 & p2 == 1 & p3 == 1) total = total + (bet * 3);
                    else if (p1 == 2 & p2 == 2 & p3 == 2) total = total + (bet * 5);

                    else if ((p1 == 3 & p2 == 3) || (p1 == 3 & p3 == 3) || (p2 == 3 & p3 == 3)) total = total + (bet * 2);
                    else if ((p1 == 1 & p2 == 1) || (p1 == 1 & p3 == 1) || (p2 == 1 & p3 == 1)) total = total + (bet * 2);
                    else if ((p1 == 2 & p2 == 2) || (p1 == 2 & p3 == 2) || (p2 == 2 & p3 == 2)) total = total + (bet * 2);

                    credits = credits + total;
                    label3.Text = "Win: " + total.ToString();
                    label1.Text = "Credits: " + credits.ToString();
                }
            }

            else
            {
                MessageBox.Show("Please enter a number value with no decimals!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cogratulations! You've won $" + credits.ToString() + "!" + Environment.NewLine +
                "Thanks for playing!");
            this.Close();
        }

    }
}