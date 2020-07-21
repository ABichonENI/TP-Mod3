using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AB_TPMODULE3.BO;

namespace AB_TPMODULE3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitialiserDatas();

            var query1 = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(a => a.Prenom) ;
            Console.WriteLine("Liste des prénoms des auteurs dont le nom commence par G");
            foreach (var prenom in query1)
            {
                Console.WriteLine(prenom);
            }
            Console.WriteLine();
            var query2 = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(l =>l.Count()).FirstOrDefault().Key;
            Console.WriteLine($"L'auteur qui a écrit le plus de livre est :{query2.Prenom} {query2.Nom}");
            
            Console.WriteLine();
            var query3 = ListeLivres.GroupBy(l=>l.Auteur);

            foreach (var author in query3)
            {
                Console.WriteLine($"Le nombre moyen de page par livre de l'auteur {author.Key.Prenom} {author.Key.Nom} est de {author.Average(l=>l.NbPages)}");
            }
                        
            Console.WriteLine();
            var query4 = ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();

            Console.WriteLine($"Le Livre qui contient le plus de page est {query4.Titre} ");
            Console.WriteLine();
            
            var query5 = ListeAuteurs.Average(s => s.Factures.Sum(f => f.Montant));
                        
            Console.WriteLine($"Les auteurs ont gagné en moyenne {query5}");
            

            Console.WriteLine();

            Console.WriteLine();
            var query6 = ListeLivres.GroupBy(l => l.Auteur);
            Console.WriteLine("Liste des auteurs et de leurs livres");
            foreach (var livres in query6)
            {
                Console.WriteLine($"Auteur : {livres.Key.Prenom} {livres.Key.Nom}");
                foreach (var livre in livres) 
                {
                    Console.WriteLine($"{livre.Titre}");
                }
            }
            Console.WriteLine();
            var query7 = ListeLivres.OrderBy(l => l.Titre);
            Console.WriteLine("Titres des livres triés par ordre alphabétique :");
            foreach (var livre in query7)
            {
                Console.WriteLine($"{livre.Titre}");
            }
            Console.WriteLine();
            var query9 = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(l => l.Count()).LastOrDefault().Key;

            Console.WriteLine($"L'auteur qui a écrit le moins de livre est :{query9.Prenom} {query9.Nom}");

            Console.ReadKey();
        }

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

    }
}
