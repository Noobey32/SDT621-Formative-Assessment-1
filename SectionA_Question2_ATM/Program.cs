/*
============================================================
Project: SDT621 – Formative Assessment 1
Section : A
Question: 2 – Simple ATM Console Application

Overview:
This console application simulates a basic ATM withdrawal
transaction. It interacts with the user to accept an account
balance and withdrawal amount, performs validation, updates
the balance, and displays transaction details including the
date and time.

Key Requirements Implemented:
- User input for account balance and withdrawal amount
- Validation of numeric input and sufficient funds
- Balance calculation after withdrawal
- Display of transaction summary and timestamp

Expected Outcomes:
- Defensive programming against invalid input
- Correct balance updates
- Logical transaction flow

Notes:
- Entry point for the ATM simulation application
- No real banking systems or persistence used
============================================================
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== CTU ATM System =====\n");

        // username
        string userName = GetUsername("Hi. Please enter your name: ");

        Console.WriteLine($"\nWelcome, {userName}!");

        // atm values
        double accountBalance = GetValidDoubleInput("Please enter your current account balance: R");
        double withdrawalAmount = GetValidDoubleInput("Please enter the amount you wish to withdraw: R");

        // validation on withdrawal amount
        while (withdrawalAmount > accountBalance)
        {
            Console.WriteLine("\nInsufficient funds. Please enter a smaller amount.");
            withdrawalAmount = GetValidDoubleInput("Please enter the amount you wish to withdraw: R");
        }

        // balance calculation
        accountBalance -= withdrawalAmount;
        Console.WriteLine(withdrawalAmount > 0 ? "\nWithdrawal successful!" : "\nNo withdrawal made."); // UX
        Console.WriteLine($"Updated balance: R{accountBalance:F2}");
        Console.WriteLine($"Transaction date and time: {DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")}");
    }

    private static double GetValidDoubleInput(string prompt)
    {
        double value;
        Console.Write(prompt);
        string input = Console.ReadLine();
        while (!double.TryParse(input, out value) || value < 0)
        {
            Console.Write("Invalid input. Please enter a valid positive number: ");
            input = Console.ReadLine();
        }
        return value;
    }

    private static string GetUsername(string question)
    {
        Console.Write(question);
        string input = Console.ReadLine();
        
        while (true)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("While we respect anonymity, please enter your name: ");
                input = Console.ReadLine();
            }
            else
                break;
        }

        return TitleCaser(input.ToLower()); // Convert to title case for better display
    }

    private static string TitleCaser(string input)
    {
        string[] words = input.Split(' ');
        string titleCase = "";

        foreach (string word in words)
        {
            if (word.Length > 0)
            {
                titleCase += char.ToUpper(word[0]) + word.Substring(1) + " ";
            }
        }
        return titleCase.TrimEnd();
    }
}