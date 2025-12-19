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

        /// <summary>
        /// Menu des options du convertisseur de bases
        /// </summary>
        static void ConvertisseurOptionMenu()
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
        static void DecimalToBinaire()
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
        static void BinaireToDecimal()
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
        static void OctalToBinaire()
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
        static void BinaireToOctal()
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

        /// <summary>
        /// Outil de conversion en Morses
        /// </summary>
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

        /// <summary>
        /// Outil de conversion en code Césare
        /// </summary>
        static void CodeCesar()
        {

            string[] optionsCesar = { "Normal => César", "César => Normal" };
            Console.Clear();

            Console.WriteLine("╭─────────────────────────────────────────────────────╮");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("│               Convertisseur code césar              │");
            Console.WriteLine("│                                                     │");
            Console.WriteLine("╰─────────────────────────────────────────────────────╯");


            Console.WriteLine("\nChoisissez une option :\n");

            // Affichage des options
            for (int i = 0; i < optionsCesar.Length; i++)
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

        /// <summary>
        /// Convertit un texte normal en code César
        /// </summary>
        static void NormalToCesar()
        {
            // Demande du texte a convertirs
            Console.Write("\nEntrez un texte à convertir en code césar : ");
            string input = Console.ReadLine();

            // Demande de la clé de déclages
            Console.Write("\nEntrer la clé de décalage (nombre entier) : ");
            int decalage = int.Parse(Console.ReadLine());
            decalage = (decalage % 26 + 26) % 26;

            string resultat = "";

            // Pour chaque caractere du texte d'entree on effectue le décalage
            foreach (char c in input)
            {
                // Si le caractère est une lettre on effectue le décalage
                if (char.IsLetter(c))
                {
                    // Verifi si la lettre est majuscule
                    bool maj = char.IsUpper(c);

                    // Détermine le caractères de début (A ou a)
                    char debut = maj ? 'A' : 'a';

                    // Effectue le decalage en utilisant la formule du code César, en gérant le retour à 'A' ou 'a' avec le modulo 26
                    char nouveau = (char)(debut + (c - debut + decalage) % 26);
                    // Ajoute le caracteres converti au résultat
                    resultat += nouveau;
                }
                else
                {
                    // Si ce n'est pas une lettres, on l'ajoute tel quel au résusltat
                    resultat += c;
                }
            }

            Console.WriteLine($"\nTexte converti en code César : {resultat}");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Convertit un tete en code César en texte normal
        /// </summary>
        static void CesarToNormal()
        {
            // Demande du texte a décoder
            Console.Write("\nEntrez un texte en code césar à décoder : ");
            string input = Console.ReadLine();

            // Demande de la clé de décalage
            Console.Write("\nEntrer la clé de décalage (nombre entier) : ");
            int decalage = int.Parse(Console.ReadLine());
            // Definition du decalage en s'assurant qu'il est dans la plage 0-25
            decalage = (decalage % 26 + 26) % 26;

            string resultat = "";

            // Pour chaque caractere du texte d'entree on effectue le décalage inverse
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    // Verifie si la lettre est majuscules
                    bool maj = char.IsUpper(c);

                    // Détermine le caractère de début (A ou a)
                    char debut = maj ? 'A' : 'a';

                    // Effectue le decalage inverse en utilisant la formule du code César, en grant le retour à 'A' ou 'a' avec le modulo 26
                    char nouveau = (char)(debut + (c - debut - decalage + 26) % 26);
                    resultat += nouveau;
                }
                else
                {
                    // Si ce n'est pas une lettre, on l'ajoute tel quel au résultat
                    resultat += c;
                }
            }

            Console.WriteLine($"\nTexte décodé du code César : {resultat}");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Convertit un texte en code Morse
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
    }
}
