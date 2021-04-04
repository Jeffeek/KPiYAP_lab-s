#region Using namespaces

using Lab_no25.Model.Entities;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.EntitiesViewModels
{
    public class ToyEntityViewModel : BindableBase
    {
        private ToyEntity _entity;

        public ToyEntityViewModel(ToyEntity entity) => Entity = entity;

        public ToyEntity Entity
        {
            get => _entity;
            set => SetProperty(ref _entity, value);
        }
    }
}