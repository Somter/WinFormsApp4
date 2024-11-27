namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int leftClicks = 0;  
        private int rightClicks = 0; 
        private int middleClicks = 0; 

        public Form1()
        {
            InitializeComponent();
            this.Text = "Статистика кликов"; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    leftClicks++;
                    break;
                case MouseButtons.Right:
                    rightClicks++;
                    break;
                case MouseButtons.Middle:
                    middleClicks++;
                    break;
            }

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            this.Text = $"Левые: {leftClicks}, Правые: {rightClicks}, Средние: {middleClicks}"; 
        }
    }
}
