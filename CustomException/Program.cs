// See https://aka.ms/new-console-template for more information

using CustomException.Exceptions;

Console.WriteLine("Hello world Banck!");

var account = new Account("Jose Roberto", 150);

try
{
    account.Debit(160);
}
catch (ProgramException e)
{
    Console.WriteLine($"Encountered exception \nException Message: {e.Message}");
    Console.WriteLine($"Account Balance: {e.AccountBalance}");
    Console.WriteLine($"Transaction Amount: {e.TransactionAmount}");
    
}

Console.Read();
