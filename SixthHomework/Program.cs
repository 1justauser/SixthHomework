//using SixthHomework.Classes;
using System.Globalization;
using System.Text;

namespace SixthHomework {
    class ArtTask 
    {
        static void Unicode_Utf8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
        static void Main(string[] args) {
            Console.WriteLine(Guid.NewGuid().ToString("N"));
            //Console.WriteLine("Hello, World!");
            DateTime birthDate = new DateTime();
            Unicode_Utf8();
            string fullBirthDate = "23.05.2007,23:11";
            CultureInfo ruRU = CultureInfo.CreateSpecificCulture("ru-RU");
            if (DateTime.TryParseExact(fullBirthDate, "dd.MM.yyyy,HH:mm", ruRU, DateTimeStyles.AllowWhiteSpaces, out birthDate))
            {
                Console.WriteLine("It works!!!");
                Console.WriteLine(birthDate.ToString("f", ruRU));
            }
            //NationalLosAngelesCasino Amir = new NationalLosAngelesCasino();
            //Amir.CasinoInfo();
            //Amir.RecallCasino();
        } 
    } 
}