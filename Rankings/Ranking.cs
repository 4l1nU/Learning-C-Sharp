namespace Rankings
{
    public class Ranking
    {
        private Team[] teams;

        public Ranking()
        {
            this.teams = new Team[0];
        }

        public void AddTeam(Team newTeam)
        {
            Array.Resize(ref this.teams, this.teams.Length + 1);
            this.teams[this.teams.Length - 1] = newTeam;
            BubbleSort();
        }

        public void AddMatch(Team homeTeam, int homeTeamScore, Team awayTeam, int awayTeamScore)
        {
            (int homeTeamPoints, int awayTeamPoints) = (homeTeamScore, awayTeamScore) switch
            {
                var (x, y) when x > y => (3, 0),
                var (x, y) when x < y => (0, 3),
                _ => (1, 1)
            };

            homeTeam.UpdatePoints(homeTeamPoints);
            awayTeam.UpdatePoints(awayTeamPoints);
            BubbleSort();
        }

        public Team TeamOnPosition(int position)
        {
            return this.teams[position - 1];
        }

        public int PositionOfTeam(Team team)
        {
            return Array.IndexOf(this.teams, team) + 1;
        }

        private void BubbleSort()
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (this.teams[j].CompareTo(this.teams[j + 1]))
                    {
                        (this.teams[j], this.teams[j + 1]) = (this.teams[j + 1], this.teams[j]);
                        swapped = true;
                    }
                }
            }
        }
    }
}