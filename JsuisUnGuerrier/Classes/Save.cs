using System.Text.Json.Serialization;
using System.Text.Json;

namespace JsuisUnGuerrier.Classes
{
    // sa était créer trop tot je doit la mettre a jour mais je souhaite dormir..
    // elle est pas tres au point pour etre honnete 
    // c'etait un essaie je suis content du test mais j'aurais peut etre du prendre plus de temp pour comprendre un peu mieux le fonctionnement
    // 
    internal class Save : Guerrier
    {
        public Save(string nom, double pDV, double aTQ, double dEF) : base(nom, pDV, aTQ, dEF)
        {
        }
        public class GuerrierData
        {
            public string Name { get; set; }
            public double PDV { get; set; }
            public double ATQ { get; set; }
            public double Heal { get; set; }
            public int CD { get; set; }
        }
        
        public static void Sauvegarder()
        {
            // Je créer une liste pour stocker 
            var guerriersData = new List<GuerrierData>();
            foreach (var guerrier in lesGuerrier)
            {
                guerriersData.Add(new GuerrierData
                {
                    Name = guerrier.Name,
                    PDV = guerrier.PDV,
                    ATQ = guerrier.ATQ,
                    Heal = guerrier.Heal,
                    CD = guerrier.CD
                });
            }
            // va etre rentrer dans serialisé
            var data = new
            {
                Guerriers = guerriersData,
            };
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                //permet que le json soit plus lisible
                WriteIndented = true,
                //permet d'eviter les propriété a valeur Null
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            // convertie les objet en une chaine json 
            string maData = JsonSerializer.Serialize(data, options);
            File.WriteAllText("SauvegardeDuJeu.json", maData);
            Console.Clear();
            Centre("Sauvegarde effectuée !");
        }
        public static void Charger()
        {
            if (File.Exists("SauvegardeDuJeu.json"))
            {
                string madata2 = File.ReadAllText("SauvegardeDuJeu.json");
                // dynamic permet donc de ne pas prendr ene compte le type de l'item et le type l'item est pris en compte au moment de l'instanciation 
                // je ne suis pas sur de l'avoir compris correctement 
                var data = JsonSerializer.Deserialize<dynamic>(madata2);

                // Désérialisation des guerriers
                //Le GetProperty  me permet d'aller prendre l'objet Guerrier et ses Objet avec 
                var guerriersData = JsonSerializer.Deserialize<List<GuerrierData>>(data.GetProperty("Guerriers").ToString());
                // vide la liste
                lesGuerrier.Clear(); 
                // ajoute les fichier sauvegarder a ma liste "lesGuerrier"
                foreach (var guerrierDATA in guerriersData)
                {
                    lesGuerrier.Add(new Guerrier(guerrierDATA.Name, guerrierDATA.PDV, guerrierDATA.ATQ, guerrierDATA.Heal)
                    {
                        CD = guerrierDATA.CD
                    });
                }
            }
            else
            {
                Console.Clear();
                Centre("Aucune sauvegarde trouvée !");
            }
        }

    }
}
