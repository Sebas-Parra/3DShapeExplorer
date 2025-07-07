using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;


namespace _3D_SHAPE_EXPLORER
{
    public partial class SplashScreenForm : Form
    {
        private int progressValue = 0;
        private string fullTitleText = "3D SHAPE EXPLORER";
        private int currentLetterIndex = 0;
        private Timer typingTimer;
        public SplashScreenForm()
        {
            InitializeComponent();
            //start at center
            this.StartPosition = FormStartPosition.CenterScreen;
            guna2ProgressBar1.Maximum = 100;
            guna2ProgressBar1.Value = 0;
            timer1.Interval = 30;
            timer1.Start();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            guna2ProgressBar1.Value = progressValue;

            if (progressValue >= 300)
            {
                timer1.Stop();
                ShapeExplorerForm mainForm = new ShapeExplorerForm();
                mainForm.Show();
                this.Hide();
            }
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            if (currentLetterIndex < fullTitleText.Length)
            {
                guna2HtmlLabel1.Text += fullTitleText[currentLetterIndex];
                currentLetterIndex++;
            }
            else
            {
                typingTimer.Stop();
            }
        }


        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Text = "";

            typingTimer = new Timer();
            typingTimer.Interval = 100; 
            typingTimer.Tick += TypingTimer_Tick;
            typingTimer.Start();
        }
    }
}
