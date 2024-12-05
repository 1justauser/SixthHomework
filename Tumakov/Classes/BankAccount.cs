namespace Tumakov
{
    enum BankAccountType
    {
        сберегательный,
        стандартный,
        неопределен
    }
    sealed class BankAccount
    {
        #region Fields
        private decimal balance;
        private decimal defaultBalance = (decimal)Math.Round(Math.Exp(1), 6);
        private BankAccountType bankAccountType;
        private string identificator;
        private Dictionary<string, bool> identificators = new Dictionary<string, bool>();
        #endregion
        #region Constructor Methods
        public BankAccount()
        {
            balance = 0;
            bankAccountType = (BankAccountType)0;
            identificator = "default";
            IDGenerator();
        }
        public BankAccount(decimal userBalance, BankAccountType bankAccountType)
        {
            this.balance = userBalance;
            this.bankAccountType = bankAccountType;
            identificator = "defalt";
            IDGenerator();
        }
        #endregion
        #region Call Methods
        static public void SolveTask()
        {
            BankAccount userAmir = new BankAccount(32310, (BankAccountType)1);
            userAmir.Output();
            BankAccount userNew = new BankAccount();
            userNew.Input();
            userNew.Output();
        }
        public void Output() 
        {
            if (bankAccountType == (BankAccountType)2) 
            { 
                Console.WriteLine("Тип и баланс не определены");
            }
            else
            {
                Console.WriteLine($"У вас {bankAccountType.ToString()} тип аккуанта");
            }
            if (balance == defaultBalance)
            {
                Console.WriteLine("Ваш баланс не определен");
            }
            else
            {
                Console.WriteLine($"Ваш баланс {balance}");
            }
        }
        public void Input()
        {
            IDGenerator();
            Console.WriteLine("Здравствуйте! Создадим банковский аккуант");
            Console.WriteLine("Определим тип счета сберегательный/текущий");
            InputBankAccountType(Console.ReadLine()!);
            if (bankAccountType == (BankAccountType)2)
            {
                Console.WriteLine("Ваш тип счета неопределен, баланс неопределен");
                balance = defaultBalance;
            }
            else 
            { 
                Console.WriteLine("Укажите баланс");
                InputBalance(Console.ReadLine()!);
            }
        }
        private void InputBalance(string stringBalance)
        {
            if(!decimal.TryParse(stringBalance, out balance))
            {
                Console.WriteLine("Ошибка вы неправильно указали баланс, он не определен");
                balance = defaultBalance;
            }
        }
        private void InputBankAccountType(string type)
        {
            if (type.ToLower().Replace(" ", string.Empty) == "сберегательный")
            {
                bankAccountType = (BankAccountType)0;
            }
            else if (type.ToLower().Replace(" ", string.Empty) == "текущий")
            {
                bankAccountType = (BankAccountType)1;
            }
            else
            {
                Console.WriteLine("Вы неправильно указали тип аккаунта!");
                bankAccountType = (BankAccountType)2;
            }
        }
        #endregion
        #region Computing Methods
        private void IDGenerator()
        {
            string Identificator = UniqueIdentificatorGenerator();
            while (identificators.ContainsKey(Identificator))
            {
                Identificator = UniqueIdentificatorGenerator();
            }
            identificators.Add(Identificator, true);
            identificator = Identificator;
        }
        static private string UniqueIdentificatorGenerator()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion
    }
}
