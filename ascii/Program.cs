namespace ascii
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                // Gets an action associated with the user selection
                Action selected_option = Menu.DisplayAndGet();
                if (selected_option == Exit) { break; }

                // call action and return to this menu
                selected_option();
            }
        }

        internal static void Exit() 
        { 
            // Display and get needs to return an action.
            // Program is quit when this is selected by user
        }
    }
}