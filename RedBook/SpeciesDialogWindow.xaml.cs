using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RedBook
{
    /// <summary>
    /// Логика взаимодействия для SpeciesDialogWindow.xaml
    /// </summary>
    public partial class SpeciesDialogWindow : Window
    {
        public SpeciesDialogWindow()
        {
            InitializeComponent();
        }

        public Species ShowTitledDialog()
        {
            Title = $"Введите параметры вида.";
            ShowDialog();
            var newSpecies = new Species()
            {
                Category = CatTBox.Text,
                Distribution = DistrTBox.Text,
                Habitat = HabTBox.Text,
                Count = CountTBox.Text,
                Protection = ProtTBox.Text,
                Title = TitleTBox.Text,
            };

            return newSpecies;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
