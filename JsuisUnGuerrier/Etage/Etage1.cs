using JsuisUnGuerrier.Classes;
using JsuisUnGuerrier.Affichage;
namespace JsuisUnGuerrier.Etage
{
    internal class Etage1
    {
        // mon compteur etage qui permet que mon switch case fait jouer l'etage de ce compteur
        public static int compteurEtage = 1;
        public static void Mob()
        {
            Wolf wolf = new Wolf("Nashoba", 250, 30, 0,0);
            Gobelin gobelin = new Gobelin("Mugluk", 350, 40, 0, 0);
            Guerrier.monstre.Add(wolf);
            Guerrier.monstre.Add(gobelin);
        }
        public static void CombatEtage1()
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
            if(Guerrier.lesGuerrier.Count > 0)
            {
            //Incrémentation si l'étage et fini
            compteurEtage++;
            }
            else
            {
                compteurEtage = 1;
            }
            
        }
    }
}
