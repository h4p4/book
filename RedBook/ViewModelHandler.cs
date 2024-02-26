using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RedBook
{
    internal class ViewModelHandler
    {
        private readonly MainViewModel _viewModel;
        private RedBookContext _context;

        public ViewModelHandler(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Initialize(bool canEdit = false)
        {
            _viewModel.IsEditing = canEdit;
            _context = ContextProvider.RedBookContext;
            _viewModel.Classes = new ObservableCollection<Class>(_context.Classes);
            _viewModel.SaveCommand = new RelayCommand(SaveSpecies);
            _viewModel.AddCommand = new RelayCommand(AddObject);
            _viewModel.PropertyChanged += HandleViewModel;
        }

        private void AddObject(object param)
        {
            var window = new DialogWindow();
            string? result;

            if (_viewModel.SelectedClass == null)
            {
                result = window.ShowTitledDialog("класс");
                var newClass = new Class() { Title = result };
                AddSaveUpdate(newClass);
                return;
            }
            if (_viewModel.SelectedSquad == null)
            {
                result = window.ShowTitledDialog("отряд");
                var newSquad = new Squad() { Title = result, ClassTitle = _viewModel.SelectedClass.Title };
                AddSaveUpdate(newSquad);
                return;
            }
            if (_viewModel.SelectedFamily == null)
            {
                result = window.ShowTitledDialog("семейств");
                var newFamily = new Family() { Title = result, SquadTitle = _viewModel.SelectedSquad.Title };
                AddSaveUpdate(newFamily);
                return;
            }
            if (_viewModel.SelectedGenuse == null)
            {
                result = window.ShowTitledDialog("род");
                var newGenuse = new Genuse() { Title = result, FamilyTitle = _viewModel.SelectedFamily.Title };
                AddSaveUpdate(newGenuse);
                return;
            }
            if (_viewModel.SelectedSpecies == null)
            {
                var newSpecies = new SpeciesDialogWindow().ShowTitledDialog();
                newSpecies.GenusTitle = _viewModel.SelectedGenuse.Title;
                AddSaveUpdate(newSpecies);
                return;
            }
        }

        private void AddSaveUpdate(object entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            HandleViewModel(null, new System.ComponentModel.PropertyChangedEventArgs(null));
        }

        private void HandleViewModel(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _viewModel.PropertyChanged -= HandleViewModel;
            Handle();
            _viewModel.PropertyChanged += HandleViewModel;
        }

        private void Handle()
        {
            if (_viewModel.SelectedClass != null)
                _viewModel.Squads = new ObservableCollection<Squad>(_context.Squads.Where(x => x.ClassTitle == _viewModel.SelectedClass.Title));
            if (_viewModel.SelectedSquad != null)
                _viewModel.Families = new ObservableCollection<Family>(_context.Families.Where(x => x.SquadTitle == _viewModel.SelectedSquad.Title));
            if (_viewModel.SelectedFamily != null)
                _viewModel.Genuses = new ObservableCollection<Genuse>(_context.Genuses.Where(x => x.FamilyTitle == _viewModel.SelectedFamily.Title));

            if (!_viewModel.IsEditing)
                Fill();
        }

        private void Fill()
        {
            if (_viewModel.SelectedGenuse != null)
                _viewModel.Species = new ObservableCollection<Species>(_context.Species.Where(x => x.GenusTitle == _viewModel.SelectedGenuse.Title));
            if (_viewModel.SelectedSpecies != null)
            {
                _viewModel.CanEdit = true;
                return;
            }
            _viewModel.CanEdit = false;
        }

        private void SaveSpecies(object param)
        {
            var selectedSpecies = _viewModel.SelectedSpecies;
            selectedSpecies.GenusTitle = _viewModel.SelectedGenuse.Title;
            _context.Update(selectedSpecies);
            _context.SaveChanges();
            _viewModel.IsEditing = false;
        }
    }
}