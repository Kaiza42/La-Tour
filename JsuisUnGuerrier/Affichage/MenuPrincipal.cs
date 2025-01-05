using JsuisUnGuerrier.Classes;


namespace JsuisUnGuerrier.Affichage
{
    internal class MenuPrincipal
    {
        public static void CentreMenu(string text)
        {
            int largeurFenetre = Console.WindowWidth;
            int longueurTexte = text.Length;
            int espaces = (largeurFenetre - longueurTexte) / 2;
            string espace = new string(' ', espaces) + text;
            Console.WriteLine(espace);
        }
        public static void CentreMenuEcrit(string text)
        {
            int largeurFenetre = Console.WindowWidth;
            int longueurTexte = text.Length;
            int espaces = (largeurFenetre - longueurTexte) / 2;
            string espace = new string(' ', espaces) + text;
            Console.Write(espace);
        }


        public static void Principal()
        {

            bool creationPersonnage = false;
            Affichage.Acceuil();
            while (true)
            {
                CentreMenu(" -----------------------------------------------");

                if (creationPersonnage == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    CentreMenu("| Tapez 1 pour créer un Elfe !                   |");
                    CentreMenu("| Tapez 2 pour créer un Nain !                   |");
                    Console.ResetColor();
                }
                CentreMenu("| Tapez 3 pour voir la liste de votre compagnie !|");
                CentreMenu("| Tapez 4 Lancer l'aventure !                    |");
                CentreMenu("| Tapez 5 Sauvegarde                             |");
                CentreMenu("| Tapez 6 Charger                                |");
                CentreMenu("| Taper 7 Quitter le jeu                         |");
                CentreMenu(" -----------------------------------------------");
              
                
                CentreMenuEcrit(" Quel sera votre choix : ");
                 string choice = Console.ReadLine();
                if (choice.Length == 1)
                {
                    switch (choice)
                    {
                        case "1":
                            if (creationPersonnage == false)
                            {
                                // donc j'appel la classe Elfe et la méthode qui est dans la classe Elfe "ChoiceElfe"
                                Elfe.ChoiceElfe();
                                creationPersonnage = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                CentreMenu($"\nAventurier Votre equipe est complete !\n");
                                Console.ResetColor();
                            }
                            break;
                        case "2":
                            if (creationPersonnage == false)
                            {
                                // donc j'appel la classe Elfe et la méthode qui est dans la classe Elfe "ChoiceElfe"
                                Nain.ChoiceNain();
                                creationPersonnage = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                CentreMenu($"\nAventurier Votre equipe est complete !\n");
                                Console.ResetColor();
                            }
                            // donc j'appel la classe Nain et la méthode qui est dans la classe nain "ChoiceNain"
                            break;
                        case "3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            // j'appel ma classe Guerrier qui contient ma méthode Pour afficher les Aventurier dans ma liste 
                            Guerrier.AfficherParticipant();
                            Console.ResetColor();
                            break;
                        case "4":
                            VisuelEtage.visuEtage();
                            Console.Clear();
                            break;
                        case "5":
                            Save.Sauvegarder();
                            break;
                        case "6":
                            Save.Charger();

                            break;
                        case "7":
                            Console.Clear();
                            Affichage.Fermeture();
                            Console.ReadKey(true);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            CentreMenu("Veuillez saisir une option valide Aventurier !");
                            break;
                    }
                }
                else
                {
                    CentreMenu("Veuillez faire une saisie valide Aventurier !");
                }
            }
        }
    }
}
