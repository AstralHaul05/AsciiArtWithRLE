namespace ascii
{
    internal class Menu
    {
        internal static void Header(string str)
        {
            Console.Clear();
            Console.WriteLine("--- " + str + " ---");
        }

        // <Text displayed on menu, Action called when option is selected>
        internal static Dictionary<string, Action> menu_options = new Dictionary<string, Action> {
            {"Enter RLE", RLE.EnterAndDisplay},
            {"Convert to RLE", RLE.ConvertAndSave },
            {"Display ASCII art", ASCII.PromptAndDisplay},
            {"Convert to ASCII art", ASCII.ConvertAndDisplayRLE },
            {"Quit", Program.Exit}
        };

        internal static void Display(string header, string[] options, int selection_index)
        {
            Header(header);
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selection_index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(i + 1 + ". " + options[i]);
                Console.ResetColor();
            }
        }

        internal static string DisplayAndGet(string header, string[] options)
        {
            /// <summary>
            /// Displays the menu defined in <c>Data.menu_options</c> and returns the function associated with the selected option
            /// </summary>

            if (options.Length == 0)
            {
                Header(header);
                Console.WriteLine("No options to display.\nEnter to return.");
                Console.ReadLine();
                return "";
            }

            int selected_option = 0;
            bool option_selected = false;
            do
            {
                Display(header, options, selected_option);
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (selected_option < options.Length-1)
                        {
                            selected_option++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (selected_option > 0)
                        {
                            selected_option--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        option_selected = true;
                        break;
                    default:
                        break;
                }
            }
            while (!option_selected);
            return options[selected_option];
        }
    }
}
