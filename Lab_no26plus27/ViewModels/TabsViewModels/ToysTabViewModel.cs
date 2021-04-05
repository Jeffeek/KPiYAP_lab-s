#region Using namespaces

using System;
using System.Collections.Generic;
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
        private readonly List<ToyEntityViewModel> _internalList;
        private ObservableCollection<ToyEntityViewModel> _toys;

        private DelegateCommand _searchCommand;
        private AsyncRelayCommand _removeToyCommand;
        private AsyncRelayCommand _applyToyChangesCommand;
        private AsyncRelayCommand _reloadToysCommand;
        private DelegateCommand _changeEditModeCommand;
        private DelegateCommand _addToyCommand;
        private string _searchText = String.Empty;

        public ToysTabViewModel(IToysService toysService)
        {
            _toysService = toysService;
            Toys = new ObservableCollection<ToyEntityViewModel>();
            _internalList = new List<ToyEntityViewModel>();
            ReloadToysAsync().Wait();
        }

        #region Commands

        public DelegateCommand AddToyCommand =>
            _addToyCommand ??= new DelegateCommand(OnAddToyCommandExecuted);

        public DelegateCommand ChangeEditModeCommand =>
            _changeEditModeCommand ??= new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnToy)
                .ObservesProperty(() => SelectedToy);

        public DelegateCommand SearchCommand =>
            _searchCommand ??=
                new DelegateCommand(OnSearchCommandExecuted, () => SearchText.Length != 0)
                    .ObservesProperty(() => SearchText);

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

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;

                if (value != String.Empty) return;

                Toys.Clear();
                Toys.AddRange(_internalList);
            }
        }

        private bool CanManipulateOnToy() => SelectedToy is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private void OnSearchCommandExecuted()
        {
            ToyEntityViewModel[] filteredToys;
            if (Int32.TryParse(SearchText, out var number))
            {
                filteredToys =
                    _internalList.Where(x => x.Entity.Id == number || x.Entity.CategoryId == number).ToArray();

                if (filteredToys.Length == 0) return;

                Toys.Clear();
                Toys.AddRange(filteredToys);

                return;
            }

            filteredToys = Toys.Where(x => x.Entity.Producer.Contains(SearchText)).ToArray();
            Toys.Clear();
            Toys.AddRange(filteredToys);
        }

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
            if (SelectedToy.Entity.Id == 0) Toys.Remove(SelectedToy);
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
            _internalList.Clear();
            foreach (var toy in dbToys)
                _internalList.Add(new ToyEntityViewModel(toy));

            Toys.AddRange(_internalList);
        }
    }
}