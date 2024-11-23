using System;

/*
Mai sus avem ilustrat triunghiul lui Pascal. Să se scrie o aplicație consolă ce generează, folosind un algoritm recursiv, triunghiul lui Pascal pentru un nivel N dat.

Exemplu:

Pentru datele de intrare:

6
La consolă se va afișa:

1
1 1
1 2 1
1 3 3 1
1 4 6 4 1
1 5 10 10 5 1
Validarea Soluției
Rezolvarea trimisă este corectă.

 5/2/2023, 9:53:12 PM - rezolvarea corectă - ascunde detaliie...

Fișier: Program.cs

Rezultate:

Compilare executată cu succes.
Testul 1: Generează corect triunghiul lui Pascal până la nivelul 10 - succes
Testul 2: Generează corect triunghiul lui Pascal până la nivelul 1 - succes
Testul 3: Generează corect triunghiul lui Pascal până la nivelul 2 - succes
Testul 4: Rezolvarea merge cu date de intrare aleatoare - succes
*/
namespace SeondApp
{
    public class Program
    {
        public static void Main()
        {
            int triangleLevel = Convert.ToInt32(Console.ReadLine());
            GetPascalTriangle(triangleLevel);
        }

        public static int[,] GetPascalTriangle(int triangleLevel)
        {
            int[,] result = new int[triangleLevel, triangleLevel];
            int currentLevel = -1;
            FormPascalTriangleLevels(triangleLevel, ref currentLevel, ref result);
            return result;
        }

        static int FormPascalTriangleLevels(int triangleLevel, ref int currentLevel, ref int[,] result)
        {
            Console.WriteLine();
            currentLevel++;
            if (currentLevel == triangleLevel)
            {
                return currentLevel;
            }

            int colomn = 0;
            GetPascalTriangleLevelValues(currentLevel, ref colomn, ref result);
            return FormPascalTriangleLevels(triangleLevel, ref currentLevel, ref result);
        }

        private static int GetPascalTriangleLevelValues(int currentLevel, ref int colomn, ref int[,] result)
        {
            if (colomn == currentLevel + 1)
            {
                return colomn;
            }

            if (colomn != 0 && colomn != currentLevel)
            {
                result[currentLevel, colomn] = result[currentLevel - 1, colomn] + result[currentLevel - 1, colomn - 1];
                Console.Write(result[currentLevel, colomn] + " ");
                colomn++;
                return GetPascalTriangleLevelValues(currentLevel, ref colomn, ref result);
            }

            result[currentLevel, colomn] = 1;
            Console.Write(result[currentLevel, colomn] + " ");
            colomn++;
            return GetPascalTriangleLevelValues(currentLevel, ref colomn, ref result);
        }
    }
}