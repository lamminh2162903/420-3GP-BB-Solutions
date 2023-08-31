namespace M3_Fibonacci
{
    public class Utilitaires
    {
        // Version récursive de Fibonnaci. Loin d'être optimal
        // mais permet d'illustrer l'utilisation de plusieurs threads
        // pour accélérer un programme. La complexité de cet algorithme
        // est de O(2^n). Il est donc très lent.
        public static int CalculerFibonnaci( int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return CalculerFibonnaci(n - 1) + CalculerFibonnaci(n - 2);
            }
        }

        public static void AfficherNombresFibonnaci(int[] tab)
        {
            foreach (int i in tab)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }



    }
}