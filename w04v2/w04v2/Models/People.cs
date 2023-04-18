using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w04v2.Models
{
    public class People : ObservableObject
    {
        string name;
        public string Name { get { return name; } set { SetProperty(ref name, value); } }
        double personalbest;
        public double Personalbest { get { return personalbest; } set { SetProperty(ref personalbest, value); } }
        double presentbest;
        public double Presentbest { get { return presentbest; } set { SetProperty(ref presentbest, value); } }
        bool hasracepermit;
        public bool Hasracepermit { get { return hasracepermit; } set { SetProperty(ref hasracepermit, value); } }
        string organisation;
        public string Organisation { get { return organisation; } set { SetProperty(ref organisation, value); } }
        int racenr;
        public int Racenr { get { return racenr; } set { SetProperty(ref racenr, value); } }

        public double MarketValue { get { return personalbest * presentbest; } }
        public People GetCopy() 
        {
            return new People()
            {
                Name = this.Name,
                Personalbest = this.Personalbest,
                Presentbest = this.Presentbest,
                Hasracepermit = this.Hasracepermit,
                Organisation = this.Organisation,
                Racenr = this.Racenr
            };
        }
    }
}
