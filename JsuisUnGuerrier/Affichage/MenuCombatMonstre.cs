using JsuisUnGuerrier.Classes;


namespace JsuisUnGuerrier.Affichage
{
    internal class MenuCombatMonstre : Guerrier
    {
        public MenuCombatMonstre(string nom, double pDV, double aTQ, double dEF) : base(nom, pDV, aTQ, dEF)
        {
        }
        public static void ChoiceMonstre()
        {
           
            // vue que les choix peuvent attaquer chacun leur tour pourquoi pas les monstre ? 
            for (int i = 0; i < monstre.Count; i++)
            {
                Affichage.Centre($"\nTour de {monstre[i]}  \n");
                int aleatoireMob = monstre[i].ActionMob();
                switch (aleatoireMob)
                {
                    case 1:
                        // Attaque classique
                        double degats = monstre[i].Attaquer();
                        monstre[0].SubirDegats(degats);
                        break;
                    case 2:
                        double degats2 = monstre[i].AttaqueSpecial();
                        //Attaque spécial des monstre !
                        lesGuerrier[0].SubirDegats(degats2);
                        break;
                }
                // Réduction du cooldown après chaque tour
                monstre[i].ReductionCooldown();
            }
        }
    }
}
