using JsuisUnGuerrier.Etage;
namespace JsuisUnGuerrier.Affichage
{
    internal class VisuelEtage
    {
        public static void visuEtage()
        {
            switch (Etage1.compteurEtage)
            {
                case 6:
                    AffichageEtage.EntreEtage();
                    Etage4.CombatEtage4();
                    break;
                case 2:
                    AffichageEtage.EntreEtage();
                    Etage2.CombatEtage2();
                    break;
                case 3:
                    AffichageBoss.EntreEtageDragon();
                    Etage3.CombatEtage3();
                    break;
                case 4:
                    AffichageEtage.EntreEtage();
                    Etage4.CombatEtage4();
                    break;
                case 5:
                    AffichageEtage.EntreEtage();
                    Etage5.CombatEtage5();
                    break;
                case 1:
                    AffichageBoss.EntreEtageVampire();
                    Etage6.CombatEtage6();
                    break;
            }
        }


    }
}
