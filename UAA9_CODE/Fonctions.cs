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
    }
}