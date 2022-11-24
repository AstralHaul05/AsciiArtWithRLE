using Microsoft.VisualBasic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ascii
{
    internal class ASCII
    {
        internal static void PromptAndDisplay()
        {
            /// <summary>
            /// Menu call.
            ///   a. the user is asked to enter the name of the text file that contains the ASCII art
            ///   b. the program reads the contents of the text file and displays the ASCII art image
            ///   c. the user is returned to the main menu.
            /// </summary>

            // Get the ascii art from an existing, valid file
            string selected_path = Menu.DisplayAndGet("Ascii Art File", Directory.GetFiles("Art\\"));
            if (selected_path == "")
            {
                return;
            }
            DisplayASCIIStr(File.ReadAllText(selected_path));
        }

        internal static void DisplayFromRLE(string rle_str)
        {
            /// <summary>
            ///     Decodes and displays ascii art encoded with RLE
            /// </summary>

            Menu.Header("Art from RLE");
            DisplayASCIIStr(ConvertFromRLE(rle_str));
        }

        internal static void DisplayASCIIStr(string ascii)
        {
            /// <summary>
            ///     Prints ascii string to console
            /// </summary>

            Menu.Header("ASCII Art");
            Console.WriteLine($"{ascii}\nEnter to return to menu...");
            Console.ReadLine();
        }

        internal static void ConvertAndDisplayRLE()
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
            Menu.Header("ASCII from RLE");
            string selected_path = Menu.DisplayAndGet("RLE File", Directory.GetFiles("Art\\"));
            DisplayFromRLE(File.ReadAllText(selected_path));
        }

        internal static string ConvertFromRLE(string rle_str)
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
                    if (!int.TryParse(chunk.AsSpan(0, 2), out int len)) { return "ERROR"; }
                    ascii_art += new string(chunk[2], len);
                }
                ascii_art += "\n";
            }

            return ascii_art;
        }
    }
}
