using System;

namespace UAA9_CODE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reponse;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Jeu de Dominos ===\n");

                // Nombre de robots
                int robots;
                do
                {
                    Console.WriteLine("Combien de robots dans la partie ? (1 à 3)");
                    robots = int.Parse(Console.ReadLine());
                } while (robots < 1 || robots > 3);

                int nombreJoueurs = robots + 1;

                // Niveau des robots
                int niveauRobot;
                do
                {
                    Console.WriteLine("\nChoisissez le niveau des robots :");
                    Console.WriteLine("1 - Nul");
                    Console.WriteLine("2 - Moyen");
                    Console.WriteLine("3 - Fort");
                    niveauRobot = int.Parse(Console.ReadLine());
                } while (niveauRobot < 1 || niveauRobot > 3);

                Console.WriteLine("\nNiveau des robots choisi : " + niveauRobot);

                // Création du talon
                string[] talon = Fonctions.creationTalon();

                // Mélange
                Fonctions.melangeAleatoire(talon);

                // Distribution
                Fonctions.distributionCartes(talon, nombreJoueurs);

                Console.WriteLine("Voulez-vous rejouer ? (o/n)");
                reponse = Console.ReadLine().ToLower();

            } while (reponse == "o");

            Console.WriteLine("\nMerci d'avoir joué !");
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