﻿using JsuisUnGuerrier.Affichage;
using JsuisUnGuerrier.Classes;
namespace JsuisUnGuerrier.Etage
{
    internal class Etage2
    {
        public static void Mob()
        {
            HobGobelin wolf = new HobGobelin("Bogg", 300, 30, 0);
            Ogres Ogres = new Ogres("Alexandre", 450, 40, 0, 0);
            Guerrier.monstre.Add(wolf);
            Guerrier.monstre.Add(Ogres);
        }
        public static void CombatEtage2()
        {
            Mob();
            while (Guerrier.monstre.Count != 0 && Guerrier.lesGuerrier.Count != 0)
            {
                //clear Pour éviter que il y est une surcharge de texte 
                Console.Clear();
                //L'attaque de l'utilisateur
                MenuCombat.Choice();
                // verifie la mort du monstre
                VerificationMort.VraiMortMonstre();
                if (Guerrier.lesGuerrier.Count > 0 && Guerrier.monstre.Count > 0)
                {
                    //attaque monstre 
                    MenuCombatMonstre.ChoiceMonstre();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                // la fonction de verification si guerrier est mort 
                VerificationMort.VraiMortAventurier();
                Console.ResetColor();
                // cette boucle permet d'executer correctement chaque reduction de delai et Dot Pour chaque heros a son index
                for (int i = 0; i < Guerrier.lesGuerrier.Count; i++)
                {
                    Guerrier.lesGuerrier[i].ReductionCooldown();
                    Guerrier.lesGuerrier[i].ReductionCooldownSpecial();
                }
                Thread.Sleep(4500);
            }
            if (Guerrier.lesGuerrier.Count > 0)
            {
                //Incrémentation si l'étage et fini
                Etage1.compteurEtage++;
            }
            else
            {
                Etage1.compteurEtage = 1;
            }

        }
    }
}
