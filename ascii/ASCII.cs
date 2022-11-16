using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace ascii
{
    internal class ASCII
    {
        internal static void Display()
        {
            /// <summary>
            /// Menu call.
            ///   a. the user is asked to enter the name of the text file that contains the ASCII art
            ///   b. the program reads the contents of the text file and displays the ASCII art image
            ///   c. the user is returned to the main menu.
            /// </summary>

            // Get the ascii art from an existing, valid file
            string ascii;
            while (true)
            {
                Console.Clear();
                Console.Write("--- DISPLAY ASCII ART ---\nPath to ASCII art file: ");
                string ascii_fn = "Art\\" + Console.ReadLine();
                try
                {
                    ascii = File.ReadAllText(ascii_fn);
                    break;
                }
                catch { }
            }
            Console.Clear();

            DisplayASCIIStr(ascii);
        }

        internal static void DisplayFromRLE(string rle_str)
        {
            /// <summary>
            ///     Decodes and displays ascii art encoded with RLE
            /// </summary>

            Console.Clear();
            string ascii = Convert(rle_str);
            DisplayASCIIStr(ascii);
        }

        internal static void DisplayASCIIStr(string ascii)
        {
            /// <summary>
            ///     Prints ascii string to console
            /// </summary>

            Console.WriteLine("--- ASCII ART ---\n" + ascii + (ascii.EndsWith("\n") ? "Enter to continue: " : "\nEnter to continue: "));
            Console.ReadLine();
        }

        internal static void Convert()
        {
            /// <summary>
            /// Menu call.
            /// a. the user is asked to enter the name of the text file that contains the RLE compressed
            ///    data
            /// b. the program reads the contents of the text file, decompresses the data and displays
            ///    the ASCII art image
            /// c. the user is returned to the main menu.
            /// </summary>

            // Gets rle string from valid file
            Console.Clear();
            Console.WriteLine("--- ASCII FROM RLE ---");
            string rle;
            while (true)
            {
                Console.Write("Path to ASCII RLE file: ");
                string rle_fn = "Art\\" + Console.ReadLine();
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

            DisplayFromRLE(rle);
        }

        internal static string Convert(string rle_str)
        {
            /// <summary>
            ///     Converts RLE string to ASCII art 
            /// </summary>

            string ascii_art = "";
            foreach (string line in rle_str.Split("\n"))
            {
                // splits each line into 3 long chunks. any remainder is disregarded
                foreach (string chunk in Enumerable.Range(0, line.Length / 3).Select(i => line.Substring(i * 3, 3)))
                {
                    bool suc = int.TryParse(chunk.AsSpan(0, 2), out int len);
                    if (!suc) { return "ERROR"; }
                    ascii_art += new string(chunk[2], len);
                }

                ascii_art += "\n";
            }

            return ascii_art;
        }
    }
}
