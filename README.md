using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothBouncingClock
{
    public partial class SmoothBouncingClockForm : Form
    {
        private Label timeLabel;
        private Timer timer;
        private float xPosition;  // Use float for smoother movement
        private float yPosition;  // Use float for smoother movement
        private float xDirection = 1.0f; // 1 = right, -1 = left
        private float yDirection = 1.0f; // 1 = down, -1 = up
        private float speed = 1.5f; // Adjust speed as needed - Float Value now

        public SmoothBouncingClockForm()
        {
            InitializeComponent();

            // Form settings
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Cursor = Cursors.None;
            this.TopMost = true;
            DoubleBuffered = true;

            // Label settings
            timeLabel = new Label();
            timeLabel.ForeColor = Color.LimeGreen;
            timeLabel.Font = new Font("Arial", 60, FontStyle.Bold);
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.AutoSize = true;
            this.Controls.Add(timeLabel);

            // Initialize position
            Random rand = new Random();
            xPosition = rand.Next(0, ClientSize.Width - timeLabel.Width);
            yPosition = rand.Next(0, ClientSize.Height - timeLabel.Height);
            timeLabel.Location = new Point((int)xPosition, (int)yPosition);

            // Timer settings
            timer = new Timer();
            timer.Interval = 16; // ~60 FPS - Using a higher framerate
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTime();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate new position - Floating point calculations
            xPosition += xDirection * speed;
            yPosition += yDirection * speed;

            // Bounce off the walls
            if (xPosition < 0 || xPosition + timeLabel.Width > this.ClientSize.Width)
            {
                xDirection *= -1;
                xPosition += xDirection * speed; //Recalculate after bounce
            }

            if (yPosition < 0 || yPosition + timeLabel.Height > this.ClientSize.Height)
            {
                yDirection *= -1;
                yPosition += yDirection * speed; //Recalculate after bounce
            }

            // Update label position - Cast back to integer for the label's location
            timeLabel.Left = (int)xPosition;
            timeLabel.Top = (int)yPosition;

            UpdateTime(); //Update the time
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Application.Exit();
        }


        private void UpdateTime()
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}