#region Using namespaces

using GalaSoft.MvvmLight;
using Lab_no25.Model.Entities;

#endregion

namespace Lab_no26plus27.ViewModel.EntitiesViewModels
{
    public class ToyEntityViewModel : ViewModelBase
    {
        private ToyEntity _entity;

        public ToyEntityViewModel(ToyEntity entity) => Entity = entity;

        public ToyEntity Entity
        {
            get => _entity;
            set => Set(ref _entity, value);
        }
    }
}