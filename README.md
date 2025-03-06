using System;
using System.Drawing;
using System.Windows.Forms;

namespace BouncingTimer
{
    public partial class BouncingTimerForm : Form
    {
        private Timer timer;
        private int xDirection = 1; // 1 = right, -1 = left
        private int yDirection = 1; // 1 = down, -1 = up
        private int speed = 5; // Adjust speed as needed

        public BouncingTimerForm()
        {
            InitializeComponent();

            // Form settings
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Cursor = Cursors.None;
            this.TopMost = true;

            // Timer settings
            timer = new Timer();
            timer.Interval = 30; // Faster updates for smoother animation
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Get the current time
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            // Measure the text size
            SizeF textSize = CreateGraphics().MeasureString(currentTime, Font);

            // Calculate new position
            int newX = (int)(TextRenderer.MeasureText(currentTime, Font).Width * 0.5); // Получаем ширину текста
            int newY = (int)(TextRenderer.MeasureText(currentTime, Font).Height * 0.5); // Получаем высоту текста

            //Get screen dimensions
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;


            //Get direction of the move
            if (newX < 0 || newX + TextRenderer.MeasureText(currentTime, Font).Width > screenWidth)
            {
                xDirection *= -1;

            }

            if (newY < 0 || newY + TextRenderer.MeasureText(currentTime, Font).Height > screenHeight)
            {
                yDirection *= -1;
            }


            // Redraw the screen
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Get the current time
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            // Set up drawing properties
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.ForeColor = Color.LimeGreen; // Время, начертание

            Font font = new Font("Arial", 60, FontStyle.Bold); // Шрифт, размер

            SizeF textSize = CreateGraphics().MeasureString(currentTime, font);


            // Calculate position with bounce
            int newX = (int)(TextRenderer.MeasureText(currentTime, font).Width * 0.5); // Получаем ширину текста
            int newY = (int)(TextRenderer.MeasureText(currentTime, font).Height * 0.5); // Получаем высоту текста


            //Get screen dimensions
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            //Get direction of the move
            if (newX < 0 || newX + TextRenderer.MeasureText(currentTime, font).Width > screenWidth)
            {
                xDirection *= -1;

            }

            if (newY < 0 || newY + TextRenderer.MeasureText(currentTime, font).Height > screenHeight)
            {
                yDirection *= -1;
            }

            e.Graphics.DrawString(currentTime, font, new SolidBrush(Color.LimeGreen), newX, newY);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            Application.Exit();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}