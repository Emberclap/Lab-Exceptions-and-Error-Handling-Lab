namespace _5._Play_Catch
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            
            int exeptionCounter = 0;
            while (exeptionCounter != 3)
            {
                string[] commandTokens = Console.ReadLine().Split();
                try
                {
                    int index = int.Parse(commandTokens[1]);
                    switch (commandTokens[0])
                    {
                        case "Replace":
                            int variable = int.Parse(commandTokens[2]);
                            numbers[index] = variable;
                            break;
                        case "Print":
                            int endIndex = int.Parse(commandTokens[2]);
                            List<int> values = new List<int>();
                            for (int i = index; i <= endIndex; i++)
                            {
                                values.Add(numbers[i]);
                            }
                            Console.WriteLine(string.Join(", ", values));
                            break;
                        case "Show":
                            Console.WriteLine(numbers[index]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exeptionCounter++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exeptionCounter++;
                    Console.WriteLine("The variable is not in the correct format!");
                }

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}