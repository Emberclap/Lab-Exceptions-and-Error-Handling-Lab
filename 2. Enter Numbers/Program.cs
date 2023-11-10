namespace _2._Enter_Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            ReadNumber(start, end);
        }

        public static void ReadNumber(int start, int end)
        {
            int[] numbers = new int[10];
            
            for (int i = 0; i < numbers.Length; i++)
            {
                string input = (Console.ReadLine());

                try
                {
                    int number = int.Parse(input);  

                    if (number <= start || number > end)
                    {
                        i--;
                        throw new ArgumentException($"Your number is not in range {start} - 100!");
                    }
                    else if (numbers[0] != 0 && numbers[i-1] > number)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        numbers[i] = number;
                        start = number;
                    }

                }
                catch (FormatException)
                {
                    i--;
                    Console.WriteLine(("Invalid Number!"));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}