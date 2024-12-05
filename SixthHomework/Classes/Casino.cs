using System.Globalization;
namespace ArtTask
{
    enum City
    {
        Казань,
        Москва,
        FarFromCasino
    }
    abstract public class Casino
    {
        #region Field;
        private string name = string.Empty;
        public BankAccount? account = null;
        private DateTime birthDate = DateTime.Now;
        private City residence;
        private string bankIdentificator = "unknown";
        #endregion
        #region Properties
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public City Residence
        {
            get
            {
                return residence;
            }
            set
            {
                residence = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
        #endregion
        #region Call Methods
        public void Input()
        {

            Console.WriteLine("Укажите Дату Рождения");
            EnterBirthDate(Console.ReadLine()!);
            int age = Age();
            if (age < 18)
            {
                Console.WriteLine("Вы не можете здесь находиться");

            }
            else
            {
                Console.WriteLine("Здравствуйте, укажите Имя");
                name = Console.ReadLine()!;
                Console.WriteLine("Создадим Банковский аккаунт");
                BankAccount Account = new BankAccount();
                Account.Input();
                this.account = Account;
                bankIdentificator = this.account.Identificator;
                Console.WriteLine("Укажите Город");
                InputResidence(Console.ReadLine()!);
            }
        }
        private void InputResidence(string city)
        {
            if (city.ToLower().Replace(" ", string.Empty) == "казань")
            {
                residence = (City)0;
            }
            else if (city.ToLower().Replace(" ", string.Empty) == "москва")
            {
                residence = (City)1;
            }
            else
            {
                Console.WriteLine("Вы не можете играть в казино");
                residence = (City)2;
            }
        }
        private void EnterBirthDate(string BirthDateruRuFromat)
        {
            CultureInfo ruRU = CultureInfo.CreateSpecificCulture("ru-RU");
            if (DateTime.TryParseExact(BirthDateruRuFromat, "dd.MM.yyyy", ruRU, DateTimeStyles.AllowWhiteSpaces, out DateTime dateValue))
            {
                birthDate = dateValue;
            }
        }
        public void Output()
        {
            Console.WriteLine($"Здравствуйте, {name}");

            if (account!.IsExpired())
            {
                Console.WriteLine("Ваша карта больше не работает");
            }
            else if (account.Balance == account.DefaultBalance)
            {
                Console.WriteLine($"Ваш баланс {account.Balance}");
            }
            else 
            {
                Console.WriteLine("Ваш баланс неопределен");
            }
        }
        public void Play()
        {
            int age = Age();
            if (account!.IsExpired())
            {
                Console.WriteLine("Ваша карта больше не работает");
            }
            else if (age < 18)
            {
                Console.WriteLine("Вам нельзя играть");
            }
            else
            {
                Console.WriteLine("Нужно поиграть!");
                Game1();
                Game2();
            }
        }
        #endregion
        #region Game Methods
        private void Game1()
        {
            account!.Balance = 0;
            Console.WriteLine("Победа Победа ваш баланс 0!!");
        }
        private void Game2() 
        {
            account!.Balance = 33312312;
            Console.Write("Деньги не главное! ");
            Console.WriteLine(account.Balance);
        }
        #endregion
        #region Computing Methods
        private int Age()
        {
            int nowInteger = int.Parse(DateTime.Now.ToString("yyyyMMhh"));
            int birthInteger = int.Parse(birthDate.ToString("yyyyMMhh"));
            return (nowInteger - birthInteger) / 10000;
        }
        #endregion
    }
    public class KazanCasino : Casino
    {
        new public void Output()
        {
            
        }
    }
}