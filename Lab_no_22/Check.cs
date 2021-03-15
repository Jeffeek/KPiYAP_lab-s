using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no_22
{
    public class Check
    {
        private int _innerSum = 0;
        private bool _isDiscount;
        private readonly Dictionary<Product, int> _products;
        
        public int Sum
        {
            get => _innerSum;
            private set
            {
                _innerSum = value;
                SumOfProductsChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<int> SumOfProductsChanged;

        public Check() => _products = new Dictionary<Product, int>();

        public void AddProduct(Product product)
        {
            if (_products.ContainsKey(product))
                _products[product]++;
            else
                _products.Add(product, 1);

            UpdateSum();
        }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => $"Магазин Чебурек\nЧек:\n{String.Join("\n", _products.Select(x => x.Key.ToString() + ". Sum = " + x.Key.Price * x.Value))}\nСумма:{Sum}\nБлагодарим за покупку!";

        #endregion

        public void NormalizeSum()
        {
            _isDiscount = false;
            UpdateSum();
        }

        public void ApplyDiscount()
        {
            _isDiscount = true;
            UpdateSum();
        }

        public void ClearProducts()
        {
            _products.Clear();
            Sum = 0;
        }

        private void UpdateSum() => Sum = (int)(_products.Sum(x => x.Key.Price * x.Value) * (_isDiscount ? 0.98 : 1));

        public void RemoveLast()
        {
            if (_products.Count == 0) return;

            var last = _products.Last().Key;
            _products.Remove(last);
            UpdateSum();
        }
    }
}
