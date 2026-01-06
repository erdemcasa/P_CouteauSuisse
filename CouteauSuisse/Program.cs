using System;


namespace CouteauSuisse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tableau des menus
            string[] optionOutils = { "Morse", "Convertisseur bases (Binaire <> Octal)", "Code césar", "Quitter" };

            bool continuer = true;

            // Boucle principale du menu
            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("╭─────────────────────────────────────────────────╮");
                Console.WriteLine("│                                                 │");
                Console.WriteLine("│    Couteau Suisse (Turc) | Réalisé par Erdem    │");
                Console.WriteLine("│                                                 │");
                Console.WriteLine("╰─────────────────────────────────────────────────╯");

                Console.WriteLine("\nChoisissez un outil :\n");

                // Affichage du menu
                for (int i = 0; i < optionOutils.Length; i++)
                {
                    Console.WriteLine($"    {i + 1}. {optionOutils[i]}");
                }

                Console.Write("\nVotre choix : ");
                string choix = Console.ReadLine();

                // Gestion des choix
                switch (choix)
                {
                    case "1":
                        Morse.OptionMenu();
                        break;
                    case "2":
                        Convertisseur.OptionMenu();
                        break;
                    case "3":
                        Cesar.OptionMenu();
                        break;
                    case "4":
                        continuer = false;
                        Console.WriteLine("Fermeture ..............");
                        break;
                    default:
                        Console.WriteLine("Votre choix est invalide. Appuyer sur une touche pour réésssayer ...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

