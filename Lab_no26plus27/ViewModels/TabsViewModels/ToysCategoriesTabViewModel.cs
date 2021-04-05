#region Using namespaces

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
    public class ToysCategoriesTabViewModel : BindableBase
    {
        private readonly IToysCategoriesService _toysCategoriesService;
        private bool _isEditMode;
        private ToyCategoryEntityViewModel _selectedToyCategory;
        private ObservableCollection<ToyCategoryEntityViewModel> _toysCategories;
        private AsyncRelayCommand _reloadToysCategoriesCommand;
        private AsyncRelayCommand _removeToyCategoryCommand;
        private AsyncRelayCommand _applyToyCategoryChangesCommand;
        private DelegateCommand _addToyCategoryCommand;
        private DelegateCommand _changeEditModeCommand;

        public ToysCategoriesTabViewModel(IToysCategoriesService toysCategoriesService)
        {
            _toysCategoriesService = toysCategoriesService;
            ToysCategories = new ObservableCollection<ToyCategoryEntityViewModel>();
            ReloadToysCategoriesAsync().Wait();
        }

        public DelegateCommand AddToyCategoryCommand =>
            _addToyCategoryCommand ??= new DelegateCommand(OnAddToyCategoryCommandExecuted);

        public AsyncRelayCommand RemoveToyCategoryCommand =>
            _removeToyCategoryCommand ??=
                new AsyncRelayCommand(OnRemoveToyCategoryCommandExecuted, CanManipulateOnToyCategory);

        public AsyncRelayCommand ApplyToyCategoryChangesCommand =>
            _applyToyCategoryChangesCommand ??=
                new AsyncRelayCommand(OnApplyToyCategoryChangesCommandExecuted);

        public DelegateCommand ChangeEditModeCommand =>
            _changeEditModeCommand ??=
                new DelegateCommand(OnChangeEditModeCommandExecuted, CanManipulateOnToyCategory)
                    .ObservesProperty(() => SelectedToyCategory);

        public AsyncRelayCommand ReloadToysCategoriesCommand =>
            _reloadToysCategoriesCommand ??= new AsyncRelayCommand(ReloadToysCategoriesAsync);

        public ObservableCollection<ToyCategoryEntityViewModel> ToysCategories
        {
            get => _toysCategories;
            set => SetProperty(ref _toysCategories, value);
        }

        public ToyCategoryEntityViewModel SelectedToyCategory
        {
            get => _selectedToyCategory;
            set
            {
                SetProperty(ref _selectedToyCategory, value);
                RemoveToyCategoryCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
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
            if (SelectedToyCategory.Entity.Id == 0) ToysCategories.Remove(SelectedToyCategory);
            await _toysCategoriesService.RemoveToyCategoryAsync(SelectedToyCategory.Entity);
            ToysCategories.Remove(SelectedToyCategory);
            SelectedToyCategory = null;
        }

        private async Task OnApplyToyCategoryChangesCommandExecuted()
        {
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
            foreach (var toyCategory in dbToysCategories) ToysCategories.Add(new ToyCategoryEntityViewModel(toyCategory));
        }
    }
}