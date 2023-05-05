using System.Xml;

namespace ExpenseTracker_App
{
    class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }

    class Tracker
    {
        List<Transaction> transactions;

        public Tracker()
        {
            transactions = new List<Transaction>();
        }
        public void AddTransaction()
        {
            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Amount (Negative for Expense and Positive for Income)");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Date (mm/dd/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Transaction transaction = new Transaction()
            {
                Title = title,
                Description = description,
                Amount = amount,
                Date = date
            };

            transactions.Add(transaction);
        }

        public void ViewExpense()
        {
            Console.WriteLine("Expense:");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount < 0)
                {
                    Console.WriteLine($"Title: {transaction.Title} \nDescription: {transaction.Description} \nAmount: {transaction.Amount} \nDate: {transaction.Date.ToShortDateString()}");

                }
            }
        }

        public void ViewIncome()
        {
            Console.WriteLine("Income:");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount > 0)
                {
                    Console.WriteLine($"Title: {transaction.Title} \nDescription: {transaction.Description} \nAmount: {transaction.Amount} \nDate: {transaction.Date.ToShortDateString()}");
                }
            }
        }

        public void ShowBalance()
        {
            int totalIncome = 0;
            int totalExpense = 0;



            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount > 0)
                {
                    totalIncome += transaction.Amount;
                }
                else
                {
                    totalExpense += Math.Abs(transaction.Amount);
                }
            }

            int availableBalance = totalIncome - totalExpense;
            Console.WriteLine($"Total Income: {totalIncome}");
            Console.WriteLine($"Total Expenses: {totalExpense}");
            Console.WriteLine($"Available Balance: {availableBalance}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Tracker track = new Tracker();
            string ans = "";
            do
            {
                Console.WriteLine("Welcome to Expense Tracker App");
                Console.WriteLine();
                Console.WriteLine("1.Add Transaction");
                Console.WriteLine("2.View Expenses");
                Console.WriteLine("3.View Income");
                Console.WriteLine("4.Check Available Balance");
                Console.WriteLine();
                int choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            track.AddTransaction();
                            break;
                        }
                    case 2:
                        {
                            track.ViewExpense();
                            break;
                        }
                    case 3:
                        {
                            track.ViewIncome();
                            break;
                        }
                    case 4:
                        {
                            track.ShowBalance();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n]");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }
    }
}