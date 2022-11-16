namespace ascii
{
    internal class ASCII
    {
        internal static void Display()
        {
            /*
                a.  the user is asked to enter the name of the text file that contains the ASCII art
                b.  the program reads the contents of the text file and displays the ASCII art image
                c.  the user is returned to the main menu.
            */

            string ascii_fn = "";

            bool success = false;
            while (!success)
            {
                Console.Clear();
                Console.WriteLine("--- DISPLAY ASCII ART ---");
                Console.Write("Path to ASCII art file: ");
                ascii_fn = "Art\\" + Console.ReadLine();
                try
                {
                    File.ReadAllLines(ascii_fn);
                    success = true;
                }
                catch
                {
                    success = false;
                }
            }
            Console.Clear();
            string ascii = File.ReadAllText(ascii_fn);
            DisplayASCIIStr(ascii);
        }

        internal static void Display(string rle_str)
        {
            Console.Clear();
            string ascii = Convert(rle_str);
            DisplayASCIIStr(ascii);
        }

        internal static void DisplayASCIIStr(string ascii)
        {
            Console.WriteLine("--- ASCII ART ---\n" + ascii + (ascii.EndsWith("\n") ? "Enter to continue: " : "\nEnter to continue: "));
            Console.ReadLine();
        }

        internal static void Convert()
        {
            /*
                a.the user is asked to enter the name of the text file that contains the RLE compressed
                data
                b.the program reads the contents of the text file, decompresses the data and displays
                the ASCII art image
                c.the user is returned to the main menu.
            */

            Console.Clear();
            Console.WriteLine("--- ASCII FROM RLE ---");
            string rle_fn = "";
            string rle;
            while (true)
            {
                Console.Write("Path to ASCII RLE file: ");
                rle_fn = "Art\\" + Console.ReadLine();
                try
                {
                    rle = File.ReadAllText(rle_fn);
                    break;
                }
                catch (FileNotFoundException)
                {
                    Console.Clear();
                }
            }
            Console.Clear();
            Display(rle);
        }

        internal static string Convert(string rle_str)
        {
            string[] rle_lines = rle_str.Split("\n");

            string ascii_art = "";

            int len;
            foreach (string line in rle_lines)
            {
                foreach (string chunk in Enumerable.Range(0, line.Length / 3).Select(i => line.Substring(i * 3, 3)))
                {
                    if (chunk.Length != 3) { return "ERROR"; }
                    bool suc = int.TryParse(chunk.AsSpan(0, 2), out len);
                    if (!suc) { return "ERROR"; }
                    ascii_art += new string(chunk[2], len);
                }

                ascii_art += "\n";
            }

            return ascii_art;
        }
    }
}
