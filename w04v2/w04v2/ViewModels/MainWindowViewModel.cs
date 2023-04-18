using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using w04v2.Logic;
using w04v2.Models;
using System.IO;

namespace w04v2.ViewModels
{
    public class MainWindowViewModel: ObservableRecipient
    {
        IRaceLogic logic;
        public ObservableCollection<People> LeftLB { get; set; }
        public ObservableCollection<People> RightLB { get; set; }
       
        private People selectedfromleft;
        private People selectedfromright;
        public People SelectedFromLeft
        {
            get { return selectedfromleft; }
            set { 
                SetProperty(ref selectedfromleft, value);
                (AddtoRaceCommand as RelayCommand).NotifyCanExecuteChanged();
                (InspectCommand as RelayCommand).NotifyCanExecuteChanged();
                }
        }
        public People SelectedFromRight
        {
            get { return selectedfromright; }
            set { 
                SetProperty(ref selectedfromright, value);
                (RemovefromRaceCommand as RelayCommand).NotifyCanExecuteChanged();
                }
        }

        public ICommand AddtoRaceCommand { get; set; }
        public ICommand RemovefromRaceCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }
        public ICommand SaveDataCommand { get; set; }
        public ICommand InspectCommand { get; set; }
        private string savename = "Verseny";
        public string SaveName
        {
            get { return savename; }
            set
            {
                SetProperty(ref savename, value);
            }
        }
        private string savedate = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString();
        public string SaveDate
        {
            get { return savedate; }
            set
            {
                SetProperty(ref savedate, value);
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
            :this(IsInDesignMode ? null:Ioc.Default.GetService<IRaceLogic>())
        {

        }
        public void LoadLeft()
        {
            //Teszt addatokat. Ezeket a load gomb lenyomásával kellne betölteni a listboxokba

            LeftLB.Add(new People()
            {
                Name = "Sarah Johnson",
                Personalbest = 21,
                Presentbest = 20,
                Hasracepermit = false,
                Organisation = "Nike",
                Racenr = 1,

            });
            LeftLB.Add(new People()
            {
                Name = "Juan Garcia",
                Personalbest = 29,
                Presentbest = 25,
                Hasracepermit = true,
                Organisation = "Adidas",
                Racenr = 2,

            });
            LeftLB.Add(new People()
            {
                Name = "Emily Chen",
                Personalbest = 14,
                Presentbest = 10,
                Hasracepermit = true,
                Organisation = "Nike",
                Racenr = 3,

            });
            LeftLB.Add(new People()
            {
                Name = "David Kim",
                Personalbest = 22,
                Presentbest = 21,
                Hasracepermit = true,
                Organisation = "Puma",
                Racenr = 4,

            });

            //RightLB.Add(LeftLB[2].GetCopy());
            //RightLB.Add(LeftLB[3].GetCopy());

            logic.SetupCollections(LeftLB, RightLB);
        }
        public void Save()
        {
            string name = savename + "_" + savedate;
            string json = JsonConvert.SerializeObject(RightLB.ToArray());
            File.WriteAllText(name+".json",json);
        }
        public MainWindowViewModel(IRaceLogic logic)
        {
            this.logic = logic;
            LeftLB = new ObservableCollection<People>();
            RightLB = new ObservableCollection<People>();
           
            LoadDataCommand = new RelayCommand
                (
                  LoadLeft,null 
                );

            AddtoRaceCommand = new RelayCommand
                (
                () => logic.AddtoArmy(SelectedFromLeft),
                () => SelectedFromLeft !=null && SelectedFromLeft.Hasracepermit!=false
                ); 
            RemovefromRaceCommand = new RelayCommand
                (
               () => logic.RemovefromArmy(SelectedFromRight),
               () => SelectedFromRight != null
               );
            InspectCommand = new RelayCommand
                (
                ()=>logic.InspectRacer(SelectedFromLeft),
                () => SelectedFromLeft != null
              );
            SaveDataCommand = new RelayCommand
                (
                Save,null
                ) ;

        }
    }
}
