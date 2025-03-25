using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Grundlagen
{
    internal class Truck : Vehicle, IDraw
    {
        public Truck(string color,string name):base(color)
        {
            ProductionDate = DateTime.Now;
            Name = name;
        }

        public string Draw()
        {
            return $"{Name} ist vom Baujahr {ProductionDate}";
        }
        // Methode wird mit override explezit überschrieben!
        public override void Drive()
        {
            Console.WriteLine("LKW fährt!");
        }
    }

    
    }
