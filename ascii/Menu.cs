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

        internal static void Display(string header, string[] options)
        {
            /// <summary>
            /// Displays the menu defined in <c>Data.menu_options</c> where the keys are the displayed name of the option
            /// </summary>
            Menu.Header(header);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + options[i]);
            }
        }

        internal static string DisplayAndGet(string header, string[] options)
        {
            /// <summary>
            /// Displays the menu defined in <c>Data.menu_options</c> and returns the function associated with the selected option
            /// </summary>
            while (true)
            {
                Display(header, options);
                Console.Write("Select option: ");

                // return assocciated action if the user enters a correct option
                if (int.TryParse(Console.ReadLine(), out int selected_option)
                            && (selected_option > 0
                            && selected_option <= options.Length))
                {
                    return options[selected_option - 1];
                }
            }

        }
    }
}
