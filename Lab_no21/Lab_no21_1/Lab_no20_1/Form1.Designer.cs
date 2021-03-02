
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_no20_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button button1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private ComboBox comboBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Button button5;
        private Label label2;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.button1 = new Button();
            this.checkBox1 = new CheckBox();
            this.checkBox2 = new CheckBox();
            this.checkBox3 = new CheckBox();
            this.checkBox4 = new CheckBox();
            this.checkBox5 = new CheckBox();
            this.comboBox1 = new ComboBox();
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.radioButton3 = new RadioButton();
            this.radioButton4 = new RadioButton();
            this.radioButton5 = new RadioButton();
            this.radioButton6 = new RadioButton();
            this.radioButton7 = new RadioButton();
            this.radioButton8 = new RadioButton();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.label1 = new Label();
            this.button5 = new Button();
            this.label2 = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            this.button1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
            this.button1.Location = new Point(247, 226);
            this.button1.Name = "button1";
            this.button1.Size = new Size(129, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Кнопка 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.Button1_Click);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte) 204);
            this.checkBox1.Location = new Point(296, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(113, 29);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Холодно";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.checkBox2.Location = new Point(296, 81);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new Size(99, 29);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Теплее";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new EventHandler(this.CheckBox2_CheckedChanged);
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.checkBox3.Location = new Point(296, 105);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new Size(88, 29);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Тепло";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new EventHandler(this.CheckBox3_CheckedChanged);
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.checkBox4.Location = new Point(296, 129);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new Size(98, 29);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Горячо";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new EventHandler(this.CheckBox4_CheckedChanged);
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.checkBox5.Location = new Point(296, 153);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new Size(109, 29);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Кипяток";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new EventHandler(this.CheckBox5_CheckedChanged);
            this.comboBox1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[4]
            {
              (object) "Кнопка 1",
              (object) "Кнопка 2",
              (object) "Кнопка 3",
              (object) "Кнопка 4"
            });
            this.comboBox1.Location = new Point(546, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(180, 33);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Выбери кнопку";
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton1.Location = new Point(22, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(109, 29);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Желтый";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new EventHandler(this.RadioButton1_CheckedChanged);
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton2.Location = new Point(22, 59);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(109, 29);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "Красный";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.RadioButton2_CheckedChanged);
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton3.Location = new Point(22, 97);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new Size(124, 29);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.Text = "Зеленный";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new EventHandler(this.RadioButton3_CheckedChanged);
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton4.Location = new Point(22, 134);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new Size(87, 29);
            this.radioButton4.TabIndex = 10;
            this.radioButton4.Text = "Синий";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new EventHandler(this.RadioButton4_CheckedChanged);
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton5.Location = new Point(22, 29);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new Size(109, 29);
            this.radioButton5.TabIndex = 11;
            this.radioButton5.Text = "Желтый";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new EventHandler(this.RadioButton5_CheckedChanged);
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton6.Location = new Point(22, 64);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new Size(124, 29);
            this.radioButton6.TabIndex = 12;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Зеленный";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new EventHandler(this.RadioButton6_CheckedChanged);
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton7.Location = new Point(22, 99);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new Size(109, 29);
            this.radioButton7.TabIndex = 13;
            this.radioButton7.Text = "Красный";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new EventHandler(this.RadioButton7_CheckedChanged);
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.radioButton8.Location = new Point(22, 134);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new Size(87, 29);
            this.radioButton8.TabIndex = 14;
            this.radioButton8.Text = "Синий";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new EventHandler(this.RadioButton8_CheckedChanged);
            this.groupBox1.Controls.Add((Control)this.radioButton4);
            this.groupBox1.Controls.Add((Control)this.radioButton1);
            this.groupBox1.Controls.Add((Control)this.radioButton2);
            this.groupBox1.Controls.Add((Control)this.radioButton3);
            this.groupBox1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.groupBox1.Location = new Point(24, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(187, 169);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвет фона";
            this.groupBox2.Controls.Add((Control)this.radioButton5);
            this.groupBox2.Controls.Add((Control)this.radioButton6);
            this.groupBox2.Controls.Add((Control)this.radioButton8);
            this.groupBox2.Controls.Add((Control)this.radioButton7);
            this.groupBox2.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.groupBox2.Location = new Point(24, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(187, 175);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цвет Кнопки";
            this.button2.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.button2.Location = new Point(382, 226);
            this.button2.Name = "button2";
            this.button2.Size = new Size(129, 46);
            this.button2.TabIndex = 17;
            this.button2.Text = "Кнопка 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.Button2_Click);
            this.button3.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.button3.Location = new Point(517, 226);
            this.button3.Name = "button3";
            this.button3.Size = new Size(129, 46);
            this.button3.TabIndex = 18;
            this.button3.Text = "Кнопка 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.Button3_Click);
            this.button4.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.button4.Location = new Point(659, 226);
            this.button4.Name = "button4";
            this.button4.Size = new Size(129, 46);
            this.button4.TabIndex = 19;
            this.button4.Text = "Кнопка 4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.Button4_Click);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.label1.Location = new Point(275, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(183, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Поставь 5 галочек";
            this.button5.Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.button5.Location = new Point(408, 359);
            this.button5.Name = "button5";
            this.button5.Size = new Size(216, 67);
            this.button5.TabIndex = 21;
            this.button5.Text = "Сбросить все";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.Button5_Click);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, (byte)204);
            this.label2.Location = new Point(236, 198);
            this.label2.Name = "label2";
            this.label2.Size = new Size(552, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Можно выбрать кнопку, у которой хочешь поменять цвет";
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.AppWorkspace;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add((Control) this.label2);
            this.Controls.Add((Control) this.button5);
            this.Controls.Add((Control) this.label1);
            this.Controls.Add((Control) this.button4);
            this.Controls.Add((Control) this.button3);
            this.Controls.Add((Control) this.button2);
            this.Controls.Add((Control) this.groupBox2);
            this.Controls.Add((Control) this.groupBox1);
            this.Controls.Add((Control) this.comboBox1);
            this.Controls.Add((Control) this.checkBox5);
            this.Controls.Add((Control) this.checkBox4);
            this.Controls.Add((Control) this.checkBox3);
            this.Controls.Add((Control) this.checkBox2);
            this.Controls.Add((Control) this.checkBox1);
            this.Controls.Add((Control) this.button1);
            this.Text = "Компоненты и их свойства";
            this.Load += new EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

