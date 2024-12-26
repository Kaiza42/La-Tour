using JsuisUnGuerrier.Classes;
using System.Collections.Generic;

List<Guerrier> lesGuerrier = new List<Guerrier>();
string saisieName;
int saisieVie;
int saisieATQ;

void ChoiceElfe()
{
    Console.Write("Veuillez saisir un nom pour votre Guerrier : ");
     saisieName = Console.ReadLine();
   
    Console.Write("Veuilez entrez les stat de vie de votre Guerrier ");
     saisieVie = int.Parse(Console.ReadLine());

    Console.Write("Veuillez entrer les stat d'attaque de votre Guerrier");
    saisieATQ = int.Parse(Console.ReadLine());

    Elfe guerrier = new Elfe(saisieName, saisieVie, saisieATQ);

    lesGuerrier.Add(guerrier);
}

void ChoiceNain()
{
    Console.Write("Veuillez saisir un nom pour votre Guerrier : ");
    saisieName = Console.ReadLine();

    Console.Write("Veuilez entrez les stat de vie de votre Guerrier : ");
    saisieVie = int.Parse(Console.ReadLine());

    Console.Write("Veuillez entrer les stat d'attaque de votre Guerrier : ");
    saisieATQ = int.Parse(Console.ReadLine());
    Nain guerrier = new Nain(saisieName, saisieVie, saisieATQ,true);
    lesGuerrier.Add(guerrier);
}

void AfficherParticipant()
{
    foreach (Guerrier lesG in lesGuerrier)
    {
        Console.WriteLine(lesG);
    }
    if (lesGuerrier.Count == 10)
    {
        Console.WriteLine("Nous avons le compte pour le tournoi ! ");
    }
}

while (true)
{
    Console.WriteLine("Tapez 1 pour créer un Elfe !");
    Console.WriteLine("Tapez 2 pour créer un Nain !");
    Console.WriteLine("Tapez 3 pour voir la liste des Participant !");
    // la saisie utilisateur pour Faire un choix dans le switc
    Console.Write("Quel seras votre choix : ");
    char choice = Convert.ToChar(Console.ReadLine());
    switch (choice)
    {
        case '1':
            ChoiceElfe();
            break;
        case '2':
            ChoiceNain();
            break;
        case '3':
            AfficherParticipant();
            break;
        case '4':
            break;
    }
}

 



//    Elfe jaquie = new Elfe("jaquie", 600,30);
//Nain jean = new Nain("jean", 350, 30, true);

//jaquie.AfficherInfos();
//jean.AfficherInfos();

//jean.SubirDegats(jaquie.Attaquer());
//jean.AfficherInfos();


//jaquie.SubirDegats(jean.Attaquer());
//jaquie.AfficherInfos();

//jean.SubirDegats(jaquie.Attaquer());
//jean.AfficherInfos();



