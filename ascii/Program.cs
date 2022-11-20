namespace ascii
{
    internal class Program
    {
        static void Main()
        {
            Action selected_action;
            do
            {
                // Gets an action associated with the user selection
                string selected_option = Menu.DisplayAndGet("Main Menu", Menu.menu_options.Keys.ToArray());

                selected_action = Menu.menu_options[selected_option];

                // call action and return to this menu
                selected_action();
            }
            while (selected_action != Exit);
        }

        public static void Exit() { }
    }
}