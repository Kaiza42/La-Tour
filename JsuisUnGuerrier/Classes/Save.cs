using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsuisUnGuerrier.Classes
{
    internal class Save : Guerrier
    {
        public Save(string nom, double pDV, double aTQ, double dEF) : base(nom, pDV, aTQ, dEF)
        {
        }
        public class GuerrierDTO
        {
            public string Name { get; set; }
            public double PDV { get; set; }
            public double ATQ { get; set; }
            public double Heal { get; set; }
            public int CD { get; set; }
        }
        // cette classe sert uniquement a la sauveguarde a rien d'autre je ne voulais pas que sa sois dans Guerrier et que sa soit une classe four-tout
        public static void Sauvegarder()
        {
            // Je créer une liste pour stocker 
            var guerriersDTO = new List<GuerrierDTO>();
            foreach (var guerrier in lesGuerrier)
            {
                guerriersDTO.Add(new GuerrierDTO
                {
                    Name = guerrier.Name,
                    PDV = guerrier.PDV,
                    ATQ = guerrier.ATQ,
                    Heal = guerrier.Heal,
                    CD = guerrier.CD 
                });
            }
            //Deux liste ?  monstre et guerrier donc logique
            var monstresDTO = new List<GuerrierDTO>();
            foreach (var monstre in monstre)
            {
                monstresDTO.Add(new GuerrierDTO
                {
                    Name = monstre.Name,
                    PDV = monstre.PDV,
                    ATQ = monstre.ATQ,
                    Heal = monstre.Heal,
                    CD = monstre.CD 
                });
            }

            // Sérialisation des listes
            var data = new
            {
                Guerriers = guerriersDTO,
                Monstres = monstresDTO
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText("save.json", jsonString);
            Console.WriteLine("Sauvegarde effectuée !");
        }
        public static void Charger()
        {
            if (File.Exists("save.json"))
            {
                string jsonString = File.ReadAllText("save.json");
                var data = JsonSerializer.Deserialize<dynamic>(jsonString);

                // Désérialisation des guerriers
                var guerriersDTO = JsonSerializer.Deserialize<List<GuerrierDTO>>(data.GetProperty("Guerriers").ToString());
                lesGuerrier.Clear(); // Vide la liste existante avant de la remplir de nouvelles données
                foreach (var guerrierDTO in guerriersDTO)
                {
                    
                    lesGuerrier.Add(new Guerrier(guerrierDTO.Name, guerrierDTO.PDV, guerrierDTO.ATQ, guerrierDTO.Heal)
                    {
                        CD = guerrierDTO.CD 
                    });
                }

                // Désérialisation des monstres
                var monstresDTO = JsonSerializer.Deserialize<List<GuerrierDTO>>(data.GetProperty("Monstres").ToString());
                monstre.Clear();
                foreach (var monstreDTO in monstresDTO)
                {
                    // Recrée les objets Monstre
                    monstre.Add(new Guerrier(monstreDTO.Name, monstreDTO.PDV, monstreDTO.ATQ, monstreDTO.Heal)
                    {
                        CD = monstreDTO.CD
                    });
                }

                Console.WriteLine("Données chargées depuis la sauvegarde !");
            }
            else
            {
                Console.WriteLine("Aucune sauvegarde trouvée.");
            }
        }

    }
}
