

using ATM_Final.AtmInfos.cs;
using ATM_Final.Cards.cs;
using System;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AtmInfo atm = new AtmInfo();
            Card? currentCard = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== ATM SYSTEM ====");
                Console.WriteLine("1. Create new card");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter card number (9 digits): ");
                            string number = Console.ReadLine()!;
                            Console.Write("Enter PIN (4 digits): ");
                            string pin = Console.ReadLine()!;
                            Console.Write("Enter starting balance (₾): ");
                            decimal balance = decimal.Parse(Console.ReadLine()!);

                            atm.CreateCard(number, pin, balance);
                            Console.WriteLine(" Card created successfully!");
                            break;

                        case "2":
                            Console.Write("Enter card number: ");
                            string num = Console.ReadLine()!;
                            Console.Write("Enter PIN: ");
                            string p = Console.ReadLine()!;

                            currentCard = atm.AuthCard(num, p);
                            Console.WriteLine(" Login successful!");

                            CardMenu(currentCard);
                            break;

                        case "3":
                            Console.WriteLine("Goodbye");
                            return;

                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error: {ex.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void CardMenu(Card card)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"==== Welcome, card [{card.Number}] ====");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Logout");
                Console.Write("Choose option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($" Balance: {card.Balance} ₾");
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        decimal dep = decimal.Parse(Console.ReadLine()!);
                        card.Balance += dep;
                        Console.WriteLine($" New balance: {card.Balance} ₾");
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        decimal wd = decimal.Parse(Console.ReadLine()!);
                        if (wd > card.Balance)
                            Console.WriteLine(" Not enough balance!");
                        else
                        {
                            card.Balance -= wd;
                            Console.WriteLine($" Withdrawn {wd} ₾. New balance: {card.Balance} ₾");
                        }
                        break;

                    case "4":
                        Console.WriteLine(" Logged out.");
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
