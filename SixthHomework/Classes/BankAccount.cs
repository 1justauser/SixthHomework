namespace ArtTask
{
    enum BankAccountType
    {
        сберегательный,
        текущий,
        неопределен
    }
    internal class BankAccount
    {
        #region Fields
        static private decimal defaultBalance = (decimal)Math.Round(Math.Exp(1), 6);
        static int defaultAmountOfDays = 100;
        private decimal balance;
        private BankAccountType accountType;
        private string identificator;
        private Dictionary<string, bool> identificators = new Dictionary<string, bool>();
        private DateTime creationTime;
        private int amountOfDaysForExploitation;
        #endregion
        #region Properties
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        public BankAccountType AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;
            }
        }
        public DateTime CreationTime
        {
            get
            {
                return creationTime;
            }
            set
            {
                creationTime = value;
            }
        }
        public int AmountOfDaysforExploitation
        { 
            get
            {
                return amountOfDaysForExploitation;
            }
            set
            {
                amountOfDaysForExploitation = value;
            }
        }
        public string Identificator
        {
            get
            {
                return identificator;
            }
        }
        public decimal DefaultBalance
        {
            get
            {
                return defaultBalance;
            }
        }
        #endregion
        #region Constructor Methods
        public BankAccount()
        {
            balance = defaultBalance;
            accountType = (BankAccountType)0;
            creationTime = DateTime.Now;
            amountOfDaysForExploitation = defaultAmountOfDays;
            identificator = "default";
            IDGenerator();
        }
        public BankAccount(decimal userBalance, BankAccountType bankAccountType, DateTime creationTime, int amountOfDaysForExploitation)
        {
            this.balance = userBalance;
            this.AccountType = bankAccountType;
            this.creationTime = creationTime;
            this.amountOfDaysForExploitation = amountOfDaysForExploitation;
            identificator = "defalt";
            IDGenerator();
        }
        #endregion
        #region Call Methods
        public void Output()
        {
            if (accountType == (BankAccountType)2)
            {
                Console.WriteLine("Тип и баланс не определены");
            }
            else
            {
                Console.WriteLine($"У вас {accountType.ToString()} тип аккуанта");
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
            if (accountType == (BankAccountType)2)
            {
                Console.WriteLine("Ваш тип счета неопределен, баланс неопределен");
                balance = defaultBalance;
            }
            else
            {
                Console.WriteLine("Укажите баланс");
                InputBalance(Console.ReadLine()!);
            }
            creationTime = DateTime.Now;
            Console.WriteLine("Укажите срок дейтсвия карты");
            InputAmountOfDaysForExploitation(Console.ReadLine()!);
        }
        private void InputAmountOfDaysForExploitation(string input)
        {
            if(int.TryParse(input, out amountOfDaysForExploitation))
            {
                Console.WriteLine($"Карты будет работать {amountOfDaysForExploitation} дней");
                this.AmountOfDaysforExploitation = amountOfDaysForExploitation;
            }
            else
            {
                Console.WriteLine($"Вы неправильно указали количество дней, поэтому карта будет работать{defaultAmountOfDays}");
                AmountOfDaysforExploitation = defaultAmountOfDays;
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
                accountType = (BankAccountType)0;
            }
            else if (type.ToLower().Replace(" ", string.Empty) == "текущий")
            {
                accountType = (BankAccountType)1;
            }
            else
            {
                Console.WriteLine("Вы неправильно указали тип аккаунта!");
                accountType = (BankAccountType)2;
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
        public bool IsExpired()
        {
            if ((DateTime.Now - creationTime).TotalDays > amountOfDaysForExploitation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
