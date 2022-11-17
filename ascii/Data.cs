namespace ascii
{
    internal class Data
    {
        // <Text displayed on menu, Action called when option is selected>
        internal static Dictionary<string, Action> menu_options = new Dictionary<string, Action> {
            {"Enter RLE", RLE.EnterAndDisplay},
            {"Convert to RLE", RLE.ConvertAndSave },
            {"Display ASCII art", ASCII.PromptAndDisplay},
            {"Convert to ASCII art", ASCII.ConvertAndDisplayRLE },
            {"Quit", Program.Exit}
        };
    }
}
