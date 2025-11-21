using System;
using System.Linq;

namespace CouteauSuisse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] optionOutils = { "Morse", "Convertisseur bases (Binaire <> Octal)", "Test2", "Quitter" };
            bool continuer = true;

            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("╭─────────────────────────────────────────────────╮");
                Console.WriteLine("│                                                 │");
                Console.WriteLine("│    Couteau Suisse (Turc) | Réalisé par Erdem    │");
                Console.WriteLine("│                                                 │");
                Console.WriteLine("╰─────────────────────────────────────────────────╯");

                Console.WriteLine("\nChoisissez un outil :\n");

                for (int i = 0; i < optionOutils.Length; i++)
                {
                    Console.WriteLine($"    {i + 1}. {optionOutils[i]}");
                }

                Console.Write("\nVotre choix : ");
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1":
                        MorseTool();
                        break;
                    case "2":
                        ConvertisseurOptionMenu();
                        break;
                    case "3":
                        Test2Tool();
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

        static void ConvertisseurOptionMenu()
        {

            string[] optionConvertisseurs = { "Décimal => Binaire", "Binaire => Décimal",  "Octal => Binaire", "Binaire => Octal" };
            Console.Clear();
            
            Console.WriteLine("╭─────────────────────────────────────────────────────╮");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("│          Convertisseur de nombre en bases           │");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("╰─────────────────────────────────────────────────────╯");
        
        
            Console.WriteLine("\nChoisissez une option :\n");

            for (int i = 0; i < optionConvertisseurs.Length ; i++)
            {
                Console.WriteLine($"    {i + 1}. {optionConvertisseurs[i]}");
            }

            Console.Write("\nVotre choix : ");
            string choix = Console.ReadLine() ?? "";

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

        static void DecimalToBinaire()
        {
            Console.Write("\nEntrez un nombre décimal : ");
            string input = Console.ReadLine() ?? "";
            int number;
        
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("\nVeuilez entrer un entier !");
            }
            else
            {
                int original = number;
                string binary = "";
        
                if (number == 0)
                {
                    binary = "0";
                }
                else
                {
                    while (number > 0)
                    {
                        binary = (number % 2) + binary;
                        number /= 2;
                    }
                }
        
                Console.WriteLine($"\nRésultat de {original} en binaire : {binary}");
            }
        
            Console.ResetColor();
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void BinaireToDecimal()
        {
            Console.Write("\nEntrez un nombre binaire : ");
            string input = Console.ReadLine() ?? "";
        
            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c == '0' || c == '1'))
            {
                Console.WriteLine("\nVeuillez entrer un nombre binaire valides (uniquement 0 et 1) !");
            }
            else
            {
                int decimalValue = 0;
        
                for (int i = 0; i < input.Length; i++)
                {
                    int bit = input[input.Length - 1 - i] - '0';
                    decimalValue += bit * (int)Math.Pow(2, i);
                }
        
                Console.WriteLine($"\nRésultat de {input} en décimal : {decimalValue}");
            }
        
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
        static void OctalToBinaire()
        {
            string userInput;
            int userInputToInt;
            Console.WriteLine("\nEntrez un nombre décimal : ");
            
            userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out userInputToInt))
            {
                Console.WriteLine(userInputToInt.GetType());
            }

        
        }
        static void BinaireToOctal()
        {
            Console.Write("\nEntrez un nombre binaire : ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c == '0' || c == '1'))
            {
                Console.WriteLine("\nVeuillez entrer un nombre binaire valide (uniquement 0 et 1) !");
            }
            else
            {
                int decimalValue = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int bit = input[input.Length - 1 - i] - '0';
                    decimalValue += bit << i; 
                }

                string octal = "";
                
                if (decimalValue == 0) octal = "0";
                else
                {
                    while (decimalValue > 0)
                    {
                        octal = (decimalValue % 8) + octal;
                        decimalValue /= 8;
                    }
                }

                Console.WriteLine($"\nRésultat de {input} en octale : {octal}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void MorseTool()
        {
            Console.Clear();
            Console.WriteLine("╭─────────────────────────────────────────────────────╮");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("│        Convertisseur de texte en code Morse         │");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("╰─────────────────────────────────────────────────────╯");

            Console.Write("\nEntrez un mot ou une phrase (sans accents, lettres A-Z) : ");
            string userText = Console.ReadLine() ?? "";
            string resultat = ConvertToMorse(userText);
            
            Console.WriteLine("\nRésultat en Morse :");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{resultat}");
            Console.ResetColor();
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }


        static void Test2Tool()
        {
            Console.Clear();
            Console.WriteLine("Vous avez choisi l'outil Test2 !");
            Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        public static string ConvertToMorse(string input)
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

            string finalText = "";
            string userInput = input.ToUpper();

            for (int i = 0; i < userInput.Length; i++)
            {
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
                if (!found) finalText += "? ";
            }

            return finalText;
        }
    }
}
