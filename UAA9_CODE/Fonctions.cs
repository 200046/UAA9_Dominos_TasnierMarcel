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
        /// Distribue les dominos entre les joueurs
        /// </summary>
        public static void distributionCartes(string[] tableauDominos, int nombreJoueurs)
        {
            if (nombreJoueurs < 2 || nombreJoueurs > 4)
            {
                Console.WriteLine("Le nombre de joueurs doit être entre 2 et 4");
                return;
            }

            int dominosParJoueur;

            // Nombre de dominos par joueur selon la règle classique
            if (nombreJoueurs == 2)
                dominosParJoueur = 7;
            else
                dominosParJoueur = 6;

            int index = 0;

            Console.WriteLine("\n=== Distribution des dominos ===\n");

            for (int joueur = 1; joueur <= nombreJoueurs; joueur++)
            {
                if (joueur == 1)
                    Console.WriteLine("Joueur humain (" + dominosParJoueur + " dominos) :");
                else
                    Console.WriteLine("Robot " + (joueur - 1) + " (" + dominosParJoueur + " dominos) :");

                for (int i = 0; i < dominosParJoueur; i++)
                {
                    Console.Write(tableauDominos[index] + " ");
                    index++;
                }

                Console.WriteLine("\n");
            }

            // Affiche le talon restant
            int talonRestant = tableauDominos.Length - index;
            Console.WriteLine("Dominos restants dans le talon : " + talonRestant + "\n");
        }
    }
}