using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RedBook
{
    internal class MainViewModel : ViewModel
    {
        private bool isEditing;
        private bool canEdit;

        private ObservableCollection<Class> classes;
        private ObservableCollection<Squad> squads;
        private ObservableCollection<Family> families;
        private ObservableCollection<Genuse> genuses;
        private ObservableCollection<Species> species;

        private Class selectedClass;
        private Squad selectedSquad;
        private Family selectedFamily;
        private Genuse selectedGenuse;
        private Species selectedSpecies;

        public MainViewModel()
        {
            IsEditing = false;
        }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Class> Classes { get => classes; set => SetProperty(ref classes, value); }
        public  ObservableCollection<Squad> Squads { get => squads; set => SetProperty(ref squads, value); }
        public  ObservableCollection<Family> Families { get => families; set => SetProperty(ref families, value); }
        public  ObservableCollection<Genuse> Genuses { get => genuses; set => SetProperty(ref genuses, value); }
        public  ObservableCollection<Species> Species { get => species; set => SetProperty(ref species, value); }

        public Class SelectedClass 
        { 
            get => selectedClass; 
            set 
            {               
                SetProperty(ref selectedClass, value);
            } 
        }
        
        public Squad SelectedSquad 
        { 
            get => selectedSquad; 
            set 
            {               
                SetProperty(ref selectedSquad, value);
            }
        }
        
        public Family SelectedFamily 
        { 
            get => selectedFamily; 
            set 
            {               
                SetProperty(ref selectedFamily, value);
            }
        }
        
        public Genuse SelectedGenuse 
        { 
            get => selectedGenuse; 
            set 
            {               
                SetProperty(ref selectedGenuse, value);
            }
        }
        
        public Species SelectedSpecies 
        { 
            get => selectedSpecies; 
            set 
            {               
                SetProperty(ref selectedSpecies, value);
            } 
        }

        public bool IsEditing { get => isEditing; set => SetProperty(ref isEditing, value); }
        public bool CanEdit { get => canEdit; set => SetProperty(ref canEdit, value); }

    }
}
