namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        int min; 
        int max; 
        int attempts; 

        public Form1()
        {
            InitializeComponent();
            StartGame(); 
        }

        private void StartGame()
        {
            min = 1;
            max = 100;
            attempts = 0;

            DialogResult startResult = MessageBox.Show("��������� ����� �� 1 �� 100", "������ �����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (startResult == DialogResult.Yes)
            {
                GuessNumber(); 
            }
            else
            {
                Close(); 
            }
        }

        private void GuessNumber()
        {
            while (min <= max)
            {
                int guess = (min + max) / 2; 
                attempts++;

                DialogResult result = MessageBox.Show($"���� ����� {guess}?", "������ �����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"� ������ ����� {guess} �� {attempts} �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PlayAgain(); 
                    return;
                }

                DialogResult higherResult = MessageBox.Show($"���� ����� ������ {guess}?", "���������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (higherResult == DialogResult.Yes)
                {
                    min = guess + 1; 
                }
                else
                {
                    max = guess - 1; 
                }
            }

            MessageBox.Show("�������, �� �������� ���-�� �� �� ��������� 1-100!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            PlayAgain();
        }

        private void PlayAgain()
        {
            DialogResult playAgainResult = MessageBox.Show("������ ������� ��� ���?", "������ �����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (playAgainResult == DialogResult.Yes)
            {
                StartGame(); 
            }
            else
            {
                Close();
            }
        }

      
    }

}
