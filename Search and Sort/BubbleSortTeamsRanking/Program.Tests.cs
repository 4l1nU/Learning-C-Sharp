using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace SoccerTeamsRanking.Tests
{
    public class TestProgram
    {
        [Fact]
        public void CheckAlarm_CheckOneNonExistentAlaram_ShouldReturnFalse()
        {
            SoccerTeam[] teamsRanking =
                {new SoccerTeam("CFR Cluj", 36),
                new SoccerTeam("FCSB", 31),
                new SoccerTeam("U Craiova", 32),
                new SoccerTeam("Dinamo", 24),
                new SoccerTeam("Viitorul", 22),
                new SoccerTeam("Astra Giurgiu", 25),
                new SoccerTeam("CSMS Iasi", 21),
                new SoccerTeam("FC Botosani", 22),
                new SoccerTeam("FC Voluntari", 17),
                new SoccerTeam("Chiajna", 18),
                new SoccerTeam("ACS Poli Tim", 14),
                new SoccerTeam("Sepsi OSK", 14),
                new SoccerTeam("Gaz Metan", 8),
                new SoccerTeam("Juventus", 10) };
            Program.BubbleSort(teamsRanking);
            SoccerTeam[] teamsRankingSorted =
                {new SoccerTeam("CFR Cluj", 36),
                new SoccerTeam("U Craiova", 32),
                new SoccerTeam("FCSB", 31),
                new SoccerTeam("Astra Giurgiu", 25),
                new SoccerTeam("Dinamo", 24),
                new SoccerTeam("Viitorul", 22),
                new SoccerTeam("FC Botosani", 22),
                new SoccerTeam("CSMS Iasi", 21),
                new SoccerTeam("Chiajna", 18),
                new SoccerTeam("FC Voluntari", 17),
                new SoccerTeam("ACS Poli Tim", 14),
                new SoccerTeam("Sepsi OSK", 14),
                new SoccerTeam("Juventus", 10),
                new SoccerTeam("Gaz Metan", 8) };
            Assert.Equal(teamsRankingSorted, teamsRanking);
        }
    }
}