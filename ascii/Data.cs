namespace ascii
{
    internal class Data
    {
        internal static Dictionary<string, Action> menu_options = new Dictionary<string, Action> {
            {"Enter RLE", RLE.Enter},
            {"Convert to RLE", RLE.Convert },
            {"Display ASCII art", ASCII.Display},
            {"Convert to ASCII art", ASCII.Convert },
            {"Quit", Program.Exit}
        };
    }
}
