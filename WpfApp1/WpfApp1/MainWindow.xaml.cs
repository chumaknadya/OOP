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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        public void MW_editHuman(object sender, RoutedEventArgs e)
        {
          // Update fields.
          ((MainViewModel)DataContext).HumanNameToEdit = NameEditField.Text;
          ((MainViewModel)DataContext).HumanSurnameToEdit = SurnameEditField.Text;
          ((MainViewModel)DataContext).HumanSexToEdit = SexEditField.Text;
          ((MainViewModel)DataContext).HumanAgeToEdit = Int32.Parse(AgeEditField.Text);
           // Call function foro editing.
           ((MainViewModel)DataContext).EditingHuman((Human)listMyItems.SelectedItem);
        }
    }
}
