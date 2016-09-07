using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NombreMystereConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            NouvellePartie();
            Console.ReadKey();
        }

        /// <summary>
        /// Correspond au fait que l'on a gagné
        /// </summary>
        static void YouWin()
        {
            Console.WriteLine("Bravo, tu as gagné. On refait une partie ?.");
        }

        static int PickANumber()
        {
            string picked = Console.ReadLine();

            // Vérifier la validité de la saisie avec TryParse
            int pickedNum;
            bool isNumeric = int.TryParse(picked, out pickedNum);
            while (isNumeric == false)
            {
                // A VOUS : Trouvez le code à écrire ici
                Console.WriteLine("Oups, ce n'est pas un nombre.");
                picked = Console.ReadLine();
                isNumeric = int.TryParse(picked, out pickedNum);
            }

            return pickedNum;
        }

        static void NouvellePartie()
        {
            int randomed = GenereNombreAleatoire();

            Console.WriteLine("Saisissez un nombre entre 1 et 1000: ");
            int pickedNum = PickANumber();

            // A vous : Tant qu’on n’a pas trouvé on recommence
            // Trouvez la condition qui permet de refaire un essai de devinette
            while (pickedNum != randomed)
            {
                pickedNum = TryAgain(pickedNum, randomed);
            }

            YouWin();

        }

        static int GenereNombreAleatoire()
        {
            return new Random().Next(1, 1001);
        }

        static int TryAgain(int pickedNum, int randomed)
        {
            // A Vous : On aide l’utilisateur : on lui indique si c’est plus ou moins
            if (pickedNum > randomed)
            {
                Console.WriteLine("C'est moins");
            }
            else
            {
                Console.WriteLine("C'est plus");
            }

            pickedNum = PickANumber();
            return pickedNum;
        }
    }
}
