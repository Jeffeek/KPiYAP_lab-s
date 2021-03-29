#region Using namespaces

using Lab_no25.Model.Entities;

#endregion

namespace Lab_no26plus27.ViewModel.EntitiesViewModels
{
    public class SaleEntityViewModel
    {
        public SaleEntityViewModel(SaleEntity entity) => Entity = entity;

        public SaleEntity Entity { get; }
    }
}