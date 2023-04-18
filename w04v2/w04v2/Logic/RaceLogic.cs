using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w04v2.Models;
using w04v2.Services;

namespace w04v2.Logic
{
    public class RaceLogic : IRaceLogic
    {
        IList<People> leftb;
        IList<People> rightb;
        IMessenger messenger;
        IInspect inspect;
        public RaceLogic(IMessenger messenger,IInspect inspect)
        {
            this.messenger = messenger;
            this.inspect = inspect;
        }
        public void SetupCollections(IList<People> leftB, IList<People> rightB)
        {
            this.leftb = leftB;
            this.rightb = rightB;
        }

        public void AddtoArmy(People people)
        {
            rightb.Add(people.GetCopy());
            messenger.Send("Racer added", "RacerInformation");
        }
        public void RemovefromArmy(People people)
        {
            rightb.Remove(people);
            messenger.Send("Racer removed", "RacerInformation");
        }
        public void InspectRacer(People people)
        {
            inspect.Inspect(people);
        }
    }
}
