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
            _viewModel.PropertyChanged += HandleViewModel;
        }

        private void HandleViewModel(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _viewModel.PropertyChanged -= HandleViewModel;
            Handle(e.PropertyName);
            _viewModel.PropertyChanged += HandleViewModel;
        }

        private void Handle(string? propertyName)
        {
            if (!_viewModel.IsEditing)
            {
                Fill();
                return;
            }

            if (_viewModel.SelectedClass != null)
                _viewModel.Squads = new ObservableCollection<Squad>(_context.Squads.Where(x => x.ClassTitle == _viewModel.SelectedClass.Title));
            if (_viewModel.SelectedSquad != null)
                _viewModel.Families = new ObservableCollection<Family>(_context.Families.Where(x => x.SquadTitle == _viewModel.SelectedSquad.Title));
            if (_viewModel.SelectedFamily != null)
                _viewModel.Genuses = new ObservableCollection<Genuse>(_context.Genuses.Where(x => x.FamilyTitle == _viewModel.SelectedFamily.Title));
        }

        private void Fill()
        {
            if (_viewModel.SelectedClass != null)
                _viewModel.Squads = new ObservableCollection<Squad>(_context.Squads.Where(x => x.ClassTitle == _viewModel.SelectedClass.Title));
            if (_viewModel.SelectedSquad != null)
                _viewModel.Families = new ObservableCollection<Family>(_context.Families.Where(x => x.SquadTitle == _viewModel.SelectedSquad.Title));
            if (_viewModel.SelectedFamily != null)
                _viewModel.Genuses = new ObservableCollection<Genuse>(_context.Genuses.Where(x => x.FamilyTitle == _viewModel.SelectedFamily.Title));
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