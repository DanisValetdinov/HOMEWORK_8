namespace std
{
    internal class BankTransaction
    {
        public readonly DateTime transactionDate;
        public readonly decimal Amount;

        public BankTransaction(decimal Amount)
        {
            this.transactionDate = DateTime.Now;
            this.Amount = Amount;
        }
    }
}