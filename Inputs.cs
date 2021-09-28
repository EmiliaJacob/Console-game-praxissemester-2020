using System;

namespace WholeNewWorld
{
    internal class Inputs
    {
        public static int ReadInt()
        {
            var cache = Console.ReadLine();

            if (cache == null)
                System.Environment.Exit(0);

            if (cache == "")//TODO: Vllt doch durch TryParse ersetzen um andere Fehleingaben, wie Buchstaben, abzufangen
                return -1;

            else
                return Int32.Parse(cache);
        }

        public static void WaitForEnterInput()
        {
            while (ReadInt() != -1) 
            {

            };
        }
    }
}
