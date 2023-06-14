using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Threading.Channels;

namespace CustomException.Exceptions;

public class ProgramException : Exception
{
    private static readonly string DefaultMessage = "Account balance is insufficient for the transaction.";


    public string AccountName { get; set; }
    public int  AccountBalance { get; set; }
    public int TransactionAmount { get; set; }

    public ProgramException() : base (DefaultMessage){}
    public ProgramException(string message) : base(message){}
    public ProgramException(string message, Exception innerException): base(message, innerException){}

    public ProgramException(string accountName, int accountBalance, int transactionAmount) : base(DefaultMessage)
    {
        AccountName = accountName;
        AccountBalance = accountBalance;
        TransactionAmount = transactionAmount;
    }

    public ProgramException(string accountName, int accountBalance, int transactionAmount, Exception innerException) :
        base(DefaultMessage, innerException)
    {
        AccountName = accountName;
        AccountBalance = accountBalance;
        TransactionAmount = transactionAmount;
    }
    
    protected  ProgramException(SerializationInfo info, StreamingContext context):base(info,context){}
}

class Account
{
    public string Name { get; private set; }
    public int Balance { get; private set; }
    
    public Account(string name, int balance)
    {
        Name = name;
        Balance = balance;
    }

    public void Debit(int amount)
    {
        if (Balance < amount) throw new ProgramException(Name, Balance, amount);
        Balance = Balance - amount;

    }

    public void Credit(int amount) => Balance = amount + Balance;
}
