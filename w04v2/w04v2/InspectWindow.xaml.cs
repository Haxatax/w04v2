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
using w04v2.Models;
using w04v2.ViewModels;

namespace w04v2
{
    /// <summary>
    /// Interaction logic for InspectWindow.xaml
    /// </summary>
    public partial class InspectWindow : Window
    {
        public InspectWindow(People person)
        {
            InitializeComponent();
            this.DataContext = new InspectWindowViewModel();
            (this.DataContext as InspectWindowViewModel).Setup(person);
        }
    }
}
