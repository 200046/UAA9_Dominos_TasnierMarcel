using System;

namespace UAA9_CODE
{
    internal class Fonctions
    {
        /// <summary>
        /// Création du talon de dominos
        /// </summary>
        public static string[] creationTalon()
        {
            string[] tableauDominos = new string[28];
            int compteurDomino = 0;

            for (int pointsFaceA = 0; pointsFaceA <= 6; pointsFaceA++)
            {
                for (int pointsFaceB = pointsFaceA; pointsFaceB <= 6; pointsFaceB++)
                {
                    string dominoActuel = "[" + pointsFaceA + "|" + pointsFaceB + "]";
                    tableauDominos[compteurDomino] = dominoActuel;
                    compteurDomino++;
                }
            }

            return tableauDominos;
        }

        /// <summary>
        /// Mélange aléatoire
        /// </summary>
        public static void melangeAleatoire(string[] tableauDominos)
        {
            Random random = new Random();

            for (int i = 0; i < tableauDominos.Length; i++)
            {
                int indexAleatoire = random.Next(i, tableauDominos.Length);

                string temp = tableauDominos[i];
                tableauDominos[i] = tableauDominos[indexAleatoire];
                tableauDominos[indexAleatoire] = temp;
            }
        }

        /// <summary>
        /// Distribue les dominos entre les joueurs avec pseudos
        /// </summary>
        public static void distributionCartes(string[] tableauDominos, string pseudoJoueur, string[] pseudosRobots)
        {
            int nombreJoueurs = pseudosRobots.Length + 1;
            int dominosParJoueur = (nombreJoueurs == 2) ? 7 : 6;

            int index = 0;

            Console.WriteLine("\n=== Distribution des dominos ===\n");

            // Joueur humain
            Console.WriteLine(pseudoJoueur + " (" + dominosParJoueur + " dominos) :");
            for (int i = 0; i < dominosParJoueur; i++)
            {
                Console.Write(tableauDominos[index] + " ");
                index++;
            }
            Console.WriteLine("\n");

            // Robots
            for (int j = 0; j < pseudosRobots.Length; j++)
            {
                Console.WriteLine("ROBOTO | " + pseudosRobots[j] + " (" + dominosParJoueur + " dominos) :");
                for (int i = 0; i < dominosParJoueur; i++)
                {
                    Console.Write(tableauDominos[index] + " ");
                    index++;
                }
                Console.WriteLine("\n");
            }

            int talonRestant = tableauDominos.Length - index;
            Console.WriteLine("Dominos restants dans le talon : " + talonRestant + "\n");
        }
    }
}