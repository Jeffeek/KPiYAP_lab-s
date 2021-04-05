#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab_no25.Model.Entities;
using Lab_no25.Services.Interfaces.EntityServices;
using Lab_no26plus27.Model.AsyncCommand;
using Lab_no26plus27.ViewModels.EntitiesViewModels;
using Prism.Commands;
using Prism.Mvvm;

#endregion

namespace Lab_no26plus27.ViewModels.TabsViewModels
{
    public class ToysTabViewModel : BindableBase
    {
        private readonly IToysService _toysService;
        private bool _isEditMode;
        private ToyEntityViewModel _selectedToy;
        private ObservableCollection<ToyEntityViewModel> _toys;

        private AsyncRelayCommand _removeToyCommand;
        private AsyncRelayCommand _applyToyChangesCommand;
        private AsyncRelayCommand _reloadToysCommand;
        private DelegateCommand _changeEditModeCommand;
        private DelegateCommand _addToyCommand;

        public ToysTabViewModel(IToysService toysService)
        {
            _toysService = toysService;
            Toys = new ObservableCollection<ToyEntityViewModel>();

            ReloadToysAsync().Wait();
        }

        #region Commands

        public DelegateCommand AddToyCommand =>
            _addToyCommand ??= new DelegateCommand(OnAddToyCommandExecuted);

        public DelegateCommand ChangeEditModeCommand =>
            _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnToy)
                .ObservesProperty(() => SelectedToy);

        public AsyncRelayCommand RemoveToyCommand =>
            _removeToyCommand ??= new AsyncRelayCommand(OnRemoveToyCommandExecuted,
                                                        CanManipulateOnToy);

        public AsyncRelayCommand ApplyToyChangesCommand =>
            _applyToyChangesCommand ??= new AsyncRelayCommand(OnApplyToyChangesCommandExecuted);

        public AsyncRelayCommand ReloadToysCommand =>
            _reloadToysCommand ??= new AsyncRelayCommand(ReloadToysAsync);

        #endregion

        public ObservableCollection<ToyEntityViewModel> Toys
        {
            get => _toys;
            set => SetProperty(ref _toys, value);
        }

        public ToyEntityViewModel SelectedToy
        {
            get => _selectedToy;
            set
            {
                SetProperty(ref _selectedToy, value);
                RemoveToyCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
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
            await _toysService.RemoveToyAsync(SelectedToy.Entity);
            Toys.Remove(SelectedToy);
            SelectedToy = null;
        }

        private async Task OnApplyToyChangesCommandExecuted()
        {
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