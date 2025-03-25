using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Grundlagen
{
    // Interface wird für die Mehrfachvererbung benötigt und dient 
    // als Schablone. Alle Eigenschaften und Methoden im Interface
    // müssen in der abgeleiteten Klasse implementiert werden. Das
    // verhalten ist ähnlich zu einer abstrakten Methode oder
    // Eigenschaft.
    internal interface IDraw
    {
        string Draw();
    }
}
