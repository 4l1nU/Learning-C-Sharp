namespace Rankings.Facts
{
    public class TeamFacts
    {
        [Fact]
        public void UpdatesTeamPoints()
        {
            var usc = new Team("USC", 1);
            usc.UpdatePoints(3);
            var test = new Team("Test", 3);
            Assert.True(test.CompareTo(usc));
        }
    }
}
