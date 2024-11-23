using System;

namespace Rankings
{
    public class Team
    {
        readonly string name;
        int points;
        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public void UpdatePoints(int newPoints)
        {
            this.points += newPoints;
        }

        public bool CompareTo(Team anotherTeam)
        {
            return this.points < anotherTeam.points;
        }
    }
}
