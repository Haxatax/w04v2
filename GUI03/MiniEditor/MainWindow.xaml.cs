using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MiniEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> people;
        public MainWindow()
        {
            InitializeComponent();
            people = new ObservableCollection<Person>()
            {
                new Person(){Name = "Kati", Age = 20, HaveGlasses = "igen"},
                new Person(){Name = "Béla", Age = 30, HaveGlasses = "nem"},
                new Person(){Name = "Sanyi", Age = 10, HaveGlasses = "igen"}
            };
            lbox.ItemsSource = people;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbox.SelectedItem != null && lbox.SelectedItem is Person p)
            {
                if (p.HaveGlasses == "igen")
                {
                    p.HaveGlasses = "nem";
                }
                else
                {
                    p.HaveGlasses = "igen";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            people.Add(new Person()
            {
                Name = ""
            });
        }
    }
}
