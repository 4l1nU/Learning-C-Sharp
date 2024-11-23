namespace SupportCases.Tests
{

    public class TestProgram
    {
        [Fact]
        public void Quick3Sort_AlreadySortedList_ShouldReturnSortedList()
        {
            SupportTicket[] tickets =
                {
                new SupportTicket(4 ,"Device immediately turns off", PriorityLevel.Critical),
                new SupportTicket(6 ,"Occasionally freeze", PriorityLevel.Critical),
                new SupportTicket(3, "Battery drain", PriorityLevel.Important),
                new SupportTicket(2, "Device not working", PriorityLevel.Important),
                new SupportTicket(1 ,"Incorrect behavior", PriorityLevel.Medium),
                new SupportTicket(8 ,"Internet connection problems", PriorityLevel.Medium),
                new SupportTicket(7 ,"Application not working", PriorityLevel.Low),
                new SupportTicket(5 ,"Strange behavior", PriorityLevel.Low)
            };

            Program.Quick3Sort(tickets);
            SupportTicket[] ticketsSorted =
                {
                new SupportTicket(4 ,"Device immediately turns off", PriorityLevel.Critical),
                new SupportTicket(6 ,"Occasionally freeze", PriorityLevel.Critical),
                new SupportTicket(2 ,"Device not working", PriorityLevel.Important),
                new SupportTicket(3 ,"Battery drain", PriorityLevel.Important),
                new SupportTicket(8 ,"Internet connection problems", PriorityLevel.Medium),
                new SupportTicket(1 ,"Incorrect behavior", PriorityLevel.Medium),
                new SupportTicket(7 ,"Application not working", PriorityLevel.Low),
                new SupportTicket(5 ,"Strange behavior", PriorityLevel.Low)

            };
            Assert.Equal(ticketsSorted, tickets);
        }

        [Fact]
        public void Quick3Sort_JustOneElementInList_ShouldReturnSameList()
        {
            SupportTicket[] tickets =
                {
                new SupportTicket(4 ,"Device immediately turns off", PriorityLevel.Critical),
            };

            Program.Quick3Sort(tickets);
            SupportTicket[] ticketsSorted =
                {
                new SupportTicket(4 ,"Device immediately turns off", PriorityLevel.Critical),
            };
            Assert.Equal(ticketsSorted, tickets);
        }

        [Fact]
        public void Quick3Sort_UnsortedTicketsListJustOneExampleOfPriority_ShouldReturnPrioritySortedTickets()
        {
            SupportTicket[] tickets =
                {
                new SupportTicket(3 ,"Incorrect behavior", PriorityLevel.Medium),
                new SupportTicket(1 ,"Device not working", PriorityLevel.Important),
                new SupportTicket(9 ,"Strange behavior", PriorityLevel.Low),
                new SupportTicket(4 ,"Occasionally freeze", PriorityLevel.Critical),

            };

            Program.Quick3Sort(tickets);
            SupportTicket[] ticketsSorted =
                {
                new SupportTicket(4 ,"Occasionally freeze", PriorityLevel.Critical),
                new SupportTicket(1 ,"Device not working", PriorityLevel.Important),
                new SupportTicket(3 ,"Incorrect behavior", PriorityLevel.Medium),
                new SupportTicket(9 ,"Strange behavior", PriorityLevel.Low)

            };
            Assert.Equal(ticketsSorted, tickets);
        }

        [Fact]
        public void Quick3Sort_UnsortedTicketsListTwoOfEachPriorityCase_ShouldReturnPrioritySortedTickets()
        {
            SupportTicket[] tickets =
                {
                new SupportTicket(1 ,"Incorrect behavior", PriorityLevel.Medium),
                new SupportTicket(2 ,"Device not working", PriorityLevel.Important),
                new SupportTicket(3 ,"Battery drain", PriorityLevel.Important),
                new SupportTicket(4 ,"Device immediately turns off", PriorityLevel.Critical),
                new SupportTicket(5 ,"Strange behavior", PriorityLevel.Low),
                new SupportTicket(6 ,"Occasionally freeze", PriorityLevel.Critical),
                new SupportTicket(7 ,"Application not working", PriorityLevel.Low),
                new SupportTicket(8 ,"Internet connection problems", PriorityLevel.Medium)
            };

            Program.Quick3Sort(tickets);
            SupportTicket[] ticketsSorted =
                {
                new SupportTicket(4 ,"Device immediately turns off", PriorityLevel.Critical),
                new SupportTicket(6 ,"Occasionally freeze", PriorityLevel.Critical),
                new SupportTicket(2 ,"Device not working", PriorityLevel.Important),
                new SupportTicket(3 ,"Battery drain", PriorityLevel.Important),
                new SupportTicket(8 ,"Internet connection problems", PriorityLevel.Medium),
                new SupportTicket(1 ,"Incorrect behavior", PriorityLevel.Medium),
                new SupportTicket(7 ,"Application not working", PriorityLevel.Low),
                new SupportTicket(5 ,"Strange behavior", PriorityLevel.Low)

            };
            Assert.Equal(ticketsSorted, tickets);
        }
    }
}