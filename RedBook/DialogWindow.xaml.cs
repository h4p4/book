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
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public string ShowTitledDialog(string title)
        {
            Title = $"Введите название {title}а.";
            ShowDialog();
            return ResultTBox.Text;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
