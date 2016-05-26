namespace Event
{
    using System.Text;

    internal class Messages
    {
        private static readonly StringBuilder Message = new StringBuilder();

        public static void EventAdded()
        {
            Message.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Message.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Message.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Message.Append(eventToPrint + "\n");
            }
        }
    }
}