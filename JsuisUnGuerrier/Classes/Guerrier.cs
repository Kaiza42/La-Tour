using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Guerrier
    {
        private string _name;
        private double _pDV;
        private double _aTQ;
        public string Name { get => _name; set { _name = value; } }
        public double PDV { get => _pDV; set { _pDV = value; } }
        public double ATQ { get => _aTQ; set { _aTQ = value; } }

        public Random dice = new Random();
        public Guerrier(string nom, double pDV, double aTQ)
        {
            Name = nom;
            PDV = pDV;
            ATQ = aTQ;
        }
        public string GetNom()
        {
            return Name;
        }

        public double GetPointsDeVie()
        {
            return PDV;
        }

        public void SetPointsDeVie(int pDV)
        {

        }

        public double GetNbDesAttaque()
        {
            return ATQ;
        }

        public void AfficherInfos()
        {
            Console.WriteLine($"{Name} {PDV} ");
        }

        public virtual double Attaquer()
        {
            if (dice.Next(1, 7) == 6)
            {
                ATQ = 100;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            }
            else if (dice.Next(1, 7) == 5) 
            {
                ATQ = 50;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            } 
            else if (dice.Next(1, 7) == 4)
            {
                ATQ = 30;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            }
            else if (dice.Next(1,7)== 1)
            {
                ATQ = 1;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            }
            else
            {
                ATQ = 15;
                Console.WriteLine($"{Name} a fait {ATQ} de dégat.");
            }
                return ATQ;
        }
        public virtual void SubirDegats(double degat)
        {
            
            PDV = PDV - degat;
            Console.WriteLine($" {Name} as subis a pris {degat} il te reste {PDV}");
            if(PDV == 0)
            {
                Console.WriteLine($"Tu a perdue {Name}");
            }
           
        }

   


    }
}
