using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Elfe : Guerrier
    {


        public Elfe(string nom, int pDV, int aTQ) : base(nom, pDV, aTQ)
        { 
        }

        public override string ToString()
        {
            return $"Nain - {Name} (PV: {PDV}, ATQ: {ATQ})";
        }

        public override double Attaquer()
        {
            if(dice.Next(1, 7) == 6)
            {
                ATQ = 150;
               
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.  ");
            }
            else if (dice.Next(1, 7) == 5)
            {
                ATQ = 75;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            }
            else if (dice.Next(1, 7) == 4)
            {
                ATQ = 45;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            }
            else if (dice.Next(1, 7) == 1)
            {
                ATQ = 1.5;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.  ");
            }
            else
            {
                ATQ = 22.5;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.  ");
            }
            return ATQ;
        }

      
    }
}
