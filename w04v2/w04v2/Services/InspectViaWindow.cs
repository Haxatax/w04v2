using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w04v2.Models;

namespace w04v2.Services
{
    public class InspectViaWindow : IInspect
    {
        public void Inspect(People people)
        {
            new InspectWindow(people).ShowDialog();
        }
    }
}
