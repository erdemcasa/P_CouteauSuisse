using System;
using System.Linq;

namespace CouteauSuisse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] optionOutils = { "Morse", "Convertisseur bases (Binaire <> Octal)", "Code césar", "Quitter" };
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
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        MorseTool();
                        break;
                    case "2":
                        ConvertisseurOptionMenu();
                        break;
                    case "3":
                        CodeCesar();
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
            string choix = Console.ReadLine();

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
            string input = Console.ReadLine();
            int number;
        
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("\nVeuilez entrez un entier !");
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
            string input = Console.ReadLine();
        
            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c == '0' || c == '1'))
            {
                Console.WriteLine("\nVeuillez entrez un nombre binaire valides (uniquement 0 et 1) !");
            }
            else
            {
                int decimalValue = 0;
        
                for (int i = 0; i < input.Length; i++)
                {
                    int bit = input[input.Length - 1 - i] - '0';
                    decimalValue += bit * (int)Math.Pow(2, i);
                }
        
                Console.WriteLine($"\nRésultats de {input} en décimal : {decimalValue}");
            }
        
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
        static void OctalToBinaire()
        {
            Console.Write("\nEntrez un nombre octal : ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || !input.All(c => c >= '0' && c <= '7'))
            {
                Console.WriteLine("\nVeuillez entrez un nombre octal valides (chiffres 0-7) !");
            }
            else
            {
                int decimalValue = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int digit = input[input.Length - 1 - i] - '0';
                    decimalValue += digit * (int)Math.Pow(8, i);
                }

                string binary = "";
                
                if (decimalValue == 0) binary = "0";
                else
                {
                    while (decimalValue > 0)
                    {
                        binary = (decimalValue % 2) + binary;
                        decimalValue /= 2;
                    }
                }

                Console.WriteLine($"\nRésultat de {input} en binaire : {binary}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
            

        }
        static void BinaireToOctal()
        {
            Console.Write("\nEntrez un nombre binaire : ");
            string input = Console.ReadLine();

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
                    decimalValue += bit * (int)Math.Pow(2, i);
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

                Console.WriteLine($"\nRésultat de {input} en octal : {octal}");
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
            string userText = Console.ReadLine();
            string resultat = ConvertToMorse(userText);
            
            Console.WriteLine("\nRésultat en Morse :");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{resultat}");
            Console.ResetColor();
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }


        static void CodeCesar()
        {

            string[] optionsCesar = { "Normal => César", "César => Normal"};
            Console.Clear();
            
            Console.WriteLine("╭─────────────────────────────────────────────────────╮");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("│               Convertisseur code césar              │");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("╰─────────────────────────────────────────────────────╯");
        
        
            Console.WriteLine("\nChoisissez une option :\n");

            for (int i = 0; i < optionsCesar.Length ; i++)
            {
                Console.WriteLine($"    {i + 1}. {optionsCesar[i]}");
            }

            Console.Write("\nVotre choix : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    NormalToCesar();
                    break;

                case "2":
                    CesarToNormal();
                    break;

                
                default:
                    Console.WriteLine("Votre choix est invalide. Appuyer sur une touche pour réésssayer ...");
                    Console.ReadKey();
                    break;

            }
        }

        static void NormalToCesar()
        {
            Console.Write("\nEntrez un texte à convertir en code césar : ");
            string input = Console.ReadLine();

            Console.Write("\nEntrer la clé de décalage (nombre entier) : ");
            int decalage = int.Parse(Console.ReadLine());
            decalage = (decalage % 26 + 26) % 26;

            string resultat = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    bool maj = char.IsUpper(c);
                    char debut = maj ? 'A' : 'a';

                    char nouveau = (char)(debut + (c - debut + decalage) % 26);
                    resultat += nouveau;
                }
                else
                {
                    resultat += c;
                }
            }

            Console.WriteLine($"\nTexte converti en code César : {resultat}");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }


        static void CesarToNormal()
        {
            Console.Write("\nEntrez un texte en code césar à décoder : ");
            string input = Console.ReadLine();

            Console.Write("\nEntrer la clé de décalage (nombre entier) : ");
            int decalage = int.Parse(Console.ReadLine());
            decalage = (decalage % 26 + 26) % 26;

            string resultat = "";

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    bool maj = char.IsUpper(c);
                    char debut = maj ? 'A' : 'a';

                    char nouveau = (char)(debut + (c - debut - decalage + 26) % 26);
                    resultat += nouveau;
                }
                else
                {
                    resultat += c;
                }
            }

            Console.WriteLine($"\nTexte décodé du code César : {resultat}");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
        

        static string ConvertToMorse(string input)
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
