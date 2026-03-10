using System;

namespace UAA9_CODE
{
    internal class Fonctions
    {
        /// <summary>
        /// Creation du talon de dominos
        /// </summary>
        public static void creationTalon()
        {
            string[] tableauDominos = new string[28]; // Il y a 28 dominos dans un jeu standard
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
        }

        /// <summary>
        /// Mélange aléatoire
        /// </summary>
        public static void melangeAleatoire()
        {
            string[] tableauDominos = new string[28]; // Il y a 28 dominos dans un jeu standard
            int compteurDomino = 0;
            // Mélange aléatoire
            Random random = new Random();

            for (int i = 0; i < tableauDominos.Length; i++)
            {
                int indexAleatoire = random.Next(i, tableauDominos.Length);

                // Échange des valeurs
                string temp = tableauDominos[i];
                tableauDominos[i] = tableauDominos[indexAleatoire];
                tableauDominos[indexAleatoire] = temp;
            }

            // Affichage après mélange
            Console.WriteLine("Dominos mélangés :");
            foreach (string domino in tableauDominos)
            {
                Console.WriteLine(domino);
            }
        }

        /// <summary>
        /// Distribue les dominos entre les joueurs
        /// </summary>
        /// <param name="tableauDominos">Tableau de dominos mélangés</param>
        /// <param name="nombreJoueurs">Nombre de joueurs (2-4)</param>
        public static void distributionCartes(string[] tableauDominos, int nombreJoueurs)
        {
            if (nombreJoueurs < 2 || nombreJoueurs > 4)
            {
                Console.WriteLine("Le nombre de joueurs doit être entre 2 et 4");
                return;
            }

            int dominosParJoueur = tableauDominos.Length / nombreJoueurs;
            int reste = tableauDominos.Length % nombreJoueurs;

            Console.WriteLine("\n=== Distribution pour " + nombreJoueurs + " joueurs ===\n");

            int index = 0;
            for (int joueur = 1; joueur <= nombreJoueurs; joueur++)
            {
                int nombreDominos = dominosParJoueur + (joueur <= reste ? 1 : 0);

                Console.WriteLine("Joueur " + joueur + " (" + nombreDominos + " dominos) :");

                for (int i = 0; i < nombreDominos; i++)
                {
                    Console.Write(tableauDominos[index] + " ");
                    index++;
                }
                Console.WriteLine("\n");
            }
        }
    }
}