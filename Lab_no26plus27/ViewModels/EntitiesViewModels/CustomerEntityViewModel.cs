using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_no25.Model.Entities;
using Prism.Mvvm;

namespace Lab_no26plus27.ViewModels.EntitiesViewModels
{
    public class CustomerEntityViewModel : BindableBase
    {
        private CustomerEntity _entity;

        public CustomerEntityViewModel(CustomerEntity entity)
        {
            _entity = entity;
        }

        public CustomerEntity Entity { get => _entity; set => SetProperty(ref _entity, value); }
    }
}
