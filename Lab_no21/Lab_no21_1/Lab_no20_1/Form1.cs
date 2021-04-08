#region Using namespaces

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Lab_no20_1
{
    public partial class Form1 : Form
    {
        private Button _currentButton;

        public Form1() =>
            InitializeComponent();

        private void StartNewGame()
        {
            _currentButton = null;
            comboBox1.Text = "Выбери кнопку";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            button1.BackColor = Color.LightGray;
            button2.BackColor = Color.LightGray;
            button3.BackColor = Color.LightGray;
            button4.BackColor = Color.LightGray;
            BackColor = Color.DarkGray;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox1.Visible = true;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
        }

        private Button GetSelectButton()
        {
            if (!(comboBox1.Text is string selectedItem))
                return null;

            switch (selectedItem)
            {
                case "Кнопка 1": return button1;

                case "Кнопка 2": return button2;

                case "Кнопка 3": return button3;

                case "Кнопка 4": return button4;

                default: return null;
            }
        }

        private void ColorButton(Color color)
        {
            button1.BackColor = color;
            button2.BackColor = color;
            button3.BackColor = color;
            button4.BackColor = color;
        }

        private void CurrentButtonColor(Color color)
        {
            if (GetSelectButton() == null)
                ColorButton(color);
            else
                GetSelectButton()
                    .BackColor = color;
        }

        private void CheckMission()
        {
            if (!checkBox1.Checked
                || !checkBox2.Checked
                || !checkBox3.Checked
                || !checkBox4.Checked
                || !checkBox5.Checked)
                return;

            MessageBox.Show("Миссия выполнена",
                            "Поздравляю",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
        }

        private void ClickButton()
        {
            if (_currentButton.BackColor == Color.Red)
            {
                MessageBox.Show("Окно Ошибки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (_currentButton.BackColor == Color.Green)
            {
                MessageBox.Show("Окно информации", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (_currentButton.BackColor == Color.Yellow)
            {
                MessageBox.Show("Окно предупреждения",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!(_currentButton.BackColor == Color.Blue))
                    return;

                MessageBox.Show("Окно Вопроса",
                                "Вопросик",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Question);
            }
        }

        private void Form1_Load(object sender, EventArgs e) =>
            StartNewGame();

        private void Button5_Click(object sender, EventArgs e) =>
            StartNewGame();

        private void RadioButton5_CheckedChanged(object sender, EventArgs e) =>
            CurrentButtonColor(Color.Yellow);

        private void RadioButton6_CheckedChanged(object sender, EventArgs e) =>
            CurrentButtonColor(Color.Green);

        private void RadioButton7_CheckedChanged(object sender, EventArgs e) =>
            CurrentButtonColor(Color.Red);

        private void RadioButton8_CheckedChanged(object sender, EventArgs e) =>
            CurrentButtonColor(Color.Blue);

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Visible = true;
            CheckMission();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Visible = true;
            CheckMission();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Visible = true;
            CheckMission();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Visible = true;
            CheckMission();
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e) =>
            CheckMission();

        private void Button1_Click(object sender, EventArgs e)
        {
            _currentButton = button1;
            ClickButton();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _currentButton = button2;
            ClickButton();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            _currentButton = button3;
            ClickButton();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            _currentButton = button4;
            ClickButton();
        }

        #region Background

        private void RadioButton1_CheckedChanged(object sender, EventArgs e) =>
            BackColor = Color.Yellow;

        private void RadioButton2_CheckedChanged(object sender, EventArgs e) =>
            BackColor = Color.Red;

        private void RadioButton3_CheckedChanged(object sender, EventArgs e) =>
            BackColor = Color.Green;

        private void RadioButton4_CheckedChanged(object sender, EventArgs e) =>
            BackColor = Color.Blue;

        #endregion
    }
}