using System;

namespace SoccerTeamsRanking
{
    // Sorteaza n echipe introduse cu punctajul vechi la care se adauga meciul nou, iar apoi se face noul clasament
    public struct SoccerTeam
    {
        public string Name;
        public int Points;

        public SoccerTeam(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }

    public class Program
    {
        public static void Main()
        {
            SoccerTeam[] teamsRanking = ReadTeams();
            BubbleSort(teamsRanking);
            Print(teamsRanking);
            Console.Read();
        }

        public static void BubbleSort(SoccerTeam[] teams)
        {
            int n = teams.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (teams[j].Points < teams[j + 1].Points)
                    {
                        Swap(teams, j, j + 1);
                    }
                }
            }
        }

        static void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);
            const string message = "Swapping elements with indexes ({0}, {1}) and values ({2}, {3})";
            Console.WriteLine(string.Format(message, minIndex, maxIndex, teams[minIndex].Name, teams[maxIndex].Name));

            SoccerTeam temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

        static (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }

        static void Print(SoccerTeam[] teamsRanking)
        {
            for (int i = 0; i < teamsRanking.Length; i++)
            {
                Console.WriteLine(teamsRanking[i].Name + "- " + teamsRanking[i].Points);
            }
        }

        static SoccerTeam[] ReadTeams()
        {
            SoccerTeam[] result = new SoccerTeam[14];

            for (int i = 0; i < result.Length; i++)
            {
                string[] teamData = Console.ReadLine().Split('-');
                int points = Convert.ToInt32(teamData[1]) + Convert.ToInt32(teamData[2]);
                result[i] = new SoccerTeam(teamData[0], points);
            }

            return result;
        }
    }
}
