namespace ascii
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Action selected_option = Menu.DisplayAndGet();
                if (selected_option == Exit)
                {
                    break;
                }

                selected_option();
            }
        }

        internal static void Exit() { }
    }
}