using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouteauSuisse
{
    public class Morse
    {
        /// <summary>
        /// Menu des options du morse
        /// </summary>
        public static void OptionMenu()
        {

            // Tableaux des options du convertisseur
            string[] optionConvertisseurs = { "Texte => Morse", "Morse => Text"};
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
                    TextToMorse();
                    break;

                case "2":
                    MorseToText();
                    break;

                default:
                    Console.WriteLine("Votre choix est invalide. Appuyer sur une touche pour réésssayer ...");
                    Console.ReadKey();
                    break;

            }
        }

        /// <summary>
        /// Convertit un texte en code Morse
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TextToMorse()
        {
            string[,] morse =
            {
                {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
                {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"I", ".."}, {"J", ".---"},
                {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
                {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
                {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
                {"Z", "--.."}, {"0", "-----"}, {"1", ".----"}, {"2", "..---"}, {"3", "...--"},
                {"4", "....-"}, {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."},
                {"9", "----."}/*, {".", ".-.-.-"}, {",", "--..--"}, {"?", "..--.."}, {"'", ".----."},
                {"!", "-.-.--"}, {"/", "-..-."}, {"(", "-.--."}, {")", "-.--.-"}, {"&", ".-..."},
                {":", "---..."}, {";", "-.-.-."}, {"=", "-...-"}, {"+", ".-.-."}, {"-", "-....-"},
                {"_", "..--.-"}, {"'", ".-..-."}, {"$", "...-..-"}, {"@", ".--.-."}, {" ", "/"}*/
            };

            // Demande du texte a convertirs
            Console.Write("\nEntrez un texte à convertir en morse : ");
            string input = Console.ReadLine();

            string finalText = "";
            string userInput = input.ToUpper();

            // Pour chaque caractères de l'entree utilisateurs, on cherche sa correspondance en Morse
            for (int i = 0; i < userInput.Length; i++)
            {
                // Recherche dans le tableau Morse
                bool found = false;
                for (int j = 0; j < morse.GetLength(0); j++)
                {
                    // Si on trouve une correspondance, on ajoute le code Morse au resultat
                    if (userInput[i].ToString() == morse[j, 0])
                    {

                        finalText += morse[j, 1] + " ";
                        found = true;
                        break;
                    }
                }
                // Si aucun correspondance n'est trouvee, on ajoute un "?" au resultat
                if (!found) finalText += "? ";
            }

            return finalText;
        }

        /// <summary>
        /// Outil de conversion en Morses
        /// </summary>
        public static void Tool()
        {
            Console.Clear();
            Console.WriteLine("╭─────────────────────────────────────────────────────╮");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("│        Convertisseur de texte en code Morse         │");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("╰─────────────────────────────────────────────────────╯");

            Console.Write("\nEntrez un mot ou une phrase (sans accents, lettres A-Z) : ");
            string userText = Console.ReadLine();
            string resultat = Morse.Convert(userText);

            Console.WriteLine("\nRésultat en Morse :");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{resultat}");
            Console.ResetColor();
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
    }
}
