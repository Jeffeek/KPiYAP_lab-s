using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Lab_no26.Model.Editors
{
    public class ToyEntityEditorViewModel : ViewModelBase
    {
        private string _producer;
        private decimal _price;
        private int _warehouseCount;
        private string _photo;
        private int _categoryId;

        public string Producer
        {
            get => _producer;
            set => Set(ref _producer, value, nameof(Producer));
        }

        // todo: not implemented. af
        public decimal Price
        {
            get => _price;
            set => Set(ref _price, value, nameof(Price));
        }

        public int WarehouseCount
        {
            get => _warehouseCount;
            set => Set(ref _warehouseCount, value, nameof(WarehouseCount));
        }

        public string Photo
        {
            get => _photo;
            set => Set(ref _photo, value, nameof(Photo));
        }

        // todo: category can be not exist
        public int CategoryId
        {
            get => _categoryId;
            set => Set(ref _categoryId, value, nameof(CategoryId));
        }
    }
}
