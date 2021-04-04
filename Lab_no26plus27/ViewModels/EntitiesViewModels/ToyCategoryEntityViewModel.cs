#region Using namespaces

using Lab_no25.Model.Entities;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.EntitiesViewModels
{
    public class ToyCategoryEntityViewModel : BindableBase
    {
        private ToyCategoryEntity _toyCategoryEntity;

        public ToyCategoryEntityViewModel(ToyCategoryEntity entity) => Entity = entity;

        public ToyCategoryEntity Entity
        {
            get => _toyCategoryEntity;
            set => SetProperty(ref _toyCategoryEntity, value);
        }
    }
}