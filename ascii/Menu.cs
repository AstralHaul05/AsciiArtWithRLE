namespace ascii
{
    internal class Menu
    {
        internal static void Display()
        {
            Console.Clear();
            for (int i = 0; i < Data.menu_options.Keys.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + Data.menu_options.Keys.ToArray()[i]);
            }
        }

        internal static Action DisplayAndGet()
        {
            while (true)
            {
                Display();
                Console.Write("Select option: ");
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
