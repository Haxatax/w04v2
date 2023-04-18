using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w03
{
    public class Army
    {
        private string name;
        private int power;
        private int vitality;
        private int cost;
        private int money;

        //public Army(string name,int power, int vitality, int cost)
        //{
        //    this.name = name;
        //    this.power = power;
        //    this.vitality = vitality;
        //    this.cost = cost;
        //}

        public int Cost { get => cost; set => cost = value; }
        public int Vitality { get => vitality; set => vitality = value; }
        public int Power { get => power; set => power = value; }
        public string Name { get => name; set => name = value; }
        public int Money { get => money; set => money = Vitality*Power*Cost; }
    }
}
