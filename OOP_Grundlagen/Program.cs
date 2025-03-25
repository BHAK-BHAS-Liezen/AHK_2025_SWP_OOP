namespace OOP_Grundlagen
{
    public delegate int Calculator(int a, int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            var auto = new Car("rot",new DateTime(2008,10,5));
            auto.Name = "Herby";
            Console.WriteLine(auto.Draw());
            // Polymorphie (Vielschichtigkeit) und ermöglicht uns mehrere
            // voneinander unabhängige, jedoch mit dem Ursprung verbundene
            // (Basisklasse), Klassen in ein Konstrukt (Liste, Array,...)
            // zusammen zu verwalten und dementsprechend die Methoden der
            // genannten Basisklasse zu verwenden
            var drawingList = new List<IDraw>();
            drawingList.Add(new Car("weiß", DateTime.Now, "Herby"));
            drawingList.Add(new Car("pink", DateTime.Now, "Daisy"));
            drawingList.Add(new Truck("blau","Alfred"));

            foreach (var item in drawingList)
            {
                Console.WriteLine(item.Draw());
            }

            Console.WriteLine("Bitte geben Sie zwei Zahlen ein:");
            //int a = Convert.ToInt32( Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            int a, b;
            Console.WriteLine("Zahl1:");
            // Präventive Fehlerbehandlung: Der Fehler, die Ausnahme
            // wird gar nicht zugelassen und vorher abgefangen
            // Beispiel bei TryParse für Zahlen die von string
            // Konvertiert werden.
            while (!Int32.TryParse(Console.ReadLine(), out a));
            Console.WriteLine("Zahl2:");
            while(!Int32.TryParse(Console.ReadLine(), out b));
            
            int result=0;
            Calculator calc;
            Console.WriteLine("Bitte geben Sie einen Rechenoperator ein:\n" +
                "a oder + für Addition\n" +
                "s oder - für Subtraktion\n" +
                "m oder * für Multiplikation\n" +
                "d oder / für Division:");
            string op = Console.ReadLine();
            if (op.ToLower() == "a" || op == "+")
            {
                calc = new Calculator(MatheBib.Add);
            }
            else if (op.ToLower() == "s" || op == "-")
            {
                calc = new Calculator(MatheBib.Sub);
            }
            else if (op.ToLower() == "m" || op == "*")
            {
                calc = new Calculator(MatheBib.Mul);
            }
            else if (op.ToLower() == "d" || op == "/")
            {
                calc = new Calculator(MatheBib.Div);
            }
            else
            {
                result = 0;
                Console.WriteLine("Falsche Eingabe!");
                return;
            }
            // Aktive Fehlerbehandlung: Fehler wird zugelassen und im
            // Fehlerfall "Ausnahme" wird der Fehler abgefangen!
            // Achtung bei NullReferenceException diese muss immer
            // Präventiv behandelt werden.Try ist Ausführung und Catch
            // ist Behandlung Abfangen! Wie auch bei Schleifen und Bedingungen
            // ist auch bei try catch jede beschriebene Variable nur in dem
            // Block anzusprechen, wenn ihr eine Variable dort drinnen
            // definiert ist diese ausserhalb nicht zu verwenden.
            // catch soll in Hierachien aufgebaut werden also von
            // Spezifisch zu Allgemein siehe unten:
            try
            {
                result = calc(a, b);
            }           
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Ergebnis: "+result);

            
        }

    }
    // OOP wird für die Übersichtlichkeit benötigt
    // Wiederverwendung des Codes
    // Klassen, Objekte, Methoden und Eigenschaften dienen nur für unser Verständnis
    // der Computer kommuniziert ausschließlich mit 0 und 1 somit ist es ihm egal
    // ob es eine Klasse oder dergleichen gibt.
    // Wartbarkeit des Codes
    // Sicherheit des Codes wird durch Zugriffsmodifikatoren geregelt
    // Das Schlüsselwort class dient zur Erstellung einer Klasse,
    // dieses Schlüsselwort erbt von object
    // Variablen sind Standardmäßig in der Klassendefinition private
    // Die Vererbung von Klassen an eine andere Klasse erfolgt
    // mittels dem : ist der Zugriffsmodifikator der abgeleiteten
    // Klasse geringer als der, der Basisklasse, ist keine Ableitung
    // (Vererbung) möglich.
    internal class Car : Vehicle, IDraw
    {
        //Ein Konstruktor ist eine Methode welche beim Erstellen
        //von neuen Objekten benötigt wird. Daher gilt auch hier
        //die Regel und Möglichkeit der Überladung der einzelnen
        //Konstruktoren. Die Konstruktoren können mittels der
        //Änderung der Übergabeparameter überladen werden.
        //Standardkonstruktor: Dieser Konstruktor besteht immer
        //sobald wir eine Klasse z.B.: Car erstellen. Erstellen
        //wir einen neuen Konstruktor, wird der Standardkonstruktor
        //überschrieben und ist nicht mehr verfügbar. Das bedeutet
        //wir müssen den Standardkonstruktor, wenn benötigt, selbst
        //wieder erstellen. Bei den Konstruktoren gibt es beim Aufruf
        //immer eine so genannte Konstruktorverkettung, diese funktioniert
        //wie folgend erläutert: Aufruf des Konstruktor Car() mit
        //new Car() in der Main Methode. Als aller erstes wird der
        //Standardkonstruktor der Klasse Objekt aufgerufen. Wird
        //mit dem Standardkonstruktor der Objektbau nicht abgedeckt
        //wird versucht in der Basisklasse, einen passenden Konstruktor
        //zu finden, ist dort auch keiner vorhanden, wird der Konstruktor
        //in der Klasse aufgerufen. Das ist auch der Grund warum wir
        //keinen Konstruktor definieren müssen, wenn wir "nur" den
        //Standardkonstruktor aufrufen wollen und im Konstruktor keine
        //Eigenschaften verändert werden sollen. Schlüsselwort
        //base wird verwendet um die Konstruktoren der Basisklasse in der
        //abgeleiteten Klasse verwenden zu können. 
        public Car(string color, DateTime prodDate):base(color)
        {
            ProductionDate = prodDate;
            Wheels = 4;
            Door = 3;

        }
        public Car(string color, DateTime prodDate,string name) : base(color)
        {
            ProductionDate = prodDate;
            Wheels = 4;
            Door = 3;
            Name = name;

        }
        public int Wheels;

        //Mit dem angeführten Block wird die Draw() Methode aus dem
        //Interface IDraw implementiert. Die Implementierung ist notwendig,
        //weil das Interface IDraw als Schablone für Car dient und alle
        //Member aus IDraw implementiert werden müssen
        //Achtung! wenn diese nicht selbst
        //ausimplementiert wird, wird beim Aufruf eine Exception geworfen
        public string Draw()
        {
            return $"{Name} hat {Wheels} und ist vom Baujahr {ProductionDate}";
        }

        public override void Drive()
        {
            Console.WriteLine("Auto fährt");
        }
    }

}
