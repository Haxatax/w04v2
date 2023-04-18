using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace w03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Army> army;
        private int allmoney = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Allmoney { get => allmoney;

            set
            {
                if (value !=allmoney)
                {
                    allmoney = value;
                    OnPropertyChanged("Allmoney");
                }
            }
            }
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #region video
        //private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler !=null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            army = new ObservableCollection<Army>()            
            {
                new Army(){ Name="Marine", Power=8, Vitality=6,Cost=6, Money=1},
                new Army(){ Name="Pilot", Power=7, Vitality=3,Cost=10, Money=1},
                new Army(){ Name="Infantry", Power=6, Vitality=9,Cost=10, Money=1},
                new Army(){ Name="Sniper", Power=3, Vitality=3,Cost=7, Money=1},
                new Army(){ Name="Engineer", Power=4, Vitality=5,Cost=9, Money=1}
            };           
            LLBox.ItemsSource = army;            
            ;
        }
        private void addarmyfromleft(object sender, RoutedEventArgs e)
        {
            if (LLBox.SelectedItem!=null)
            {
                rlbox.Items.Add(LLBox.SelectedItem);
                dynamic Booth = LLBox.SelectedItem as dynamic;
                Allmoney += Booth.Money;

            }
            ;
        }

        private void deletearmyfromright(object sender, RoutedEventArgs e)
        {
            if (rlbox.SelectedItem!=null)
            {
                rlbox.Items.Remove(rlbox.SelectedItem);
                dynamic Booth = LLBox.SelectedItem as dynamic;
                Allmoney -= Booth.Money;
            }
            ;
        }

        private void armyeditor(object sender, RoutedEventArgs e)
        {
            dynamic Booth = LLBox.SelectedItem as dynamic;
            //ObservableCollection<Army> army33= Booth;
        ArmyEditor ablak= new ArmyEditor(Booth);
            ablak.Show();  
        }
    }
   
}
