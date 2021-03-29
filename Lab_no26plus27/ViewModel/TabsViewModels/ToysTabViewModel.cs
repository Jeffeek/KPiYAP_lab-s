#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.ViewModel.EntitiesViewModels;

#endregion

namespace Lab_no26plus27.ViewModel.TabsViewModels
{
    public class ToysTabViewModel : ViewModelBase
    {
        private readonly IToysService _toysService;
        private bool _isEditMode;
        private ToyEntityViewModel _selectedToy;
        private ObservableCollection<ToyEntityViewModel> _toys;

        public ToysTabViewModel(IToysService toysService)
        {
            _toysService = toysService;
            Toys = new ObservableCollection<ToyEntityViewModel>();
            ChangeEditModeCommand = new RelayCommand(OnChangeEditModeCommandExecuted);
            ApplyToyChangesCommand = new AsyncRelayCommand(OnApplyToyChangesCommandExecuted);
            RemoveToyCommand = new AsyncRelayCommand(OnRemoveToyCommandExecuted);
            AddToyCommand = new RelayCommand(OnAddToyCommandExecuted);
            ReloadToysCommand = new AsyncRelayCommand(ReloadToysAsync);
            ReloadToysAsync();
        }

        public ICommand AddToyCommand { get; }

        public ICommand RemoveToyCommand { get; }

        public ICommand ApplyToyChangesCommand { get; }

        public ICommand ChangeEditModeCommand { get; }

        public ICommand ReloadToysCommand { get; }

        public ObservableCollection<ToyEntityViewModel> Toys
        {
            get => _toys;
            set => Set(ref _toys, value);
        }

        public ToyEntityViewModel SelectedToy
        {
            get => _selectedToy;
            set => Set(ref _selectedToy, value);
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => Set(ref _isEditMode, value);
        }

        private bool CanManipulateOnToy() => SelectedToy is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private void OnAddToyCommandExecuted()
        {
            Toys.Insert(0,
                        new ToyEntityViewModel(new ToyEntity
                                               {
                                                   CategoryId = 1,
                                                   Price = 0,
                                                   Producer = String.Empty,
                                                   WarehouseCount = 0
                                               }));
            SelectedToy = Toys.First();
        }

        private async Task OnRemoveToyCommandExecuted()
        {
            if (!CanManipulateOnToy()) return;

            await _toysService.RemoveToyAsync(SelectedToy.Entity);
            Toys.Remove(SelectedToy);
            SelectedToy = null;
        }

        private async Task OnApplyToyChangesCommandExecuted()
        {
            if (!CanManipulateOnToy()) return;

            if (SelectedToy.Entity.Id == 0)
                await _toysService.AddToyAsync(SelectedToy.Entity);
            else
                await _toysService.UpdateToyAsync(SelectedToy.Entity);
            await ReloadToysAsync();
        }

        private async Task ReloadToysAsync()
        {
            var dbToys = await _toysService.GetAllToysAsync();
            Toys.Clear();
            foreach (var toy in dbToys) Toys.Add(new ToyEntityViewModel(toy));
        }
    }
}