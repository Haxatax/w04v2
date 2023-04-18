using System.Collections.Generic;
using w04v2.Models;

namespace w04v2.Logic
{
    public interface IRaceLogic
    {
        void AddtoArmy(People people);
        void RemovefromArmy(People people);
        void SetupCollections(IList<People> leftB, IList<People> rightB);
        public void InspectRacer(People people);
    }
}