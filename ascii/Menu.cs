namespace ascii
{
    internal class Menu
    {
        internal static void Display()
        {
            /// <summary>
            /// Displays the menu defined in <c>Data.menu_options</c> where the keys are the displayed name of the option
            /// </summary>
            Console.Clear();
            for (int i = 0; i < Data.menu_options.Keys.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + Data.menu_options.Keys.ToArray()[i]);
            }
        }

        internal static Action DisplayAndGet()
        {
            /// <summary>
            /// Displays the menu defined in <c>Data.menu_options</c> and returns the function associated with the selected option
            /// </summary>
            while (true)
            {
                Display();
                Console.Write("Select option: ");

                // return assocciated action if the user enters a correct option
                if (int.TryParse(Console.ReadLine(), out int selected_option)
                            && (selected_option > 0
                            && selected_option <= Data.menu_options.Count))
                {
                    return Data.menu_options[Data.menu_options.Keys.ToArray()[selected_option - 1]];
                }
            }

        }
    }
}
