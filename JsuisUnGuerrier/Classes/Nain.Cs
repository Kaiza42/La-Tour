using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Nain : Guerrier
    {
        private bool _armureLourde;

        public bool ArmureLourde { get => _armureLourde; set { _armureLourde = value; } }


        public Nain(string nom, double pDV, double aTQ, bool armureLourde ) : base (nom, pDV,aTQ)
        {
         
            ArmureLourde = armureLourde;
        }

        public override string ToString()
        {
            return $"Nain - {Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        
        public override void SubirDegats(double degat)
        {
            if(ArmureLourde == true)
            {
                degat /= 2;
            }

            PDV = PDV - degat;
            Console.WriteLine($" {Name} as subis a pris {degat} il te reste {PDV}");
            if (PDV == 0)
            {
                Console.WriteLine($"Tu a perdue {Name}");
            }

        }

    }
}
