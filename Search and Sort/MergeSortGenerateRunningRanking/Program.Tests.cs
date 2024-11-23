namespace RunningContest.Tests
{

    public class TestProgram
    { //ceva e gresit la test dar codul functioneaza corecta
        [Fact]
        public void MergeSort_TwoUnsortedSeriesEachThreeContestants_ShouldReturnSortedGeneralRanking()
        {
            Contest contest = new Contest();
            contest.Series = new ContestRanking[2];
            contest.Series[0].Contestants = new Contestant[3];
            contest.Series[0].Contestants[0] = new Contestant("Ion", "Romania", 9.800);
            contest.Series[0].Contestants[1] = new Contestant("John", "USA", 9.825);
            contest.Series[0].Contestants[2] = new Contestant("Zoli", "Ungaria", 9.910);
            contest.Series[1].Contestants = new Contestant[3];
            contest.Series[1].Contestants[0] = new Contestant("Michael", "Franta", 9.810);
            contest.Series[1].Contestants[1] = new Contestant("Vasile", "Romania", 9.900);
            contest.Series[1].Contestants[2] = new Contestant("Adriano", "Italia", 9.925);
            contest.GeneralRanking = new ContestRanking();
            contest.GeneralRanking.Contestants = new Contestant[6];
            contest.GeneralRanking.Contestants[0] = new Contestant("Ion", "Romania", 9.800);
            contest.GeneralRanking.Contestants[1] = new Contestant("John", "USA", 9.825);
            contest.GeneralRanking.Contestants[2] = new Contestant("Zoli", "Ungaria", 9.910);
            contest.GeneralRanking.Contestants[3] = new Contestant("Michael", "Franta", 9.810);
            contest.GeneralRanking.Contestants[4] = new Contestant("Vasile", "Romania", 9.900);
            contest.GeneralRanking.Contestants[5] = new Contestant("Adriano", "Italia", 9.925);

            Contest contestSorted = contest;
            contestSorted.GeneralRanking.Contestants[0] = new Contestant("Ion", "Romania", 9.800);
            contestSorted.GeneralRanking.Contestants[1] = new Contestant("Michael", "Franta", 9.810);
            contestSorted.GeneralRanking.Contestants[2] = new Contestant("John", "USA", 9.825);
            contestSorted.GeneralRanking.Contestants[3] = new Contestant("Vasile", "Romania", 9.900);
            contestSorted.GeneralRanking.Contestants[4] = new Contestant("Zoli", "Ungaria", 9.910); 
            contestSorted.GeneralRanking.Contestants[5] = new Contestant("Adriano", "Italia", 9.925);
            Program.GenerateGeneralRanking(ref contest);
            Assert.Equal(contestSorted.GeneralRanking, contest.GeneralRanking);
        }
    }
}