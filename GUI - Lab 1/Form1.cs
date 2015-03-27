using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Lab_1
{
    public partial class Form1 : Form
    {
        // instance of Random class
        static Random randomNum = new Random();

        // member variables
        private int m_randNum, 
                    m_minValue,
                    m_maxValue,
                    m_numTries,
                    m_score;

        //
        // ctor
        //
        public Form1()
        {
            InitializeComponent();
            
            m_minValue = 0;
            m_maxValue = 100;
            m_numTries = 0;
            m_score = 0;

            // generate and store random number
            m_randNum = randomNum.Next(m_minValue, m_maxValue);
        }


        //
        // "Guess" button functionality
        //
        private void button1_Click(object sender, EventArgs e)
        {
            // check if user entered a valid integer
            string userInput = textBox1.Text.Trim();
            double userNum;

            bool isNum = double.TryParse(userInput, out userNum);

            if (isNum)
            {
                // check if user entered a number within range
                if (userNum >= m_minValue && userNum <= m_maxValue)
                {
                    // increment # of tries
                    ++m_numTries;
                    label5.Text = m_numTries.ToString();
                    
                    // user guess is compared to random number 
                    int guess = userNum.CompareTo(m_randNum);

                    // user guess is handled
                    switch( guess )
                    {
                        case -1:
                            MessageBox.Show("Guess higher");
                            break;
                        case 1:
                            MessageBox.Show("Guess lower");
                            break;
                        default:
                            if (m_score == 0 || m_numTries < m_score)
                            m_score = m_numTries;
                            label6.Text = m_score.ToString();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Number must be between 0 and 100");
                }
            }
            else
            {
                MessageBox.Show("Invalid number");
            }

            textBox1.Text = "";
        }

        //
        // "Reset" button functionality
        //
        private void button2_Click(object sender, EventArgs e)
        {
            // generate/set a different random number and reset all data
            m_randNum = randomNum.Next(m_minValue, m_maxValue);
            m_numTries = 0;
            label5.Text = m_numTries.ToString();
        }
    }

   
}
