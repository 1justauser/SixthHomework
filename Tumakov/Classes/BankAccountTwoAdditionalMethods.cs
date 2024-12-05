namespace Tumakov
{
    sealed class BankAccountTwoAdditionalMethods
    {  
        #region Fields
        static private int instance = 0;
        private int identificator;
        private BankAccountType bankAccountType;
        private decimal balance;
        static private decimal defaultBalance = (decimal)(Math.Round(Math.Exp(1), 6));
        #endregion
        #region Constructor Methods
        public BankAccountTwoAdditionalMethods()
        {
            instance++;
            identificator = instance;
            bankAccountType = (BankAccountType)2;
            balance = defaultBalance;
        }
        public BankAccountTwoAdditionalMethods(BankAccountType bankAccountType, decimal balance)
        {
            instance++;
            identificator = instance;
            this.bankAccountType = bankAccountType;
            this.balance = balance;
        }
        #endregion
        #region Call Methods
        static public void SolveTask()
        {
            BankAccountTwoAdditionalMethods userAmir = new BankAccountTwoAdditionalMethods((BankAccountType)1, 32444);
            userAmir.Output();
            BankAccountTwoAdditionalMethods userNew = new BankAccountTwoAdditionalMethods();
            userAmir.StartAutomatedTellerMachine();
            userNew.Input();
            userNew.Output();
            userNew.StartAutomatedTellerMachine();
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
                if (balance != defaultBalance)
                {
                    Console.WriteLine($"Ваш баланс {balance}");
                }
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
        private void InputBalanceWithdrawal(string inputWithdrawal)
        {
            if (balance == defaultBalance)
            {
                Console.WriteLine("Ваш баланс неопределен");
            }
            else if (decimal.TryParse(inputWithdrawal, out decimal withdrawal) && withdrawal > 0)
            {
                BalanceWithdrawal(withdrawal);
            }
            else
            {
                Console.WriteLine("Ошибка: нужно указать число большее нуля");
            }
        }
        private void InputAdditionalBalance(string inputAdditionalBalance)
        {
            if (balance == defaultBalance)
            {
                Console.WriteLine("Ваш баланс неопределен");
            }
            else if (decimal.TryParse(inputAdditionalBalance, out decimal additionalBalance) && additionalBalance > 0)
            {
                AdditionalBalance(additionalBalance);
            }
            else
            {
                Console.WriteLine("Ошибка: нужно указать число большее нуля");
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
        public void StartAutomatedTellerMachine()
        {
            Console.WriteLine("Хотите ли вы провести некоторые операции с банкоматом?(Y/n)");
            bool flag = true;
            while (flag && Console.ReadLine() == "Y") 
            { 
                Console.WriteLine("Выберите функцию: снять деньги (W), внести деньги (A)");
                string operation = Console.ReadLine()!;
                if (balance==defaultBalance)
                {
                    Console.WriteLine("Ваш баланс не определен");
                    flag = false;
                }
                else if (operation == "W")
                {
                    Console.WriteLine("Укажите число");
                    InputBalanceWithdrawal(Console.ReadLine()!);
                }
                else if (operation == "A")
                {
                    Console.WriteLine("Укажите число");
                    InputAdditionalBalance(Console.ReadLine()!);
                }
                if (balance != defaultBalance)
                {
                    Console.WriteLine($"Ваш баланс: {balance}");
                    Console.WriteLine("Хотите ли вы провести некоторые операции с банкоматом?(Y/n)");
                }
            }
        }
        #endregion
        #region AutomatedTellerMachine Methods
        private void AdditionalBalance(decimal additionalBalance)
        {
            balance += additionalBalance;
            Console.WriteLine("Баланс Успешно Добавлен");
        }
        private void BalanceWithdrawal(decimal balanceWithdrawal)
        {
            if (balanceWithdrawal > balance)
            {
                Console.WriteLine($"Снять деньги не удалось");
            }
            else
            {
                Console.WriteLine($"Успешное снятие денег");
                balance -= balanceWithdrawal;
            }
        }
        #endregion   
    }
}