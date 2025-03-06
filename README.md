using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClockScreenSaver
{
    public partial class ClockScreenForm : Form
    {
        private Label timeLabel;
        private Timer timer;

        public ClockScreenForm()
        {
            InitializeComponent();

            // Настройка формы
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Cursor = Cursors.None;
            this.TopMost = true;

            // Создание метки для отображения времени
            timeLabel = new Label();
            timeLabel.ForeColor = Color.LimeGreen; // Цвет шрифта
            timeLabel.Font = new Font("Arial", 60, FontStyle.Bold); // Шрифт, размер, начертание
            timeLabel.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста
            timeLabel.AutoSize = false; // Важно, чтобы задать размер
            this.Controls.Add(timeLabel);

            // Настройка таймера для обновления времени
            timer = new Timer();
            timer.Interval = 1000; // Обновлять каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();

            // Initial time display and position the label
            UpdateTimeAndPositionLabel();

            // Handle form resize to reposition the label
            this.Resize += ClockScreenForm_Resize;
        }


        private void ClockScreenForm_Resize(object sender, EventArgs e)
        {
            UpdateTimeAndPositionLabel();
        }

        private void UpdateTimeAndPositionLabel()
        {
           timeLabel.Width = this.Width;
           timeLabel.Height = this.Height; // Make sure height is set correctly
           timeLabel.Location = new Point(0, 0); // Cover the entire screen
           timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimeAndPositionLabel(); // Update every tick
        }

         protected override void OnKeyPress(KeyPressEventArgs e)
        {
             Application.Exit();
        }

         protected override void OnMouseDown(MouseEventArgs e)
        {
             Application.Exit();
        }

        private void ClockScreenForm_MouseMove(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
