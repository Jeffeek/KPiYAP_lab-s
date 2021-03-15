
namespace Lab_no_22
{
    partial class ShopForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarCurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentSum = new System.Windows.Forms.Label();
            this.richTextBoxCheck = new System.Windows.Forms.RichTextBox();
            this.contextMenuCheck = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPayVariants = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenuCheck.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarCurrentTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(526, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarCurrentTime
            // 
            this.statusBarCurrentTime.Name = "statusBarCurrentTime";
            this.statusBarCurrentTime.Size = new System.Drawing.Size(151, 20);
            this.statusBarCurrentTime.Text = "toolStripStatusLabel1";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.CausesValidation = false;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(12, 51);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(147, 24);
            this.comboBoxProducts.TabIndex = 1;
            this.comboBoxProducts.Text = "Выберите товар..";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Товары:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма:";
            // 
            // labelCurrentSum
            // 
            this.labelCurrentSum.AutoSize = true;
            this.labelCurrentSum.Location = new System.Drawing.Point(246, 28);
            this.labelCurrentSum.Name = "labelCurrentSum";
            this.labelCurrentSum.Size = new System.Drawing.Size(16, 17);
            this.labelCurrentSum.TabIndex = 4;
            this.labelCurrentSum.Text = "0";
            // 
            // richTextBoxCheck
            // 
            this.richTextBoxCheck.ContextMenuStrip = this.contextMenuCheck;
            this.richTextBoxCheck.Location = new System.Drawing.Point(188, 85);
            this.richTextBoxCheck.Name = "richTextBoxCheck";
            this.richTextBoxCheck.ReadOnly = true;
            this.richTextBoxCheck.Size = new System.Drawing.Size(314, 340);
            this.richTextBoxCheck.TabIndex = 5;
            this.richTextBoxCheck.Text = "";
            // 
            // contextMenuCheck
            // 
            this.contextMenuCheck.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuCheck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSave,
            this.toolStripMenuItemClear});
            this.contextMenuCheck.Name = "contextMenuCheck";
            this.contextMenuCheck.Size = new System.Drawing.Size(153, 52);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(152, 24);
            this.toolStripMenuItemSave.Text = "Сохранить";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(152, 24);
            this.toolStripMenuItemClear.Text = "Очистить";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Чек:";
            // 
            // comboBoxPayVariants
            // 
            this.comboBoxPayVariants.FormattingEnabled = true;
            this.comboBoxPayVariants.Items.AddRange(new object[] {
            "Наличными",
            "Картой"});
            this.comboBoxPayVariants.Location = new System.Drawing.Point(12, 401);
            this.comboBoxPayVariants.Name = "comboBoxPayVariants";
            this.comboBoxPayVariants.Size = new System.Drawing.Size(147, 24);
            this.comboBoxPayVariants.TabIndex = 8;
            this.comboBoxPayVariants.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayVariants_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Способ оплаты:";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(12, 85);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(147, 29);
            this.buttonAddProduct.TabIndex = 10;
            this.buttonAddProduct.Text = "Добавить";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 120);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(147, 30);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShowInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(526, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripShowInfo
            // 
            this.toolStripShowInfo.Name = "toolStripShowInfo";
            this.toolStripShowInfo.Size = new System.Drawing.Size(186, 24);
            this.toolStripShowInfo.Text = "Показать информацию";
            this.toolStripShowInfo.Click += new System.EventHandler(this.toolStripShowInfo_Click);
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 464);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxPayVariants);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxCheck);
            this.Controls.Add(this.labelCurrentSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopForm";
            this.Text = "Ильюшин Михаил Александрович П1807 3 вариант";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuCheck.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarCurrentTime;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentSum;
        private System.Windows.Forms.RichTextBox richTextBoxCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuCheck;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ComboBox comboBoxPayVariants;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowInfo;
    }
}

