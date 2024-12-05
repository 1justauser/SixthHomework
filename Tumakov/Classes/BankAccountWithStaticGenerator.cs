namespace Tumakov
{
    sealed class BankAccountWithStaticGenerator
    {
        #region Fields
        static private int instance = 0;
        private int identificator;
        private BankAccountType bankAccountType;
        private decimal balance;
        static private decimal defaultBalance = (decimal)(Math.Round(Math.Exp(1), 6));
        #endregion
        #region Constructor Methods
        public BankAccountWithStaticGenerator()
        {
            CountInstance();
            identificator = instance;
            bankAccountType = (BankAccountType)2;
            balance = defaultBalance;
        }
        public BankAccountWithStaticGenerator(BankAccountType bankAccountType, decimal balance) 
        {
            CountInstance();
            identificator = instance;
            this.bankAccountType = bankAccountType;
            this.balance = balance;
        }
        #endregion
        #region Call Methods
        static public void SolveTask()
        {
            BankAccountWithStaticGenerator userAmir = new BankAccountWithStaticGenerator((BankAccountType)1, 32310);
            userAmir.Output();
            BankAccountWithStaticGenerator userNew = new BankAccountWithStaticGenerator();
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
            if (!decimal.TryParse(stringBalance, out balance))
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
        #region Count Method
        private void CountInstance()
        {
            instance++;
        }
        #endregion
    }
}
