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
    public class ToyCategoryEntityViewModel
    {
        private readonly ObservableCollection<ToyCategoryEntityViewModel> _source;
        private readonly IToysCategoriesService _toysService;

        public ToyCategoryEntity Entity { get; }

        public ICommand RemoveCommand { get; }

        public ToyCategoryEntityViewModel(ObservableCollection<ToyCategoryEntityViewModel> source,
                                          ToyCategoryEntity entity,
                                          IToysCategoriesService toysCategoriesService)
        {
            Entity = entity;
            _source = source;
            _toysService = toysCategoriesService;
            RemoveCommand = new RelayCommand(OnRemoveFromCollectionExecuted, CanRemoveFromCollectionExecute);
        }

        private bool CanRemoveFromCollectionExecute() => _source.Contains(this);

        private void OnRemoveFromCollectionExecuted()
        {
            _source.Remove(this);
            _toysService.RemoveToyCategoryAsync(Entity);
        }
    }
}
