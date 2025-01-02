using JsuisUnGuerrier.Classes;
//Cette varibale sert a bloquer une faille qui est que si le joueur a créer un personnage il ne peut pas en créer un deuxieme 
bool creationPersonnage = false;
// alors j'ai tentez plusieur choses mais je suis arriver a un moment ou sa ma épuiser de tentez des choses Pour voir si sa fonctionne
// Donc j'ai décider de créer une boucle qui va vérifier chaque membre de ma liste et si il est mort il degage 
// a quoi sa sert alors que je peut faire un Bool isMort On me la répéter "fait sa c'est plus simple gnagnagna" 
// PAS ENVIE CEST MOCHE ISMORT 
void VraiMortMonstre()
{
    //i pour index 
    // le "Guerrier.monstre" en gros ca va appeler ma classe Guerrier et la liste monstre lié a ma classe Guerrier que monstre hérite bien évidament
    for (int i = Guerrier.monstre.Count - 1; i >= 0; i--)
    {
        if (Guerrier.monstre[i].PDV <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Aventurier vous avez vaincu le monstre {Guerrier.monstre[0].Name} !");
            Console.ResetColor();
            Guerrier.monstre[i].Death();
            //Je remove en fonction de l'index
            Guerrier.monstre.RemoveAt(i);
        }
    }
}
// a quoi sa sert alors que je peut faire un Bool isMort On me la répéter "fait sa c'est plus simple gnagnagna" 
// PAS ENVIE CEST MOCHE ISMORT 
void VraiMortAventurier()
{
    //C'est pareil que audessus mais pour la liste lesGuerrier.
    for (int i = Guerrier.lesGuerrier.Count - 1; i >= 0; i--)
    {
        if (Guerrier.lesGuerrier[i].PDV <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Aventurier la Tour a eux raison de {Guerrier.lesGuerrier[i].Name} ! ");
            Console.ResetColor();
            Guerrier.lesGuerrier[i].Death();
            Guerrier.lesGuerrier.RemoveAt(i);
        }
    }
}
while (true)
{
    // Quand l'utilisateur va créer son personnage cela va faire qu'il ne peut en créer d'autre je rectifie sa car j'avais bloquer la liste a 1 mais quand il va rencontrer d'autre compagnon il pouvais
    // créer autant de personnage qu'il le souhaiter et sa .. on ne veut pas non ? 
    if (creationPersonnage == false)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Tapez 1 pour créer un Elfe !");
        Console.WriteLine("Tapez 2 pour créer un Nain !");
        Console.ResetColor();
    }
    Console.WriteLine("Tapez 3 pour voir la liste de votre compagnie !");
    Console.WriteLine("Tapez 4 Lancer l'aventure !");
    Console.WriteLine("Tapez 5 Sauvegarde");
    Console.WriteLine("Tapez 6 Charger");
    Console.WriteLine("Taper 7 Quitter le jeu");
    // la saisie utilisateur pour Faire un choix dans le switch
    Console.Write("Quel seras votre choix : ");
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
                }else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nAventurier Votre equipe est complete !\n");
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
                    Console.WriteLine($"\nAventurier Votre equipe est complete !\n");
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
                Guerrier.Mob();
                while (Guerrier.monstre.Count != 0 && Guerrier.lesGuerrier.Count != 0)
                {
                    //clear Pour éviter que il y est une surcharge de texte 
                    Console.Clear();
                    Guerrier.Choice(); //L'attaque de l'utilisateur 
                    VraiMortMonstre();// verifie la mort du monstre
                    // verifie la vie des guerrier et monstre 
                    if (Guerrier.lesGuerrier.Count > 0 && Guerrier.monstre.Count > 0)
                    {
                        //attaque monstre 
                        Guerrier.ChoiceMonstre();
                    }
                    //delai pour éviter que tout disparaisse 
                   

                    Console.ForegroundColor = ConsoleColor.Red;
                    // la fonction de verification si guerrier est mort 
                    VraiMortAventurier();
                    Console.ResetColor();
                    //va verifier un guerrier est toujours ne vie et si c'est le cas l methode s'execute
                    if (Guerrier.lesGuerrier.Count > 0)
                    {
                        // reduit le delai de CD et de CDS a chaque tour de la boucle while
                        Guerrier.lesGuerrier[0].ReductionCooldown();
                        Guerrier.lesGuerrier[0].ReductionCooldownSpecial();
                    } 
                    Thread.Sleep(4500);
                }
                break;
            case "5":
                Save.Sauvegarder();
                break;
            case "6":
                Save.Charger();
                break;
            case "7":
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n\n\n");
                Console.WriteLine($"\t\t ╔═════════════════════════╗ ");
                Console.WriteLine($"\t\t ║  A bientôt Aventurier ! ║ ");
                Console.WriteLine($"\t\t ╚═════════════════════════╝ \n\n\n");
                Console.ResetColor();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Veuillez saisir une option valide Aventurier !");
                break;
        }
    }
    else
    {
        Console.WriteLine("Veuillez faire une saisie valide Aventurier !");
    }
}