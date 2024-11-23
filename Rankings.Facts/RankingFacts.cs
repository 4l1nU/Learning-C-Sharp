using Newtonsoft.Json.Schema;

namespace Rankings.Facts
{
    public class RankingFacts
    {
        [Fact]
        public void CanAddAndReturnThePositionOfTeam()
        {
            var ranking = new Ranking();
            var usc = new Team("USC", 1169);
            ranking.AddTeam(usc);
            Assert.Equal(1, ranking.PositionOfTeam(usc)); 
        }

        [Fact]
        public void CanSortTeamsCorrectly()
        {
            var ranking = new Ranking();
            var usc = new Team("USC", 1169);
            ranking.AddTeam(usc);
            var pennState = new Team("Penn state", 1244);
            ranking.AddTeam(pennState);
            Assert.Equal(1, ranking.PositionOfTeam(pennState));
        }

        [Fact]
        public void CanReturnTeamByPosition()
        {
            var ranking = new Ranking();
            var usc = new Team("USC", 1169);
            ranking.AddTeam(usc);
            Assert.Equal(usc, ranking.TeamOnPosition(1));
        }

        [Fact]
        public void IsSortingCorrectly()
        {
            Ranking collegeFootballTeams = new Ranking();
            var pennState = new Team("Penn state", 1244);
            collegeFootballTeams.AddTeam(pennState);
            var usc = new Team("USC", 1169);
            collegeFootballTeams.AddTeam(usc);
            var ohio = new Team("Ohio State", 1370);
            collegeFootballTeams.AddTeam(ohio);
            Assert.Equal(ohio, collegeFootballTeams.TeamOnPosition(1));
            Assert.Equal(pennState, collegeFootballTeams.TeamOnPosition(2));
            Assert.Equal(usc, collegeFootballTeams.TeamOnPosition(3));
        }

        [Fact]
        public void UpdatesPointsCorrectlyWhenTeamWins()
        {
            var ranking = new Ranking();
            var usc = new Team("USC", 1);
            ranking.AddTeam(usc);
            var pennState = new Team("Penn state", 3);
            ranking.AddTeam(pennState);
            ranking.AddMatch(usc, 2, pennState, 1);
            Assert.Equal(usc, ranking.TeamOnPosition(1));
        }

        [Fact]
        public void UpdatesPointsCorrectlyWhenTeamLoses()
        {
            var ranking = new Ranking();
            var usc = new Team("USC", 3);
            ranking.AddTeam(usc);
            var pennState = new Team("Penn state", 1);
            ranking.AddTeam(pennState);
            ranking.AddMatch(usc, 1, pennState, 2);
            Assert.Equal(pennState, ranking.TeamOnPosition(1));
        }

        [Fact]
        public void UpdatesPointsCorrectlyWhenScoresAreEven()
        {
            var ranking = new Ranking();
            var usc = new Team("USC", 0);
            ranking.AddTeam(usc);
            var pennState = new Team("Penn state", 1);
            ranking.AddTeam(pennState);
            ranking.AddMatch(usc, 0, pennState, 0);
            Assert.Equal(pennState, ranking.TeamOnPosition(1));
        }

        /*[Fact(Skip = "specific reason")]
        public void IsSortingCorrectly2()
        {
            Ranking collegeFootballUnsorted = new Ranking(
                new Team[]
                {new Team("Penn state", 1244),
                new Team("USC", 1169),
                new Team("Ohio State", 1370),
                new Team("Utah", 981),
                new Team("Michigan", 1445),
                new Team("Florida State", 1351),
                new Team("Texas", 1401),
                new Team("Washington", 1228),
                new Team("Georgia", 1562),
                new Team("Oregon", 1076)});
            Ranking collegeFootballSorted = new Ranking(
                new Team[]
                {new Team("Georgia", 1562),
                new Team("Michigan", 1445),
                new Team("Texas", 1401),
                new Team("Ohio State", 1370),
                new Team("Florida State", 1351),
                new Team("Penn state", 1244),
                new Team("Washington", 1228),
                new Team("USC", 1169),
                new Team("Oregon", 1076),
                new Team("Utah", 981)});
            Assert.Equal(collegeFootballSorted, collegeFootballUnsorted);
        }*/
    }
}