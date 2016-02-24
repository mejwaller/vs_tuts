using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maths_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        //integer variables to store the numbers for teh addition problem
        int addend1;
        int addend2;

        //integer to keep track of remaining time
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer
        /// </summary>
        public void StartTheQuiz()
        {
            //fill in the addition problem.
            //Generate 2 random numbers to add
            //store the values in the variables 'addend1' and 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //convert the two randomly generated numbers
            //into strings so that they can be displayed 
            //in the label controls
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //'sum' is the name of the NumericUpDown control.
            //Thus step makes sure its value is zero before 
            //adding any values to it
            sum.Value = 0;

            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timeLeft > 0)
            {
                //display the new time left
                //by updating the time left label
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                //if the user ran out of time, stop the timerm, show
                // a messagebox, and fill in the answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }

        }
    }
}
