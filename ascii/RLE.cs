namespace ascii
{
    internal class RLE
    {
        internal static void EnterAndDisplay()
        {
            /*
                a.  the user is asked how many lines of RLE compressed data they want to enter
                b.  the program should check that the number entered is greater than 2 and if it isn’t
                    display a suitable error message and get the user to keep re-entering the number until
                    it is valid
                c.  if the user entered a valid number, they then enter the compressed data one line at a
                    time until they have entered the specified number of lines
                d.  once all the compressed data has been entered, the program decompresses the data
                    and displays the ASCII art image
                e.  the user is returned to the main menu. 
            */

            int num_lines;
            do
            {
                Menu.Header("Enter RLE");
                Console.Write("How many lines of RLE to enter?: ");
            }
            while (!int.TryParse(Console.ReadLine(), out num_lines));

            Menu.Header("Enter RLE");
            string rle_lines = "";
            for (int i = 0; i < num_lines; i++)
            {
                Console.Write($"Line {i + 1}: ");
                rle_lines += (Console.ReadLine() + "\n");
            }
            ASCII.DisplayFromRLE(rle_lines);

            string response;
            do
            {
                Menu.Header("Enter RLE");
                Console.Write("Save art? (y/n): ");
                response = Console.ReadLine().ToLower();
            }
            while (!(new string[2] { "y", "n" }.Contains(response)));

            if (response == "y")
            {
                while (true)
                {
                    Menu.Header("Enter RLE");
                    Console.Write("Filename to save RLE to: ");
                    try
                    {
                        File.WriteAllText("Art\\" + Console.ReadLine(), rle_lines);
                        break;
                    }
                    catch { }
                }
                Console.Write("File saved.\nEnter to return: ");
                Console.ReadLine();
            }
        }
        internal static void ConvertAndSave()
        {
            /*
                a.  the user is asked to enter the name of the text file that contains the ASCII art
                b.  the program reads the contents of the text file, compresses each line and stores the
                    compressed data in a new text file
                c.  the program calculates the difference between the number of characters used in the
                    compressed and uncompressed versions of the ASCII art and displays this value
                d.  the user is returned to the main menu. 
            */

            string ascii_fn = Menu.DisplayAndGet("ASCII Art File to Convert", Directory.GetFiles("Art\\"));
            string ascii_src = File.ReadAllText(ascii_fn);

            Menu.Header("Convert to RLE");
            
            string fn;
            string rle_str;
            while (true)
            {
                Console.Write("Save to: ");
                fn = "Art\\" + Console.ReadLine();
                try
                {
                    rle_str = Convert(ascii_src);
                    File.WriteAllText(fn, rle_str);
                    break;
                }
                catch { }
            }

            Console.WriteLine($"Compressed to: '{fn}'");
            Console.WriteLine($"Saved {ascii_src.Length - rle_str.Length} chars.\nEnter to return to main menu...");
            Console.ReadLine();
        }

        private static string Convert(string ascii_src)
        {
            string[] ascii_lines = ascii_src.Split('\n');

            string rle = "";
            foreach (string line in ascii_lines)
            {
                int c = 1;
                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (line[i] == line[i + 1])
                    {
                        c++;
                    }
                    else
                    {
                        if (c == 1)
                        {
                            rle += 1.ToString("00");
                            rle += line[i];
                        }
                        else
                        {
                            rle += c.ToString("00");
                            rle += line[i];
                            c = 1;
                        }

                    }
                }
                rle += "\n";
            }
            return rle;
        }
    }
}
