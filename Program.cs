namespace combinations_searcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string minRangeValue = "";
            string maxRangeValue = "";
            int parsedMinRangeValue;
            int parsedMaxRangeValue;

            int x = 0;
            int y = 0;

            while (minRangeValue == "" || !int.TryParse(minRangeValue, out parsedMinRangeValue) || parsedMinRangeValue < 1)
            {
                Console.Clear();
                Console.WriteLine("Type in the min range number in.");
                if(x > 0)
                {
                    if (minRangeValue == "") Console.WriteLine("You need to put a min range value.");
                    else if (!int.TryParse(minRangeValue, out parsedMinRangeValue)) Console.WriteLine("The min range value need to be a integer.");
                    else if (int.TryParse(minRangeValue, out parsedMinRangeValue) && parsedMinRangeValue < 1) Console.WriteLine("Min range value can not be smaller then 1.");
                }
                minRangeValue = Console.ReadLine();
                x++;

            }

            while (maxRangeValue == "" || !int.TryParse(maxRangeValue, out parsedMaxRangeValue) || parsedMaxRangeValue <= parsedMinRangeValue)
            { 
                Console.Clear();
                Console.WriteLine("Min range number: " + minRangeValue);
                Console.WriteLine("Type in the max range number in.");
                if(y > 0)
                {
                    if (maxRangeValue == "") Console.WriteLine("You need to put a max range value.");
                    else if (!int.TryParse(maxRangeValue, out parsedMaxRangeValue)) Console.WriteLine("The max range value need to be a integer.");
                    else if (int.TryParse(maxRangeValue, out parsedMaxRangeValue) && parsedMaxRangeValue <= parsedMinRangeValue)
                    {
                        if (parsedMaxRangeValue == parsedMinRangeValue) Console.WriteLine("Min range value can not be equal max range value.");
                        else if (parsedMaxRangeValue < parsedMinRangeValue) Console.WriteLine("Min range value can not be bigger then max range value.");
                    }
                }
                maxRangeValue = Console.ReadLine();
                y++;
            }

            var combinations_list = new List<string>();

            Console.Clear();
            for (int length = parsedMinRangeValue; length <= parsedMaxRangeValue; length++)
            {
                GenerateCombinations(length, "", combinations_list);
            }

            Console.Clear();
            Console.WriteLine("EVERYTHING IS SAVED IN combinations.txt FILE!");
            File.WriteAllLines("combinations.txt", combinations_list);
        }

        static void GenerateCombinations(int length, string combination, List<string> combinations)
        {
            string[] symbols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "!", "@", "#", "$", "%", "&" };

            if (combination.Length == length)
            {
                Console.WriteLine(combination);
                combinations.Add(combination);
            }
            else
            {
                for (int i = 0; i < symbols.Length; i++)
                {
                    GenerateCombinations(length, combination + symbols[i], combinations);
                }
            }
        }
    }
}