using JsuisUnGuerrier.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Affichage
{
    internal class VerificationMort
    {
        //j'aurais pu faire plus simple Oui, Mais j'ai choisie cette option qui présente des erreure mais qui va vérifier chaque membre de ma liste a la fin de des tour de combat si 1 membre est endessous de
        // il est compter comme mort et retirer de la liste 
        public static void VraiMortMonstre()
        {
            for (int i = Guerrier.monstre.Count - 1; i >= 0; i--)
            {
                if (Guerrier.monstre[i].PDV <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Affichage.Centre($"Aventurier vous avez vaincu le monstre {Guerrier.monstre[i].Name} !");
                    Console.ResetColor();
                    Guerrier.monstre[i].Death();
                    //Je remove en fonction de l'index
                    Guerrier.monstre.RemoveAt(i);
                }
            }
        }
        public static void VraiMortAventurier()
        {
            //C'est pareil que audessus mais pour la liste lesGuerrier.
            for (int i = Guerrier.lesGuerrier.Count - 1; i >= 0; i--)
            {
                if (Guerrier.lesGuerrier[i].PDV <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Affichage.Centre($"Aventurier la Tour a eux raison de {Guerrier.lesGuerrier[i].Name} ! ");
                    Console.ResetColor();
                    Guerrier.lesGuerrier[i].Death();
                    Guerrier.lesGuerrier.RemoveAt(i);
                }
            }
        }
    }
}
