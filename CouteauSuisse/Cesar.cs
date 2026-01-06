using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouteauSuisse
{
    public class Cesar
    {

        /// <summary>
        /// Outil de conversion en code Césare
        /// </summary>
        public static void OptionMenu()
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
        public static void NormalToCesar()
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
        public static void CesarToNormal()
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

    }
}
