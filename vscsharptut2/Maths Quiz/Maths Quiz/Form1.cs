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

        //integers for the subtraction problem
        int minuend;
        int subtrahend;

        //ints for multiplication problem
        int multiplicand;
        int multiplier;

        //ints for division problem
        int dividend;
        int divisor;

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

            //fill in the subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //fill in multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            //fill in division problem
            divisor = randomizer.Next(2, 11);
            int tempQuot = randomizer.Next(2, 11);
            dividend = divisor * tempQuot;
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();

            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        /// <summary>
        /// /// Check the answer to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise, </returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend/divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.White;
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                //If CheckTheAnswer returns true, the the user
                //got the answer right. Stop the timer
                //and show a messagebox
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft > 0)
            {
                //If CheckTheAnswer() retunrs false, keep counting
                //down. Decrease the time left by one second and
                //display the new lwft by updating the
                //time left label
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if(timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                //if the user ran out of time, stop the timerm, show
                // a messagebox, and fill in the answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // select the whole andwer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void check_addition(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                //play sound
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void check_subtraction(object sender, EventArgs e)
        {
            if(minuend - subtrahend == difference.Value)
            {
                //play sound
                System.Media.SystemSounds.Asterisk.Play();
            }
        }

        private void check__multiplication(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
            {
                //play sound
                System.Media.SystemSounds.Asterisk.Play();
            }

        }

        private void check_division(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                //play sound
                System.Media.SystemSounds.Asterisk.Play();
            }

        }

    }
}
