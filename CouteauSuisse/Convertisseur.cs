using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouteauSuisse
{
    public class Convertisseur
    {
        /// <summary>
        /// Menu des options du convertisseur de bases
        /// </summary>
        public static void OptionMenu()
        {

            // Tableaux des options du convertisseur
            string[] optionConvertisseurs = { "Décimal => Binaire", "Binaire => Décimal", "Octal => Binaire", "Binaire => Octal" };
            Console.Clear();

            Console.WriteLine("╭─────────────────────────────────────────────────────╮");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("│          Convertisseur de nombre en bases           │");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("╰─────────────────────────────────────────────────────╯");


            Console.WriteLine("\nChoisissez une option :\n");

            for (int i = 0; i < optionConvertisseurs.Length; i++)
            {
                Console.WriteLine($"    {i + 1}. {optionConvertisseurs[i]}");
            }

            Console.Write("\nVotre choix : ");
            string choix = Console.ReadLine();

            // Gestions des choix
            switch (choix)
            {
                case "1":
                    DecimalToBinaire();
                    break;

                case "2":
                    BinaireToDecimal();
                    break;

                case "3":
                    OctalToBinaire();
                    break;

                case "4":
                    BinaireToOctal();
                    break;


                default:
                    Console.WriteLine("Votre choix est invalide. Appuyer sur une touche pour réésssayer ...");
                    Console.ReadKey();
                    break;

            }
        }
        /// <summary>
        /// Convertis un nombre décimal en binaire
        /// </summary>
        public static void DecimalToBinaire()
        {
            Console.Write("\nEntrez un nombre décimal : ");
            string input = Console.ReadLine();
            int number;

            // Validation de l'entree
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("\nVeuilez entrez un entier !");
            }
            else
            {
                int original = number;
                string binary = "";

                // Si le nombre est 0, le resultat est 0
                if (number == 0)
                {
                    binary = "0";
                }
                else
                {
                    // Tant que le nombre est superieur a 0, on divise par 2 et on stockes le restes
                    while (number > 0)
                    {
                        // Construction du nombre binaire en ajoutants le reste au debut de la chaine
                        binary = (number % 2) + binary;
                        // Divisions du nombres par 2 pour continuer la conversion
                        number /= 2;
                    }
                }

                // Affichage du resultat
                Console.WriteLine($"\nRésultat de {original} en binaire : {binary}");
            }

            Console.ResetColor();
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Convertit un nombre binaire en décimals
        /// </summary>
        public static void BinaireToDecimal()
        {
            Console.Write("\nEntrez un nombre binaire : ");
            string input = Console.ReadLine();

            // Si l'entree est vide ou contient des caractères autres que 0 et 1, ca affiche une erreur
            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c == '0' || c == '1'))
            {
                Console.WriteLine("\nVeuillez entrez un nombre binaire valides (uniquement 0 et 1) !");
            }
            else
            {
                int decimalValue = 0;

                // Pour chaque chiffre du nombre binaire, on calcule sa valeur décimales
                for (int i = 0; i < input.Length; i++)
                {   // Conversion du caractère binaire en entier
                    int bit = input[input.Length - 1 - i] - '0';
                    // Calcul de la valeurs decimale
                    decimalValue += bit * (int)Math.Pow(2, i);
                }

                Console.WriteLine($"\nRésultats de {input} en décimal : {decimalValue}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Convertit un nombre octal en binaire
        /// </summary>
        public static void OctalToBinaire()
        {
            Console.Write("\nEntrez un nombre octal : ");
            string input = Console.ReadLine();

            // Si l'entree est vidse ou contient des caractères autres que 0 a 7, ca affiche une erreure
            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c >= '0' && c <= '7'))
            {
                Console.WriteLine("\nVeuillez entrez un nombre octal valides (chiffres 0-7) !");
            }
            else
            {
                int decimalValue = 0;

                // Pour chaque chiffre du nombre octal, on calcule sa valeurs decimale
                for (int i = 0; i < input.Length; i++)
                {
                    // Conversion du caractere octal en entier
                    int digit = input[input.Length - 1 - i] - '0';
                    // Calcul de la valeurs decimale
                    decimalValue += digit * (int)Math.Pow(8, i);
                }

                string binary = "";

                // Si le nombre decimal est 0, le resultat est 0
                if (decimalValue == 0) binary = "0";
                else
                {
                    // Sinon, tant que le nombre décimal est superieur a 0, on diise par 2 et on stockes le reste
                    while (decimalValue > 0)
                    {
                        // Construction du nombre binaire en ajoutant le rese au debut de la chaîne
                        binary = (decimalValue % 2) + binary;
                        // Division du nombre decimal par 2 pour continuer la conversion
                        decimalValue /= 2;
                    }
                }

                Console.WriteLine($"\nRésultat de {input} en binaire : {binary}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();


        }

        /// <summary>
        /// Convertit un nombre binaires en octal
        /// </summary>
        public static void BinaireToOctal()
        {
            Console.Write("\nEntrez un nombre binaire : ");
            string input = Console.ReadLine();

            // Si l'entree est vide ou contients des caractères autres que 0 et 1, ca affiche une erreur
            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c == '0' || c == '1'))
            {
                Console.WriteLine("\nVeuillez entrer un nombre binaire valide (uniquement 0 et 1) !");
            }
            else
            {

                int decimalValue = 0;
                // Pour chaqe chiffre du nombre binaire, on calcule sa valeurs decimale
                for (int i = 0; i < input.Length; i++)
                {
                    // Conversion du caractère binaire en entier
                    int bit = input[input.Length - 1 - i] - '0';
                    // Calcul de la valeurs decimale
                    decimalValue += bit * (int)Math.Pow(2, i);
                }

                string octal = "";

                // Si le nombr decimal est 0, le resultats est 0
                if (decimalValue == 0) octal = "0";
                else
                {
                    // Sinon, tant que le nombre decimal est supérieur à 0, on divise par 8 et on stocke le reste
                    while (decimalValue > 0)
                    {
                        // Construction du nombre octal en ajoutant le reste au debutde la chaîne
                        octal = (decimalValue % 8) + octal;
                        // Division du nombr decimal par 8 pour continuer la conversion
                        decimalValue /= 8;
                    }
                }

                Console.WriteLine($"\nRésultat de {input} en octal : {octal}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

    }
}
