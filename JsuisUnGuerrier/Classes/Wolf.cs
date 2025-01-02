using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Wolf : Guerrier
    {
        private bool _saignement;

        public bool Saignement { get => _saignement; set { _saignement = value; } }
        public Wolf(string nom, double pDV, double aTQ, double dEF, bool saignement) : base(nom, pDV, aTQ, dEF)
        {
            Saignement = saignement;
        }
        public override string ToString()
        {
            return $" le monstre {Name} (PV: {PDV}, ATQ: {ATQ})";
        }
        public override double Attaquer()
        {
            //Pourquoi stocker dice ? hum.. a la base c'etait un if else et je devais le retaper en boucle sa me déranger un peu
            int result = dice.Next(1, 7);
            int rollAttack = dice.Next(1, 7);
            switch (rollAttack)
            {
                case 6:
                    ATQ = 90;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégat !");
                    Console.ResetColor();
                    break;
                case 1:
                    ATQ = 10;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} a raté son attaque !");
                    Console.ResetColor();
                    break;
                default:
                    ATQ = 45;
                    Console.WriteLine($"{Name} a fait {ATQ} de dégat !");
                    break;
            }
            return ATQ;
        }
        public void Mob()
        {
            Wolf wolf = new Wolf("wolfy", 250, 0, 0, true);
            Ogres Ogres = new Ogres("Alexandre", 300, 40, 0, 0);
            monstre.Add(wolf);
            monstre.Add(Ogres);
        }
        public void Drop()
        {
                Console.WriteLine("Bravo Vous avez un Nouveau Compagnon ! ");
                MaitreDesRat Julie = new MaitreDesRat("julie", 500, 40, 10, 0);
                lesGuerrier.Add(Julie);
                //if (dice.Next(1, 101) < 1 && dice.Next(1, 101) > 6) 
                //{
                //    MaitreDesRat 
                //}
        }
        public override void SubirDegats(double degat)
        {
        
            PDV -= degat;
            Console.WriteLine($"{Name} as subis {degat} degats, il lui reste {PDV} de vie");
        }
        public override void Death()
        {
            Console.WriteLine($"{Name} est mort.");
            Drop();

        }
        
    }
}
