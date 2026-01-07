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
        public static void TextToMorse()
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
                {"9", "----."}, {".", ".-.-.-"}, {",", "--..--"}, {"?", "..--.."}, {"'", ".----."},
                {"!", "-.-.--"}, {"/", "-..-."}, {"(", "-.--."}, {")", "-.--.-"}, {"&", ".-..."},
                {":", "---..."}, {";", "-.-.-."}, {"=", "-...-"}, {"+", ".-.-."}, {"-", "-....-"},
                {"_", "..--.-"}, {"'", ".-..-."}, {"$", "...-..-"}, {"@", ".--.-."}, {" ", "/"}
            };

            Console.Write("\nEntrez un texte à convertir en morse : ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Veuillez saisir qeulque chose");
                return;
            }

            string finalText = "";
            string userInput = input.ToUpper();
            bool hasError = false;
            string invalidChars = "";

            // Parcours de chaque caractère de l'utilisateur
            for (int i = 0; i < userInput.Length; i++)
            {
                // mEttre / si il y'a un espace
                if (userInput[i] == ' ')
                {
                    finalText += "/ ";
                    continue;
                }

                bool found = false;
                for (int j = 0; j < morse.GetLength(0); j++)
                {
                    if (userInput[i].ToString() == morse[j, 0])
                    {
                        finalText += morse[j, 1] + " ";
                        found = true;
                        break;
                    }
                }

                // Si le caractère n'est pas dans le tableau ca met [?]
                if (!found)
                {
                    hasError = true;
                    invalidChars += userInput[i] + " ";
                    finalText += "[?] "; 
                }
            }

            // Affihce les caracteres si 
            if (hasError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nCes caractere la ne sont pas reconnus : {invalidChars}");
                Console.ResetColor();
            }

            Console.WriteLine("\nRésultats en Morse :");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(finalText);
            Console.ResetColor();

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Convertit du morse en texte
        /// </summary>
        public static void MorseToText()
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
                {"9", "----."}, {".", ".-.-.-"}, {",", "--..--"}, {"?", "..--.."}, {"'", ".----."},
                {"!", "-.-.--"}, {"/", "-..-."}, {"(", "-.--."}, {")", "-.--.-"}, {"&", ".-..."},
                {":", "---..."}, {";", "-.-.-."}, {"=", "-...-"}, {"+", ".-.-."}, {"-", "-....-"},
                {"_", "..--.-"}, {"\"", ".-..-."}, {"$", "...-..-"}, {"@", ".--.-."}, {" ", "/"}
            };

            Console.Write("\nEntrer le code morse a convertir : ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Veuillez saisir quelques chose");
                return;
            }

            // On separe la chaine par les espaces pour obtenir chaque symbole Morse
            string[] words = input.Split(' ');
            string finalText = "";
            bool hasError = false;
            string invalidCodes = "";

            foreach (string symbol in words)
            {
                // Ignore les doubles espaces
                if (string.IsNullOrEmpty(symbol)) continue; 

                bool found = false;

                for (int j = 0; j < morse.GetLength(0); j++)
                {
                    if (symbol == morse[j, 1])
                    {
                        finalText += morse[j, 0];
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    hasError = true;
                    invalidCodes += symbol + " ";
                    finalText += "[?]";
                }
            }

            if (hasError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nCodes mrses non reconnu : {invalidCodes}");
                Console.ResetColor();
            }

            Console.WriteLine("\nResultat en texte :");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(finalText);
            Console.ResetColor();

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        // /// <summary>
        // /// Outil de conversion en Morses
        // /// </summary>
        // public static void Tool()
        // {
        //     Console.Clear();
        //     Console.WriteLine("╭─────────────────────────────────────────────────────╮");
        //     Console.WriteLine("│                                                     │");
        //     Console.WriteLine("│        Convertisseur de texte en code Morse         │");
        //     Console.WriteLine("│                                                     │");
        //     Console.WriteLine("╰─────────────────────────────────────────────────────╯");
        // 
        //     Console.Write("\nEntrez un mot ou une phrase (sans accents, lettres A-Z) : ");
        //     string userText = Console.ReadLine();
        //     string resultat = Morse.Convert(userText);
        // 
        //     Console.WriteLine("\nRésultat en Morse :");
        //     Console.ForegroundColor = ConsoleColor.Cyan;
        //     Console.WriteLine($"{resultat}");
        //     Console.ResetColor();
        //     Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
        //     Console.ReadKey();
        // }
    }
}
