using System.Globalization;
using System.Runtime.CompilerServices;

namespace _06._Money_Transactions
{
    public class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            string[] input = Console.ReadLine().Split(",");

            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (var account in input)
            {
                string[] accInfo = account.Split("-");
                int accNumber = int.Parse(accInfo[0]);
                double balance = double.Parse(accInfo[1]);
                accounts.Add(accNumber, balance);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string operation = tokens[0];
                    int account = int.Parse(tokens[1]);
                    double balance = double.Parse(tokens[2]);
                    if (!accounts.ContainsKey(account))
                    {
                        throw new IndexOutOfRangeException();
                    }
                    if (operation == "Deposit")
                    {
                        accounts[account] += balance;
                        Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
                    }
                    else if (operation == "Withdraw")
                    {
                        if (accounts[account] >= balance)
                        {
                            accounts[account] -= balance;
                            Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    else { throw new FormatException(); }
                }
                catch (FormatException)
                {

                    Console.WriteLine("Invalid command!");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}