#region Using namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

#endregion

namespace Lab_no_22
{
    public partial class ShopForm : Form
    {
        private readonly Check _check;
        private readonly string _productsFilePath = $"{Directory.GetCurrentDirectory()}\\products.json";
        private List<Product> _allProducts;

        public ShopForm()
        {
            InitializeComponent();
            _check = new Check();

            ChangeTime()
                .ConfigureAwait(true);

            ReadProductsFromFile();
            FillProductsComboBox();

            _check.SumOfProductsChanged += (s, e) =>
                                           {
                                               labelCurrentSum.Text = e.ToString();
                                               UpdateCheck(s.ToString());
                                           };
        }

        private async Task ChangeTime()
        {
            await Task.Run(() =>
                           {
                               while (true)
                               {
                                   var currentTime = DateTime.Now.ToString("hh:mm:ss MM/dd/yyyy");
                                   statusBarCurrentTime.Text = currentTime;
                               }
                           });
        }

        private void ReadProductsFromFile()
        {
            var fileString = File.ReadAllText(_productsFilePath);
            _allProducts = JsonConvert.DeserializeObject(fileString, typeof(List<Product>)) as List<Product>;
        }

        private void FillProductsComboBox()
        {
            foreach (var product in _allProducts)
                comboBoxProducts.Items.Add($"{product.Title} : {product.Price}");
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedIndex < 0)
                return;

            var product = _allProducts[comboBoxProducts.SelectedIndex];

            if (product is null)
                throw new NotSupportedException();

            _check.AddProduct(product);
        }

        public void UpdateCheck(string text)
        {
            richTextBoxCheck.Text = text;
        }

        private void comboBoxPayVariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayVariants.SelectedIndex == 1)
                _check.ApplyDiscount();
            else
                _check.NormalizeSum();
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            _check.ClearProducts();
            richTextBoxCheck.Text = String.Empty;
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            if (richTextBoxCheck.Text == String.Empty)
                return;

            var fileDialog = new SaveFileDialog
                             {
                                 Filter = "*.txt;|*.txt",
                                 InitialDirectory = $"{Directory.GetCurrentDirectory()}"
                             };

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            MessageBox.Show(this, "Ok");
            File.WriteAllText(fileDialog.FileName, richTextBoxCheck.Text);
            _check.ClearProducts();
            richTextBoxCheck.Text = String.Empty;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var passForm = new PasswordForm(RemoveLast);
            passForm.ShowDialog(this);
        }

        private void RemoveLast()
        {
            _check.RemoveLast();
        }

        private void toolStripShowInfo_Click(object sender, EventArgs e)
        {
            var infoForm = new InfoForm();
            infoForm.Show(this);
        }
    }
}