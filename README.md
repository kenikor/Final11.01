using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClockScreenSaver
{
    public partial class ClockScreenForm : Form
    {
        private Label timeLabel;
        private Timer timer;
        private int xDirection = 1; // 1 = right, -1 = left
        private int yDirection = 1; // 1 = down, -1 = up
        private int speed = 5; // Adjust speed as needed

        public ClockScreenForm()
        {
            InitializeComponent();

            // Form settings
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Cursor = Cursors.None;
            this.TopMost = true;

            // Label settings
            timeLabel = new Label();
            timeLabel.ForeColor = Color.LimeGreen;
            timeLabel.Font = new Font("Arial", 60, FontStyle.Bold);
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.AutoSize = true;  // Let the label determine its size
            this.Controls.Add(timeLabel);

            // Timer settings
            timer = new Timer();
            timer.Interval = 30; // Faster updates for smoother animation
            timer.Tick += Timer_Tick;
            timer.Start();

            // Initial position and update label
            UpdateTimeAndPositionLabel();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate new position
            int newX = timeLabel.Left + xDirection * speed;
            int newY = timeLabel.Top + yDirection * speed;

            // Bounce off the walls
            if (newX < 0 || newX + timeLabel.Width > this.ClientSize.Width)
            {
                xDirection *= -1;
                newX = timeLabel.Left + xDirection * speed; // Recalculate after bounce
            }

            if (newY < 0 || newY + timeLabel.Height > this.ClientSize.Height)
            {
                yDirection *= -1;
                newY = timeLabel.Top + yDirection * speed; // Recalculate after bounce
            }

            // Update label position
            timeLabel.Left = newX;
            timeLabel.Top = newY;

            // Update the time
            timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //Remove all methods relating to mouse movement and clicks.

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Application.Exit();
        }
    }
}
