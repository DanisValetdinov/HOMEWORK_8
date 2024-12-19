using hw8;


namespace std
{
    class BankAccount : IDisposable
    {
        public uint id;
        public static uint autoID = 0;
        public decimal balance;
        public AccType? accountType;
        private Queue<BankTransaction> transactions = new Queue<BankTransaction>();
        private bool disposed = false;
        private int v;
        private AccType debit;

        public BankAccount(decimal balance, hw8.AccType debit)
        {
            this.id = GenerateID();
            this.balance = balance;
            this.accountType = null;
        }

        public BankAccount(AccType? accountType)
        {
            this.id = GenerateID();
            this.balance = 0;
            this.accountType = accountType;
        }

        public BankAccount(decimal balance, AccType? accountType)
        {
            this.id = GenerateID();
            this.balance = balance;
            this.accountType = accountType;
        }

        public BankAccount(int v)
        {
            this.v = v;
        }

        public BankAccount(AccType debit)
        {
            this.debit = debit;
        }

        private uint GenerateID()
        {
            autoID++;
            return autoID;
        }

        public bool Transfer(BankAccount account, decimal amount)
        {
            if (account.WithdrawCash(amount))
            {
                this.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }

        public uint GetID()
        {
            return id;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public AccType? GetAccountType()
        {
            return accountType;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {id}, Баланс: {balance:N}, Тип счета: {accountType}\n");
        }

        public bool WithdrawCash(decimal cash)
        {
            if (cash < 0)
            {
                Console.WriteLine($"сумма должна быть больше 0");
                return false;
            }

            if ((balance - cash) > 0)
            {
                balance -= cash;
                AddTransaction(-cash);
                return true;
            }
            else return false;
        }

        public void Deposit(decimal cash)
        {
            if (cash <= 0)
            {
                Console.WriteLine("Сумма депозита должна быть больше нуля.");
            }
            balance += cash;
            AddTransaction(cash);
        }

        private void AddTransaction(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(amount);
            transactions.Enqueue(transaction);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                using (StreamWriter writer = new StreamWriter("transaction.txt", true))
                {
                    while (transactions.Count > 0)
                    {
                        BankTransaction transaction = transactions.Dequeue();
                        writer.WriteLine($"{transaction.transactionDate} : {transaction.Amount}");
                    }
                }
            }
            disposed = true;
        }
    }
}