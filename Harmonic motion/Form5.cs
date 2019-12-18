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
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
        }

        int velocy = 4;
        bool addV = false;
        bool decV = true;

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
          

            lapTime = 2 * Math.PI * Math.Sqrt(mass / k);         //calculate the time of the system (T = 2 * Pi * sqrt(m/k))

            frequency = 1 / lapTime;

            omega = 2 * Math.PI * frequency;                    //calculate the omega (w) (w = 2 * pi * f)

            a = vMax / omega;                                   // calculate the motion range based on the equation (Vmax = w * A)

            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;

            label12.Text = "Omega: " + omega;
            label13.Text = "T (lap time): " + lapTime;
            label14.Text = "A (amplitude): " + a;

            textBox1.AppendText(" A = v/omega   -->  A = " + velocy.ToString() + " / " + omega  + " A = " + a);

            label4.Text = vMax.ToString();
            label5.Text = ((lapTime / 2)).ToString();
            label6.Text = ((lapTime)).ToString();

            pictureBox1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            label7.Text = a.ToString();
            label8.Text = ((lapTime / 2)).ToString();
            label9.Text = ((lapTime)).ToString();

            pictureBox2.Visible = true;
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

            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;

            timer1.Enabled = true;
            timer1.Interval = (int)(lapTime) * 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {





            if (addV)
                velocy++;
            if (decV)
                velocy--;
           
            if (velocy == 5)
            {
                addV = false;
                decV = true;
            }

            if(velocy == -5)
            {
                decV = false;
                addV = true;
            }
          
            pictureBox5.Top += velocy;
           // pictureBox4.Top += velocy;
            pictureBox4.Height+=velocy;


            pictureBox6.Left += 10;

            pictureBox7.Left += 10;

            if (pictureBox6.Left >= 850)
            {
                pictureBox6.Left -= 200;
            }

            if (pictureBox7.Left >= 850)
            {
                pictureBox7.Left -= 200;
            }
        }
    }
}
