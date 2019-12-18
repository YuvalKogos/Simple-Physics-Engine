using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harmonic_motion
{
    public partial class Form8 : Form
    {
        public Form8()
        {
           
            InitializeComponent();
        }

        int velocy = 4;
        bool  accelerationUp = false;
        bool accelerationDown = true;

        double mass;
        double vMax;
        double k;
        double a;

        double lapTime;
        double frequency;
        double omega;

/*
        public static CheckBox[] checkIfCLicked(CheckBox[] checkboxes)
        {
            int remNum = 0;

            for (int i = 0; i < checkboxes.Length; i++)
            {
                if (!(checkboxes[i].Checked))
                {
                    checkboxes[i] = null;
                    remNum++; 
                }
            }
            CheckBox[] arr1 = new CheckBox[checkboxes.Length - remNum];
            int k = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                
            }

            
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {

       
            try
            {
                mass = Convert.ToDouble(massT.Text);
                vMax = Convert.ToDouble(vMaxT.Text);
                k = Convert.ToDouble(kT.Text);
            }
            catch                                               //Enter the values using the text boxes text
            {

                MessageBox.Show("Enter numbers only !");

            }

            //calculate the time of the system (T = 2 * Pi * sqrt(m/k))
            lapTime = 2 * Math.PI * Math.Sqrt(mass / k);         

            frequency = 1 / lapTime;

            //calculate the omega (w) (w = 2 * pi * f)
            omega = 2 * Math.PI * frequency;

            // calculate the motion range based on the equation (Vmax = w * A)
            a = vMax / omega;                                  

            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            label12.Text = "Omega: " + omega;
            label13.Text = "T (lap time): " + lapTime;
            label14.Text = "A (amplitude): " + a;

            //textBox1.AppendText(" A = v/omega   -->  A = " + velocy.ToString() + " / " + omega  + " A = " + a);

            label4.Text = vMax.ToString();
            label5.Text = ((lapTime / 2)).ToString();
            label6.Text = ((lapTime)).ToString();

            //pictureBox1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            label7.Text = a.ToString();
            label8.Text = ((lapTime / 2)).ToString();
            label9.Text = ((lapTime)).ToString();

            //pictureBox2.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;

            label10.Visible = true;
            label11.Visible = true;

            label4.BringToFront();
            label5.BringToFront();
            label6.BringToFront();
            label7.BringToFront();
            label8.BringToFront();
            label9.BringToFront();
            label10.BringToFront();
            label11.BringToFront();

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            PB_rope.Visible = true;
            PB_object.Visible = true;

            timer1.Enabled = true;
            timer1.Interval = (int)(lapTime) * 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Acceleration direction

            if (accelerationDown)
                velocy++;
            else
                velocy--;

            //Switch acceleration direction based on velocy value

            if (velocy == 5)           
                accelerationDown = false;
            if(velocy == -5)
                accelerationDown = true;
          

            //Increase object Y value based on velocy value
            PB_object.Top += velocy;
          
            //increase 'rope' length 
            PB_rope.Height+=velocy;

            
            //Graphs pointer movement

            PB_pointer1.Left += 10;

            PB_pointer2.Left += 10;

            if (PB_pointer1.Left >= 850)
            {
                PB_pointer1.Left -= 200;
            }

            if (PB_pointer2.Left >= 850)
            {
                PB_pointer2.Left -= 200;
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
