using System.Timers;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer moveTimer;
        private int step = 10;
        private string direction = "right";

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            moveTimer = new System.Timers.Timer(50);
            moveTimer.Elapsed += MoveWindow;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Location = new Point(0, 0);
                this.Size = new Size(300, 300);

                direction = "right";
                moveTimer.Start();
            }
            else if (e.KeyCode == Keys.Escape)
            {

                moveTimer.Stop();
            }
        }

        private void MoveWindow(object sender, ElapsedEventArgs e)
        {

            this.Invoke(new Action(() =>
            {

                Rectangle screenBounds = Screen.PrimaryScreen.Bounds;


                int x = this.Location.X;
                int y = this.Location.Y;

                switch (direction)
                {
                    case "right":
                        x += step;
                        if (x + this.Width >= screenBounds.Width)
                        {
                            x = screenBounds.Width - this.Width;
                            direction = "down";
                        }
                        break;

                    case "down":
                        y += step;
                        if (y + this.Height >= screenBounds.Height)
                        {
                            y = screenBounds.Height - this.Height;
                            direction = "left";
                        }
                        break;

                    case "left":
                        x -= step;
                        if (x <= 0)
                        {
                            x = 0;
                            direction = "up";
                        }
                        break;

                    case "up":
                        y -= step;
                        if (y <= 0)
                        {
                            y = 0;
                            direction = "right";
                        }
                        break;
                }
                this.Location = new Point(x, y);
            }));
        }
    }
}
