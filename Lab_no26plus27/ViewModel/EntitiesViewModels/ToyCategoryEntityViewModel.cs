#region Using namespaces

using Lab_no25.Model.Entities;

#endregion

namespace Lab_no26plus27.ViewModel.EntitiesViewModels
{
    public class ToyCategoryEntityViewModel
    {
        public ToyCategoryEntityViewModel(ToyCategoryEntity entity) => Entity = entity;

        public ToyCategoryEntity Entity { get; }
    }
}