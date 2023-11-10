using System.ComponentModel;
using System.Diagnostics;

namespace Square_Root
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0 )
                {
                    throw new ArgumentException("Invalid number.");
                }
                else
                {
                    Console.WriteLine($"{Math.Sqrt(number)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Goodbye.");
            }
            
        }
    }
}