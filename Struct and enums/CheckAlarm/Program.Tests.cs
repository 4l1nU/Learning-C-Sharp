namespace Alarm.Tests
{
    public class TestProgram
    {
        [Fact]
        public void CheckAlarm_CheckOneNonExistentAlaram_ShouldReturnFalse()
        {
            int countAllerts = 1;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(12, 30), Days.Mo);
            Time timeToCheck = new Time(12, 00);
            Days dayToCheck = Days.Sa;
            Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void CheckAlarm_CheckOneTrueAlarm_ShouldReturnTrue()
        {
            int countAllerts = 1;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(12, 30), Days.Mo);
            Time timeToCheck = new Time(12, 30);
            Days dayToCheck = Days.Mo;
            Assert.True(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void CheckAlarm_CheckOneAlarmCorrectDayFalseHour_ShouldReturnFalse()
        {
            int countAllerts = 1;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(12, 30), Days.Mo);
            Time timeToCheck = new Time(12, 00);
            Days dayToCheck = Days.Mo;
            Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }


        [Fact]
        public void CheckAlarm_CheckOneAlarmCorrectDayCorrectHourFalseMinutes_ShouldReturnFalse()
        {
            int countAllerts = 1;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(12, 30), Days.Mo);
            Time timeToCheck = new Time(12, 00);
            Days dayToCheck = Days.Mo;
            Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void CheckAlarm_CheckOneAlarmCorrectDayFalseHourCorrectMinutes_ShouldReturnFalse()
        {
            int countAllerts = 1;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(12, 30), Days.Mo);
            Time timeToCheck = new Time(13, 30);
            Days dayToCheck = Days.Mo;
            Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void CheckAlarm_CheckOneAlarmFalseDayCorrectHourCorrectMinutes_ShouldReturnFalse()
        {
            int countAllerts = 1;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(12, 30), Days.Mo);
            Time timeToCheck = new Time(12, 30);
            Days dayToCheck = Days.Su;
            Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void CheckAlarm_CheckOneCorrectAlarmWhenMoreAlarmsSet_ShouldReturnTrue()
        {
            int countAllerts = 10;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(1, 30), Days.Su);
            alerts[1] = new Alert(new Time(2, 00), Days.Th);
            alerts[2] = new Alert(new Time(3, 30), Days.Mo);
            alerts[3] = new Alert(new Time(4, 00), Days.We);
            alerts[4] = new Alert(new Time(5, 30), Days.Fr);
            alerts[5] = new Alert(new Time(11, 00), Days.Mo);
            alerts[6] = new Alert(new Time(12, 30), Days.We);
            alerts[7] = new Alert(new Time(13, 00), Days.Sa);
            alerts[8] = new Alert(new Time(14, 30), Days.Th);
            alerts[9] = new Alert(new Time(15, 00), Days.Tu);
            Time timeToCheck = new Time(4, 00);
            Days dayToCheck = Days.We;
            Assert.True(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void CheckAlarm_CheckOneNonExistentAlarmWhenMoreAlarmsSet_ShouldReturnFalse()
        {
            int countAllerts = 10;
            Alert[] alerts = new Alert[countAllerts];
            alerts[0] = new Alert(new Time(1, 30), Days.Su);
            alerts[1] = new Alert(new Time(2, 00), Days.Th);
            alerts[2] = new Alert(new Time(3, 30), Days.Mo);
            alerts[3] = new Alert(new Time(4, 00), Days.We);
            alerts[4] = new Alert(new Time(5, 30), Days.Fr);
            alerts[5] = new Alert(new Time(11, 00), Days.Mo);
            alerts[6] = new Alert(new Time(12, 30), Days.We);
            alerts[7] = new Alert(new Time(13, 00), Days.Sa);
            alerts[8] = new Alert(new Time(14, 30), Days.Th);
            alerts[9] = new Alert(new Time(15, 00), Days.Tu);
            Time timeToCheck = new Time(5, 00);
            Days dayToCheck = Days.Fr;
            Assert.False(Program.CheckAlarm(alerts, timeToCheck, dayToCheck));
        }

        [Fact]
        public void AddDayToAlert_AddDayMoToAllert_ShouldReturnSetDayMoToAlert()
        {
            Alert alertOne = new Alert(new Time(1, 30));
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Assert.Equal(Days.Mo, alertOne.Days);
        }
​
        [Fact]
        public void AddDayToAlert_AddDaysMoAndTuToAllert_ShouldReturnSetDayMoAndTuToAlert()
        {
            Alert alertOne = new Alert(new Time(1, 30));
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Program.AddDayToAlert(ref alertOne, Days.Tu);
            Assert.Equal(Days.Mo | Days.Tu, alertOne.Days);
        }
​
        [Fact]
        public void AddDayToAlert_AddAllDaysToAllert_ShouldReturnSetAllDaysToAlert()
        {
            Alert alertOne = new Alert(new Time(1, 30));
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Program.AddDayToAlert(ref alertOne, Days.Tu);
            Program.AddDayToAlert(ref alertOne, Days.We);
            Program.AddDayToAlert(ref alertOne, Days.Th);
            Program.AddDayToAlert(ref alertOne, Days.Fr);
            Program.AddDayToAlert(ref alertOne, Days.Sa);
            Program.AddDayToAlert(ref alertOne, Days.Su);
            Assert.Equal(Days.Mo | Days.Tu | Days.We | Days.Th | Days.Fr | Days.Sa | Days.Su, alertOne.Days);
        }
​
        [Fact]
        public void AddDayToAlert_AddSameDayToAllert_ShouldReturnSetDayOneTimeToAlert()
        {
            Alert alertOne = new Alert(new Time(1, 30));
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Program.AddDayToAlert(ref alertOne, Days.Mo);
            Assert.Equal(Days.Mo, alertOne.Days);
        }
    }
}