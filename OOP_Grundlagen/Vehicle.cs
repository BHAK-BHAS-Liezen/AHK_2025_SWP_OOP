using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Grundlagen
{
    // Basisklasse Vehicle: Alle Eigenschaften und Methoden die mindestens
    // prodected gesetzt sind werden an die abgeleiteten Klassen vererbt
    // Wird private verwendet, ist es für die abgeleiteten Klassen
    // nicht ersichtlich. Wird der Standardkonstruktor überschrieben
    // kann dies bei der Instanzierung der abgeleiteten Klassen
    // zu Probleme führen. 
    internal abstract class Vehicle
    {
        public Vehicle() { }
        public Vehicle(string color)
        {
            Color = color;
        }

        public string Name { get; set; }

        //Property (prop)
        public string Color { get; set; }

        protected int Door { get; set; }

        // Datenkapselung (propfull)
        private DateTime productionDate;

        public DateTime ProductionDate
        {
            get { return productionDate; }
            set
            {
                if (value < DateTime.Now)
                { productionDate = value; }
                else
                {
                    Console.WriteLine("Fehler!");
                }
            }
        }
        public abstract void Drive(); 
    }
}
