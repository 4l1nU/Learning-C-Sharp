using System;

/*
 Problema de rezolvat:

Descarcă proiectul atașat problemei și continuă rezolvarea. Trebuie implementată funcția GenerateGeneralRanking și apoi se trimite – ca de obicei – fișierul Program.cs pentru validare.

Problema:

La un concurs de atletism la proba de viteză concurenții aleargă în N serii a câte M atleți per serie.

Să se scrie o aplicație consolă ce primește clasamentul pentru fiecare serie în parte și tipărește clasamentul general.

Clasamentul conține câte un sportiv pe linie, având următorul format:
 <nume> - <țara> - <timpul în secunde>

Concurenții din fiecare serie sunt ordonați în ordine crescătoare a timpului realizat și clasamentele per serii sunt despărțite între ele printr-o linie goală.

Important: Implementează algoritmul MergeSort pentru a rezolva problema. Acesta este o soluție de sortare foarte eficientă atunci când trebuie obținut un șir ordonat pornind de la subșiruri gata ordonate.

Exemplu:

Pentru datele de intrare:

2
3
Ion - Romania - 9.800
John - USA - 9.825
Zoli - Ungaria - 9.910

Michael - Franta - 9.810
Vasile - Romania - 9.900
Adriano - Italia - 9.925
La consolă se va afișa:

Ion - Romania - 9.800
Michael - Franta - 9.810
John - USA - 9.825
Vasile - Romania - 9.900
Zoli - Ungaria - 9.910
Adriano - Italia - 9.925
Rezolvarea trimisă este corectă.

 6/2/2023, 3:53:06 PM - rezolvarea corectă - ascunde detaliie...

Fișier: Program.cs

Rezultate:

Compilare executată cu succes.
Testul 1: Ordonează corect concurenții din două serii (2, 3, Ion - Romania - 9.800, John - USA - 9.825, Zoli - Ungaria - 9.910, Michael - Franta - 9.810, Vasile - Romania - 9.900, Adriano - Italia - 9.925) - succes
Testul 2: Tratează corect cazul când e o singurâ serie (1, 3, Ion - Romania - 9.800, John - USA - 9.825, Zoli - Ungaria - 9.910) - succes
Testul 3: Ordonează corect concurenții din mai multe serii (4, 6, Ion - Romania - 9.800, John - USA - 9.825, Zoli - Ungaria - 9.910, Hans - Germania - 9.915, Ivan - Rusia - 9.950, Anderson - Suedia - 9.972, Michael - Franta - 9.810, Vasile - Romania - 9.900, Adriano - Italia - 9.925, Bill - USA - 9.927, Muller - Germania - 9.940, Ronaldo - Brazilia - 9.965, Eusebio - Portugalia - 9.790, Chan - China - 9.824, Diego - Argentina - 9.866, Armando - Brazilia - 9.898, Fatih - Turcia - 9.945, Saulos - Grecia - 9.948, Alonso - Spania - 9.830, Miroslav - Serbia - 9.831, Kwang - Coreea de Sud - 9.879, Koichi - Japonia - 9.884, Amir - Egipt - 9.893, Vladimir - Rusia - 9.990) - succes
Testul 4: Rezolvarea merge cu date de intrare aleatoare - succes
 */
namespace RunningContest
{
    public struct Contestant
    {
        public string Name;
        public string Country;
        public double Time;

        public Contestant(string name, string country, double time)
        {
            this.Name = name;
            this.Country = country;
            this.Time = time;
        }
    }

    public struct ContestRanking
    {
        public Contestant[] Contestants;
    }

    public struct Contest
    {
        public ContestRanking[] Series;
        public ContestRanking GeneralRanking;
    }

    public class Program
    {
        public static void Main()
        {
            Contest contest = ReadContestSeries();
            GenerateGeneralRanking(ref contest);
            Print(contest.GeneralRanking);
            Console.Read();
        }

        public static void GenerateGeneralRanking(ref Contest contest)
        {
            int totalOfConstestants = contest.Series.Length * contest.Series[0].Contestants.Length;
            contest.GeneralRanking = new ContestRanking();
            contest.GeneralRanking.Contestants = new Contestant[totalOfConstestants];
            int indexOfGeneralRanking = 0;
            for (int indexOfSerie = 0; indexOfSerie < contest.Series.Length; indexOfSerie++)
            {
                for (int indexOfContestant = 0; indexOfContestant < contest.Series[indexOfSerie].Contestants.Length; indexOfContestant++, indexOfGeneralRanking++)
                {
                    contest.GeneralRanking.Contestants[indexOfGeneralRanking] = contest.Series[indexOfSerie].Contestants[indexOfContestant];
                }
            }

            SortArray(ref contest, 0, contest.GeneralRanking.Contestants.Length - 1);
        }

        private static void Print(ContestRanking contestRanking)
        {
            for (int i = 0; i < contestRanking.Contestants.Length; i++)
            {
                Contestant contestant = contestRanking.Contestants[i];
                const string line = "{0} - {1} - {2:F3}";
                Console.WriteLine(string.Format(line, contestant.Name, contestant.Country, contestant.Time));
            }
        }

        static void SortArray(ref Contest contest, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int middle = left + (right - left) / 2;
            SortArray(ref contest, left, middle);
            SortArray(ref contest, middle + 1, right);
            MergeArray(ref contest, left, middle, right);
        }

        static void MergeArray(ref Contest contest, int left, int middle, int right)
        {
            int leftArrayLength = middle - left + 1;
            int rightArrayLength = right - middle;
            Contestant[] tempLeftContestants = new Contestant[leftArrayLength];
            Contestant[] tempRightContestants = new Contestant[rightArrayLength];
            int i;
            int j;
            for (i = 0; i < leftArrayLength; ++i)
                {
                    tempLeftContestants[i] = contest.GeneralRanking.Contestants[left + i];
                }

            for (j = 0; j < rightArrayLength; ++j)
            {
            tempRightContestants[j] = contest.GeneralRanking.Contestants[middle + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                contest.GeneralRanking.Contestants[k++] = tempLeftContestants[i].Time <= tempRightContestants[j].Time ? tempLeftContestants[i++] : tempRightContestants[j++];
            }

            while (i < leftArrayLength)
            {
                contest.GeneralRanking.Contestants[k++] = tempLeftContestants[i++];
            }

            while (j < rightArrayLength)
            {
                contest.GeneralRanking.Contestants[k++] = tempRightContestants[j++];
            }
        }

        static Contest ReadContestSeries()
        {
            Contest contest = new Contest();

            int seriesNumber = Convert.ToInt32(Console.ReadLine());
            int contestantsPerSeries = Convert.ToInt32(Console.ReadLine());

            contest.Series = new ContestRanking[seriesNumber];

            for (int i = 0; i < seriesNumber; i++)
            {
                contest.Series[i].Contestants = new Contestant[contestantsPerSeries];
                for (int j = 0; j < contestantsPerSeries; j++)
                {
                    string contestantLine = "";

                    while (contestantLine == "")
                    {
                        contestantLine = Console.ReadLine();
                    }

                    contest.Series[i].Contestants[j] = CreateContestant(contestantLine.Split('-'));
                }
            }

            return contest;
        }

        private static Contestant CreateContestant(string[] contestantData)
        {
            const int nameIndex = 0;
            const int countryIndex = 1;
            const int timeIndex = 2;

            return new Contestant(
                contestantData[nameIndex].Trim(),
                contestantData[countryIndex].Trim(),
                Convert.ToDouble(contestantData[timeIndex]));
        }
    }
}