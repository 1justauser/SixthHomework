using System.Globalization;


namespace SixthHomework.Classes
{
    class User
    {
        #region Fields
        private decimal balance;
        private string defaultName = "Amir-e1112";
        private decimal defaultBalance = (decimal)Math.Round(Math.Exp(1), 6);
        private bool isMinor = true;
        private string name;
        private int age = -1;
        private DateTime birthDate;
        private bool birthDateUnknown = true;
        private string identificator;
        private Dictionary<string, bool> identificators = new Dictionary<string, bool>();
        #endregion
        #region Properties
        public string Name
        {
            get { return name; }
        }
        public decimal DefaultBalance
        {
            get { return defaultBalance; }
        }
        public decimal Balance
        {
            get { return balance; }
        }
        #endregion
        #region Constructor Methods
        public User()
        {
            balance = defaultBalance;
            name = defaultName;
            IDGenerator();
        }
        public User(decimal balance, string name, DateTime birthDate)
        {
            this.balance = balance;
            this.name = name;
            this.birthDate = birthDate;
            birthDateUnknown = false;
            Age(0);
            IDGenerator();
        }
        public User(decimal balance, string name, string birthDate)
        {
            this.balance = balance;
            this.name = name;
            EnterBirthDate(birthDate);
            IDGenerator();
        }
        #endregion 
        #region Methods
        private bool Age(int restrictionAge)
        {
            if (!birthDateUnknown)
            {
                int nowInteger = int.Parse(DateTime.Now.ToString("yyyyMMhh"));
                int birthInteger = int.Parse(birthDate.ToString("yyyyMMhh"));
                age = (nowInteger - birthInteger) / 10000;
                if (age >= restrictionAge)
                {
                    isMinor = false;
                }
                else
                {
                    isMinor = true;
                }
            }
            return isMinor;
        }
        public bool IsUserMinor(int restrictionAge)
        {
            return Age(restrictionAge);
        }
        public void EnterBirthDate(string BirthDateruRuFromat)
        {
            CultureInfo ruRU = CultureInfo.CreateSpecificCulture("ru-RU");
            if (DateTime.TryParseExact(BirthDateruRuFromat, "dd.MM.yyyy", ruRU, DateTimeStyles.AllowWhiteSpaces, out DateTime dateValue))
            {
                birthDate = dateValue;
            }
        }
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
        static string UniqueIdentificatorGenerator()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion
    }
}
