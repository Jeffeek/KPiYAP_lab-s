#region Using namespaces

using System;
using System.Windows.Forms;
using Lab_no21_2.Properties;

#endregion

namespace Lab_no21_2
{
    public partial class Form1 : Form
    {
        private readonly Random _random = new Random();
        private int _currentBalance = 100;
        private bool _isOpen;
        private int _number;

        public Form1() =>
            InitializeComponent();

        private void Button1_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value >= 1)
                CheckGoldenChest(button1, 1);
        }

        private void CheckGoldenChest(Button button, int n)
        {
            if (_isOpen)
                return;

            _isOpen = true;

            if (n == _number)
            {
                button.BackgroundImage = Resources.gold;
                _currentBalance += trackBar1.Value;
            }
            else
            {
                button.BackgroundImage = Resources.empty;
                _currentBalance -= trackBar1.Value;
            }

            RefreshWindow();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e) =>
            RefreshWindow();

        private void Form1_Load(object sender, EventArgs e) =>
            Restart();

        private void Restart()
        {
            RefreshWindow();
            _isOpen = false;
            _number = _random.Next(1, 4);
            button1.BackgroundImage = Resources.closed;
            button2.BackgroundImage = Resources.closed;
            button3.BackgroundImage = Resources.closed;
        }

        private void RefreshWindow()
        {
            trackBar1.Maximum = _currentBalance;
            label2.Text = "Деньги:" + _currentBalance;
            label1.Text = "Ставка:" + trackBar1.Value;

            if (_currentBalance != 0)
                return;

            MessageBox.Show("Вы бонкрот, прощайте",
                            "GameOver",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);

            Close();
        }

        private void Button4_Click(object sender, EventArgs e) =>
            Restart();

        private void Button2_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value >= 1)
                CheckGoldenChest(button2, 2);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value >= 1)
                CheckGoldenChest(button3, 3);
        }
    }
}