using System;

namespace UAA9_CODE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string reponse;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Jeu de Dominos ===\n");

                Random generateur = new Random();

                // =========================
                // Pseudos disponibles et déjà pris
                // =========================
                string[] pseudosDisponibles = { "Bob", "Titan", "Bertrand", "Pixel", "Nova", "Luna", "Prout", "Vortex" };
                string[] pseudosPris = new string[4]; // max 1 humain + 3 robots
                int nbPseudosPris = 0;

                // =========================
                // Choix du pseudo humain
                // =========================
                Console.WriteLine("Entrez votre pseudo (ou tapez 'aleatoire') :");
                string inputPseudo = Console.ReadLine();
                string pseudoHumain;

                if (inputPseudo.ToLower() == "aleatoire")
                {
                    string pseudoChoisi;
                    bool pseudoUnique;
                    do
                    {
                        int index = generateur.Next(pseudosDisponibles.Length);
                        pseudoChoisi = pseudosDisponibles[index];

                        // Vérifier si déjà pris
                        pseudoUnique = true;
                        for (int i = 0; i < nbPseudosPris; i++)
                        {
                            if (pseudosPris[i] == pseudoChoisi)
                            {
                                pseudoUnique = false;
                            }
                        }
                    } while (!pseudoUnique);

                    pseudoHumain = pseudoChoisi;
                    Console.WriteLine("Votre pseudo aléatoire est : " + pseudoHumain);
                }
                else
                {
                    pseudoHumain = inputPseudo;
                    Console.WriteLine("Bienvenue, " + pseudoHumain + " !");
                }

                pseudosPris[nbPseudosPris] = pseudoHumain;
                nbPseudosPris++;

                // =========================
                // Tutoriel optionnel
                // =========================
                Console.WriteLine("\nVoulez-vous voir le tutoriel du jeu ? (o/n)");
                string choixTuto = Console.ReadLine().ToLower();
                if (choixTuto == "o")
                {
                    AfficherTutoriel();
                }

                // =========================
                // Nombre de robots
                // =========================
                int nombreRobots;
                do
                {
                    Console.WriteLine("\nCombien de robots dans la partie ? (1 à 3)");
                } while (!int.TryParse(Console.ReadLine(), out nombreRobots) || nombreRobots < 1 || nombreRobots > 3);

                // =========================
                // Niveau des robots
                // =========================
                int niveauRobots;
                do
                {
                    Console.WriteLine("\nChoisissez le niveau des robots :");
                    Console.WriteLine("1 - Nul");
                    Console.WriteLine("2 - Moyen");
                    Console.WriteLine("3 - Fort");
                } while (!int.TryParse(Console.ReadLine(), out niveauRobots) || niveauRobots < 1 || niveauRobots > 3);

                Console.WriteLine("\nNiveau des robots choisi : " + niveauRobots);

                // =========================
                // Attribution des pseudos aux robots
                // =========================
                string[] pseudosRobots = new string[nombreRobots];
                for (int i = 0; i < nombreRobots; i++)
                {
                    string pseudoRobot;
                    bool pseudoUnique;
                    do
                    {
                        int index = generateur.Next(pseudosDisponibles.Length);
                        pseudoRobot = pseudosDisponibles[index];

                        // Vérifier si déjà pris
                        pseudoUnique = true;
                        for (int j = 0; j < nbPseudosPris; j++)
                        {
                            if (pseudosPris[j] == pseudoRobot)
                            {
                                pseudoUnique = false;
                            }
                        }

                    } while (!pseudoUnique);

                    pseudosRobots[i] = pseudoRobot;
                    pseudosPris[nbPseudosPris] = pseudoRobot;
                    nbPseudosPris++;

                    Console.WriteLine("Robot " + (i + 1) + " pseudo : " + pseudoRobot);
                }

                // =========================
                // Création et mélange du talon
                // =========================
                string[] talon = Fonctions.creationTalon();
                Fonctions.melangeAleatoire(talon);

                // =========================
                // Distribution des dominos
                // =========================
                Fonctions.distributionCartes(talon, pseudoHumain, pseudosRobots);

                // =========================
                // Rejouer ? 
                // =========================
                Console.WriteLine("Voulez-vous rejouer ? (o/n)");
                reponse = Console.ReadLine().ToLower();

            } while (reponse == "o");

            Console.WriteLine("\nMerci d'avoir joué !");
        }

        public static void AfficherTutoriel()
        {
            Console.WriteLine("\n=== Tutoriel du Jeu de Dominos ===");
            Console.WriteLine("1. Chaque joueur reçoit des dominos.");
            Console.WriteLine("2. Le but est de poser des dominos qui correspondent aux extrémités de la table.");
            Console.WriteLine("3. Les robots ont différents niveaux : Nul, Moyen, Fort.");
            Console.WriteLine("4. Le joueur humain joue à son tour.");
            Console.WriteLine("5. Le jeu continue jusqu'à ce qu'un joueur n'ait plus de dominos.");
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();
        }
    }
}

/*
=====================================================
IDÉES POUR LES ROBOTS
=====================================================
1. Robot nul - Comportement simple.

Principe :
- regarde les dominos qu’il peut jouer
- en choisit un au hasard
- Il pioche même s’il peut jouer

2. Robot moyen (plus intelligent)
- jouer le domino qui correspond le plus souvent dans sa main

Exemple :
Main du robot :
6|2
6|5
3|6
Si la table finit par 6,
il joue un domino avec 6 pour garder le contrôle.

Logique :
compter les chiffres dans la main
jouer le domino avec le chiffre le plus fréquent

    Ne pas jouer les doubles trop vite.
    Exemple :
    6|6
    Le robot peut :
    - garder ce domino pour bloquer plus tard


3. Robot fort - Jouer le domino qui donne le moins de possibilités aux autres

Exemple :
Si la table finit par :
... 5

Le robot peut jouer :
5|1
5|6

Il regarde dans sa main :
- combien de 1
- combien de 6

Il joue celui qui est le plus rare.

Logique :
jouer le domino qui laisse un chiffre rare

*/