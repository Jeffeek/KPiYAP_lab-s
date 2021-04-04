#region Using namespaces

using Lab_no25.Model.Entities;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.EntitiesViewModels
{
    public class SaleEntityViewModel : BindableBase
    {
        private SaleEntity _saleEntity;

        public SaleEntityViewModel(SaleEntity entity) => Entity = entity;

        public SaleEntity Entity
        {
            get => _saleEntity;
            set => SetProperty(ref _saleEntity, value);
        }
    }
}