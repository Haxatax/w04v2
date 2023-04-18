using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w04v2.Models;

namespace w04v2.ViewModels
{
    public class InspectWindowViewModel
    {
        public People Actual { get; set; }
        public void Setup(People person)
        {
            this.Actual = person;
        }
        public InspectWindowViewModel() { }
    }
}
