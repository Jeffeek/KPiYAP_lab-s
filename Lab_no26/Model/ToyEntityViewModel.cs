using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;

namespace Lab_no26.Model
{
    public class ToyEntityViewModel
    {
        private readonly ObservableCollection<ToyEntityViewModel> _source;
        private readonly IToysService _toysService;

        public ToyEntity Entity { get; }

        public ICommand RemoveCommand { get; }

        public ToyEntityViewModel(ObservableCollection<ToyEntityViewModel> source,
                                  ToyEntity entity,
                                  IToysService toysService)
        {
            Entity = entity;
            _source = source;
            _toysService = toysService;
            RemoveCommand = new RelayCommand(OnRemoveFromCollectionExecuted, CanRemoveFromCollectionExecute);
        }

        private bool CanRemoveFromCollectionExecute() => _source.Contains(this);

        private void OnRemoveFromCollectionExecuted()
        {
            _source.Remove(this);
            _toysService.RemoveToyAsync(Entity);
        }
    }
}
