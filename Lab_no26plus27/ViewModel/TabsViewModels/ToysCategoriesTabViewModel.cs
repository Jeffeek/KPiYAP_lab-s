#region Using namespaces

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
    public class ToysCategoriesTabViewModel : ViewModelBase
    {
        private readonly IToysCategoriesService _toysCategoriesService;
        private bool _isEditMode;
        private ToyCategoryEntityViewModel _selectedToyCategory;
        private ObservableCollection<ToyCategoryEntityViewModel> _toysCategories;

        public ToysCategoriesTabViewModel(IToysCategoriesService toysCategoriesService)
        {
            _toysCategoriesService = toysCategoriesService;
            ToysCategories = new ObservableCollection<ToyCategoryEntityViewModel>();
            ChangeEditModeCommand = new RelayCommand(OnChangeEditModeCommandExecuted);
            ApplyToyCategoryChangesCommand = new AsyncRelayCommand(OnApplyToyCategoryChangesCommandExecuted);
            RemoveToyCategoryCommand = new AsyncRelayCommand(OnRemoveToyCategoryCommandExecuted);
            AddToyCategoryCommand = new RelayCommand(OnAddToyCategoryCommandExecuted);
            ReloadToysCategoriesCommand = new AsyncRelayCommand(ReloadToysCategoriesAsync);
            ReloadToysCategoriesAsync();
        }

        public ICommand AddToyCategoryCommand { get; }

        public ICommand RemoveToyCategoryCommand { get; }

        public ICommand ApplyToyCategoryChangesCommand { get; }

        public ICommand ChangeEditModeCommand { get; }

        public ICommand ReloadToysCategoriesCommand { get; }

        public ObservableCollection<ToyCategoryEntityViewModel> ToysCategories
        {
            get => _toysCategories;
            set => Set(ref _toysCategories, value);
        }

        public ToyCategoryEntityViewModel SelectedToyCategory
        {
            get => _selectedToyCategory;
            set => Set(ref _selectedToyCategory, value);
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => Set(ref _isEditMode, value);
        }

        private bool CanManipulateOnToyCategory() => SelectedToyCategory is not null;

        private void OnChangeEditModeCommandExecuted() => IsEditMode = !IsEditMode;

        private void OnAddToyCategoryCommandExecuted()
        {
            ToysCategories.Insert(0,
                                  new ToyCategoryEntityViewModel(new ToyCategoryEntity
                                                                 {
                                                                     Age = 0,
                                                                     CareRules = "",
                                                                     WarrantyPeriod = 0
                                                                 }));
            SelectedToyCategory = ToysCategories.First();
        }

        private async Task OnRemoveToyCategoryCommandExecuted()
        {
            if (!CanManipulateOnToyCategory()) return;

            await _toysCategoriesService.RemoveToyCategoryAsync(SelectedToyCategory.Entity);
            ToysCategories.Remove(SelectedToyCategory);
            SelectedToyCategory = null;
        }

        private async Task OnApplyToyCategoryChangesCommandExecuted()
        {
            if (!CanManipulateOnToyCategory()) return;

            if (SelectedToyCategory.Entity.Id == 0)
                await _toysCategoriesService.AddToyCategoryAsync(SelectedToyCategory.Entity);
            else
                await _toysCategoriesService.UpdateToyCategoryAsync(SelectedToyCategory.Entity);
            await ReloadToysCategoriesAsync();
        }

        private async Task ReloadToysCategoriesAsync()
        {
            var dbToysCategories = await _toysCategoriesService.GetAllToysCategoriesAsync();
            ToysCategories.Clear();
            foreach (var toyCategory in dbToysCategories)
                ToysCategories.Add(new ToyCategoryEntityViewModel(toyCategory));
        }
    }
}